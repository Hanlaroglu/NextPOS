namespace Barcode_Sales.Forms
{
    partial class fEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEditProduct));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.lookCategory = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookTax = new DevExpress.XtraEditors.LookUpEdit();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookStatus = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.separatorControl1);
            this.panelControl2.Controls.Add(this.lookCategory);
            this.panelControl2.Controls.Add(this.lookStatus);
            this.panelControl2.Controls.Add(this.lookTax);
            this.panelControl2.Controls.Add(this.bSave);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.lookWarehouse);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.labelControl24);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Location = new System.Drawing.Point(5, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(460, 222);
            this.panelControl2.TabIndex = 13;
            // 
            // separatorControl1
            // 
            this.separatorControl1.AutoSizeMode = true;
            this.separatorControl1.Location = new System.Drawing.Point(9, 167);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Padding = new System.Windows.Forms.Padding(3);
            this.separatorControl1.Size = new System.Drawing.Size(445, 7);
            this.separatorControl1.TabIndex = 15;
            // 
            // lookCategory
            // 
            this.lookCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookCategory.Location = new System.Drawing.Point(135, 53);
            this.lookCategory.Name = "lookCategory";
            this.lookCategory.Properties.AllowButtonNavigation = DevExpress.Utils.DefaultBoolean.False;
            this.lookCategory.Properties.AllowFocused = false;
            this.lookCategory.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookCategory.Properties.Appearance.Options.UseFont = true;
            this.lookCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCategory.Properties.LookAndFeel.SkinName = "WXI";
            this.lookCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookCategory.Properties.NullText = "";
            this.lookCategory.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.lookCategory.Properties.PopupFindMode = DevExpress.XtraEditors.FindMode.Always;
            this.lookCategory.Properties.PopupView = this.searchView;
            this.lookCategory.Properties.ShowClearButton = false;
            this.lookCategory.Properties.ShowFooter = false;
            this.lookCategory.Size = new System.Drawing.Size(316, 32);
            this.lookCategory.TabIndex = 1;
            // 
            // searchView
            // 
            this.searchView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn4});
            this.searchView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchView.Name = "searchView";
            this.searchView.OptionsMenu.EnableColumnMenu = false;
            this.searchView.OptionsMenu.EnableFooterMenu = false;
            this.searchView.OptionsMenu.EnableGroupPanelMenu = false;
            this.searchView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchView.OptionsView.ShowGroupPanel = false;
            this.searchView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Id";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.MaxWidth = 25;
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Width = 25;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kateqoriya adı";
            this.gridColumn4.FieldName = "CategoryName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 50;
            // 
            // lookTax
            // 
            this.lookTax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookTax.Location = new System.Drawing.Point(135, 91);
            this.lookTax.Name = "lookTax";
            this.lookTax.Properties.AllowFocused = false;
            this.lookTax.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.Appearance.Options.UseFont = true;
            this.lookTax.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.AppearanceDisabled.Options.UseFont = true;
            this.lookTax.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookTax.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookTax.Properties.AppearanceFocused.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.AppearanceFocused.Options.UseFont = true;
            this.lookTax.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookTax.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.lookTax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookTax.Properties.DropDownRows = 5;
            this.lookTax.Properties.NullText = "";
            this.lookTax.Properties.NullValuePrompt = "Vergi dərəcəsini seçin";
            this.lookTax.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.lookTax.Properties.ShowFooter = false;
            this.lookTax.Properties.ShowHeader = false;
            this.lookTax.Size = new System.Drawing.Size(316, 32);
            this.lookTax.TabIndex = 2;
            // 
            // bSave
            // 
            this.bSave.AllowFocus = false;
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bSave.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bSave.Appearance.Options.UseBackColor = true;
            this.bSave.Appearance.Options.UseFont = true;
            this.bSave.Appearance.Options.UseForeColor = true;
            this.bSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSave.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSave.AppearanceHovered.Options.UseBackColor = true;
            this.bSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bAddProduct.ImageOptions.SvgImage")));
            this.bSave.ImageOptions.SvgImageSize = new System.Drawing.Size(28, 28);
            this.bSave.Location = new System.Drawing.Point(333, 182);
            this.bSave.LookAndFeel.SkinName = "WXI";
            this.bSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bSave.Name = "bSave";
            this.bSave.Padding = new System.Windows.Forms.Padding(3);
            this.bSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSave.Size = new System.Drawing.Size(118, 33);
            this.bSave.TabIndex = 14;
            this.bSave.TabStop = false;
            this.bSave.Text = "Saxla";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl5.Location = new System.Drawing.Point(9, 21);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl5.Size = new System.Drawing.Size(49, 20);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Anbar";
            this.labelControl5.UseMnemonic = false;
            // 
            // lookWarehouse
            // 
            this.lookWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookWarehouse.Location = new System.Drawing.Point(135, 15);
            this.lookWarehouse.Name = "lookWarehouse";
            this.lookWarehouse.Properties.AllowFocused = false;
            this.lookWarehouse.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookWarehouse.Properties.Appearance.Options.UseFont = true;
            this.lookWarehouse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookWarehouse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookWarehouse.Properties.AppearanceFocused.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookWarehouse.Properties.AppearanceFocused.Options.UseFont = true;
            this.lookWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookWarehouse.Properties.DropDownRows = 6;
            this.lookWarehouse.Properties.NullText = "";
            this.lookWarehouse.Properties.NullValuePrompt = "Anbar seçimini edin";
            this.lookWarehouse.Properties.ShowFooter = false;
            this.lookWarehouse.Properties.ShowHeader = false;
            this.lookWarehouse.Size = new System.Drawing.Size(316, 32);
            this.lookWarehouse.TabIndex = 0;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.Location = new System.Drawing.Point(9, 58);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl24.Size = new System.Drawing.Size(77, 20);
            this.labelControl24.TabIndex = 5;
            this.labelControl24.Text = "Kateqoriya";
            this.labelControl24.UseMnemonic = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(9, 97);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl6.Size = new System.Drawing.Size(100, 20);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Vergi dərəcəsi";
            this.labelControl6.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 135);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(48, 20);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Status";
            this.labelControl1.UseMnemonic = false;
            // 
            // lookStatus
            // 
            this.lookStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookStatus.Location = new System.Drawing.Point(135, 129);
            this.lookStatus.Name = "lookStatus";
            this.lookStatus.Properties.AllowFocused = false;
            this.lookStatus.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.Appearance.Options.UseFont = true;
            this.lookStatus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.lookStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookStatus.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookStatus.Properties.AppearanceFocused.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.lookStatus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Nunito", 10F);
            this.lookStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.lookStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookStatus.Properties.DropDownRows = 5;
            this.lookStatus.Properties.NullText = "";
            this.lookStatus.Properties.NullValuePrompt = "Vergi dərəcəsini seçin";
            this.lookStatus.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.lookStatus.Properties.ShowFooter = false;
            this.lookStatus.Properties.ShowHeader = false;
            this.lookStatus.Size = new System.Drawing.Size(316, 32);
            this.lookStatus.TabIndex = 3;
            // 
            // fEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(468, 229);
            this.Controls.Add(this.panelControl2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 225);
            this.Name = "fEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul düzəlişi";
            this.Load += new System.EventHandler(this.fEditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lookCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView searchView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LookUpEdit lookTax;
        private DevExpress.XtraEditors.SimpleButton bSave;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookWarehouse;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lookStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}