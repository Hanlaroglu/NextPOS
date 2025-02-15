using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;

namespace Barcode_Sales.Forms
{
    public partial class fSupplierPaidData : DevExpress.XtraEditors.XtraForm
    {
        ISupplierPaymentOperation supplierPaymentOperation = new SupplierPaymentManager();
        public fSupplierPaidData()
        {
            InitializeComponent();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            PeriodicDataLoad(dateStart.DateTime,dateFinish.DateTime);
        }

        private void fSupplierPaidData_Load(object sender, EventArgs e)
        {
            dateStart.DateTime = DateTime.Now;
            dateFinish.DateTime = DateTime.Now;
            DataLoad();
        }

        private async void DataLoad()
        {
            var data = await supplierPaymentOperation.WhereAsync(x => x.IsDeleted == 0);

            FormHelpers.ControlLoad(data, gridControlSupplierDebt);
            gridSupplierDebt.GroupPanelText = $"Ödənişlərin sayı: {gridSupplierDebt.RowCount}";
            gridSupplierDebt.RefreshData();
            FormHelpers.GridCustomRowNumber(gridSupplierDebt);
        }

        private async void PeriodicDataLoad(DateTime start, DateTime finish)
        {
            var data = await supplierPaymentOperation.WhereAsync(x=> x.PayDate > start && x.PayDate <= finish);

            FormHelpers.ControlLoad(data, gridControlSupplierDebt);
            gridSupplierDebt.GroupPanelText = $"Ödənişlərin sayı: {gridSupplierDebt.RowCount}";
            gridSupplierDebt.RefreshData();
            FormHelpers.GridCustomRowNumber(gridSupplierDebt);
        }
    }
}