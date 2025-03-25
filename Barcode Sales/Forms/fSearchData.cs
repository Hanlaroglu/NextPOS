using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fSearchData : DevExpress.XtraEditors.XtraForm
    {
        public Customers _customer { get; set; }
        ICustomerOperation customerOperation = new CustomerManager();
        NextposDBEntities db = new NextposDBEntities();
        public fSearchData()
        {
            InitializeComponent();
            CustomerLoadData();
        }

        void CustomerLoadData()
        {
            List<Customers> customersList = customerOperation.WhereAsync(x => x.IsDeleted == 0).Result;
            FormHelpers.ControlLoad(customersList, gridControlSelected);
        }


        private void gridSelected_DoubleClick(object sender, EventArgs e)
        {
            if (gridSelected.GetFocusedRow() is null) { CommonMessageBox.InformationMessageBox(CommonMessages.NOT_SELECTİON); return; }

            int id = Convert.ToInt32(gridSelected.GetFocusedRowCellValue("Id").ToString());
            Customers customer = db.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _customer = customer;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void bDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridSelected.GetFocusedRow() is null) { CommonMessageBox.InformationMessageBox(CommonMessages.NOT_SELECTİON); return; }

            int id = Convert.ToInt32(gridSelected.GetFocusedRowCellValue("Id").ToString());
            Customers customer = db.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            //_customer = customer;
        }

        private void bHesabatSearch_Click(object sender, EventArgs e)
        {

        }
    }
}