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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        ISupplierOperation supplierOperation = new SupplierManager();
        IProductOperation productOperation = new ProductManager();
        IInvoiceOperation invoiceOperation = new InvoiceManager();
        IInvoiceDetailOperation invoiceDetailOperation = new InvoiceDetailManager();

        private BindingList<ProductInvoiceDto> _dataList = new BindingList<ProductInvoiceDto>();
        RepositoryItemTextEdit repositoryN3;
        RepositoryItemTextEdit repositoryN0;

        public fInvoiceProduct()
        {
            InitializeComponent();
            gridView1.RowCountChanged += (s, x) => UpdateCountData();
            //_dataList = productListDto ?? new BindingList<ProductInvoiceDto>();
            gridControl1.DataSource = _dataList;
        }

        private void fInvoiceProduct_Shown(object sender, EventArgs e)
        {
            tDate.Text = DatetimeService.CurrentDateString;
            WarehouseLoad();
            SupplierDataLoad();
            ProductsLoadAsync();
            GridRepoAdd();
        }

        private void UpdateCountData()
        {
            if (gridView1.RowCount > 0)
            {
                bSave.Cursor = Cursors.Hand;
                bSave.Text = $"Saxla ({_dataList.Count})";
            }
            else
            {
                bSave.Cursor = Cursors.No;
                bSave.Text = "Saxla (0)";
            }
        }

        private async void WarehouseLoad()
        {
            var data = await warehouseOperation.ToListAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, lookWarehouse);
        }

        private async void SupplierDataLoad()
        {
            var data = await supplierOperation.ToListAsync(x => x.IsDeleted == false);
            FormHelpers.ControlLoad(data, lookSuppliers, "SupplierName");
        }

        private async void ProductsLoadAsync()
        {
            var data = await productOperation
                .Where(x => x.IsDeleted == false && x.IsActive == true)
                .Select(x => new ProductInvoiceDto
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    SalePrice = x.SalePrice,
                    PurchasePrice = x.PurchasePrice,
                    Barcode = x.Barcode,
                    Stock = x.Quantity,
                    UnitName = x.UnitTypes.Name
                }).ToListAsync();

            lookProductName.Properties.DataSource = data;
            lookProductName.Properties.DisplayMember = "ProductName";
            lookProductName.Properties.ValueMember = "Id";
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (bSave.Cursor == Cursors.No)
                return;

            if (!ValidationHelpers.IsValidDate(tDate.Text))
            {
                NotificationHelpers.Messages.WarningMessage(this, ValidationHelpers.DatetimeFormatError);
                tDate.Focus();
                return;
            }

            AddInvoice();
        }

        private async void AddInvoice()
        {
            try
            {
                Invoice invoice = new Invoice()
                {
                    InvoiceNo = tContractNo.Text.TrimStart().Trim(),
                    InvoiceDate = Convert.ToDateTime(tDate.Text),
                    TotalPurchasePrice = _dataList.Sum(x => x.PurchasePrice),
                    WarehouseId = lookWarehouse.EditValue == null ? 0 : (int)lookWarehouse.EditValue,
                    SupplierId = lookSuppliers.EditValue == null ? 0 : (int)lookSuppliers.EditValue,
                    Comment = tComment.Text.TrimStart().Trim(),
                    UserId = UserCacheService.User.Id,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                };

                var validator = ValidationHelpers.ValidateMessage(invoice, new InvoiceValidation(), this);

                if (!validator.IsValid)
                    return;

                var invoiceId = await invoiceOperation.Add(invoice);
                if (invoiceId > 0)
                {
                    List<InvoiceDetail> details = new List<InvoiceDetail>();
                    details.AddRange(_dataList.Select(x => new InvoiceDetail
                    {
                        InvoiceId = invoiceId,
                        ProductId = x.Id,
                        Amount = x.Quantity,
                        PurchasePrice = x.PurchasePrice,
                        SalePrice = x.SalePrice,
                        Discount = 0,
                        TotalPurchasePrice = (x.Quantity * x.PurchasePrice),
                    }));

                    if (await invoiceDetailOperation.Add(details))
                    {
                        NotificationHelpers.Messages.SuccessMessage(this, "Məhsul alışı uğurla tamamlandı");
                        Reset();
                    }
                }
                else
                    NotificationHelpers.Messages.ErrorMessage(this, "İnvoys yaradılarkən xəta yarandı");
            }
            catch (Exception e)
            {
                NotificationHelpers.Messages.ErrorMessage(this, e.Message);
            }
        }

        private void tBarcodeSearch_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcodeSearch_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void lookProductName_EditValueChanged(object sender, EventArgs e)
        {
            var selectedRow = lookProductName.Properties.View.GetFocusedRow() as ProductInvoiceDto;
            if (selectedRow == null) return;

            var product = _dataList.FirstOrDefault(x => x.Barcode == selectedRow.Barcode);

            if (product != null)
                product.Quantity++;
            else
            {
                selectedRow.Quantity = 1;
                _dataList.Add(selectedRow);
            }

            gridView1.RefreshData();

            lookProductName.EditValueChanged -= lookProductName_EditValueChanged;
            lookProductName.EditValue = null;
            lookProductName.EditValueChanged += lookProductName_EditValueChanged;

            lookProductName.Focus();
        }

        private async void tBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                string barcode = tBarcodeSearch.Text.TrimStart().Trim();

                var product = _dataList.FirstOrDefault(x => x.Barcode == barcode);

                if (product != null)
                    product.Quantity ++;
                else
                {
                    var data = await productOperation.Get(x => x.Barcode == barcode && x.IsDeleted == false);
                    if (data is null)
                    {
                        NotificationHelpers.Messages.WarningMessage(this, $"({barcode}) barkoduna aid məhsul sistemdə tapılmadı", "Məhsul tapılmadı");
                    }
                    else
                    {
                        _dataList.Add(new ProductInvoiceDto()
                        {
                            Id = data.Id,
                            Barcode = data.Barcode,
                            ProductName = data.ProductName,
                            PurchasePrice = data.PurchasePrice,
                            SalePrice = data.SalePrice,
                            Stock = data.Quantity,
                            UnitName = data.UnitTypes.Name
                        });
                    }
                }

                gridView1.RefreshData();
                tBarcodeSearch.Text = null;
                tBarcodeSearch.Focus();
            }
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            tBarcodeSearch.Clear();
            lookProductName.EditValue = null;
            tDate.Text = DateTime.Now.ToShortDateString();
            tContractNo.Clear();
            lookWarehouse.EditValue = null;
            lookSuppliers.EditValue = null;
            tComment.Clear();
        }

        private void bReport_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceReport>();
        }

        private void bDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as ProductInvoiceDto;
            if (selectedRow != null)
                _dataList.Remove(selectedRow);

            gridView1.RefreshData();
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
        }

        private void bAddWarehouse_Click(object sender, EventArgs e)
        {
            fWarehouse f = new fWarehouse(Enums.Operation.Add, null);
            f.FormClosed += (s, args) =>
            {
                WarehouseLoad();
            };
            f.ShowDialog();
        }

        private void bAddSupplier_Click(object sender, EventArgs e)
        {
            fSupplier f = new fSupplier(Enums.Operation.Add, null);
            f.FormClosed += (s, args) =>
            {
                SupplierDataLoad();
            };
            f.ShowDialog();
        }

        private void bMultiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rowsToDelete = gridView1
                .GetSelectedRows()
                .Select(r => gridView1.GetRow(r) as ProductInvoiceDto)
                .Where(x => x != null)
                .ToList();

            foreach (var item in rowsToDelete)
                _dataList.Remove(item);

            gridView1.RefreshData();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            var hasValidSelection = gridView1
                .GetSelectedRows()
                .Any(r => r >= 0);

            if (_dataList.Count > 0 && hasValidSelection)
                popupMenu1.ShowPopup(Control.MousePosition);
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName is "Quantity")
            {
                var unitName = gridView1.GetRowCellValue(e.RowHandle, "UnitName")?.ToString();

                if (unitName is "Ədəd")
                    e.RepositoryItem = repositoryN0;
                else
                    e.RepositoryItem = repositoryN3;
            }
        }

        private void GridRepoAdd()
        {
            repositoryN3 = new RepositoryItemTextEdit();
            repositoryN3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN3.Mask.EditMask = "n3";
            repositoryN3.Mask.UseMaskAsDisplayFormat = true;

            repositoryN0 = new RepositoryItemTextEdit();
            repositoryN0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN0.Mask.EditMask = "n0";
            repositoryN0.Mask.UseMaskAsDisplayFormat = true;

            gridControl1.RepositoryItems.Add(repositoryN3);
            gridControl1.RepositoryItems.Add(repositoryN0);
        }
    }
}