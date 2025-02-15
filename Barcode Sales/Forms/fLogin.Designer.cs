
namespace Barcode_Sales.Forms
{
    partial class fLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.lVersion = new DevExpress.XtraEditors.LabelControl();
            this.lContact = new DevExpress.XtraEditors.LabelControl();
            this.chSaveMe = new DevExpress.XtraEditors.CheckEdit();
            this.bExit = new NextPOS.UserControls.ButtonRadius();
            this.bLogin = new NextPOS.UserControls.ButtonRadius();
            this.tPassword = new DevExpress.XtraEditors.TextEdit();
            this.tUsername = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chSaveMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUsername.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 36.08F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 23.92F)});
            this.tablePanel1.Controls.Add(this.svgImageBox1);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1072, 601);
            this.tablePanel1.TabIndex = 0;
            // 
            // svgImageBox1
            // 
            this.tablePanel1.SetColumn(this.svgImageBox1, 0);
            this.svgImageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.svgImageBox1.Location = new System.Drawing.Point(4, 4);
            this.svgImageBox1.Name = "svgImageBox1";
            this.tablePanel1.SetRow(this.svgImageBox1, 0);
            this.svgImageBox1.Size = new System.Drawing.Size(637, 593);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 1;
            this.svgImageBox1.TabStop = false;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.tablePanel2);
            this.panelControl1.Controls.Add(this.chSaveMe);
            this.panelControl1.Controls.Add(this.bExit);
            this.panelControl1.Controls.Add(this.bLogin);
            this.panelControl1.Controls.Add(this.tPassword);
            this.panelControl1.Controls.Add(this.tUsername);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(644, 1);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(427, 599);
            this.panelControl1.TabIndex = 0;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureEdit1.EditValue = global::Barcode_Sales.Properties.Resources.Logo_1024;
            this.pictureEdit1.Location = new System.Drawing.Point(128, 29);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.NullText = "Logo";
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(185, 156);
            this.pictureEdit1.TabIndex = 5;
            // 
            // tablePanel2
            // 
            this.tablePanel2.AutoSize = true;
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.86F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 27.14F)});
            this.tablePanel2.Controls.Add(this.lVersion);
            this.tablePanel2.Controls.Add(this.lContact);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePanel2.Location = new System.Drawing.Point(0, 573);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(427, 26);
            this.tablePanel2.TabIndex = 4;
            // 
            // lVersion
            // 
            this.lVersion.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.lVersion.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.lVersion.Appearance.Options.UseFont = true;
            this.lVersion.Appearance.Options.UseForeColor = true;
            this.lVersion.Appearance.Options.UseTextOptions = true;
            this.lVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.tablePanel2.SetColumn(this.lVersion, 1);
            this.lVersion.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lVersion.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.lVersion.Location = new System.Drawing.Point(234, 3);
            this.lVersion.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lVersion.Name = "lVersion";
            this.tablePanel2.SetRow(this.lVersion, 0);
            this.lVersion.Size = new System.Drawing.Size(188, 19);
            this.lVersion.TabIndex = 5;
            this.lVersion.Text = "Version: ";
            // 
            // lContact
            // 
            this.lContact.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.lContact.Appearance.ForeColor = System.Drawing.Color.SlateBlue;
            this.lContact.Appearance.Options.UseFont = true;
            this.lContact.Appearance.Options.UseForeColor = true;
            this.lContact.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.tablePanel2.SetColumn(this.lContact, 0);
            this.lContact.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lContact.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lContact.ImageOptions.SvgImage")));
            this.lContact.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.lContact.Location = new System.Drawing.Point(3, 0);
            this.lContact.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lContact.Name = "lContact";
            this.tablePanel2.SetRow(this.lContact, 0);
            this.lContact.Size = new System.Drawing.Size(231, 26);
            this.lContact.TabIndex = 3;
            this.lContact.Text = "Əlaqə: 0702008816";
            // 
            // chSaveMe
            // 
            this.chSaveMe.Location = new System.Drawing.Point(52, 311);
            this.chSaveMe.Name = "chSaveMe";
            this.chSaveMe.Properties.AllowFocused = false;
            this.chSaveMe.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F);
            this.chSaveMe.Properties.Appearance.Options.UseFont = true;
            this.chSaveMe.Properties.Caption = "Yadda saxla";
            this.chSaveMe.Size = new System.Drawing.Size(123, 23);
            this.chSaveMe.TabIndex = 2;
            this.chSaveMe.TabStop = false;
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.Crimson;
            this.bExit.BackgroundColor = System.Drawing.Color.Crimson;
            this.bExit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bExit.BorderRadius = 10;
            this.bExit.BorderSize = 0;
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Font = new System.Drawing.Font("Calibri", 14F);
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(52, 400);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(336, 40);
            this.bExit.TabIndex = 4;
            this.bExit.TabStop = false;
            this.bExit.Text = "Çıxış";
            this.bExit.TextColor = System.Drawing.Color.White;
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bLogin
            // 
            this.bLogin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bLogin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bLogin.BorderRadius = 10;
            this.bLogin.BorderSize = 0;
            this.bLogin.FlatAppearance.BorderSize = 0;
            this.bLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLogin.Font = new System.Drawing.Font("Calibri", 14F);
            this.bLogin.ForeColor = System.Drawing.Color.White;
            this.bLogin.Location = new System.Drawing.Point(52, 354);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(336, 40);
            this.bLogin.TabIndex = 3;
            this.bLogin.TabStop = false;
            this.bLogin.Text = "Daxil ol";
            this.bLogin.TextColor = System.Drawing.Color.White;
            this.bLogin.UseVisualStyleBackColor = false;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // tPassword
            // 
            this.tPassword.EditValue = "12345";
            this.tPassword.Location = new System.Drawing.Point(52, 273);
            this.tPassword.Name = "tPassword";
            this.tPassword.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tPassword.Properties.Appearance.Options.UseFont = true;
            this.tPassword.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tPassword.Properties.ContextImageOptions.SvgImage")));
            this.tPassword.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.tPassword.Properties.NullValuePrompt = "Şifrə";
            this.tPassword.Properties.UseSystemPasswordChar = true;
            this.tPassword.Size = new System.Drawing.Size(336, 32);
            this.tPassword.TabIndex = 1;
            this.tPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardPress);
            // 
            // tUsername
            // 
            this.tUsername.EditValue = "admin";
            this.tUsername.Location = new System.Drawing.Point(52, 235);
            this.tUsername.Name = "tUsername";
            this.tUsername.Properties.AllowFocused = false;
            this.tUsername.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tUsername.Properties.Appearance.Options.UseFont = true;
            this.tUsername.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tUsername.Properties.ContextImageOptions.SvgImage")));
            this.tUsername.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.tUsername.Properties.NullValuePrompt = "İstifadəçi adı";
            this.tUsername.Size = new System.Drawing.Size(336, 32);
            this.tUsername.TabIndex = 0;
            this.tUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardPress);
            // 
            // fLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1072, 601);
            this.Controls.Add(this.tablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardPress);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chSaveMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUsername.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chSaveMe;
        private NextPOS.UserControls.ButtonRadius bExit;
        private NextPOS.UserControls.ButtonRadius bLogin;
        private DevExpress.XtraEditors.TextEdit tPassword;
        private DevExpress.XtraEditors.TextEdit tUsername;
        private DevExpress.XtraEditors.LabelControl lContact;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.LabelControl lVersion;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}