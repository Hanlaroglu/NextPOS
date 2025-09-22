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
using DevExpress.Data;

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
            real.DataSource = warehouseOperation.Where(x=> x.IsDeleted == 0).ToList();

            gridControlDashboardStock.DataSource = real;
        }
    }
}