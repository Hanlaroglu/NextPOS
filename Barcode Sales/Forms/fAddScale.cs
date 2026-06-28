using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Validations;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddScale : DevExpress.XtraEditors.XtraForm
    {
        IScaleOperation scaleOperation = new ScaleManager();

        private Enums.Operation _operation { get; set; }
        private Scale _scale { get; set; }
        public fAddScale(Enums.Operation operation, Scale scale)
        {
            InitializeComponent();
            _operation = operation;
            _scale = scale;
        }

        private void fAddScale_Shown(object sender, EventArgs e)
        {
            GetScales();
            GetScale();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                Add();
            else
                Edit();
        }

        private void GetScales()
        {
            var data = Enum.GetValues(typeof(Enums.Scale))
                .Cast<Enums.Scale>()
                .ToDictionary(e => e, e => EnumExtensions.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(data, null), lookScales, "Value", "Key");
        }

        private void GetScale()
        {
            if (_scale != null)
            {
                lookScales.SelectedText = _scale.ModelName;
                tIpAddress.Text = _scale.IpAddress;
                tFilePath.Text = _scale.FilePath;
            }
        }

        private async void Add()
        {
            _scale = new Scale
            {
                StoreId = UserCacheService.User.StoreId,
                ModelName = lookScales.Text,
                IpAddress = tIpAddress.Text.Trim(),
                FilePath = tFilePath.Text.Trim(),
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DatetimeService.CurrentDateTime,
                CreatedUserId = UserCacheService.User.Id
            };

            var validator = ValidationHelpers.ValidateMessage(_scale, new ScaleValidation(), this);

            if (!validator.IsValid)
                return;

            var result = await scaleOperation.Add(_scale);
            if (result > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this,"Tərəzi uğurla əlavə edildi");
                Clear();
            }
        }

        private async void Edit()
        {
            _scale.ModelName = lookScales.Text;
            _scale.IpAddress = tIpAddress.Text;
            _scale.FilePath = tFilePath.Text;

            var validator = ValidationHelpers.ValidateMessage(_scale, new ScaleValidation(), this);

            if (!validator.IsValid)
                return;

            var result = await scaleOperation.Update(_scale,
                x=> x.ModelName,
                x=> x.IpAddress,
                x=> x.FilePath);
            if (result)
            {
                NotificationHelpers.Messages.SuccessMessage(this, "Uğurla düzəliş edildi");
                Close();
            }
        }

        private void Clear()
        {
            lookScales.EditValue = null;
            tIpAddress.Clear();
            tFilePath.Clear();
        }
    }
}