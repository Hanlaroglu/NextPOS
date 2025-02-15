using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Tools;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
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
        private Terminals _terminal { get; set; }

        public fKassalar()
        {
            InitializeComponent();

            FormHelpers.GridCustomRowNumber(gridView1);
        }

        private void fKassalar_Load(object sender, EventArgs e)
        {
            OperatorLoad();
            UsersLoad();
            TerminalsDataLoad();
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
                labelControl3.Visible = true;
                tMerchantId.Visible = true;
                tMerchantId.Text = "";
                groupControl1.Height = 165;
                groupControl2.Location = new Point(0, 171);
                gridControl1.Location = new Point(5, 217);
            }
            else
            {
                labelControl3.Visible = false;
                tMerchantId.Visible = false;
                tMerchantId.Text = "";
                groupControl1.Height = 123;
                groupControl2.Location = new Point(0, 130);
                gridControl1.Location = new Point(5, 176);
            }
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (bSave.Text == Enums.GetEnumDescription(Enums.Operation.Add))
                {
                    Add();
                }
                else if (bSave.Text == Enums.GetEnumDescription(Enums.Operation.Edit))
                {
                    UpdateData();
                }

                await TerminalsDataLoad();
            }
            catch (Exception ex)
            {
                CommonMessageBox.ErrorMessageBox(ex.Message);
            }
        }

        private void Add()
        {
            int? userId = (int?)lookUser.EditValue;

            _terminal = new Terminals()
            {
                Name = lookKassa.Text,
                IpAddress = tIpAdress.Text,
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

            await terminalOperation.UpdateAsync(_terminal);
            bSave.Text = Enums.GetEnumDescription(Enums.Operation.Add);
            Clear();
        }

        private void Clear()
        {
            lookKassa.EditValue = null;
            lookUser.EditValue = null;
            tIpAdress.Text = null;
            tMerchantId.Text = null;
            _terminal = null;
        }

        private async Task TerminalsDataLoad()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                var data = await terminalOperation.WhereAsync();
                //FormHelpers.ControlLoad(data, gridControl1);

                gridControl1.Invoke(new Action(() => FormHelpers.ControlLoad(data, gridControl1)));
            }
            catch (Exception ex)
            {
                CommonMessageBox.ErrorMessageBox(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void bDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                var item = terminalOperation.GetById(Id);
                terminalOperation.Remove(item);
                await TerminalsDataLoad();
            }
        }

        private void bEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id").ToString());
                var item = terminalOperation.GetById(Id);
                _terminal = item;


                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), item.Name);

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
    }
}