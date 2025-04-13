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
    public partial class fPosRollback : DevExpress.XtraEditors.XtraForm
    {
        ISaleDataOperation saleDataOperation = new SalesDataManager();
        public fPosRollback()
        {
            InitializeComponent();
            dateStart.DateTime = DateTime.Now;
            dateFinish.DateTime = DateTime.Now;
        }

        private enum CheckedType
        {
            Date,
            ReceiptNo,
            FiscalID
        }

        private void SelectedType(object sender, EventArgs e)
        {
            var type = (CheckEdit)sender;
            if (type.Checked)
            {
                switch (type.Tag)
                {
                    case nameof(CheckedType.Date):
                        navigationFrame1.SelectedPage = pageDate;
                        dateStart.DateTime = DateTime.Now;
                        dateFinish.DateTime = DateTime.Now;
                        break;
                    case nameof(CheckedType.ReceiptNo):
                        navigationFrame1.SelectedPage = pageReceiptNo;
                        tReceiptNo.Focus();
                        break;
                    case nameof(CheckedType.FiscalID):
                        navigationFrame1.SelectedPage = pageFıscal;
                        tFiscalId.Focus();
                        break;
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            object data = null;
            switch (navigationFrame1.SelectedPage)
            {
                case var page when page == pageDate:
                   data = saleDataOperation.Where(x=> x.SaleDate > dateStart.DateTime && x.SaleDate <= dateFinish.DateTime).ToList();
                    break;
                case var page when page == pageReceiptNo:
                    data = saleDataOperation.Where(x => x.ReceiptNo == tReceiptNo.Text.Trim()).ToList();
                    break;
                case var page when page == pageFıscal:
                    data = saleDataOperation.Where(x => x.ShortFiscalId == tFiscalId.Text.Trim()).ToList();
                    break;
            }
            gridControlSalesData.DataSource = data;
        }

        private void tReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                bSearch_Click(null, null);
        }

        private void tFiscalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void bReturnSale_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
    }
}