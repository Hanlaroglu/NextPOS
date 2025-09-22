using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using DevExpress.XtraEditors;

namespace Barcode_Sales.Forms
{
    public partial class fWarehouse : XtraForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        private Warehouses _warehouses;
        private Enums.Operation _operation;
        public fWarehouse(Enums.Operation operation, Warehouses warehouses)
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
            chStatus.IsOn = _warehouses.Status ?? true;
        }

        private void Clear()
        {
            tName.Clear();
            chStatus.IsOn = true;
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

        private void Add()
        {
            _warehouses = new Warehouses
            {
                Name = tName.Text.Trim(),
                Status = chStatus.IsOn,
                IsDeleted = 0
            };

            var validator = ValidationHelpers.ValidateMessage(_warehouses, new WarehouseValidation(), this);

            if (!validator.IsValid)
                return;

            if (warehouseOperation.Add(_warehouses))
            {
                NoticationHelpers.Messages.SuccessMessage(this, "Anbar uğurla yaradıldı");
                Clear();
            }
            else
                NoticationHelpers.Messages.ErrorMessage(this, "Anbar yaradılarkən xəta yarandı");
        }

        private void Edit()
        {
            _warehouses.Name = tName.Text.Trim();
            _warehouses.Status = chStatus.IsOn;

            var validator = ValidationHelpers.ValidateMessage(_warehouses, new WarehouseValidation(), this);

            if (!validator.IsValid)
                return;

            warehouseOperation.Update(_warehouses);
            Close();
        }

    }
}