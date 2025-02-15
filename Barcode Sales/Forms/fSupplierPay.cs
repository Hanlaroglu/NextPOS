using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraCharts.Designer.Native;
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
    public partial class fSupplierPay : DevExpress.XtraEditors.XtraForm
    {
        ISupplierDebtOperation supplierDebtOperation = new SupplierDebtManager();
        ISupplierPaymentOperation supplierPaymentOperation = new SupplierPaymentManager();
        private Enums.Operation _operation;
        private SuppliersDebt _supplierDebt;

        public fSupplierPay(Enums.Operation operation, SuppliersDebt supplierDebt)
        {
            InitializeComponent();
            _operation = operation;
            _supplierDebt = supplierDebt;
        }

        private void fSupplierPay_Load(object sender, EventArgs e)
        {
            #region Mask
            tDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            tDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            tDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            tDate.EditValue = DateTime.Now;


            tTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tTotal.Properties.Mask.EditMask = "n2";
            tTotal.Properties.Mask.UseMaskAsDisplayFormat = true;

            tMainDebt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tMainDebt.Properties.Mask.EditMask = "n2";
            tMainDebt.Properties.Mask.UseMaskAsDisplayFormat = true;


            tTaxDebt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tTaxDebt.Properties.Mask.EditMask = "n2";
            tTaxDebt.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask

            if (_operation is Enums.Operation.Pay)
            {
                SupplierDataLoad();
                controlFooterButton1.CancelVisible = false;
                controlFooterButton1.SaveButtonText = Enums.GetEnumDescription(Enums.Operation.Pay);
                controlFooterButton1.SaveButtonImage = Enums.Operation.Pay;
            }
        }

        private void controlFooterButton1_SaveClick(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Pay)
            {
                Pay();
            }
        }

        private void Pay()
        {
            var selectedPaymentType = groupControl1.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);

            SupplierPayment payment = new SupplierPayment();
            payment.SupplierDebtId = _supplierDebt.Id;
            payment.PayDate = (DateTime)tDate.EditValue;
            payment.DebtPaid = Double.Parse(tMainDebt.Text);
            payment.TaxPaid = Double.Parse(tTaxDebt.Text);
            payment.Comment = tComment.Text;
            payment.PaymentType = selectedPaymentType.Text;
            payment.IsDeleted = 0;
            payment.LogDate = DateTime.Now;

            var validator = ValidationHelpers.ValidateMessage(payment, new SupplierPaymentValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            bool IsSuccess = supplierPaymentOperation.Add(payment);
            if (IsSuccess)
            {
                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                NoticationHelpers.Messages.SuccessMessage(form, "Ödəniş uğurla tamamlandı");
                DialogResult = DialogResult.OK;
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(this, "Ödəniş əməliyyatı uğursuz oldu");
            }
        }

        private void SupplierDataLoad()
        {
            groupControl2.Text = $"{_supplierDebt.Supplier.SupplierName} təchizatçısının ümumi yekun borcu";
            lSupplierTotalDebt.Text = supplierDebtOperation.SupplierTotalDebt(_supplierDebt.SupplierId ?? 0).ToString("C2");
            tTotal.Text = (_supplierDebt.Debt + _supplierDebt.TaxDebt).Value.ToString();
            tMainDebt.Text = _supplierDebt.Debt.Value.ToString();
            tTaxDebt.Text = _supplierDebt.TaxDebt.Value.ToString();
        }
    }
}