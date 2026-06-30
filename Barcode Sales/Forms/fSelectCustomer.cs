using System;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;

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

        private async void GetCustomers()
        {
            var data = await customerOperation.ToListAsync(x => x.IsDeleted == false && x.Status == true);
            gridControlCustomers.DataSource = data;
        }

        private void fSelectCustomer_Shown(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void tSearchCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tSearchCustomer.Text))
            {
                tileView1.ActiveFilterString = $"Contains([NameSurname], '{tSearchCustomer.Text.Trim()}')";
            }
            else
                tileView1.ActiveFilter.Clear();
        }

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            var row = tileView1.GetRow(e.Item.RowHandle) as Customer;

            if (row != null)
            {
                var method = _parentForm.GetType().GetMethod("ReceiveData");
                if (method != null)
                {
                    method.MakeGenericMethod(row.GetType()).Invoke(_parentForm, new object[] { row });
                    this.Close();
                }
            }
        }

        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            fAddCustomer f = new fAddCustomer(Enums.Operation.Add);
            f.FormClosed += (s, x) =>
            {
                GetCustomers();
            };
            f.ShowDialog();
        }
    }
}