
namespace NextDBSetup
{
    partial class fConnection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fConnection));
            this.chSql = new DevExpress.XtraEditors.CheckButton();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chWindows = new DevExpress.XtraEditors.CheckButton();
            this.tPassword = new DevExpress.XtraEditors.TextEdit();
            this.tUsername = new DevExpress.XtraEditors.TextEdit();
            this.tServerName = new DevExpress.XtraEditors.TextEdit();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.bTest = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chProcedure = new DevExpress.XtraEditors.CheckEdit();
            this.chCreateDB = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chProcedure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCreateDB.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chSql
            // 
            this.chSql.AllowFocus = false;
            this.chSql.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.chSql.Appearance.Options.UseFont = true;
            this.chSql.GroupIndex = 1;
            this.chSql.ImageOptions.ImageIndex = 1;
            this.chSql.ImageOptions.ImageList = this.ımageList1;
            this.chSql.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chSql.Location = new System.Drawing.Point(278, 11);
            this.chSql.Margin = new System.Windows.Forms.Padding(2);
            this.chSql.Name = "chSql";
            this.chSql.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.chSql.Size = new System.Drawing.Size(257, 242);
            this.chSql.TabIndex = 3;
            this.chSql.TabStop = false;
            this.chSql.Text = "Uzaq Server";
            this.chSql.CheckedChanged += new System.EventHandler(this.chSql_CheckedChanged);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Windows.png");
            this.ımageList1.Images.SetKeyName(1, "SQL Server.png");
            // 
            // chWindows
            // 
            this.chWindows.AllowFocus = false;
            this.chWindows.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.chWindows.Appearance.Options.UseFont = true;
            this.chWindows.Checked = true;
            this.chWindows.GroupIndex = 1;
            this.chWindows.ImageOptions.ImageIndex = 0;
            this.chWindows.ImageOptions.ImageList = this.ımageList1;
            this.chWindows.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chWindows.Location = new System.Drawing.Point(11, 11);
            this.chWindows.Margin = new System.Windows.Forms.Padding(2);
            this.chWindows.Name = "chWindows";
            this.chWindows.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.chWindows.Size = new System.Drawing.Size(257, 242);
            this.chWindows.TabIndex = 4;
            this.chWindows.Text = "Lokal Server";
            // 
            // tPassword
            // 
            this.tPassword.Enabled = false;
            this.tPassword.Location = new System.Drawing.Point(12, 354);
            this.tPassword.Name = "tPassword";
            this.tPassword.Properties.Appearance.Font = new System.Drawing.Font("Nunito Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword.Properties.Appearance.Options.UseFont = true;
            this.tPassword.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tPassword.Properties.ContextImageOptions.Image")));
            this.tPassword.Properties.UseSystemPasswordChar = true;
            this.tPassword.Size = new System.Drawing.Size(524, 36);
            this.tPassword.TabIndex = 2;
            // 
            // tUsername
            // 
            this.tUsername.Enabled = false;
            this.tUsername.Location = new System.Drawing.Point(12, 312);
            this.tUsername.Name = "tUsername";
            this.tUsername.Properties.Appearance.Font = new System.Drawing.Font("Nunito Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsername.Properties.Appearance.Options.UseFont = true;
            this.tUsername.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tUsername.Properties.ContextImageOptions.Image")));
            this.tUsername.Size = new System.Drawing.Size(524, 36);
            this.tUsername.TabIndex = 1;
            // 
            // tServerName
            // 
            this.tServerName.Location = new System.Drawing.Point(12, 270);
            this.tServerName.Name = "tServerName";
            this.tServerName.Properties.Appearance.Font = new System.Drawing.Font("Nunito Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tServerName.Properties.Appearance.Options.UseFont = true;
            this.tServerName.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tServerName.Properties.ContextImageOptions.Image")));
            this.tServerName.Size = new System.Drawing.Size(524, 36);
            this.tServerName.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.AllowFocus = false;
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.bSave.Appearance.Options.UseFont = true;
            this.bSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bSave.ImageOptions.Image")));
            this.bSave.Location = new System.Drawing.Point(193, 508);
            this.bSave.LookAndFeel.SkinName = "Office 2019 White";
            this.bSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bSave.Name = "bSave";
            this.bSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSave.Size = new System.Drawing.Size(165, 42);
            this.bSave.TabIndex = 15;
            this.bSave.Text = "Əlavə et";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.AllowFocus = false;
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.ImageOptions.Image")));
            this.bCancel.Location = new System.Drawing.Point(370, 508);
            this.bCancel.LookAndFeel.SkinName = "Office 2019 White";
            this.bCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bCancel.Name = "bCancel";
            this.bCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bCancel.Size = new System.Drawing.Size(165, 42);
            this.bCancel.TabIndex = 16;
            this.bCancel.Text = "Ləğv et";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bTest
            // 
            this.bTest.AllowFocus = false;
            this.bTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bTest.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.bTest.Appearance.Options.UseFont = true;
            this.bTest.Location = new System.Drawing.Point(11, 508);
            this.bTest.LookAndFeel.SkinName = "Office 2019 White";
            this.bTest.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bTest.Name = "bTest";
            this.bTest.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bTest.Size = new System.Drawing.Size(165, 42);
            this.bTest.TabIndex = 16;
            this.bTest.Text = "Test et";
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Nunito", 12F);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.Controls.Add(this.chProcedure);
            this.groupControl3.Controls.Add(this.chCreateDB);
            this.groupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl3.Location = new System.Drawing.Point(11, 394);
            this.groupControl3.LookAndFeel.SkinName = "Office 2019 White";
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Margin = new System.Windows.Forms.Padding(1);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(524, 99);
            this.groupControl3.TabIndex = 18;
            // 
            // chProcedure
            // 
            this.chProcedure.Enabled = false;
            this.chProcedure.Location = new System.Drawing.Point(5, 57);
            this.chProcedure.Name = "chProcedure";
            this.chProcedure.Properties.AllowFocused = false;
            this.chProcedure.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.chProcedure.Properties.Appearance.Options.UseFont = true;
            this.chProcedure.Properties.Appearance.Options.UseTextOptions = true;
            this.chProcedure.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.chProcedure.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.chProcedure.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chProcedure.Properties.Caption = "Bazanı sil yenidən yarat";
            this.chProcedure.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chProcedure.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.chProcedure.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chProcedure.Size = new System.Drawing.Size(513, 30);
            this.chProcedure.TabIndex = 18;
            // 
            // chCreateDB
            // 
            this.chCreateDB.Location = new System.Drawing.Point(5, 21);
            this.chCreateDB.Name = "chCreateDB";
            this.chCreateDB.Properties.AllowFocused = false;
            this.chCreateDB.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.chCreateDB.Properties.Appearance.Options.UseFont = true;
            this.chCreateDB.Properties.Appearance.Options.UseTextOptions = true;
            this.chCreateDB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.chCreateDB.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.chCreateDB.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chCreateDB.Properties.Caption = "Baza yarat";
            this.chCreateDB.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chCreateDB.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.chCreateDB.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chCreateDB.Size = new System.Drawing.Size(513, 30);
            this.chCreateDB.TabIndex = 19;
            // 
            // fConnection
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(548, 562);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.bTest);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tUsername);
            this.Controls.Add(this.tServerName);
            this.Controls.Add(this.chSql);
            this.Controls.Add(this.chWindows);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "fConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chProcedure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCreateDB.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckButton chSql;
        private DevExpress.XtraEditors.CheckButton chWindows;
        private DevExpress.XtraEditors.TextEdit tPassword;
        private DevExpress.XtraEditors.TextEdit tUsername;
        private DevExpress.XtraEditors.TextEdit tServerName;
        private DevExpress.XtraEditors.SimpleButton bSave;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.SimpleButton bTest;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckEdit chCreateDB;
        private DevExpress.XtraEditors.CheckEdit chProcedure;
    }
}