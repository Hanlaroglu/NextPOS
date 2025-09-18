using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors.Internal;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using Barcode_Sales.Barcode.Sales.UI;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IWarehouseOperation warehouseOperation = new WarehouseManager();
        private IPaymentTypeOperation paymentTypeOperation = new PaymentTypeManager();
        private IProductOperation productOperation = new ProductManager();
        private IInvoiceOperation invoiceOperation = new InvoiceManager();
        IInvoiceDetailOperation invoiceDetailOperation = new InvoiceDetailManager();

        private BindingList<Products> _products = new BindingList<Products>();

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
            gridControl1.DataSource = _products;
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
            var data = await productOperation.Where(x => x.IsDeleted == 0 && x.Status == true)
                .Select(x => new
                {
                    x.Id,
                    SupplierName = x.Suppliers.SupplierName,
                    x.ProductName,
                    x.SalePrice,
                }).ToListAsync();
            lookProductName.Properties.DataSource = data;
            lookProductName.Properties.DisplayMember = "ProductName";
            lookProductName.Properties.ValueMember = "Id";
        }

        private void lookWarehouse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormHelpers.OpenForm<fWarehouse>(Enums.Operation.Add, null);
        }

        private bool IsValidDate(string text)
        {
            return DateTime.TryParse(text, out _);
        }

        private void tBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                string barcode = tBarcodeSearch.Text.TrimStart().Trim();

                var existingData = _products.FirstOrDefault(x => x.Barcode == barcode);

                if (existingData != null)
                {
                    existingData.Amount += 1;
                }
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
                        Products product = new Products()
                        {

                        };
                    }
                }

                gridView1.RefreshData();
                tBarcodeSearch.Text = null;
                tBarcodeSearch.Focus();



            }
        }

        private void Lock()
        {

        }

        private void GridAdd()
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!IsValidDate(tDate.Text))
            {
                NoticationHelpers.Messages.WarningMessage(this, $"Tarix düzgün daxil edilmədi");
                tDate.Focus();
                return;
            }

            Invoice invoice = new Invoice()
            {
                InvoiceDate = Convert.ToDateTime(tDate.Text),
                InvoiceNo = tContractNo.Text.Trim(),
                TotalPurchasePrice = 0,//Ümumi alış məbləği
                WarehouseId = lookWarehouse.EditValue == null ? 0 : (int)lookWarehouse.EditValue,
                PaymentTypeId = lookPaymentType.EditValue == null ? 0 : (int)lookPaymentType.EditValue,
                Comment = tComment.Text.Trim(),
                UserId = CommonData.CURRENT_USER.Id,
                IsDeleted = 0,
                CreatedDate = DateTime.UtcNow
            };
            var invoiceId = invoiceOperation.AddInvoice(invoice);
            AddInvoiceDetails(invoiceId);
        }

        private void AddInvoiceDetails(int invoiceId)
        {
            InvoiceDetail detail = new InvoiceDetail()
            {
                InvoiceId = invoiceId
            };
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
        }

        private class ProductSearchData
        {
            public int Id { get; set; }
            public int SupplierId { get; set; }
            public string ProductName { get; set; }
            public double? PurchasePrice { get; set; }
            public double SalePrice { get; set; } = 0;
            public double Discount { get; set; } = 0;
            public string Barcode { get; set; }
            public int UnitId { get; set; }
            public int TaxId { get; set; }
            public double Amount { get; set; }
        }
    }
}