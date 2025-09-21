namespace Barcode_Sales.Forms
{
    partial class fWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fWarehouse));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.chStatus = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.bSave);
            this.panelControl1.Controls.Add(this.chStatus);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.tName);
            this.panelControl1.Location = new System.Drawing.Point(3, 5);
            this.panelControl1.LookAndFeel.SkinName = "WXI";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(490, 95);
            this.panelControl1.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.AllowFocus = false;
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bSave.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.bSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bSave.Appearance.Options.UseBackColor = true;
            this.bSave.Appearance.Options.UseFont = true;
            this.bSave.Appearance.Options.UseForeColor = true;
            this.bSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSave.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSave.AppearanceHovered.Options.UseBackColor = true;
            this.bSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bSave.ImageOptions.SvgImage")));
            this.bSave.ImageOptions.SvgImageSize = new System.Drawing.Size(28, 28);
            this.bSave.Location = new System.Drawing.Point(343, 51);
            this.bSave.LookAndFeel.SkinName = "WXI";
            this.bSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bSave.Name = "bSave";
            this.bSave.Padding = new System.Windows.Forms.Padding(3);
            this.bSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSave.Size = new System.Drawing.Size(140, 35);
            this.bSave.TabIndex = 25;
            this.bSave.TabStop = false;
            this.bSave.Text = "Saxla";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // chStatus
            // 
            this.chStatus.EditValue = true;
            this.chStatus.Location = new System.Drawing.Point(99, 57);
            this.chStatus.Name = "chStatus";
            this.chStatus.Properties.AutoWidth = true;
            this.chStatus.Properties.OffText = "Deaktiv";
            this.chStatus.Properties.OnText = "Aktiv";
            this.chStatus.Size = new System.Drawing.Size(113, 24);
            this.chStatus.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(5, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(48, 20);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Status";
            this.labelControl1.UseMnemonic = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl4.Location = new System.Drawing.Point(5, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl4.Size = new System.Drawing.Size(72, 20);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Anbar adı";
            this.labelControl4.UseMnemonic = false;
            // 
            // tName
            // 
            this.tName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tName.Location = new System.Drawing.Point(99, 7);
            this.tName.Name = "tName";
            this.tName.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.tName.Properties.Appearance.Options.UseFont = true;
            this.tName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tName.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tName.Properties.MaxLength = 50;
            this.tName.Size = new System.Drawing.Size(384, 32);
            this.tName.TabIndex = 0;
            // 
            // fWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(498, 106);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 140);
            this.Name = "fWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anbar";
            this.Load += new System.EventHandler(this.fWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ToggleSwitch chStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit tName;
        private DevExpress.XtraEditors.SimpleButton bSave;
    }
}