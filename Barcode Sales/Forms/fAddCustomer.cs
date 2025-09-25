using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fAddCustomer : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private ICustomerGroupOperation customerGroupOperation = new CustomerGroupManager();
        ICustomerOperation customerOperation = new CustomerManager();
        private Enums.Operation _operation { get; }
        private Customer _customer { get; set; }
        public fAddCustomer(Enums.Operation operation, Customer customer = null)
        {
            InitializeComponent();
            _operation = operation;
            _customer = customer;
        }

        private void fAddCustomer_Load(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.Operation.Add:
                    CustomerGroupsLoad();
                    break;
                case Enums.Operation.Edit:
                    CustomerDataLoad();
                    break;
                case Enums.Operation.Show:
                    CustomerDataLoad();
                    break;
            }
        }

        private void CustomerGroupsLoad()
        {
            var data = customerGroupOperation.Where(x => x.IsDeleted == false).ToList();
            FormHelpers.ControlLoad(data, lookCustomerGroup);
        }

        private void CustomerDataLoad()
        {
            tNameSurname.Text = _customer.NameSurname;
            tDateBirth.EditValue = _customer.DateBirth == null ? null : _customer.DateBirth;
            chMan.Checked = _customer.Gender == "KİŞİ" || _customer.Gender == "KISI ";
            chWomen.Checked = _customer.Gender == "QADIN";
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
            var gender = groupCustomer.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);
            _customer = new Customer()
            {
                NameSurname = tNameSurname.Text.Trim(),
                DateBirth = tDateBirth.EditValue as DateTime?,
                Gender = gender.Text,
                Voen = tVoen.Text.Trim(),
                Comment = tComment.Text.Trim(),
                Email = tEmail.Text.Trim(),
                Phone = tPhone.Text,
                BankName = tBankName.Text.Trim(),
                BankVoen = tBankVoen.Text.Trim(),
                BankAccountNumber = tBankAccountNumber.Text.Trim(),
                BankKOD = tBankKod.Text.Trim(),
                BankSwift = tBankSwift.Text.Trim(),
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
            var gender = groupCustomer.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);

            _customer.DateBirth = tDateBirth.EditValue as DateTime?;
            _customer.Gender = gender.Text;
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
            tNameSurname.Clear();
            tDateBirth.Text = null;
            chMan.Checked = false;
            chWomen.Checked = false;
            tVoen.Clear();
            tComment.Clear();
            tEmail.Clear();
            tPhone.Clear();
            tBankName.Clear();
            tBankVoen.Clear();
            tBankAccountNumber.Clear();
            tBankKod.Clear();
            tBankSwift.Clear();
            tNameSurname.Focus();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.Operation.Add:
                    Add(); break;
                case Enums.Operation.Edit:
                    Edit(); break;
            }
        }
    }
}