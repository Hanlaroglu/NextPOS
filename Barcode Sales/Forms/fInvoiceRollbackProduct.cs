using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors.Repository;
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
        IProductOperation productOperation = new ProductManager();
        IInvoiceRollbackDetailOperation invoiceRollbackDetailOperation = new InvoiceRollbackDetailManager();

        private List<view_InvoiceRollbackList> _dataListData = new List<view_InvoiceRollbackList>();
        public fInvoiceRollbackProduct()
        {
            InitializeComponent();
        }

        private async void fInvoiceRollbackProduct_Shown(object sender, EventArgs e)
        {
            GridRepoAdd();
            tDate.Text = DatetimeService.CurrentDateString;
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
            var data = await supplierOperation.ToListAsync(x => x.IsDeleted == false);
            FormHelpers.ControlLoad(data, lookSuppliers, "SupplierName");
        }

        private void SelectDate(object sender, EventArgs e)
        {
            if (dateStart.EditValue is null || dateEnd.EditValue is null) return;

            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;

            if (string.IsNullOrWhiteSpace(lookSuppliers.Text))
            {
                NotificationHelpers.Messages.WarningMessage(this, "Təchizatçı seçimi edilmədi");
                return;
            }

            if (!ValidationHelpers.IsValidDate(start.ToString()) ||
                !ValidationHelpers.IsValidDate(end.ToString()))
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Tarix formatı düzgün seçilmədi");
                return;
            }

            if (start > end)
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Başlanğıc tarixi bitiş tarixindən böyük ola bilməz!");
                dateStart.EditValue = null;
                dateEnd.EditValue = null;
                return;
            }

            LoadData(start, end);
        }

        private async void LoadData(DateTime? start = null, DateTime? end = null)
        {
            gridView1.ShowLoadingPanel();

            _dataListData = await invoiceRollbackOperation.RollbackList((int)lookSuppliers.EditValue, start, end);

            var bindingList = new BindingList<view_InvoiceRollbackList>(_dataListData);
            FormHelpers.ControlLoad(bindingList, gridControl1);

            gridView1.HideLoadingPanel();
        }

        private void Clear()
        {
            _dataListData.Clear();
            gridView1.RefreshData();
            tDate.Text = DatetimeService.CurrentDateString;
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
                LoadData();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
             if (bSave.Cursor == Cursors.No)
                return;

            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();

            var selectedRows = gridView1.GetSelectedRows();
            var selectedItems = new List<view_InvoiceRollbackList>();
            foreach (var item in selectedRows)
            {
                if (item >= 0)
                {
                    var row = gridView1.GetRow(item) as view_InvoiceRollbackList;
                    if (row != null)
                    {
                        if (row.ReturnQuantity > row.Amount)
                        {
                            NotificationHelpers.Messages.ErrorMessage(this, "Qaytarılacaq miqdar alış miqdarından çox ola bilməz");
                            return;
                        }

                        if (row.ReturnQuantity > 0)
                            selectedItems.Add(row);
                    }
                }
            }

            if (selectedItems.Count > 0)
                AddRollback(selectedItems);
        }

        private async void AddRollback(List<view_InvoiceRollbackList> list)
        {
            List<InvoiceRollback> rollbackList = new List<InvoiceRollback>();
            /*
             * List yaradıb view də ki dataları listə göndər daha sonra manager classına gönder.
             *
             *
             *
             */

            try
            {
                var grouped = list.GroupBy(x => x.InvoiceId);
                foreach (var group in grouped)
                {
                    InvoiceRollback rollback = new InvoiceRollback()
                    {
                        InvoiceId = group.Key,
                        WarehouseId = group.First().WarehouseId,
                        RollbackDate = Convert.ToDateTime(tDate.Text),
                        Commnet = tComment.Text.TrimStart().Trim(),
                        UserId = UserCacheService.User.Id,
                        CreatedDate = DatetimeService.CurrentDateTime,
                        IsDeleted = false,
                    };

                    var result = await invoiceRollbackOperation.Add(rollback);
                    if (result > 0)
                    {
                        var details = group.Select(x => new InvoiceRollbackDetail
                        {
                            InvoiceRollbackId = result,
                            ProductId = (int)x.ProductId,
                            Quantity = x.ReturnQuantity
                        }).ToList();

                       var resultProduct = await invoiceRollbackDetailOperation.Add(details);
                       if (resultProduct)
                       {
                           UpdateProducts(details);
                           Clear();
                           NotificationHelpers.Messages.SuccessMessage(this, $"{list.Count} məhsul uğurla qaytarıldı");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                NotificationHelpers.Messages.ErrorMessage(this, e.Message);
            }
        }

        private async void UpdateProducts(List<InvoiceRollbackDetail> items)
        {
            List<Products> products = new List<Products>();
            foreach (var item in items)
            {
                var product = await productOperation.Get(x => x.Id == item.ProductId);
                product.Quantity -= item.Quantity;
                products.Add(product);
            }

            var result = await productOperation.Update(products, x => x.Quantity);
        }

        private void bReport_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceRollbackReport>();
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName is "ReturnQuantity")
            {
                var unitName = gridView1.GetRowCellValue(e.RowHandle, "UnitName")?.ToString();

                if (unitName is "Kq")
                    e.RepositoryItem = repositoryF3;
                else
                    e.RepositoryItem = repositoryF0;
            }
        }

        RepositoryItemTextEdit repositoryF3;
        RepositoryItemTextEdit repositoryF0;
        private void GridRepoAdd()
        {
            repositoryF3 = new RepositoryItemSpinEdit();
            ((RepositoryItemSpinEdit)repositoryF3).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ((RepositoryItemSpinEdit)repositoryF3).Mask.EditMask = "F3";
            ((RepositoryItemSpinEdit)repositoryF3).Mask.UseMaskAsDisplayFormat = true;
            ((RepositoryItemSpinEdit)repositoryF3).IsFloatValue = true;
            ((RepositoryItemSpinEdit)repositoryF3).Increment = 0.001m;

            repositoryF0 = new RepositoryItemSpinEdit();
            ((RepositoryItemSpinEdit)repositoryF0).Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ((RepositoryItemSpinEdit)repositoryF0).Mask.EditMask = "F0";
            ((RepositoryItemSpinEdit)repositoryF0).Mask.UseMaskAsDisplayFormat = true;
            ((RepositoryItemSpinEdit)repositoryF0).IsFloatValue = false;

            gridControl1.RepositoryItems.Add(repositoryF3);
            gridControl1.RepositoryItems.Add(repositoryF0);
        }
    }
}