
namespace NextPOS.UserControls
{
    partial class userSaveFooter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userSaveFooter));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.bAdd = new DevExpress.XtraEditors.SimpleButton();
            this.svgCollectionImage1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgCollectionImage1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.bAdd);
            this.panelControl2.Controls.Add(this.bCancel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.SkinName = "WXI";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(700, 53);
            this.panelControl2.TabIndex = 12;
            // 
            // bAdd
            // 
            this.bAdd.AllowFocus = false;
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bAdd.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.bAdd.Appearance.Options.UseBackColor = true;
            this.bAdd.Appearance.Options.UseFont = true;
            this.bAdd.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.bAdd.Location = new System.Drawing.Point(502, 5);
            this.bAdd.LookAndFeel.SkinName = "WXI";
            this.bAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bAdd.Name = "bAdd";
            this.bAdd.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bAdd.Size = new System.Drawing.Size(193, 45);
            this.bAdd.TabIndex = 8;
            this.bAdd.Text = "Yadda saxla";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // svgCollectionImage1
            // 
            this.svgCollectionImage1.ImageSize = new System.Drawing.Size(32, 32);
            this.svgCollectionImage1.Add("pay", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgCollectionImage1.pay"))));
            this.svgCollectionImage1.Add("close", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgCollectionImage1.close"))));
            this.svgCollectionImage1.Add("add", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgCollectionImage1.add"))));
            // 
            // bCancel
            // 
            this.bCancel.AllowFocus = false;
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.bCancel.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.bCancel.Appearance.Options.UseBackColor = true;
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.ImageOptions.Image")));
            this.bCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bCancel.ImageOptions.SvgImage")));
            this.bCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.bCancel.Location = new System.Drawing.Point(303, 5);
            this.bCancel.LookAndFeel.SkinName = "WXI";
            this.bCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bCancel.Name = "bCancel";
            this.bCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bCancel.Size = new System.Drawing.Size(193, 45);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Ləğv et";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // userSaveFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelControl2);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "userSaveFooter";
            this.Size = new System.Drawing.Size(700, 53);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svgCollectionImage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton bAdd;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.Utils.SvgImageCollection svgCollectionImage1;
    }
}
