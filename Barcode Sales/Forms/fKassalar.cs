using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Tools;
using Barcode_Sales.Validations;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fKassalar : FormBase
    {
        IUserOperation userOperation = new UserManager();
        ITerminalOperation terminalOperation = new TerminalManager();
        private Terminal _terminal { get; set; }

        public fKassalar()
        {
            InitializeComponent();

            //FormHelpers.GridCustomRowNumber(gridView1);
        }

        private async void fKassalar_Load(object sender, EventArgs e)
        {
            OperatorLoad();
            UsersLoad();
            await TerminalsDataLoad();
        }

        private void UsersLoad()
        {
            var data = userOperation.Where(x => true)
                                    .Select(x => new
                                    {
                                        x.NameSurname,
                                        x.Id
                                    })
                                    .ToList();

            FormHelpers.ControlLoad(data, lookUser, "NameSurname");
        }

        private void OperatorLoad()
        {
            var kassa = Enum.GetValues(typeof(Enums.KassaOperator))
                            .Cast<Enums.KassaOperator>()
                            .ToDictionary(e => e, e => Enums.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(kassa, null), lookKassa, "Value", "Key");
        }

        private void lookKassa_TextChanged(object sender, EventArgs e)
        {
            if (lookKassa.Text == "AZSMART")
            {
                tMerchantId.Visible = true;
                tMerchantId.Text = "";
            }
            else
            {
                tMerchantId.Visible = false;
                tMerchantId.Text = "";
            }
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                //else if (bSave.Text == Enums.GetEnumDescription(Enums.Operation.Edit))
                //    UpdateData();

                await TerminalsDataLoad();
            }
            catch (Exception ex)
            {
                NotificationHelpers.Messages.ErrorMessage(this, ex.Message);
            }
        }

        private void Add()
        {



            int? userId = (int?)lookUser.EditValue;

            var ipAdress = $"{tIpAdress.Text.TrimStart().Trim()}:{tPort.Text.TrimStart().Trim()}";

            _terminal = new Terminal()
            {
                Name = lookKassa.Text,
                IpAddress = ipAdress,
                MerchantId = tMerchantId.Text,
                Status = true,
                IsDeleted = 0,
                UserId = userId
            };

            var validator = ValidationHelpers.ValidateMessage(_terminal, new TerminalValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tPort.Text))
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Port nömrəsi daxil edilmədi");
                return;
            }

            terminalOperation.Add(_terminal);
            Clear();
        }

        private async void UpdateData()
        {
            int? userId = (int?)lookUser.EditValue;

            _terminal.Name = lookKassa.Text;
            _terminal.UserId = userId;
            _terminal.MerchantId = tMerchantId.Text;
            _terminal.IpAddress = tIpAdress.Text;

            var validator = ValidationHelpers.ValidateMessage(_terminal, new TerminalValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            await terminalOperation.Update(_terminal,
                x => x.Name,
                x => x.UserId,
                x => x.MerchantId,
                x => x.IpAddress);
            bSave.Text = Enums.GetEnumDescription(Enums.Operation.Add);
            Clear();
        }

        private void Clear()
        {
            lookKassa.EditValue = null;
            lookUser.EditValue = null;
            tIpAdress.Clear();
            tPort.Clear();
            tMerchantId.Clear();
            _terminal = null;
        }

        private async Task TerminalsDataLoad()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                var data = await terminalOperation.ToListAsync();

                gridControl1.Invoke(new Action(() => FormHelpers.ControlLoad(data, gridControl1)));
            }
            catch (Exception ex)
            {
                NotificationHelpers.Messages.ErrorMessage(this, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void bEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                var terminal = await terminalOperation.Get(x => x.Id == Id);
                _terminal = terminal;


                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), terminal.Name);

                lookKassa.EditValue = kassa;
                lookUser.EditValue = _terminal.UserId;
                tIpAdress.Text = _terminal.IpAddress;
                tMerchantId.Text = _terminal.MerchantId;
                bSave.Text = Enums.GetEnumDescription(Enums.Operation.Edit);
            }
        }

        private void bCheckConnection_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                string data = gridView1.GetFocusedRowCellValue("IpAddress").ToString();

                if (string.IsNullOrWhiteSpace(data))
                    return;

                string IpAddress = data.Split(':')[0];

                FormHelpers.PingHostAsync(IpAddress);
            }

        }

        private async void bRefresh_Click(object sender, EventArgs e)
        {
            await TerminalsDataLoad();
        }

        private async void bPopupDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await Delete();
        }

        private async Task Delete()
        {
            if (gridView1.GetFocusedRow() == null)
                NotificationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
            else
            {
                int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                var terminal = await terminalOperation.Get(x => x.Id == Id);
                terminal.IsDeleted = terminal.Id;

                await terminalOperation.Update(terminal, x => x.IsDeleted);
                await TerminalsDataLoad();
            }
        }

        private void bDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            popupMainMenu.ShowPopup(mousePosition);
        }

        private void bPopupPing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                NotificationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
            }
            else
            {
                string data = gridView1.GetFocusedRowCellValue("IpAddress").ToString();

                if (string.IsNullOrWhiteSpace(data))
                    return;

                string IpAddress = data.Split(':')[0];

                bool result = FormHelpers.PingHostAsync(IpAddress);
                if (result)
                    NotificationHelpers.Messages.SuccessMessage(this, $"{IpAddress} adresi ilə əlaqə mövcuddur");
                else
                    NotificationHelpers.Messages.ErrorMessage(this, $"{IpAddress} adresi ilə əlaqə yoxdur");
            }
        }
    }
}