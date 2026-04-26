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
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;

namespace Barcode_Sales.Forms
{
    public partial class fSelectCustomer : DevExpress.XtraEditors.XtraForm
    {
        private ICustomerOperation customerOperation = new CustomerManager();

        public fSelectCustomer()
        {
            InitializeComponent();
        }

        private async void CustomerLoad()
        {
            var data = await customerOperation.ToListAsync(x => x.IsDeleted == false && x.Status == true);
            gridControlBasket.DataSource = data;
        }

        private void fSelectCustomer_Shown(object sender, EventArgs e)
        {
            CustomerLoad();
        }
    }
}