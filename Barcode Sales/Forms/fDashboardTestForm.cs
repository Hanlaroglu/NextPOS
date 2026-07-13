using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.Data;
using System;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fDashboardTestForm : DevExpress.XtraEditors.XtraForm
    {
        private IWarehouseOperation warehouseOperation = new WarehouseManager();
        public fDashboardTestForm()
        {
            InitializeComponent();
        }

        private void fDashboardTestForm_Load(object sender, EventArgs e)
        {
            RealTimeSource real = new RealTimeSource();
            real.DataSource = warehouseOperation.Where(x=> x.IsDeleted == false).ToList();

            gridControlDashboardStock.DataSource = real;
        }
    }
}