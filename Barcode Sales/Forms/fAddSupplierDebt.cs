using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
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
    public partial class fAddSupplierDebt : DevExpress.XtraEditors.XtraForm
    {
        ISupplierDebtOperation supplierDebtOperation = new SupplierDebtManager();
        ISupplierOperation supplierOperation = new SupplierManager();
        ITaxTypeOperation taxTypeOperation = new TaxTypeManager();
        private Enums.Operation _operation;
        private SuppliersDebt _supplierDebt;
        public fAddSupplierDebt(Enums.Operation operation, SuppliersDebt supplierDebt = null)
        {
            InitializeComponent();
            _operation = operation;
            _supplierDebt = supplierDebt;
        }

        private void fAddSupplierDebt_Load(object sender, EventArgs e)
        {
            #region Mask
            tDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            tDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            tDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            tDate.EditValue = DateTime.Now;

            tPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tPrice.Properties.Mask.EditMask = "n2";
            tPrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            tMainPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tMainPrice.Properties.Mask.EditMask = "n2";
            tMainPrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            tTaxPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tTaxPrice.Properties.Mask.EditMask = "n2";
            tTaxPrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            tNewDebt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tNewDebt.Properties.Mask.EditMask = "n2";
            tNewDebt.Properties.Mask.UseMaskAsDisplayFormat = true;

            tBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tBalance.Properties.Mask.EditMask = "n2";
            tBalance.Properties.Mask.UseMaskAsDisplayFormat = true;

            tTotalBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tTotalBalance.Properties.Mask.EditMask = "n2";
            tTotalBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask

            Clear();
            TaxTypeLoad();
            SupplierDataLoad();
            DataLoad();
        }

        private void controlFooterButton1_SaveClick(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
            {
                Add();
            }
            else if (_operation is Enums.Operation.Edit)
            {
                Edit();
            }
        }

        private void controlFooterButton1_CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void DataLoad()
        {
            if (_operation is Enums.Operation.Edit)
            {
                tDate.EditValue = _supplierDebt.DebtDate;
                tName.Text = _supplierDebt.Name;
                lookSupplier.EditValue = _supplierDebt.SupplierId;
                tMainPrice.EditValue = _supplierDebt.Debt.Value;
                tTaxPrice.EditValue = _supplierDebt.TaxDebt.Value;
                tPrice.EditValue = _supplierDebt.Debt.Value + _supplierDebt.TaxDebt.Value;
                tComment.Text = _supplierDebt.Comment;
            }
        }

        private void Add()
        {
            _supplierDebt = new SuppliersDebt();
            _supplierDebt.DebtDate = (DateTime)tDate.EditValue;
            _supplierDebt.SupplierId = lookSupplier.EditValue == null ? default(int) : (int)lookSupplier.EditValue;
            _supplierDebt.Name = tName.Text.Trim();
            _supplierDebt.Debt = Double.Parse(tMainPrice.Text);
            _supplierDebt.TaxDebt = Double.Parse(tTaxPrice.Text);
            _supplierDebt.Comment = tComment.Text.Trim();
            _supplierDebt.IsDeleted = 0;

            var validator = ValidationHelpers.ValidateMessage(_supplierDebt, new SupplierDebtValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            bool IsSuccess = supplierDebtOperation.Add(_supplierDebt);
            if (IsSuccess)
            {
                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                NoticationHelpers.Messages.SuccessMessage(form, $"{tName.Text} borcu uğurla yaradıldı");
                DialogResult = DialogResult.OK;
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(this, "Borc yaradılması zamanı xəta yarandı");
            }
        }

        private void Edit()
        {
            _supplierDebt.Comment = tComment.Text.Trim();
            
            supplierDebtOperation.Update(_supplierDebt);
            DialogResult = DialogResult.OK;
        }

        private void SupplierDataLoad()
        {
            var data = supplierOperation.Where(x => x.IsDeleted == 0)
                                        .Select(x => new
                                        {
                                            x.SupplierName,
                                            x.Id
                                        }).ToList();


            FormHelpers.ControlLoad(data, lookSupplier, "SupplierName", "Id");
        }

        private async void TaxTypeLoad()
        {
            var data = await taxTypeOperation.WhereAsync(null);

            FormHelpers.ControlLoad(data, lookTaxType);
        }

        private void Clear()
        {
            tDate.EditValue = DateTime.Now;
            lookSupplier.Clear();
            tName.Text = null;
            lookTaxType.Clear();
            tPrice.Text = CommonData.DEFAULT_INT_TOSTRING;
            tMainPrice.Text = CommonData.DEFAULT_INT_TOSTRING;
            tTaxPrice.Text = CommonData.DEFAULT_INT_TOSTRING;
            tComment.Text = null;

            tNewDebt.Text = CommonData.DEFAULT_INT_TOSTRING;
            tBalance.Text = CommonData.DEFAULT_INT_TOSTRING;
            tTotalBalance.Text = CommonData.DEFAULT_INT_TOSTRING;
        }

        private void lookSupplier_EditValueChanged(object sender, EventArgs e)
        {
            int Id = (int)lookSupplier.EditValue;

            var data = supplierDebtOperation.SupplierTotalDebt(Id);
            tBalance.EditValue = data;
            tTotalBalance.EditValue = Double.Parse(tNewDebt.Text) + Double.Parse(tBalance.Text);
        }

        private void tPrice_EditValueChanged(object sender, EventArgs e)
        {
            TaxCalculation();
            tNewDebt.Text = tPrice.Text;
            tTotalBalance.EditValue = Double.Parse(tNewDebt.Text) + Double.Parse(tBalance.Text);
        }

        private void TaxCalculation()
        {
            if (lookTaxType.EditValue != null)
            {
                int TaxId = (int)lookTaxType.EditValue;
                var price = Double.Parse(tPrice.Text);
                var taxPrice = Double.Parse(tTaxPrice.Text);

                switch ((int)lookTaxType.EditValue)
                {
                    case 1:
                        taxPrice = (price * 18) / 118;
                        break;
                        case 2:
                        //Ticarət əlavəsi olanının hesablamasını da apar
                        break;
                    case 4:
                    case 6:
                        taxPrice = price * 0.02;
                        break;
                    case 5:
                        taxPrice = price * 0.08;
                        break;
                    case 3:
                        taxPrice = 0;
                        break;
                }
                tMainPrice.EditValue = price - taxPrice;
                tTaxPrice.EditValue = taxPrice;
            }
        }

        private void lookTaxType_EditValueChanged(object sender, EventArgs e)
        {
            TaxCalculation();
        }
    }
}