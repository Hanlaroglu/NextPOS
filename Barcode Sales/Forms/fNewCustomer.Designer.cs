
namespace Barcode_Sales.Forms
{
    partial class fNewCustomer
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tComment = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tVoen = new DevExpress.XtraEditors.TextEdit();
            this.tAddress = new DevExpress.XtraEditors.TextEdit();
            this.tPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tNameSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.userSaveFooter1 = new NextPOS.UserControls.userSaveFooter();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tVoen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNameSurname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Nunito", 12F);
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.tComment);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.tVoen);
            this.groupControl1.Controls.Add(this.tAddress);
            this.groupControl1.Controls.Add(this.tPhone);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.tNameSurname);
            this.groupControl1.Controls.Add(this.labelControl24);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.LookAndFeel.SkinName = "Office 2019 White";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Margin = new System.Windows.Forms.Padding(1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(512, 348);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Müştəri məlumatları";
            // 
            // tComment
            // 
            this.tComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tComment.Location = new System.Drawing.Point(132, 190);
            this.tComment.Name = "tComment";
            this.tComment.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tComment.Properties.Appearance.Options.UseFont = true;
            this.tComment.Size = new System.Drawing.Size(375, 153);
            this.tComment.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 191);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl3.Size = new System.Drawing.Size(44, 22);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Qeyd";
            this.labelControl3.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 153);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(44, 22);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Vöen";
            this.labelControl1.UseMnemonic = false;
            // 
            // tVoen
            // 
            this.tVoen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tVoen.Location = new System.Drawing.Point(132, 150);
            this.tVoen.Name = "tVoen";
            this.tVoen.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tVoen.Properties.Appearance.Options.UseFont = true;
            this.tVoen.Properties.MaxLength = 11;
            this.tVoen.Size = new System.Drawing.Size(375, 32);
            this.tVoen.TabIndex = 3;
            // 
            // tAddress
            // 
            this.tAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tAddress.Location = new System.Drawing.Point(132, 112);
            this.tAddress.Name = "tAddress";
            this.tAddress.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tAddress.Properties.Appearance.Options.UseFont = true;
            this.tAddress.Size = new System.Drawing.Size(375, 32);
            this.tAddress.TabIndex = 2;
            // 
            // tPhone
            // 
            this.tPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tPhone.Location = new System.Drawing.Point(132, 74);
            this.tPhone.Name = "tPhone";
            this.tPhone.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tPhone.Properties.Appearance.Options.UseFont = true;
            this.tPhone.Properties.Mask.EditMask = "(999) 000-00-00";
            this.tPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.tPhone.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tPhone.Properties.MaxLength = 20;
            this.tPhone.Size = new System.Drawing.Size(375, 32);
            this.tPhone.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl2.Size = new System.Drawing.Size(52, 22);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Ünvan";
            this.labelControl2.UseMnemonic = false;
            // 
            // tNameSurname
            // 
            this.tNameSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tNameSurname.Location = new System.Drawing.Point(132, 36);
            this.tNameSurname.Name = "tNameSurname";
            this.tNameSurname.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tNameSurname.Properties.Appearance.Options.UseFont = true;
            this.tNameSurname.Properties.MaxLength = 250;
            this.tNameSurname.Size = new System.Drawing.Size(375, 32);
            this.tNameSurname.TabIndex = 0;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl24.Location = new System.Drawing.Point(5, 39);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl24.Size = new System.Drawing.Size(98, 26);
            this.labelControl24.TabIndex = 5;
            this.labelControl24.Text = "Ad Soyad";
            this.labelControl24.UseMnemonic = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(5, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl4.Size = new System.Drawing.Size(98, 26);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Telefon";
            this.labelControl4.UseMnemonic = false;
            // 
            // userSaveFooter1
            // 
            this.userSaveFooter1.CancelVisible = true;
            this.userSaveFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userSaveFooter1.Location = new System.Drawing.Point(0, 363);
            this.userSaveFooter1.LookAndFeel.SkinName = "Office 2019 White";
            this.userSaveFooter1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.userSaveFooter1.Name = "userSaveFooter1";
            this.userSaveFooter1.SaveButtonText = "Yadda Saxla";
            this.userSaveFooter1.Size = new System.Drawing.Size(523, 53);
            this.userSaveFooter1.TabIndex = 9;
            this.userSaveFooter1.SaveClick += new System.EventHandler(this.userSaveFooter1_SaveClick);
            this.userSaveFooter1.CancelClick += new System.EventHandler(this.userSaveFooter1_CancelClick);
            // 
            // fNewCustomer
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(523, 416);
            this.Controls.Add(this.userSaveFooter1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(525, 448);
            this.Name = "fNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni müştəri";
            this.Load += new System.EventHandler(this.fNewCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tVoen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNameSurname.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit tComment;
        private DevExpress.XtraEditors.TextEdit tNameSurname;
        private DevExpress.XtraEditors.TextEdit tPhone;
        private DevExpress.XtraEditors.TextEdit tVoen;
        private DevExpress.XtraEditors.TextEdit tAddress;
        private NextPOS.UserControls.userSaveFooter userSaveFooter1;
    }
}