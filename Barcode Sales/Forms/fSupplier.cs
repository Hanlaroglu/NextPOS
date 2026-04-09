using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fSupplier : XtraForm
    {
        ISupplierOperation supplierOperation = new SupplierManager();
        IProductOperation productOperation = new ProductManager();
        private Enums.Operation _operation { get; }
        private Supplier _supplier { get; set; }

        public fSupplier(Enums.Operation operation, Supplier supplier = null)
        {
            InitializeComponent();
            _operation = operation;
            _supplier = supplier;
        }

        private void fSupplier_Load(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Edit)
            {
                tName.ReadOnly = true;
                tStock.ReadOnly = true;
                SupplierDataLoad();
                bDelete.Visible = true;
            }
            else if (_operation is Enums.Operation.Show)
            {
                bDelete.Visible = true;
                tName.ReadOnly = true;
                tVoen.ReadOnly = true;
                tAddress.ReadOnly = true;
                tStock.ReadOnly = true;
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

        private async void AddSupplier()
        {
            _supplier = new Supplier
            {
                SupplierName = tName.Text.TrimStart().Trim(),
                Voen = tVoen.Text.TrimStart().Trim(),
                Phone = tPhone.Text.TrimStart().Trim(),
                Email = tEmail.Text.TrimStart().Trim(),
                Address = tAddress.Text.TrimStart().Trim(),
                Debt = Convert.ToDecimal(tStock.EditValue),
                BankName = tBankName.Text.TrimStart().Trim(),
                BankAccountNumber = tBankAccountNumber.Text.TrimStart().Trim(),
                BankKOD = tBankKod.Text.TrimStart().Trim(),
                BankVoen = tBankVoen.Text.TrimStart().Trim(),
                BankSwift = tBankSwift.Text.TrimStart().Trim(),
                Status = true,
                IsDeleted = false
            };

            var validateResult = ValidationHelpers.ValidateMessage(_supplier, new SupplierValidation(), this);
            if (!validateResult.IsValid)
            {
                return;
            }

            var valueUnique = await supplierOperation.Get(x => x.SupplierName.ToLower() == _supplier.SupplierName.ToLower());
            if (valueUnique != null)
            {
                NotificationHelpers.Messages.WarningMessage(this, $"{_supplier.SupplierName} təchizatçısı sistemdə mövcuddur");
                return;
            }

            if (await supplierOperation.Add(_supplier) > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this, $"{_supplier.SupplierName} təchizatçısı uğurla yaradıldı");
                Clear();
            }
        }

        private async void EditSupplier()
        {
            _supplier.SupplierName = tName.Text.TrimStart().Trim();
            _supplier.Voen = tVoen.Text.TrimStart().Trim();
            _supplier.Address = tAddress.Text.TrimStart().Trim();
            _supplier.Email = tEmail.Text.TrimStart().Trim();
            _supplier.Phone = tPhone.Text.TrimStart().Trim();
            _supplier.BankName = tBankName.Text.TrimStart().Trim();
            _supplier.BankAccountNumber = tBankAccountNumber.Text.TrimStart().Trim();
            _supplier.BankKOD = tBankKod.Text.TrimStart().Trim();
            _supplier.BankVoen = tBankVoen.Text.TrimStart().Trim();
            _supplier.BankSwift = tBankSwift.Text.TrimStart().Trim();

            var validateResult = ValidationHelpers.ValidateMessage(_supplier, new SupplierValidation(), this);
            if (!validateResult.IsValid)
                return;


            var result = await supplierOperation.Update(_supplier,
                x => x.SupplierName,
                x => x.Voen,
                x => x.Address,
                x => x.Email,
                x => x.Phone,
                x => x.BankName,
                x => x.BankVoen,
                x => x.BankAccountNumber,
                x => x.BankKOD,
                x => x.BankSwift);

            if (result)
            {
                NotificationHelpers.Messages.SuccessMessage(this, "Uğurla düzəliş edildi");
                this.Dispose();
            }
        }

        private void SupplierDataLoad()
        {
            tName.Text = _supplier.SupplierName;
            tVoen.Text = _supplier.Voen;
            tPhone.Text = _supplier.Phone;
            tStock.EditValue = _supplier.Debt;
            tAddress.Text = _supplier.Address;
            tEmail.Text = _supplier.Email;
            tBankName.Text = _supplier.BankName;
            tBankKod.Text = _supplier.BankKOD;
            tBankAccountNumber.Text = _supplier.BankAccountNumber;
            tBankVoen.Text = _supplier.BankVoen;
            tBankSwift.Text = _supplier.BankSwift;
        }

        private void Clear()
        {
            tName.Text = null;
            tVoen.Text = null;
            tAddress.Text = null;
            tStock.EditValue = 0;
            tPhone.Text = null;
            tEmail.Text = null;
            tBankName.Text = null;
            tBankVoen.Text = null;
            tBankAccountNumber.Text = null;
            tBankKod.Text = null;
            tBankSwift.Text = null;
        }

        private async void bDelete_Click(object sender, EventArgs e)
        {
            var args = NotificationHelpers.Dialogs.DialogResultYesNo($"{_supplier.SupplierName} təchizatçısını silmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);

            if (result is DialogResult.Yes)
                if (await supplierOperation.Remove(_supplier))
                {
                    NotificationHelpers.Messages.SuccessMessage(this, $"{_supplier.SupplierName} təchizatçısı uğurla silindi");
                    this.Dispose();
                }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                AddSupplier();
            else
                EditSupplier();
        }
    }
}