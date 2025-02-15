using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
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
    public partial class fAdding : DevExpress.XtraEditors.XtraForm
    {
        ICategoryOperation categoryOperation = new CategoryManager();
        private Enums.Operation Operation { get; }
        private Categories Category { get; set; }
        public fAdding(Enums.Operation _operation, Categories _category)
        {
            InitializeComponent();
            Operation = _operation;
            Category = _category;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {

            }
            else
            {

            }
        }

        void AddCategory()
        {
            Category = new Categories
            {
                CategoryName = tName.Text.Trim(),
                IsDeleted = 0,
                Status = true,
            };

            categoryOperation.Add(Category);
        }

        private void fAdding_Load(object sender, EventArgs e)
        {

        }
    }
}