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
    public partial class fInvoiceProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IWarehouseOperation warehouseOperation = new WarehouseManager();
        private IPaymentTypeOperation paymentTypeOperation = new PaymentTypeManager();
        private IProductOperation productOperation = new ProductManager();
        private IInvoiceOperation invoiceOperation = new InvoiceManager();
        IInvoiceDetailOperation invoiceDetailOperation = new InvoiceDetailManager();

        private BindingList<ProductSearchData> _dataList = new BindingList<ProductSearchData>();

        public fInvoiceProduct()
        {
            InitializeComponent();
        }

        private async void fInvoiceProduct_Load(object sender, EventArgs e)
        {
            tDate.Text = DateTime.Now.ToShortDateString();
            WarehouseLoad();
            PaymentTypeLoad();
            await ProductsLoadAsync();
            gridControl1.DataSource = _dataList;
            gridView1.RowCountChanged += (s, x) =>
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
            };
        }

        private void WarehouseLoad()
        {
            var data = warehouseOperation.Where(x => x.IsDeleted == 0).ToList();
            FormHelpers.ControlLoad(data, lookWarehouse);
        }

        private void PaymentTypeLoad()
        {
            var data = paymentTypeOperation.Where(x => x.IsDeleted == 0).ToList();
            FormHelpers.ControlLoad(data, lookPaymentType);
        }

        private async Task ProductsLoadAsync()
        {
            var data = await productOperation
                .Where(x => x.IsDeleted == 0 && x.Status == true)
                .Select(x => new ProductSearchData
                {
                    Id = x.Id,
                    SupplierId = (int)x.SupplierId,
                    SupplierName = x.Suppliers.SupplierName,
                    ProductName = x.ProductName,
                    SalePrice = x.SalePrice ?? 0,
                    PurchasePrice = x.PurchasePrice ?? 0,
                    Barcode = x.Barcode,
                    Stock = x.Amount
                }).ToListAsync();
            lookProductName.Properties.DataSource = data;
            lookProductName.Properties.DisplayMember = "ProductName";
            lookProductName.Properties.ValueMember = "Id";
        }

        private void lookWarehouse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            fWarehouse f = new fWarehouse(Enums.Operation.Add, null);
            f.FormClosed += (s, args) =>
            {
                WarehouseLoad();
            };
            f.ShowDialog();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (bSave.Cursor == Cursors.No)
                return;

            if (!ValidationHelpers.IsValidDate(tDate.Text))
            {
                NoticationHelpers.Messages.WarningMessage(this, $"Tarix düzgün daxil edilmədi");
                tDate.Focus();
                return;
            }

            AddInvoice();
        }

        private void AddInvoice()
        {
            try
            {
                Invoice invoice = new Invoice()
                {
                    InvoiceDate = Convert.ToDateTime(tDate.Text),
                    InvoiceNo = tContractNo.Text.Trim(),
                    TotalPurchasePrice = _dataList.Sum(x => x.PurchasePrice),
                    WarehouseId = lookWarehouse.EditValue == null ? 0 : (int)lookWarehouse.EditValue,
                    PaymentTypeId = lookPaymentType.EditValue == null ? 0 : (int)lookPaymentType.EditValue,
                    Comment = tComment.Text.Trim(),
                    UserId = 3,
                    IsDeleted = 0,
                    CreatedDate = DateTime.Now
                };

                var validator = ValidationHelpers.ValidateMessage(invoice, new InvoiceValidation(), this);

                if (!validator.IsValid)
                {
                    return;
                }


                var invoiceId = invoiceOperation.AddInvoice(invoice);

                List<InvoiceDetail> details = new List<InvoiceDetail>();
                details.AddRange(_dataList.Select(x => new InvoiceDetail
                {
                    InvoiceId = invoiceId,
                    ProductId = x.Id,
                    Amount = x.Quantity,
                    PurchasePrice = x.PurchasePrice,
                    Discount = 0,
                    TotalPurchasePrice = x.Quantity * x.PurchasePrice,
                }));
                invoiceDetailOperation.AddRange(details);
                NoticationHelpers.Messages.SuccessMessage(this, "Məhsul alışı tamamlandı");
                Reset();
            }
            catch (Exception e)
            {
                NoticationHelpers.Messages.ErrorMessage(this, e.Message);
            }

        }

        private void tBarcodeSearch_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcodeSearch_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void lookProductName_EditValueChanged(object sender, EventArgs e)
        {
            lookProductName.EditValueChanged -= lookProductName_EditValueChanged;

            var selectedRow = lookProductName.Properties.View.GetFocusedRow() as ProductSearchData;
            if (selectedRow == null) return;

            var checkProduct = _dataList.FirstOrDefault(x => x.Barcode == selectedRow.Barcode);

            if (checkProduct != null)
                checkProduct.Quantity += 1;
            else
                _dataList.Add(selectedRow);

            gridView1.RefreshData();
            lookProductName.Text = null;
            lookProductName.Focus();
            lookProductName.EditValueChanged += lookProductName_EditValueChanged;
        }

        private void tBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                string barcode = tBarcodeSearch.Text.TrimStart().Trim();

                var existingData = _dataList.FirstOrDefault(x => x.Barcode == barcode);

                if (existingData != null)
                    existingData.Quantity += 1;
                else
                {
                    var data = productOperation.Where(x => x.Barcode == barcode && x.IsDeleted == 0).FirstOrDefault();
                    if (data is null)
                    {
                        NoticationHelpers.Messages.WarningMessage(this, $"({barcode}) barkoduna aid məhsul sistemdə tapılmadı", "Məhsul tapılmadı");
                        return;
                    }
                    else
                    {
                        _dataList.Add(new ProductSearchData()
                        {
                            Id = data.Id,
                            SupplierId = data.SupplierId ?? default,
                            SupplierName = data.Suppliers.SupplierName,
                            Barcode = data.Barcode,
                            ProductName = data.ProductName,
                            PurchasePrice = data.PurchasePrice,
                            SalePrice = data.SalePrice ?? default,
                            Stock = data.Amount
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
            _dataList.Clear();
            tBarcodeSearch.Clear();
            lookProductName.EditValue = null;
            tDate.Text = DateTime.Now.ToShortDateString();
            tContractNo.Clear();
            lookWarehouse.EditValue = null;
            lookPaymentType.EditValue = null;
            tComment.Clear();
        }

        private class ProductSearchData
        {
            public int Id { get; set; }
            public int SupplierId { get; set; }
            public string SupplierName { get; set; }
            public string ProductName { get; set; }
            public double? PurchasePrice { get; set; }
            public double SalePrice { get; set; }
            public string Barcode { get; set; }
            public double? Stock { get; set; } //Anbar qalığı
            public double Quantity { get; set; } = 1;
            public double TotalPurchaseAmount { get => Quantity * (double)PurchasePrice; }
            public double TotalSaleAmount { get => Quantity * SalePrice; }
            private double _percent;
            public double Percent
            {
                get => _percent;
                set
                {
                    _percent = value;
                    SalePrice = (double)PurchasePrice * (1 + (_percent / 100));
                }
            }
            public double GainAmount { get => TotalSaleAmount - TotalPurchaseAmount; }
        }

        private void bReport_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceReport>();
        }

        private void bDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as ProductSearchData;
            if (selectedRow != null)
                _dataList.Remove(selectedRow);

            gridView1.RefreshData();
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
        }
    }
}