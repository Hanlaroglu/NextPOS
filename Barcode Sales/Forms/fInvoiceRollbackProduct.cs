using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceRollbackProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        ISupplierOperation supplierOperation = new SupplierManager();
        IInvoiceRollbackOperation invoiceRollbackOperation = new InvoiceRollbackManager();
        IInvoiceRollbackDetailOperation invoiceRollbackDetailOperation = new InvoiceRollbackDetailManager();
        List<ViewInvoiceRollbackListDto> _dataList = new List<ViewInvoiceRollbackListDto>();

        public fInvoiceRollbackProduct()
        {
            InitializeComponent();
        }

        private async void fInvoiceRollbackProduct_Load(object sender, EventArgs e)
        {
            tDate.Text = DateTime.Now.ToShortDateString();
            await SupplierDataLoad();
            gridView1.SelectionChanged += (s, x) =>
            {
                int count = gridView1.GetSelectedRows().Length;
                if (count > 0)
                {
                    bSave.Cursor = Cursors.Hand;
                    bSave.Text = $"Qaytar ({count})";
                }
                else
                {
                    bSave.Cursor = Cursors.No;
                    bSave.Text = "Qaytar (0)";
                }
            };
        }

        private async Task SupplierDataLoad()
        {
            var data = await supplierOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, lookSuppliers, "SupplierName");
        }

        private void SelectDate(object sender, EventArgs e)
        {
            if (dateStart.EditValue is null || dateEnd.EditValue is null) return;

            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;


            if (!ValidationHelpers.IsValidDate(start.ToString()) ||
                !ValidationHelpers.IsValidDate(end.ToString()))
            {
                NoticationHelpers.Messages.ErrorMessage(this, "Tarix formatı düzgün seçilmədi");
                return;
            }

            if (start > end)
            {
                NoticationHelpers.Messages.ErrorMessage(this, "Başlanğıc tarixi bitiş tarixindən böyük ola bilməz!");
                return;
            }

            lookSuppliers.EditValue = null;
            DataLoad(start, end);
        }

        private void DataLoad(DateTime? start = null, DateTime? end = null, string supplierName = null)
        {
            gridView1.ShowLoadingPanel();
            using (var db = new NextposDBEntities())
            {
                if (supplierName is null)
                {

                    _dataList = db.view_InvoiceRollbackList
                        .Where(x =>
                           x.InvoiceDate >= DbFunctions.TruncateTime(start) &&
                           x.InvoiceDate <= DbFunctions.TruncateTime(end))
                        .Select(x => new ViewInvoiceRollbackListDto()
                        {
                            WarehouseId = x.WarehouseId,
                            WarehouseName = x.WarehouseName,
                            InvoiceId = x.InvoiceId,
                            InvoiceNo = x.InvoiceNo,
                            InvoiceDate = x.InvoiceDate,
                            SupplierName = x.SupplierName,
                            ProductId = x.ProductId,
                            ProductName = x.ProductName,
                            Barcode = x.Barcode,
                            Amount = x.Amount,
                            PurchasePrice = x.PurchasePrice,
                            RollbackQuantity = 0
                        })
                        .ToList();
                }
                else
                {
                    _dataList = db.view_InvoiceRollbackList
                        .Where(x =>
                            x.SupplierName == supplierName)
                        .Select(x => new ViewInvoiceRollbackListDto()
                        {
                            WarehouseId = x.WarehouseId,
                            WarehouseName = x.WarehouseName,
                            InvoiceId = x.InvoiceId,
                            InvoiceNo = x.InvoiceNo,
                            InvoiceDate = x.InvoiceDate,
                            SupplierName = x.SupplierName,
                            ProductId = x.ProductId,
                            ProductName = x.ProductName,
                            Barcode = x.Barcode,
                            Amount = x.Amount,
                            PurchasePrice = x.PurchasePrice,
                            RollbackQuantity = 0
                        })
                        .ToList();
                }

                var bindingList = new BindingList<ViewInvoiceRollbackListDto>(_dataList);
                FormHelpers.ControlLoad(bindingList, gridControl1);

            }
            gridView1.HideLoadingPanel();
        }

        private void Clear()
        {
            _dataList.Clear();
            gridView1.RefreshData();
            tDate.Text = DateTime.Now.ToShortDateString();
            lookSuppliers.EditValue = null;
            dateStart.EditValue = null;
            dateEnd.EditValue = null;
            tComment.Text = null;
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void lookSuppliers_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lookSuppliers.Text))
            {
                DataLoad(null, null, lookSuppliers.Text);
                dateStart.EditValue = null;
                dateEnd.EditValue = null;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (bSave.Cursor == Cursors.No)
                return;

            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();

            var selectedRows = gridView1.GetSelectedRows();
            var selectedItems = new List<ViewInvoiceRollbackListDto>();
            foreach (var item in selectedRows)
            {
                if (item >= 0)
                {
                    var row = gridView1.GetRow(item) as ViewInvoiceRollbackListDto;
                    if (row != null)
                    {
                        if (row.RollbackQuantity > row.Amount)
                        {
                            NoticationHelpers.Messages.ErrorMessage(this, "Qaytarılacaq miqdar alış miqdarından çox ola bilməz");
                            return;
                        }

                        if (row.RollbackQuantity > 0)
                            selectedItems.Add(row);
                    }
                }
            }

            if (selectedItems.Count > 0)
                AddRollback(selectedItems);
        }

        private void AddRollback(List<ViewInvoiceRollbackListDto> list)
        {
            using (var db = new NextposDBEntities())
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var grouped = list.GroupBy(x => x.InvoiceId);
                    foreach (var group in grouped)
                    {
                        InvoiceRollback rollback = new InvoiceRollback()
                        {
                            InvoiceId = group.Key,
                            RollbackDate = Convert.ToDateTime(tDate.Text),
                            Commnet = tComment.Text.Trim(),
                            UserId = CommonData.CURRENT_USER.Id,
                            CreatedDate = DateTime.Now,
                            IsDeleted = false,
                        };
                        var result = invoiceRollbackOperation.AddRollback(rollback);

                        var details = group.Select(x => new InvoiceRollbackDetail
                        {
                            InvoiceRollbackId = result,
                            ProductId = x.ProductId,
                            Quantity = x.RollbackQuantity
                        }).ToList();
                        invoiceRollbackDetailOperation.AddRange(details);
                    }
                    tran.Commit();
                    Clear();
                    NoticationHelpers.Messages.SuccessMessage(this,$"{list.Count} məhsul uğurla qaytarıldı");
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    NoticationHelpers.Messages.ErrorMessage(this, e.Message);
                }
            }

        }

        private void bReport_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceRollbackReport>();
        }
    }
}