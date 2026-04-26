namespace Barcode_Sales.Forms
{
    partial class fSelectedProduct
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlProducts = new DevExpress.XtraGrid.GridControl();
            this.gridProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bProductSettings = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlProducts
            // 
            this.gridControlProducts.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlProducts.Location = new System.Drawing.Point(0, 0);
            this.gridControlProducts.LookAndFeel.SkinName = "WXI";
            this.gridControlProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlProducts.MainView = this.gridProducts;
            this.gridControlProducts.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlProducts.Name = "gridControlProducts";
            this.gridControlProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bProductSettings});
            this.gridControlProducts.Size = new System.Drawing.Size(909, 674);
            this.gridControlProducts.TabIndex = 21;
            this.gridControlProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProducts});
            // 
            // gridProducts
            // 
            this.gridProducts.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridProducts.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 11F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProducts.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridProducts.Appearance.OddRow.Options.UseBackColor = true;
            this.gridProducts.Appearance.Row.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridProducts.Appearance.Row.Options.UseFont = true;
            this.gridProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn52,
            this.colBarkod,
            this.gridColumn94,
            this.colPName,
            this.colUnit,
            this.colSPrice});
            this.gridProducts.DetailHeight = 50;
            this.gridProducts.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridProducts.GridControl = this.gridControlProducts;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.OptionsBehavior.Editable = false;
            this.gridProducts.OptionsMenu.EnableColumnMenu = false;
            this.gridProducts.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProducts.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridProducts.OptionsView.EnableAppearanceEvenRow = true;
            this.gridProducts.OptionsView.RowAutoHeight = true;
            this.gridProducts.OptionsView.ShowGroupPanel = false;
            this.gridProducts.OptionsView.ShowIndicator = false;
            // 
            // gridColumn52
            // 
            this.gridColumn52.Caption = "Id";
            this.gridColumn52.FieldName = "Id";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.OptionsColumn.AllowEdit = false;
            // 
            // colBarkod
            // 
            this.colBarkod.Caption = "Barkod";
            this.colBarkod.FieldName = "Barcode";
            this.colBarkod.MinWidth = 27;
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.OptionsColumn.AllowEdit = false;
            this.colBarkod.Visible = true;
            this.colBarkod.VisibleIndex = 2;
            this.colBarkod.Width = 141;
            // 
            // gridColumn94
            // 
            this.gridColumn94.Caption = "Kateqoriya";
            this.gridColumn94.FieldName = "CategoryName";
            this.gridColumn94.Name = "gridColumn94";
            this.gridColumn94.OptionsColumn.AllowEdit = false;
            this.gridColumn94.Visible = true;
            this.gridColumn94.VisibleIndex = 0;
            this.gridColumn94.Width = 154;
            // 
            // colPName
            // 
            this.colPName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colPName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPName.Caption = "Məhsul adı";
            this.colPName.FieldName = "ProductName";
            this.colPName.MinWidth = 27;
            this.colPName.Name = "colPName";
            this.colPName.OptionsColumn.AllowEdit = false;
            this.colPName.Visible = true;
            this.colPName.VisibleIndex = 1;
            this.colPName.Width = 358;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colUnit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUnit.Caption = "Vahid";
            this.colUnit.FieldName = "UnitName";
            this.colUnit.MinWidth = 27;
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 3;
            this.colUnit.Width = 94;
            // 
            // colSPrice
            // 
            this.colSPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colSPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colSPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSPrice.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colSPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSPrice.Caption = "Satış qiyməti";
            this.colSPrice.DisplayFormat.FormatString = "C2";
            this.colSPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSPrice.FieldName = "SalePrice";
            this.colSPrice.MinWidth = 27;
            this.colSPrice.Name = "colSPrice";
            this.colSPrice.OptionsColumn.AllowEdit = false;
            this.colSPrice.Visible = true;
            this.colSPrice.VisibleIndex = 4;
            this.colSPrice.Width = 110;
            // 
            // bProductSettings
            // 
            this.bProductSettings.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = global::Barcode_Sales.Properties.Resources.dots_three_circle_vertical_light;
            this.bProductSettings.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bProductSettings.Name = "bProductSettings";
            this.bProductSettings.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // fSelectedProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(909, 674);
            this.Controls.Add(this.gridControlProducts);
            this.Name = "fSelectedProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul seçimi";
            this.Shown += new System.EventHandler(this.fSelectedProduct_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn52;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn94;
        private DevExpress.XtraGrid.Columns.GridColumn colPName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colSPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bProductSettings;
    }
}