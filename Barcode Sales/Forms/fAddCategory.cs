using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fAddCategory : DevExpress.XtraEditors.XtraForm
    {
        private ICategoryOperation categoryOperation = new CategoryManager();
        private Categories _category;
        private Enums.Operation _operation;
        public fAddCategory(Enums.Operation operation, Categories category)
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

        private void Add()
        {
            _category = new Categories()
            {
                CategoryName = tName.Text.TrimStart().Trim(),
                Status = chStatus.Checked,
                IsDeleted = 0
            };

            if (!CheckName(_category.CategoryName))
            {
                bool IsSuccess = categoryOperation.Add(_category);
                if (IsSuccess)
                {
                    NoticationHelpers.Messages.SuccessMessage(this, $"{_category.CategoryName} kateqoriyası yaradıldı");
                    Clear();
                }
            }
        }

        private void Edit()
        {
            _category.CategoryName = tName.Text.TrimStart().Trim();
            _category.Status = chStatus.Checked;

            if (!CheckName(_category.CategoryName))
            {
                categoryOperation.Update(_category);
                Clear();
            }
        }

        private bool CheckName(string name)
        {
            bool check = categoryOperation.Where(x => x.CategoryName == name && x.IsDeleted == 0).Any();
            if (check)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Kateqoriya adı sistemdə mövcuddur.");
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
    }
}