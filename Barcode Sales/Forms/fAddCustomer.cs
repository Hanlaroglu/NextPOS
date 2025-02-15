using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fAddCustomer : DevExpress.XtraEditors.XtraForm
    {
        ICustomerOperation customerOperation = new CustomerManager();
        private Enums.Operation _operation { get; }
        private Customers _customer { get; set; }
        public fAddCustomer(Enums.Operation operation, Customers customer = null)
        {
            InitializeComponent();
            _operation = operation;
            _customer = customer;
        }

        private void fAddCustomer_Load(object sender, EventArgs e)
        {
            tDateBirth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            tDateBirth.Properties.Mask.EditMask = "dd.MM.yyyy";
            tDateBirth.Properties.Mask.UseMaskAsDisplayFormat = true;
            tDateBirth.EditValue = DateTime.Now;

            switch (_operation)
            {
                case Enums.Operation.Add:
                    Clear();
                    controlFooterButton1.SaveButtonText = Enums.GetEnumDescription(Enums.Operation.Add);
                    controlFooterButton1.SaveButtonImage = Enums.Operation.Add;
                    bSaleHistory.Visible = false;
                    bCredit.Visible = false;
                    bDebtHistory.Visible = false;
                    break;
                case Enums.Operation.Edit:
                    CustomerDataLoad();
                    controlFooterButton1.SaveButtonText = Enums.GetEnumDescription(Enums.Operation.Edit);
                    controlFooterButton1.SaveButtonImage = Enums.Operation.Edit;
                    break;
                case Enums.Operation.Show:
                    CustomerDataLoad();
                    controlFooterButton1.SaveButtonText = Enums.GetEnumDescription(Enums.Operation.Close);
                    controlFooterButton1.SaveButtonImage = Enums.Operation.Close;
                    break;
            }
        }

        private void CustomerDataLoad()
        {
            tNameSurname.Text = _customer.NameSurname;
            tDateBirth.EditValue = _customer.DateBirth;
            chMan.Checked = _customer.Gender == "KİŞİ" || _customer.Gender == "KISI ";
            chWomen.Checked = _customer.Gender == "QADIN";
            tAddress.Text = _customer.Address;
            tVoen.Text = _customer.Voen;
            tComment.Text = _customer.Comment;
            tEmail.Text = _customer.Email;
            tPhone.Text = _customer.Phone;
            tBankName.Text = _customer.BankName;
            tBankVoen.Text = _customer.BankVoen;
            tBankAccountNumber.Text = _customer.BankAccountNumber;
            tBankKod.Text = _customer.BankKOD;
            tBankSwift.Text = _customer.BankSwift;
        }

        private void Add()
        {
            var gender = groupProduct.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);
            _customer = new Customers()
            {
                NameSurname = tNameSurname.Text.Trim(),
                DateBirth = (DateTime)tDateBirth.EditValue,
                Gender = gender.Text,
                Address = tAddress.Text.Trim(),
                Voen = tVoen.Text.Trim(),
                Comment = tComment.Text.Trim(),
                Email = tEmail.Text.Trim(),
                Phone = tPhone.Text.Trim(),
                BankName = tBankName.Text.Trim(),
                BankVoen = tBankVoen.Text.Trim(),
                BankAccountNumber = tBankAccountNumber.Text.Trim(),
                BankKOD = tBankKod.Text.Trim(),
                BankSwift = tBankSwift.Text.Trim(),
                Debt = 0,
                Balance = 0,
                Status = true,
                IsDeleted = 0,
            };

            var validator = ValidationHelpers.ValidateMessage(_customer, new CustomerValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            if (customerOperation.Add(_customer))
            {
                NoticationHelpers.Messages.SuccessMessage(this, $"{_customer.NameSurname} müştərisi uğurla yaradıldı");
                Clear();
            }
        }

        private void Edit()
        {
            var gender = groupProduct.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);

            _customer.DateBirth = (DateTime)tDateBirth.EditValue;
            _customer.Gender = gender.Text;
            _customer.Address = tAddress.Text.Trim();
            _customer.Voen = tVoen.Text.Trim();
            _customer.Comment = tComment.Text.Trim();
            _customer.Email = tEmail.Text.Trim();
            _customer.Phone = tPhone.Text.Trim();
            _customer.BankName = tBankName.Text.Trim();
            _customer.BankVoen = tBankVoen.Text.Trim();
            _customer.BankAccountNumber = tBankAccountNumber.Text.Trim();
            _customer.BankKOD = tBankKod.Text.Trim();
            _customer.BankSwift = tBankSwift.Text.Trim();

            customerOperation.Update(_customer);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Clear()
        {
            tNameSurname.Text = null;
            tDateBirth.Text = null;
            chMan.Checked = false;
            chWomen.Checked = false;
            tAddress.Text = null;
            tVoen.Text = null;
            tComment.Text = null;
            tEmail.Text = null;
            tPhone.Text = null;
            tBankName.Text = null;
            tBankVoen.Text = null;
            tBankAccountNumber.Text = null;
            tBankKod.Text = null;
            tBankSwift.Text = null;
            tNameSurname.Focus();
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
    }
}