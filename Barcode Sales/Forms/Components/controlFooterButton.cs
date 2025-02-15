using Barcode_Sales.Helpers;
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

namespace Barcode_Sales.Forms.Components
{
    public partial class controlFooterButton : DevExpress.XtraEditors.XtraUserControl
    {
        private bool cancelvisible = true;
        private string saveButtonText = "Yadda Saxla";
        private Enums.Operation _operation = Enums.Operation.Add;

        public controlFooterButton()
        {
            InitializeComponent();
        }

        [Category("Action Buttons")]
        [Description("Yadda Saxla")]
        public event EventHandler SaveClick;

        [Category("Action Buttons")]
        [Description("Ləğv Et")]
        public event EventHandler CancelClick;

        public event EventHandler ButtonImage;

        public bool CancelVisible
        {
            get { return cancelvisible; }
            set
            {
                bCancel.Visible = value;
            }
        }

        public string SaveButtonText
        {
            get { return saveButtonText; }
            set
            {
                bAdd.Text = value;
            }
        }

        public Enums.Operation SaveButtonImage
        {
            get { return _operation; }
            set
            {
                SaveButtonImageMethod(value);
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            SaveClick?.Invoke(this, e);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(this, e);
        }

        private void SaveButtonImageMethod(Enums.Operation operation)
        {
            switch (operation)
            {
                case Enums.Operation.Add:
                    bAdd.ImageOptions.SvgImage = Properties.Resources.add_svg;
                    bAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
                    break;
                case Enums.Operation.Edit:
                    break;
                case Enums.Operation.Show:
                    break;
                case Enums.Operation.Save:
                    break;
                case Enums.Operation.Delete:
                    break;
                case Enums.Operation.Refresh:
                    break;
                case Enums.Operation.Close:
                    bAdd.ImageOptions.SvgImage = Properties.Resources.close_svg;
                    bAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                    break;
                case Enums.Operation.Block:
                    break;
                case Enums.Operation.Active:
                    break;
                case Enums.Operation.Pay:
                    bAdd.ImageOptions.SvgImage = Properties.Resources.pay_svg;
                    bAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
                    break;
            }
        }

        private void controlFooterButton_Load(object sender, EventArgs e)
        {
            
        }
    }
}