using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fWarehouse : XtraForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        private Warehouse _warehouses;
        private Enums.Operation _operation;
        public fWarehouse(Enums.Operation operation, Warehouse warehouses)
        {
            InitializeComponent();
            _warehouses = warehouses;
            _operation = operation;
        }

        private void fWarehouse_Load(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Edit)
                WarehouseDataList();
        }

        private void WarehouseDataList()
        {
            tName.Text = _warehouses.Name;
            chStatus.Checked = _warehouses.Status ?? true;
        }

        private void Clear()
        {
            tName.Clear();
            chStatus.Checked = true;
            tName.Focus();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.Operation.Add:
                    Add();
                    break;
                case Enums.Operation.Edit:
                    Edit();
                    break;
            }
        }

        private async void Add()
        {
            _warehouses = new Warehouse
            {
                Name = tName.Text.Trim(),
                Status = chStatus.Checked,
                IsDeleted = 0
            };

            var validator = ValidationHelpers.ValidateMessage(_warehouses, new WarehouseValidation(), this);

            if (!validator.IsValid)
                return;

            if (await warehouseOperation.Add(_warehouses) > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this, "Anbar uğurla yaradıldı");
                Clear();
            }
            else
                NotificationHelpers.Messages.ErrorMessage(this, "Anbar yaradılarkən xəta yarandı");
        }

        private async void Edit()
        {
            _warehouses.Name = tName.Text.Trim();
            _warehouses.Status = chStatus.Checked;

            var validator = ValidationHelpers.ValidateMessage(_warehouses, new WarehouseValidation(), this);

            if (!validator.IsValid)
                return;

            var result = await warehouseOperation.Update(_warehouses,
                   x => x.Name,
                   x => x.Status);

            if (result)
                Close();
        }

        private void tName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                bSave.PerformClick();
        }
    }
}