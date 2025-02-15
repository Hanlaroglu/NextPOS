
namespace Barcode_Sales.Forms
{
    partial class fRole
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
            this.groupUser = new DevExpress.XtraEditors.GroupControl();
            this.tRoleName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.userSaveFooter1 = new NextPOS.UserControls.userSaveFooter();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabAdmin = new DevExpress.XtraTab.XtraTabPage();
            this.chCredit = new DevExpress.XtraEditors.CheckEdit();
            this.chUsers = new DevExpress.XtraEditors.CheckEdit();
            this.chSettings = new DevExpress.XtraEditors.CheckEdit();
            this.chReport = new DevExpress.XtraEditors.CheckEdit();
            this.chBank = new DevExpress.XtraEditors.CheckEdit();
            this.tabCashier = new DevExpress.XtraTab.XtraTabPage();
            this.chMoneyBox = new DevExpress.XtraEditors.CheckEdit();
            this.chPosReturn = new DevExpress.XtraEditors.CheckEdit();
            this.chPosSales = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupUser)).BeginInit();
            this.groupUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chSettings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBank.Properties)).BeginInit();
            this.tabCashier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chMoneyBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPosReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPosSales.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupUser
            // 
            this.groupUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupUser.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupUser.Appearance.Options.UseBackColor = true;
            this.groupUser.AppearanceCaption.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupUser.AppearanceCaption.Options.UseFont = true;
            this.groupUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupUser.Controls.Add(this.tRoleName);
            this.groupUser.Controls.Add(this.labelControl1);
            this.groupUser.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupUser.Location = new System.Drawing.Point(5, 0);
            this.groupUser.LookAndFeel.SkinName = "Office 2019 White";
            this.groupUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupUser.Name = "groupUser";
            this.groupUser.Size = new System.Drawing.Size(518, 72);
            this.groupUser.TabIndex = 14;
            this.groupUser.Text = "Rol məlumatları";
            // 
            // tRoleName
            // 
            this.tRoleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tRoleName.Location = new System.Drawing.Point(130, 30);
            this.tRoleName.Name = "tRoleName";
            this.tRoleName.Properties.AllowFocused = false;
            this.tRoleName.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.tRoleName.Properties.Appearance.Options.UseFont = true;
            this.tRoleName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tRoleName.Size = new System.Drawing.Size(380, 28);
            this.tRoleName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(5, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(53, 21);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Rol adı";
            this.labelControl1.UseMnemonic = false;
            // 
            // userSaveFooter1
            // 
            this.userSaveFooter1.CancelVisible = true;
            this.userSaveFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userSaveFooter1.Location = new System.Drawing.Point(0, 315);
            this.userSaveFooter1.LookAndFeel.SkinName = "Office 2019 White";
            this.userSaveFooter1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.userSaveFooter1.Name = "userSaveFooter1";
            this.userSaveFooter1.SaveButtonText = "Yadda Saxla";
            this.userSaveFooter1.Size = new System.Drawing.Size(528, 53);
            this.userSaveFooter1.TabIndex = 15;
            this.userSaveFooter1.SaveClick += new System.EventHandler(this.userSaveFooter1_SaveClick);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Nunito", 12F);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Options.UseTextOptions = true;
            this.xtraTabControl1.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseTextOptions = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Nunito", 12F);
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseTextOptions = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Nunito", 12F);
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseTextOptions = true;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xtraTabControl1.AppearancePage.PageClient.Font = new System.Drawing.Font("Nunito", 12F);
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseTextOptions = true;
            this.xtraTabControl1.AppearancePage.PageClient.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 83);
            this.xtraTabControl1.LookAndFeel.SkinName = "Metropolis";
            this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabAdmin;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Size = new System.Drawing.Size(518, 228);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAdmin,
            this.tabCashier});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.chCredit);
            this.tabAdmin.Controls.Add(this.chUsers);
            this.tabAdmin.Controls.Add(this.chSettings);
            this.tabAdmin.Controls.Add(this.chReport);
            this.tabAdmin.Controls.Add(this.chBank);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(516, 194);
            this.tabAdmin.Text = "ADMİN PANEL";
            // 
            // chCredit
            // 
            this.chCredit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chCredit.Location = new System.Drawing.Point(5, 146);
            this.chCredit.Name = "chCredit";
            this.chCredit.Properties.AllowFocused = false;
            this.chCredit.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chCredit.Properties.Appearance.Options.UseFont = true;
            this.chCredit.Properties.Caption = "Kredit satış və ödənişləri";
            this.chCredit.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chCredit.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chCredit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chCredit.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chCredit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chCredit.Size = new System.Drawing.Size(505, 28);
            this.chCredit.TabIndex = 5;
            // 
            // chUsers
            // 
            this.chUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chUsers.Location = new System.Drawing.Point(5, 112);
            this.chUsers.Name = "chUsers";
            this.chUsers.Properties.AllowFocused = false;
            this.chUsers.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chUsers.Properties.Appearance.Options.UseFont = true;
            this.chUsers.Properties.Caption = "İstifadəçilər";
            this.chUsers.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chUsers.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chUsers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chUsers.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chUsers.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chUsers.Size = new System.Drawing.Size(505, 28);
            this.chUsers.TabIndex = 4;
            // 
            // chSettings
            // 
            this.chSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chSettings.Location = new System.Drawing.Point(5, 78);
            this.chSettings.Name = "chSettings";
            this.chSettings.Properties.AllowFocused = false;
            this.chSettings.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chSettings.Properties.Appearance.Options.UseFont = true;
            this.chSettings.Properties.Caption = "Tənzimləmələr";
            this.chSettings.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chSettings.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chSettings.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chSettings.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chSettings.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chSettings.Size = new System.Drawing.Size(505, 28);
            this.chSettings.TabIndex = 3;
            // 
            // chReport
            // 
            this.chReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chReport.Location = new System.Drawing.Point(5, 44);
            this.chReport.Name = "chReport";
            this.chReport.Properties.AllowFocused = false;
            this.chReport.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chReport.Properties.Appearance.Options.UseFont = true;
            this.chReport.Properties.Caption = "Hesabatlar";
            this.chReport.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chReport.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chReport.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chReport.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chReport.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chReport.Size = new System.Drawing.Size(505, 28);
            this.chReport.TabIndex = 2;
            // 
            // chBank
            // 
            this.chBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chBank.Location = new System.Drawing.Point(5, 10);
            this.chBank.Name = "chBank";
            this.chBank.Properties.AllowFocused = false;
            this.chBank.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chBank.Properties.Appearance.Options.UseFont = true;
            this.chBank.Properties.Caption = "Bank satış";
            this.chBank.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chBank.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chBank.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chBank.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chBank.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chBank.Size = new System.Drawing.Size(505, 28);
            this.chBank.TabIndex = 1;
            // 
            // tabCashier
            // 
            this.tabCashier.Controls.Add(this.chMoneyBox);
            this.tabCashier.Controls.Add(this.chPosReturn);
            this.tabCashier.Controls.Add(this.chPosSales);
            this.tabCashier.Name = "tabCashier";
            this.tabCashier.Size = new System.Drawing.Size(516, 194);
            this.tabCashier.Text = "KASSİR";
            // 
            // chMoneyBox
            // 
            this.chMoneyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chMoneyBox.Location = new System.Drawing.Point(5, 78);
            this.chMoneyBox.Name = "chMoneyBox";
            this.chMoneyBox.Properties.AllowFocused = false;
            this.chMoneyBox.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chMoneyBox.Properties.Appearance.Options.UseFont = true;
            this.chMoneyBox.Properties.Caption = "Pul çəkməcəsini açma";
            this.chMoneyBox.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chMoneyBox.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chMoneyBox.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chMoneyBox.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chMoneyBox.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chMoneyBox.Size = new System.Drawing.Size(505, 28);
            this.chMoneyBox.TabIndex = 8;
            // 
            // chPosReturn
            // 
            this.chPosReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chPosReturn.Location = new System.Drawing.Point(5, 44);
            this.chPosReturn.Name = "chPosReturn";
            this.chPosReturn.Properties.AllowFocused = false;
            this.chPosReturn.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chPosReturn.Properties.Appearance.Options.UseFont = true;
            this.chPosReturn.Properties.Caption = "Kassa qaytarma";
            this.chPosReturn.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chPosReturn.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chPosReturn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chPosReturn.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chPosReturn.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chPosReturn.Size = new System.Drawing.Size(505, 28);
            this.chPosReturn.TabIndex = 7;
            // 
            // chPosSales
            // 
            this.chPosSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chPosSales.Location = new System.Drawing.Point(5, 10);
            this.chPosSales.Name = "chPosSales";
            this.chPosSales.Properties.AllowFocused = false;
            this.chPosSales.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.chPosSales.Properties.Appearance.Options.UseFont = true;
            this.chPosSales.Properties.Caption = "Kassa satışı";
            this.chPosSales.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chPosSales.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(26, 24);
            this.chPosSales.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chPosSales.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.chPosSales.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chPosSales.Size = new System.Drawing.Size(505, 28);
            this.chPosSales.TabIndex = 6;
            // 
            // fRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(528, 368);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.userSaveFooter1);
            this.Controls.Add(this.groupUser);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 400);
            this.MinimumSize = new System.Drawing.Size(530, 400);
            this.Name = "fRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupUser)).EndInit();
            this.groupUser.ResumeLayout(false);
            this.groupUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chSettings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBank.Properties)).EndInit();
            this.tabCashier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chMoneyBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPosReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPosSales.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupUser;
        private DevExpress.XtraEditors.TextEdit tRoleName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private NextPOS.UserControls.userSaveFooter userSaveFooter1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabAdmin;
        private DevExpress.XtraTab.XtraTabPage tabCashier;
        private DevExpress.XtraEditors.CheckEdit chCredit;
        private DevExpress.XtraEditors.CheckEdit chUsers;
        private DevExpress.XtraEditors.CheckEdit chSettings;
        private DevExpress.XtraEditors.CheckEdit chReport;
        private DevExpress.XtraEditors.CheckEdit chBank;
        private DevExpress.XtraEditors.CheckEdit chMoneyBox;
        private DevExpress.XtraEditors.CheckEdit chPosReturn;
        private DevExpress.XtraEditors.CheckEdit chPosSales;
    }
}