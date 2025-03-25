using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceProduct : FormBase
    {
        private short rowNo = 1;
        ISupplierOperation supplierOperation = new SupplierManager();
        private BindingList<ProductGridData> dataList;
        public fInvoiceProduct()
        {
            InitializeComponent();
        }

        void SuppliersDataLoad()
        {
            var data = supplierOperation.Where(x => x.IsDeleted == 0)
                                        .Select(x => new
                                        {
                                            x.SupplierName,
                                            x.Id
                                        }).ToList();


            FormHelpers.ControlLoad(data, lookSupplier, "SupplierName", "Id");
        }

        void PayTypeDataLoad()
        {
            var payType = Enum.GetValues(typeof(Enums.UnitTypes))
                                .Cast<Enums.PayTypes>()
                                .Where(x => x == Enums.PayTypes.Free || x == Enums.PayTypes.Bank)
                                .ToDictionary(x => x, x => Enums.GetEnumDescription(x));
            FormHelpers.ControlLoad(new BindingSource(payType, null), lookPayType, "Value", "Key");
            lookPayType.Properties.DropDownRows = payType.Values.Count;
        }

        void FullClear()
        {
            //Invoice
            tInvoiceNo.Text = null;
            tInvoiceDate.Text = null;
            lookSupplier.Text = null;
            lookWarehouse.Text = null;
            lookPayType.Text = null;
            tComment.Text = null;
            //Supplier
            tSupplierName.Text = null;
            tTotalInvoice.Text = null;
            tOldDebt.Text = null;
            tTotalDebt.Text = null;
            //Product
            tProductCode.Text = null;
            tProductName.Text = null;
            tBarcode.Text = null;
            tTax.Text = null;
            tUnit.Text = null;
            tPurchasePrice.Text = null;
            tDiscount.Text = null;
            tProductTotal.Text = null;
            tPrincipalAmount.Text = null;
            tVatAmount.Text = null;
            tInvoiceNo.Focus();
        }

        void ProductClear()
        {
            tProductCode.Text = null;
            tProductName.Text = null;
            tBarcode.Text = null;
            tTax.Text = null;
            tUnit.Text = null;
            tAmount.EditValue = 0;
            tPurchasePrice.EditValue = 0;
            tDiscount.EditValue = 0;
            tProductTotal.EditValue = 0;
            tPrincipalAmount.EditValue = 0;
            tVatAmount.EditValue = 0;
            tProductId.Text = null;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            FullClear();
        }

        private void bRemoveProduct_Click(object sender, EventArgs e)
        {
            ProductClear();
        }

        private void fInvoiceProduct_Load(object sender, EventArgs e)
        {
            PayTypeDataLoad();
            SuppliersDataLoad();
            dataList = new BindingList<ProductGridData>();
            gridControlProducts.DataSource = dataList;
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            ProductAddGrid();
        }

        private void ProductAddGrid()
        {
            ProductGridData productGrid = new ProductGridData();
            productGrid.Id = int.Parse(tProductId.Text);
            productGrid.No = rowNo;
            productGrid.ProductCode = tProductCode.Text;
            productGrid.ProductName = tProductName.Text;
            productGrid.Barcode = tBarcode.Text;
            productGrid.Amount = Double.Parse(tAmount.EditValue.ToString());
            productGrid.UnitName = tUnit.Text;
            productGrid.TaxName = tTax.Text;
            productGrid.PurchasePrice = Double.Parse(tPurchasePrice.EditValue.ToString());
            productGrid.Discount = Double.Parse(tDiscount.EditValue.ToString());
            productGrid.TotalPurchasePrice = Double.Parse(tProductTotal.EditValue.ToString());
            dataList.Add(productGrid);
            rowNo++;
            ProductClear();
        }

        private class ProductGridData
        {
            public int Id { get; set; }
            public short No { get; set; }
            public string Warehouses { get; set; } = "MƏRKƏZİ ANBAR";
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public string Barcode { get; set; }
            public string UnitName { get; set; }
            public string TaxName { get; set; }
            public double Amount { get; set; }
            public double PurchasePrice { get; set; }
            public double Discount { get; set; }
            public double TotalPurchasePrice { get; set; }
        }

        private void bSelectProduct_Click(object sender, EventArgs e)
        {
            fSelectedProduct<fInvoiceProduct> selectedProduct = new fSelectedProduct<fInvoiceProduct>(this);
            selectedProduct.ShowDialog();
        }

        public override void ReceiveData<T>(T data)
        {
            if (data != null && data is Products product)
            {
                tProductId.Text = product.Id.ToString();
                tProductCode.Text = product.ProductCode;
                tProductName.Text = product.ProductName;
                tBarcode.Text = product.Barcode;
                tTax.Text = product.Tax;
                tUnit.Text = product.Unit;

                tPurchasePrice.ReadOnly = false;
                tAmount.ReadOnly = false;
                tDiscount.ReadOnly = false;
            }
        }

        private void CalcTotal()
        {
            decimal amount = Decimal.Parse(tAmount.EditValue.ToString());
            decimal price = Decimal.Parse(tPurchasePrice.EditValue.ToString());
            decimal total = Decimal.Parse(tPurchasePrice.EditValue.ToString());
            decimal discount = Decimal.Parse(tDiscount.EditValue.ToString()) / 100;

            var test = (total * Decimal.Parse(tDiscount.EditValue.ToString())) / 100;

            if (!((double)tDiscount.EditValue <= 0))
            {
                tProductTotal.EditValue = total - discount;
            }
            else
            {
                tProductTotal.EditValue = amount * price;
            }
        }

        private void tAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalcTotal();
        }

        private void tPurchasePrice_EditValueChanged(object sender, EventArgs e)
        {
            CalcTotal();
        }

        private void tDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalcTotal();
        }

        private void DiscountCalc()
        {
            double discount = Double.Parse(tDiscount.EditValue.ToString()) / 100;
            if (!((double)tDiscount.EditValue <= 0))
            {
                tProductTotal.EditValue = Double.Parse(tProductTotal.EditValue.ToString()) - discount;
            }
            else
            {
                CalcTotal();
            }

        }

        private void lookSupplier_Properties_EditValueChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(lookSupplier.EditValue.ToString());
            var control = supplierOperation.GetById(Id);
            tSupplierName.Text = control.SupplierName;
            tOldDebt.EditValue = control.Debt;
        }
    }
}