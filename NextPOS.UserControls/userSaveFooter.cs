using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextPOS.UserControls
{
    //Butunların imagelərini dinamik olaraq təyin et
    public partial class userSaveFooter : DevExpress.XtraEditors.XtraUserControl
    {
        private bool cancelvisible = true;
        private string saveButtonText = "Yadda Saxla";
        SvgImage saveButtonImage;
        //private SvgImage saveButtonImage = svgCollectionImage1.GetImage(1);

        [Category("Action Buttons")]
        [Description("Yadda Saxla")]
        public event EventHandler SaveClick;

        [Category("Action Buttons")]
        [Description("Ləğv Et")]
        public event EventHandler CancelClick;

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

        public SvgImage SaveButtonImage
        {
            get { return saveButtonImage; }
            set
            {
                bAdd.ImageOptions.SvgImage = value;
            }
        }

        public userSaveFooter()
        {
            InitializeComponent();
        }

        public enum Operation
        {
            [Description("ƏLAVƏ ET")]
            Add,
            [Description("DÜZƏLİŞ ET")]
            Edit,
            [Description("ƏTRAFLI BAXIŞ")]
            Show,
            [Description("YADDA SAXLA")]
            Save,
            [Description("SİL")]
            Delete,
            [Description("YENİLƏ")]
            Refresh,
            [Description("BAĞLA")]
            Close,
            [Description("DEAKTİV ET")]
            Block,
            [Description("AKTİV ET")]
            Active
        }

        private void ShowSaveButtonImage(Operation operation)
        {
            if (true)
            {

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
    }
}
