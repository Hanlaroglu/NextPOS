using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fSupplier : FormBase
    {
        ISupplierOperation supplierOperation = new SupplierManager();
        private Enums.Operation Operation { get; }
        private Suppliers Supplier { get; set; }

        public fSupplier(Enums.Operation _operation, Suppliers _suppliers = null)
        {
            InitializeComponent();
            Operation = _operation;
            Supplier = _suppliers;
        }

        private void fSupplier_Load(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Edit)
            {
                tName.ReadOnly = true;
                tDebt.ReadOnly = true;
                userSaveFooter1.SaveButtonText = Enums.GetEnumDescription(Operation);
                SupplierDataLoad();
            }
            else if (Operation is Enums.Operation.Show)
            {
                userSaveFooter1.SaveButtonText = Enums.GetEnumDescription(Enums.Operation.Close);
                userSaveFooter1.CancelVisible = false;
                bDelete.Visible = true;
                tName.ReadOnly = true;
                tVoen.ReadOnly = true;
                tAddress.ReadOnly = true;
                tDebt.ReadOnly= true;
                tEmail.ReadOnly = true;
                tPhone.ReadOnly = true;
                tBankAccountNumber.ReadOnly = true;
                tBankKod.ReadOnly = true;
                tBankName.ReadOnly = true;
                tBankSwift.ReadOnly = true;
                tBankVoen.ReadOnly = true;
                SupplierDataLoad();
            }
        }

        private void userSaveFooter1_SaveClick(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                AddSupplier();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                EditSupplier();
            }
            else if (Operation is Enums.Operation.Show)
            {
                Close();
            }
        }

        void AddSupplier()
        {
            Supplier = new Suppliers
            {
                SupplierName = tName.Text,
                Voen = tVoen.Text,
                Phone = tPhone.Text,
                Email = tEmail.Text,
                Address = tAddress.Text,
                Debt = Convert.ToDouble(tDebt.Text),
                BankName = tBankName.Text,
                BankAccountNumber = tBankAccountNumber.Text,
                BankKOD  = tBankKod.Text,
                BankVoen = tBankVoen.Text,
                BankSwift = tBankSwift.Text,
                Status = true,
                IsDeleted = 0
            };
            
            var validateResult = ValidationHelpers.ValidateMessage(Supplier, new SupplierValidation(), this);
            if (!validateResult.IsValid){
                return;
            }

            bool valueUnique = ValidationHelpers.Any<Suppliers>(x => x.SupplierName.ToLower() == Supplier.SupplierName.ToLower());
            if (valueUnique){
                NotificationHelpers.Messages.WarningMessage(this, $"{Supplier.SupplierName} təchizatçısı sistemdə mövcuddur");
                return;
            }

            supplierOperation.Add(Supplier);
            NotificationHelpers.Messages.SuccessMessage(this, $"{Supplier.SupplierName} təchizatçısı uğurla yaradıldı");
            Clear();
        }

        void EditSupplier()
        {
            Supplier.SupplierName = tName.Text;
            Supplier.Voen = tVoen.Text;
            Supplier.Phone = tPhone.Text;
            Supplier.Address = tAddress.Text;
            Supplier.Email = tEmail.Text;
            Supplier.BankVoen = tBankVoen.Text;
            Supplier.BankKOD = tBankKod.Text;
            Supplier.BankSwift = tBankSwift.Text;
            Supplier.BankAccountNumber = tBankAccountNumber.Text;
            Supplier.BankName = tBankName.Text;

            var validateResult = ValidationHelpers.ValidateMessage(Supplier, new SupplierValidation(), this);
            if (!validateResult.IsValid)
            {
                return;
            }

            supplierOperation.Update(Supplier);
            DialogResult = DialogResult.OK;
        }

        void SupplierDataLoad()
        {
            tName.Text = Supplier.SupplierName;
            tVoen.Text = Supplier.Voen;
            tPhone.Text = Supplier.Phone;
            tDebt.Text = Supplier.Debt.ToString();
            tAddress.Text = Supplier.Address;
            tEmail.Text = Supplier.Email;
            tBankName.Text = Supplier.BankName;
            tBankKod.Text = Supplier.BankKOD;
            tBankAccountNumber.Text  = Supplier.BankAccountNumber;
            tBankVoen.Text = Supplier.BankVoen;
            tBankSwift.Text = Supplier.BankSwift;
        }

        void Clear()
        {
            tName.Text = null;
            tVoen.Text = null;
            tAddress.Text = null;
            tDebt.EditValue = 0;
            tPhone.Text = null;
            tEmail.Text = null;
            tBankName.Text = null;
            tBankVoen.Text = null;
            tBankAccountNumber.Text = null;
            tBankKod.Text = null;
            tBankSwift.Text = null;
        }

        private void userSaveFooter1_CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            var data = supplierOperation.GetById(Supplier.Id);
            supplierOperation.Remove(data);
            NotificationHelpers.Messages.SuccessMessage(this,$"{data.SupplierName} təchizatçısı uğurla silindi");
            Close();
        }
    }
}