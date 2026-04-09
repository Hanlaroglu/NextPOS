using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fStoreAdd : DevExpress.XtraEditors.XtraForm
    {
        IStoreOperation storeOperation = new StoreManager();
        IWarehouseOperation warehouseOperation = new WarehouseManager();

        private Store _store;
        private Enums.Operation _operation;

        public fStoreAdd(Enums.Operation operation, Store store)
        {
            InitializeComponent();
            _store = store;
            _operation = operation;
        }

        private void fStoreAdd_Shown(object sender, EventArgs e)
        {
            WarehouseDataList();
            if (_operation is Enums.Operation.Edit)
                StoreDataList();
        }

        private void StoreDataList()
        {
            tName.Text = _store.Name;
            lookWarehouse.EditValue = _store.WarehouseId;
            chStatus.Checked = _store.Status;
        }

        private async void WarehouseDataList()
        {
            var data = await warehouseOperation.ToListAsync(x => x.IsDeleted == 0
                                                                 && (bool)x.Status == true);
            FormHelpers.ControlLoad(data, lookWarehouse);
        }

        private void Clear()
        {
            tName.Clear();
            lookWarehouse.EditValue = null;
            chStatus.Checked = true;
            tName.Focus();
        }

        private async void Add()
        {
            _store = new Store
            {
                Name = tName.Text.Trim(),
                WarehouseId = (int?)lookWarehouse.EditValue ?? 0,
                Status = chStatus.Checked,
                IsDeleted = false
            };

            var validator = ValidationHelpers.ValidateMessage(_store, new StoreValidation(), this);

            if (!validator.IsValid)
                return;

            var exists = await storeOperation.Get(x => x.Name == _store.Name);
            if (exists != null)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Flial adı sistemdə mövcuddur");
                return;
            }

            if (await storeOperation.Add(_store) > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this, "Flial uğurla yaradıldı");
                Clear();
            }
            else
                NotificationHelpers.Messages.ErrorMessage(this, "Flial yaradılarkən xəta yarandı");
        }

        private async void Edit()
        {
            _store.Name = tName.Text.Trim();
            _store.WarehouseId = (int?)lookWarehouse.EditValue ?? 0;
            _store.Status = chStatus.Checked;

            var validator = ValidationHelpers.ValidateMessage(_store, new StoreValidation(), this);

            if (!validator.IsValid)
                return;

            var exists = await storeOperation.Get(x => x.Name == _store.Name);
            if (exists != null)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Flial adı sistemdə mövcuddur");
                return;
            }

            var result = await storeOperation.Update(_store,
                x => x.Name,
                x=> x.WarehouseId,
                x => x.Status);

            if (result)
                Close();
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

        private void tName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                bSave.PerformClick();
        }
    }
}