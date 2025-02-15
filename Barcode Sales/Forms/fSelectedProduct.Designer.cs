
namespace Barcode_Sales.Forms
{
    partial class fSelectedProduct<TParent>
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
            this.gridControlProducts = new DevExpress.XtraGrid.GridControl();
            this.gridProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlisQiymet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.bRefresh = new NextPOS.UserControls.ButtonRadius();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookWarehouse.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlProducts
            // 
            this.gridControlProducts.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProducts.Location = new System.Drawing.Point(0, 40);
            this.gridControlProducts.LookAndFeel.SkinName = "Office 2013";
            this.gridControlProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlProducts.MainView = this.gridProducts;
            this.gridControlProducts.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlProducts.Name = "gridControlProducts";
            this.gridControlProducts.Size = new System.Drawing.Size(648, 453);
            this.gridControlProducts.TabIndex = 8;
            this.gridControlProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProducts});
            // 
            // gridProducts
            // 
            this.gridProducts.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.FocusedRow.Options.UseFont = true;
            this.gridProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProducts.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.Row.Options.UseFont = true;
            this.gridProducts.ColumnPanelRowHeight = 35;
            this.gridProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colProductCode,
            this.colProductName,
            this.colBarcode,
            this.colPrice,
            this.colAlisQiymet});
            this.gridProducts.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridProducts.GridControl = this.gridControlProducts;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.OptionsMenu.EnableColumnMenu = false;
            this.gridProducts.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridProducts.OptionsView.ShowIndicator = false;
            this.gridProducts.RowHeight = 35;
            this.gridProducts.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridProducts_RowClick);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // colProductCode
            // 
            this.colProductCode.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colProductCode.AppearanceCell.Options.UseFont = true;
            this.colProductCode.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.colProductCode.AppearanceHeader.Options.UseFont = true;
            this.colProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductCode.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colProductCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductCode.Caption = "Məhsul kodu";
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.OptionsColumn.AllowEdit = false;
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            this.colProductCode.Width = 137;
            // 
            // colProductName
            // 
            this.colProductName.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colProductName.AppearanceCell.Options.UseFont = true;
            this.colProductName.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.colProductName.AppearanceHeader.Options.UseFont = true;
            this.colProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colProductName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductName.Caption = "Məhsul adı";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsColumn.AllowEdit = false;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            this.colProductName.Width = 234;
            // 
            // colBarcode
            // 
            this.colBarcode.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colBarcode.AppearanceCell.Options.UseFont = true;
            this.colBarcode.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.colBarcode.AppearanceHeader.Options.UseFont = true;
            this.colBarcode.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarcode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBarcode.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colBarcode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBarcode.Caption = "Barkod";
            this.colBarcode.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.AllowEdit = false;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 2;
            this.colBarcode.Width = 155;
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colPrice.AppearanceCell.Options.UseFont = true;
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPrice.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.colPrice.AppearanceHeader.Options.UseFont = true;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPrice.Caption = "Satış qiyməti";
            this.colPrice.DisplayFormat.FormatString = "C2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "SalePrice";
            this.colPrice.MaxWidth = 110;
            this.colPrice.MinWidth = 110;
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 110;
            // 
            // colAlisQiymet
            // 
            this.colAlisQiymet.Caption = "Alış Qiyməti";
            this.colAlisQiymet.FieldName = "PurchasePrice";
            this.colAlisQiymet.Name = "colAlisQiymet";
            this.colAlisQiymet.OptionsColumn.AllowEdit = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.lookWarehouse);
            this.panelControl1.Controls.Add(this.labelControl17);
            this.panelControl1.Controls.Add(this.bRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Office 2019 White";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(648, 40);
            this.panelControl1.TabIndex = 9;
            // 
            // lookWarehouse
            // 
            this.lookWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lookWarehouse.Enabled = false;
            this.lookWarehouse.Location = new System.Drawing.Point(66, 6);
            this.lookWarehouse.Name = "lookWarehouse";
            this.lookWarehouse.Properties.AllowFocused = false;
            this.lookWarehouse.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.lookWarehouse.Properties.Appearance.Options.UseFont = true;
            this.lookWarehouse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.lookWarehouse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookWarehouse.Properties.AppearanceFocused.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.lookWarehouse.Properties.AppearanceFocused.Options.UseFont = true;
            this.lookWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookWarehouse.Properties.NullText = "MƏRKƏZİ ANBAR";
            this.lookWarehouse.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookWarehouse.Properties.ShowFooter = false;
            this.lookWarehouse.Properties.ShowHeader = false;
            this.lookWarehouse.Properties.SortColumnIndex = 1;
            this.lookWarehouse.Size = new System.Drawing.Size(161, 28);
            this.lookWarehouse.TabIndex = 8;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl17.Location = new System.Drawing.Point(12, 10);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl17.Size = new System.Drawing.Size(48, 21);
            this.labelControl17.TabIndex = 8;
            this.labelControl17.Text = "Anbar";
            this.labelControl17.UseMnemonic = false;
            // 
            // bRefresh
            // 
            this.bRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bRefresh.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bRefresh.BorderRadius = 10;
            this.bRefresh.BorderSize = 0;
            this.bRefresh.FlatAppearance.BorderSize = 0;
            this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRefresh.Font = new System.Drawing.Font("Comfortaa", 8.75F);
            this.bRefresh.ForeColor = System.Drawing.Color.White;
            this.bRefresh.Location = new System.Drawing.Point(542, 4);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(103, 33);
            this.bRefresh.TabIndex = 14;
            this.bRefresh.Text = "Yenilə";
            this.bRefresh.TextColor = System.Drawing.Color.White;
            this.bRefresh.UseVisualStyleBackColor = false;
            this.bRefresh.Visible = false;
            // 
            // fSelectedProduct
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(648, 493);
            this.Controls.Add(this.gridControlProducts);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fSelectedProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul seçimi";
            this.Load += new System.EventHandler(this.fSelectedProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookWarehouse.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProducts;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAlisQiymet;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookWarehouse;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private NextPOS.UserControls.ButtonRadius bRefresh;
    }
}