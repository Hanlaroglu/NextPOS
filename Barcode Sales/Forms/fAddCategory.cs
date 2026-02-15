using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddCategory : DevExpress.XtraEditors.XtraForm
    {
        private ICategoryOperation categoryOperation = new CategoryManager();
        private Category _category;
        private Enums.Operation _operation;
        public fAddCategory(Enums.Operation operation, Category category)
        {
            InitializeComponent();
            _operation = operation;
            _category = category;
        }

        private void fAddCategory_Load(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Edit)
            {
                tName.Text = _category.CategoryName;
                chStatus.Checked = (bool)_category.Status;
                tName.Focus();
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                Add();
            else
                Edit();
        }

        private async void Add()
        {
            _category = new Category()
            {
                CategoryName = tName.Text.TrimStart().Trim(),
                Status = chStatus.Checked,
                IsDeleted = 0
            };

            if (!CheckName(_category.CategoryName))
                if (await categoryOperation.Add(_category) > 0)
                {
                    NotificationHelpers.Messages.SuccessMessage(this, $"{_category.CategoryName} kateqoriyası yaradıldı");
                    Clear();
                }
        }

        private async void Edit()
        {
            _category.CategoryName = tName.Text.TrimStart().Trim();
            _category.Status = chStatus.Checked;

            if (!CheckName(_category.CategoryName) && await categoryOperation.Update(_category, x => x.CategoryName, x => x.Status))
                Close();
        }

        private bool CheckName(string name)
        {
            bool check = categoryOperation
                .Where(x =>
                    x.CategoryName == name &&
                    x.Status == chStatus.Checked &&
                    x.IsDeleted == 0)
                .Any();

            if (check)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Kateqoriya adı sistemdə mövcuddur.");
                return true;
            }
            return false;
        }

        private void Clear()
        {
            tName.Clear();
            chStatus.Checked = true;
            tName.Focus();
        }

        private void tName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                bSave_Click(sender, null);
        }
    }
}