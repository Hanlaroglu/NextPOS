using Barcode_Sales.Helpers;
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
    public partial class fNisyeSales : FormBase
    {
        public fNisyeSales()
        {
            InitializeComponent();
            userSaveFooter1.SaveButtonText = "Satış et";
            userSaveFooter1.CancelVisible = false;
        }

        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            fNewCustomer newCustomer = new fNewCustomer(Enums.Operation.Add, null);
            newCustomer.ShowDialog();
        }

        private void userSaveFooter1_CancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void userSaveFooter1_SaveClick(object sender, EventArgs e)
        {

        }

        private void bCustomerSearch_Click(object sender, EventArgs e)
        {
            fSearchData searchData = new fSearchData();
            if (searchData.ShowDialog() is DialogResult.OK)
            {
                tNameSurname.Text = searchData._customer.NameSurname;
                lDebt.Text = $"BORC : {searchData._customer.Debt.Value.ToString("C2")}";
            }
        }
    }
}