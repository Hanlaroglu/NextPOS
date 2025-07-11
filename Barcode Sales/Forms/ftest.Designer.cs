namespace Barcode_Sales.Forms
{
    partial class ftest
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
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.tSearch = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlBasket = new DevExpress.XtraGrid.GridControl();
            this.gridProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiqdar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotals = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chCustomerStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCustomerStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tSearch
            // 
            this.tSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSearch.Location = new System.Drawing.Point(10, 10);
            this.tSearch.Margin = new System.Windows.Forms.Padding(1);
            this.tSearch.Name = "tSearch";
            this.tSearch.Properties.AllowButtonNavigation = DevExpress.Utils.DefaultBoolean.False;
            this.tSearch.Properties.AllowFocused = false;
            this.tSearch.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.tSearch.Properties.Appearance.Options.UseFont = true;
            this.tSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tSearch.Properties.LookAndFeel.SkinName = "WXI";
            this.tSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tSearch.Properties.NullText = "";
            this.tSearch.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.NoBorder;
            this.tSearch.Properties.PopupFindMode = DevExpress.XtraEditors.FindMode.Always;
            this.tSearch.Properties.PopupView = this.searchView;
            this.tSearch.Properties.ShowClearButton = false;
            this.tSearch.Properties.ShowFooter = false;
            this.tSearch.Size = new System.Drawing.Size(1266, 32);
            this.tSearch.TabIndex = 18;
            this.tSearch.EditValueChanged += new System.EventHandler(this.tSearch_EditValueChanged);
            // 
            // searchView
            // 
            this.searchView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.MaxWidth = 25;
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Width = 25;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Təchizatçı";
            this.gridColumn2.FieldName = "SupplierName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Məhsul adı";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Satış qiyməti";
            this.gridColumn4.DisplayFormat.FormatString = "C2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "SalePrice";
            this.gridColumn4.MaxWidth = 130;
            this.gridColumn4.MinWidth = 130;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 130;
            // 
            // gridControlBasket
            // 
            this.gridControlBasket.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlBasket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlBasket.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlBasket.Location = new System.Drawing.Point(10, 472);
            this.gridControlBasket.LookAndFeel.SkinName = "WXI";
            this.gridControlBasket.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlBasket.MainView = this.gridProducts;
            this.gridControlBasket.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlBasket.Name = "gridControlBasket";
            this.gridControlBasket.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chCustomerStatus});
            this.gridControlBasket.Size = new System.Drawing.Size(1266, 280);
            this.gridControlBasket.TabIndex = 19;
            this.gridControlBasket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProducts});
            // 
            // gridProducts
            // 
            this.gridProducts.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.FocusedRow.Options.UseFont = true;
            this.gridProducts.Appearance.GroupPanel.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridProducts.Appearance.GroupPanel.Options.UseFont = true;
            this.gridProducts.Appearance.GroupRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.GroupRow.Options.UseFont = true;
            this.gridProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProducts.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.Row.Options.UseFont = true;
            this.gridProducts.ColumnPanelRowHeight = 48;
            this.gridProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5,
            this.colBarkod,
            this.colPName,
            this.colMiqdar,
            this.colUnit,
            this.colSPrice,
            this.colTotals});
            this.gridProducts.DetailHeight = 485;
            this.gridProducts.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridProducts.GridControl = this.gridControlBasket;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.OptionsEditForm.PopupEditFormWidth = 1067;
            this.gridProducts.OptionsMenu.EnableColumnMenu = false;
            this.gridProducts.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridProducts.OptionsView.ShowGroupPanel = false;
            this.gridProducts.OptionsView.ShowIndicator = false;
            this.gridProducts.RowHeight = 48;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.gridColumn6.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn6.Caption = "№";
            this.gridColumn6.FieldName = "RowNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Id";
            this.gridColumn5.FieldName = "Id";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            // 
            // colBarkod
            // 
            this.colBarkod.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colBarkod.AppearanceCell.Options.UseFont = true;
            this.colBarkod.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colBarkod.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colBarkod.AppearanceHeader.Options.UseBackColor = true;
            this.colBarkod.AppearanceHeader.Options.UseFont = true;
            this.colBarkod.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarkod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBarkod.Caption = "Barkod";
            this.colBarkod.FieldName = "Barcode";
            this.colBarkod.MinWidth = 27;
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.OptionsColumn.AllowEdit = false;
            this.colBarkod.Visible = true;
            this.colBarkod.VisibleIndex = 1;
            this.colBarkod.Width = 244;
            // 
            // colPName
            // 
            this.colPName.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colPName.AppearanceCell.Options.UseFont = true;
            this.colPName.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colPName.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colPName.AppearanceHeader.Options.UseBackColor = true;
            this.colPName.AppearanceHeader.Options.UseFont = true;
            this.colPName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colPName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPName.Caption = "Məhsul adı";
            this.colPName.FieldName = "ProductName";
            this.colPName.MinWidth = 27;
            this.colPName.Name = "colPName";
            this.colPName.OptionsColumn.AllowEdit = false;
            this.colPName.Visible = true;
            this.colPName.VisibleIndex = 2;
            this.colPName.Width = 663;
            // 
            // colMiqdar
            // 
            this.colMiqdar.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colMiqdar.AppearanceCell.Options.UseFont = true;
            this.colMiqdar.AppearanceCell.Options.UseTextOptions = true;
            this.colMiqdar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMiqdar.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colMiqdar.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colMiqdar.AppearanceHeader.Options.UseBackColor = true;
            this.colMiqdar.AppearanceHeader.Options.UseFont = true;
            this.colMiqdar.AppearanceHeader.Options.UseTextOptions = true;
            this.colMiqdar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMiqdar.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colMiqdar.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMiqdar.Caption = "Miqdar";
            this.colMiqdar.FieldName = "Amount";
            this.colMiqdar.MinWidth = 27;
            this.colMiqdar.Name = "colMiqdar";
            this.colMiqdar.OptionsColumn.AllowEdit = false;
            this.colMiqdar.Visible = true;
            this.colMiqdar.VisibleIndex = 3;
            this.colMiqdar.Width = 128;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colUnit.AppearanceCell.Options.UseFont = true;
            this.colUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colUnit.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colUnit.AppearanceHeader.Options.UseBackColor = true;
            this.colUnit.AppearanceHeader.Options.UseFont = true;
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colUnit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUnit.Caption = "Vahid";
            this.colUnit.FieldName = "Unit";
            this.colUnit.MinWidth = 27;
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 4;
            this.colUnit.Width = 141;
            // 
            // colSPrice
            // 
            this.colSPrice.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colSPrice.AppearanceCell.Options.UseFont = true;
            this.colSPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colSPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSPrice.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colSPrice.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colSPrice.AppearanceHeader.Options.UseBackColor = true;
            this.colSPrice.AppearanceHeader.Options.UseFont = true;
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
            this.colSPrice.VisibleIndex = 5;
            this.colSPrice.Width = 169;
            // 
            // colTotals
            // 
            this.colTotals.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.colTotals.AppearanceCell.Options.UseFont = true;
            this.colTotals.AppearanceCell.Options.UseTextOptions = true;
            this.colTotals.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotals.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.colTotals.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.colTotals.AppearanceHeader.Options.UseBackColor = true;
            this.colTotals.AppearanceHeader.Options.UseFont = true;
            this.colTotals.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotals.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotals.Caption = "Toplam";
            this.colTotals.DisplayFormat.FormatString = "C2";
            this.colTotals.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotals.FieldName = "Total";
            this.colTotals.MinWidth = 27;
            this.colTotals.Name = "colTotals";
            this.colTotals.OptionsColumn.AllowEdit = false;
            this.colTotals.Visible = true;
            this.colTotals.VisibleIndex = 6;
            this.colTotals.Width = 188;
            // 
            // chCustomerStatus
            // 
            this.chCustomerStatus.AutoHeight = false;
            this.chCustomerStatus.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chCustomerStatus.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.chCustomerStatus.Name = "chCustomerStatus";
            // 
            // ftest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 780);
            this.Controls.Add(this.gridControlBasket);
            this.Controls.Add(this.tSearch);
            this.Name = "ftest";
            this.Text = "ftest";
            this.Load += new System.EventHandler(this.ftest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBasket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCustomerStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SearchLookUpEdit tSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView searchView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gridControlBasket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkod;
        private DevExpress.XtraGrid.Columns.GridColumn colPName;
        private DevExpress.XtraGrid.Columns.GridColumn colMiqdar;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colSPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotals;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chCustomerStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}