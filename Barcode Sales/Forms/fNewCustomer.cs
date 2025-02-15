using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using NextPOS.UserControls;
using System;

namespace Barcode_Sales.Forms
{
    public partial class fNewCustomer : FormBase
    {
        ICustomerOperation customerOperation = new CustomerManager();
        private Enums.Operation Operation { get; }
        private Customers Customer { get; }

        public fNewCustomer(Enums.Operation _operation, Customers _customer = null)
        {
            InitializeComponent();
            Operation = _operation;
            Customer = _customer;
        }

        void CustomerAdd()
        {
            Customers customer = new Customers
            {
                NameSurname = tNameSurname.Text.Trim(),
                Phone = tPhone.Text,
                Address = tAddress.Text.Trim(),
                Voen = tVoen.Text,
                Comment = tComment.Text.Trim(),
                Debt = 0,
                IsDeleted = 0,
                Status = true
            };

            var validator = new CustomerValidation();
            var validateResult = validator.Validate(customer);
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    Message(error.ErrorMessage, fMessage.enmType.Warning);
                    return;
                }
            }

            customerOperation.Add(customer);
            Clear();
            Message($"{customer.NameSurname} müştərisi yaradıldı", fMessage.enmType.Success);
            //todo customer log əlavə et
        }

        void CustomerEdit()
        {
            Customer.NameSurname = tNameSurname.Text.Trim();
            Customer.Phone = tPhone.Text;
            Customer.Voen = tVoen.Text;
            Customer.Address = tAddress.Text.Trim();
            Customer.Comment = tComment.Text.Trim();

            var validator = new CustomerValidation();
            var validateResult = validator.Validate(Customer);
            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    Message(error.ErrorMessage, fMessage.enmType.Warning);
                    return;
                }
            }

            customerOperation.Update(Customer);
            Close();
        }

        void CustomerLoadData()
        {
            if (Operation is Enums.Operation.Edit)
            {
                tNameSurname.Text = Customer.NameSurname;
                tPhone.Text = Customer.Phone;
                tAddress.Text = Customer.Address;
                tVoen.Text = Customer.Voen;
                tComment.Text = Customer.Comment;
                userSaveFooter1.SaveButtonText = Enums.GetEnumDescription(Operation);
            }
        }

        private void userSaveFooter1_SaveClick(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                CustomerAdd();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                CustomerEdit();
            }
        }

        private void userSaveFooter1_CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        void Clear()
        {
            tNameSurname.Text = null;
            tPhone.Text = null;
            tAddress.Text = null;
            tVoen.Text = null;
            tComment.Text = null;
            tNameSurname.Focus();
        }

        private void fNewCustomer_Load(object sender, EventArgs e)
        {
            CustomerLoadData();
        }
    }
}