
namespace Barcode_Sales.Forms
{
    partial class fRegistration
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
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.dateRegistration = new DevExpress.XtraEditors.DateEdit();
            this.tPhone = new DevExpress.XtraEditors.TextEdit();
            this.tEmail = new DevExpress.XtraEditors.TextEdit();
            this.tAddress = new DevExpress.XtraEditors.TextEdit();
            this.tCompanyCode = new DevExpress.XtraEditors.TextEdit();
            this.tVoen = new DevExpress.XtraEditors.TextEdit();
            this.tCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateRegistration.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRegistration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCompanyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tVoen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCompanyName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Appearance.AeroWizardTitle.Font = new System.Drawing.Font("Nunito", 10F);
            this.wizardControl1.Appearance.AeroWizardTitle.Options.UseFont = true;
            this.wizardControl1.Appearance.ExteriorPage.Font = new System.Drawing.Font("Nunito", 10F);
            this.wizardControl1.Appearance.ExteriorPage.Options.UseFont = true;
            this.wizardControl1.Appearance.ExteriorPageTitle.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.wizardControl1.Appearance.ExteriorPageTitle.Options.UseFont = true;
            this.wizardControl1.Appearance.Page.Font = new System.Drawing.Font("Nunito", 10F);
            this.wizardControl1.Appearance.Page.Options.UseFont = true;
            this.wizardControl1.Appearance.PageTitle.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.wizardControl1.Appearance.PageTitle.Options.UseFont = true;
            this.wizardControl1.CancelText = "Çıxış et";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Bitir";
            this.wizardControl1.HelpText = "&Yardım";
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&İrəli >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Geri";
            this.wizardControl1.Size = new System.Drawing.Size(677, 432);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "• Tərəflərin hüquq və öhdəlikləri\r\n";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "İrəli düyməsini sıxaraq müqavilə şərtlərini qəbul etmiş olursunuz.";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(460, 297);
            this.welcomeWizardPage1.Text = "NextPOS\'a xoş gəlmisiniz";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.dateRegistration);
            this.wizardPage1.Controls.Add(this.tPhone);
            this.wizardPage1.Controls.Add(this.tEmail);
            this.wizardPage1.Controls.Add(this.tAddress);
            this.wizardPage1.Controls.Add(this.tCompanyCode);
            this.wizardPage1.Controls.Add(this.tVoen);
            this.wizardPage1.Controls.Add(this.tCompanyName);
            this.wizardPage1.Controls.Add(this.labelControl5);
            this.wizardPage1.Controls.Add(this.labelControl4);
            this.wizardPage1.Controls.Add(this.labelControl3);
            this.wizardPage1.Controls.Add(this.labelControl2);
            this.wizardPage1.Controls.Add(this.labelControl1);
            this.wizardPage1.Controls.Add(this.labelControl17);
            this.wizardPage1.DescriptionText = "";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(645, 289);
            this.wizardPage1.Text = "Sifarişçi məlumatları";
            // 
            // dateRegistration
            // 
            this.dateRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateRegistration.EditValue = null;
            this.dateRegistration.Location = new System.Drawing.Point(235, 215);
            this.dateRegistration.Name = "dateRegistration";
            this.dateRegistration.Properties.AllowFocused = false;
            this.dateRegistration.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateRegistration.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.dateRegistration.Properties.Appearance.Options.UseFont = true;
            this.dateRegistration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRegistration.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateRegistration.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dateRegistration.Properties.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dateRegistration.Properties.LookAndFeel.SkinName = "The Bezier";
            this.dateRegistration.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateRegistration.Properties.ShowToday = false;
            this.dateRegistration.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateRegistration.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateRegistration.Size = new System.Drawing.Size(400, 32);
            this.dateRegistration.TabIndex = 6;
            this.dateRegistration.TabStop = false;
            // 
            // tPhone
            // 
            this.tPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tPhone.Location = new System.Drawing.Point(235, 139);
            this.tPhone.Name = "tPhone";
            this.tPhone.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tPhone.Properties.Appearance.Options.UseFont = true;
            this.tPhone.Properties.Mask.EditMask = "(999) 000-00-00";
            this.tPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.tPhone.Size = new System.Drawing.Size(400, 32);
            this.tPhone.TabIndex = 4;
            // 
            // tEmail
            // 
            this.tEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tEmail.Location = new System.Drawing.Point(235, 177);
            this.tEmail.Name = "tEmail";
            this.tEmail.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tEmail.Properties.Appearance.Options.UseFont = true;
            this.tEmail.Size = new System.Drawing.Size(400, 32);
            this.tEmail.TabIndex = 5;
            // 
            // tAddress
            // 
            this.tAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tAddress.Location = new System.Drawing.Point(235, 101);
            this.tAddress.Name = "tAddress";
            this.tAddress.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tAddress.Properties.Appearance.Options.UseFont = true;
            this.tAddress.Properties.MaxLength = 250;
            this.tAddress.Size = new System.Drawing.Size(400, 32);
            this.tAddress.TabIndex = 3;
            // 
            // tCompanyCode
            // 
            this.tCompanyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCompanyCode.EditValue = "";
            this.tCompanyCode.Location = new System.Drawing.Point(535, 63);
            this.tCompanyCode.Name = "tCompanyCode";
            this.tCompanyCode.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tCompanyCode.Properties.Appearance.Options.UseFont = true;
            this.tCompanyCode.Properties.Appearance.Options.UseTextOptions = true;
            this.tCompanyCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tCompanyCode.Properties.Mask.EditMask = "d";
            this.tCompanyCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tCompanyCode.Properties.MaxLength = 5;
            this.tCompanyCode.Size = new System.Drawing.Size(100, 32);
            this.tCompanyCode.TabIndex = 2;
            // 
            // tVoen
            // 
            this.tVoen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tVoen.Location = new System.Drawing.Point(235, 63);
            this.tVoen.Name = "tVoen";
            this.tVoen.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tVoen.Properties.Appearance.Options.UseFont = true;
            this.tVoen.Properties.Mask.EditMask = "d";
            this.tVoen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tVoen.Properties.MaxLength = 11;
            this.tVoen.Size = new System.Drawing.Size(294, 32);
            this.tVoen.TabIndex = 1;
            // 
            // tCompanyName
            // 
            this.tCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCompanyName.Location = new System.Drawing.Point(235, 25);
            this.tCompanyName.Name = "tCompanyName";
            this.tCompanyName.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tCompanyName.Properties.Appearance.Options.UseFont = true;
            this.tCompanyName.Properties.MaxLength = 255;
            this.tCompanyName.Size = new System.Drawing.Size(400, 32);
            this.tCompanyName.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(13, 218);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl5.Size = new System.Drawing.Size(140, 26);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Qeydiyyat tarixi";
            this.labelControl5.UseMnemonic = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(13, 180);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl4.Size = new System.Drawing.Size(53, 26);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Email";
            this.labelControl4.UseMnemonic = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(13, 142);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl3.Size = new System.Drawing.Size(131, 26);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Əlaqə nömrəsi";
            this.labelControl3.UseMnemonic = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(13, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl2.Size = new System.Drawing.Size(62, 26);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Ünvan";
            this.labelControl2.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 66);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(186, 26);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "VÖEN - Obyekt kodu";
            this.labelControl1.UseMnemonic = false;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Location = new System.Drawing.Point(13, 28);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl17.Size = new System.Drawing.Size(68, 26);
            this.labelControl17.TabIndex = 11;
            this.labelControl17.Text = "VÖ Adı";
            this.labelControl17.UseMnemonic = false;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "NextPOS proqram təminatının yüklənməsi uğurla başa çatdı";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "";
            this.completionWizardPage1.Size = new System.Drawing.Size(460, 297);
            this.completionWizardPage1.Text = "Uğurla tamamlandı";
            // 
            // fRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(677, 432);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NextPOS";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateRegistration.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateRegistration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCompanyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tVoen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCompanyName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.TextEdit tAddress;
        private DevExpress.XtraEditors.TextEdit tVoen;
        private DevExpress.XtraEditors.TextEdit tCompanyName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit tCompanyCode;
        private DevExpress.XtraEditors.TextEdit tEmail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tPhone;
        private DevExpress.XtraEditors.DateEdit dateRegistration;
    }
}