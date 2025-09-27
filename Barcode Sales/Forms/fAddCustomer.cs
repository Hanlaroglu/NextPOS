using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private async void fAddCustomer_Load(object sender, EventArgs e)
        {
           await CustomerGroupsLoad();
            switch (_operation)
            {
                case Enums.Operation.Edit:
                    CustomerDataLoad();
                    break;
                case Enums.Operation.Show:
                    CustomerDataLoad();
                    break;
            }
        }

        private async Task CustomerGroupsLoad()
        {
            var data = await customerGroupOperation.WhereAsync(x => x.IsDeleted == false);
            FormHelpers.ControlLoad(data, lookCustomerGroup);
        }

        private void CustomerDataLoad()
        {
            tNameSurname.ReadOnly = true;
            tNameSurname.Cursor = Cursors.No;
            tNameSurname.Text = _customer.NameSurname;
            tDateBirth.EditValue = _customer.DateBirth == null ? null : _customer.DateBirth;
            chMan.Checked = _customer.Gender.Trim() == "Man";
            chWoman.Checked = _customer.Gender.Trim() == "Woman";
            chOther.Checked = _customer.Gender.Trim() == "Other";
            tVoen.Text = _customer.Voen;
            lookCustomerGroup.EditValue = _customer.CustomerGroupId;
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
                Gender = gender.Tag.ToString(),
                CustomerGroupId = lookCustomerGroup.EditValue as int?,
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
                NotificationHelpers.Messages.SuccessMessage(this, $"{_customer.NameSurname} müştərisi uğurla yaradıldı");
                Clear();
            }
        }

        private async Task Edit()
        {
            var gender = groupCustomer.Controls.OfType<CheckEdit>().FirstOrDefault(x => x.Checked);

            _customer.DateBirth = tDateBirth.EditValue as DateTime?;
            _customer.Gender = gender.Tag.ToString();
            _customer.CustomerGroupId = lookCustomerGroup.EditValue as int?;
            _customer.Voen = tVoen.Text.Trim();
            _customer.Comment = tComment.Text.Trim();
            _customer.Email = tEmail.Text.Trim();
            _customer.Phone = tPhone.Text.Trim();
            _customer.BankName = tBankName.Text.Trim();
            _customer.BankVoen = tBankVoen.Text.Trim();
            _customer.BankAccountNumber = tBankAccountNumber.Text.Trim();
            _customer.BankKOD = tBankKod.Text.Trim();
            _customer.BankSwift = tBankSwift.Text.Trim();

            await customerOperation.UpdateAsync(_customer);
            Close();
        }

        private void Clear()
        {
            tNameSurname.Clear();
            tDateBirth.Text = null;
            chMan.Checked = false;
            chWoman.Checked = false;
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

        private async void bSave_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.Operation.Add:
                    Add(); break;
                case Enums.Operation.Edit:
                    await Edit(); break;
            }
        }

        private void bSaleHistory_Click(object sender, EventArgs e)
        {

        }

        private void bCredit_Click(object sender, EventArgs e)
        {

        }

        private void bDebtHistory_Click(object sender, EventArgs e)
        {

        }

        private void bAddCustomerGroup_Click(object sender, EventArgs e)
        {
            fAddCustomerGroup f = new fAddCustomerGroup(Enums.Operation.Add);
            f.FormClosed += async (s, x) =>
            {
                await CustomerGroupsLoad();
            };
            f.ShowDialog();
        }
    }
}