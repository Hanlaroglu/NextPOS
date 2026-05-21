using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fSelectCustomer<T> : FormBase where T : FormBase
    {
        private ICustomerOperation customerOperation = new CustomerManager();
        private T _parentForm;
        public fSelectCustomer(T parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private async void CustomerLoad()
        {
            var data = await customerOperation.ToListAsync(x => x.IsDeleted == false && x.Status == true);
            gridControlBasket.DataSource = data;
        }

        private void fSelectCustomer_Shown(object sender, EventArgs e)
        {
            CustomerLoad();
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsView.ShowHeaderPanel = false;
        }

        private void layoutView1_CardClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        {
            var row = layoutView1.GetRow(e.RowHandle) as Customer;

            if (row != null)
            {
                var method = _parentForm.GetType().GetMethod("ReceiveData");
                if (method != null)
                {
                    method.MakeGenericMethod(row.GetType()).Invoke(_parentForm, new object[] { row });
                    this.Close();
                }
            }

            //var customer = layoutView1.GetFocusedRow() as Customer;
            //MessageBox.Show(customer.NameSurname);



           
        }
    }
}