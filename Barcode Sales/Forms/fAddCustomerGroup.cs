using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Barcode_Sales.Forms
{
    public partial class fAddCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        private ICustomerGroupOperation customerGroupOperation = new CustomerGroupManager();
        private CustomerGroup _customerGroup;
        private Enums.Operation _operation;
        public fAddCustomerGroup(Enums.Operation operation, CustomerGroup customerGroup = null)
        {
            InitializeComponent();
            _operation = operation;
            _customerGroup = customerGroup;
        }

        private void fAddCustomerGroup_Load(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Edit)
                CustomerGroupDataLoad();
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.Operation.Add: Add(); break;
                case Enums.Operation.Edit: await Edit(); break;
            }
        }

        private async void Add()
        {
            _customerGroup = new CustomerGroup()
            {
                Name = tName.Text.Trim(),
                Discount = Convert.ToDouble(tDiscount.Text),
                UserId = CommonData.CURRENT_USER.Id,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            var validator = ValidationHelpers.ValidateMessage(_customerGroup, new CustomerGroupValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            if (!CheckName(_customerGroup))
            {
                if (await customerGroupOperation.Add(_customerGroup) > 0)
                {
                    NotificationHelpers.Messages.SuccessMessage(this, $"{_customerGroup.Name} qrup adı yaradıldı");
                    Clear();
                }
                else
                    NotificationHelpers.Messages.ErrorMessage(this, "Qrup adı yaradılarkən xəta yarandı");
            }
        }

        private async Task Edit()
        {
            _customerGroup.Name = tName.Text.Trim();
            _customerGroup.Discount = Convert.ToDouble(tDiscount.Text);

            var validator = ValidationHelpers.ValidateMessage(_customerGroup, new CustomerGroupValidation(), this);

            if (!validator.IsValid)
                return;

            if (!CheckName(_customerGroup))
            {
                await customerGroupOperation.Update(_customerGroup, x=> x.Name, x => x.Discount);
                Close();
            }
        }

        private bool CheckName(CustomerGroup data)
        {
            bool check = customerGroupOperation
                .Where(x =>
                    x.Name == data.Name &&
                    x.IsDeleted == false)
                .Any();

            if (check)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Qrup adı sistemdə mövcuddur.");
                return true;
            }
            return false;
        }

        private void CustomerGroupDataLoad()
        {
            tName.Text = _customerGroup.Name;
            tDiscount.Text = _customerGroup.Discount.ToString("N2");
        }

        private void Clear()
        {
            tName.Clear();
            tDiscount.Clear();
            tName.Focus();
        }
    }
}