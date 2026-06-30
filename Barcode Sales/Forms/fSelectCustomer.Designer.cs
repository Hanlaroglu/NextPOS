namespace Barcode_Sales.Forms
{
    partial class fSelectCustomer<T>
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControlCustomers = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.bProductDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tSearchCustomer = new DevExpress.XtraEditors.ButtonEdit();
            this.bAddCustomer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSearchCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Müştəri adı";
            this.gridColumn2.FieldName = "NameSurname";
            this.gridColumn2.MinWidth = 31;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 117;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceCell.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Balans";
            this.gridColumn3.DisplayFormat.FormatString = "C2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Balance";
            this.gridColumn3.MinWidth = 31;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ShowCaption = true;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.AllowInHeaderSearch = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 117;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Qrup";
            this.gridColumn5.FieldName = "CustomerGroup.Name";
            this.gridColumn5.MinWidth = 31;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 117;
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "Təvəllüd";
            this.layoutViewColumn1.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.layoutViewColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.layoutViewColumn1.FieldName = "DateBirth";
            this.layoutViewColumn1.MinWidth = 25;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            this.layoutViewColumn1.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn1.OptionsColumn.AllowFocus = false;
            this.layoutViewColumn1.OptionsColumn.ShowCaption = true;
            this.layoutViewColumn1.Visible = true;
            this.layoutViewColumn1.VisibleIndex = 3;
            this.layoutViewColumn1.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Telefon";
            this.gridColumn4.FieldName = "Phone";
            this.gridColumn4.MinWidth = 31;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ShowCaption = true;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 117;
            // 
            // gridControlCustomers
            // 
            this.gridControlCustomers.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.SetColumn(this.gridControlCustomers, 0);
            this.gridControlCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCustomers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlCustomers.Location = new System.Drawing.Point(1, 52);
            this.gridControlCustomers.LookAndFeel.SkinName = "WXI";
            this.gridControlCustomers.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlCustomers.MainView = this.tileView1;
            this.gridControlCustomers.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlCustomers.Name = "gridControlCustomers";
            this.gridControlCustomers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bProductDelete});
            this.tablePanel1.SetRow(this.gridControlCustomers, 1);
            this.gridControlCustomers.Size = new System.Drawing.Size(566, 538);
            this.gridControlCustomers.TabIndex = 13;
            this.gridControlCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.ActiveFilterEnabled = false;
            this.tileView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.layoutViewColumn1,
            this.gridColumn5,
            this.gridColumn3});
            this.tileView1.DetailHeight = 437;
            this.tileView1.GridControl = this.gridControlCustomers;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsBehavior.ReadOnly = true;
            this.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.tileView1.OptionsTiles.IndentBetweenGroups = 0;
            this.tileView1.OptionsTiles.IndentBetweenItems = 0;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(690, 100);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.RowCount = 0;
            this.tileView1.TileColumns.Add(tableColumnDefinition1);
            this.tileView1.TileColumns.Add(tableColumnDefinition2);
            this.tileView1.TileColumns.Add(tableColumnDefinition3);
            tableRowDefinition1.Length.Value = 27D;
            tableRowDefinition2.Length.Value = 27D;
            tableRowDefinition3.Length.Value = 30D;
            this.tileView1.TileRows.Add(tableRowDefinition1);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            this.tileView1.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnIndex = 2;
            tableSpan1.RowSpan = 3;
            this.tileView1.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Column = this.gridColumn2;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement1.Text = "gridColumn2";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = this.gridColumn3;
            tileViewItemElement2.ColumnIndex = 2;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement2.Text = "gridColumn3";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Column = this.gridColumn5;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement3.RowIndex = 1;
            tileViewItemElement3.Text = "gridColumn5";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Column = this.layoutViewColumn1;
            tileViewItemElement4.ColumnIndex = 1;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement4.Text = "layoutViewColumn1";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.Column = this.gridColumn4;
            tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileViewItemElement5.RowIndex = 2;
            tileViewItemElement5.Text = "gridColumn4";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileView1_ItemClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.MinWidth = 31;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 117;
            // 
            // bProductDelete
            // 
            this.bProductDelete.AutoHeight = false;
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(24, 24);
            this.bProductDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bProductDelete.Name = "bProductDelete";
            this.bProductDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.bAddCustomer);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.gridControlCustomers);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 51F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 540F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.ShowGrid = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.Size = new System.Drawing.Size(568, 626);
            this.tablePanel1.TabIndex = 14;
            // 
            // panelControl1
            // 
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.tSearchCustomer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(562, 45);
            this.panelControl1.TabIndex = 14;
            // 
            // tSearchCustomer
            // 
            this.tSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSearchCustomer.Location = new System.Drawing.Point(5, 5);
            this.tSearchCustomer.Name = "tSearchCustomer";
            this.tSearchCustomer.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.tSearchCustomer.Properties.Appearance.Options.UseFont = true;
            this.tSearchCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.tSearchCustomer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tSearchCustomer.Properties.NullValuePrompt = "Müştəri axtar...";
            this.tSearchCustomer.Size = new System.Drawing.Size(552, 36);
            this.tSearchCustomer.TabIndex = 7;
            this.tSearchCustomer.EditValueChanged += new System.EventHandler(this.tSearchCustomer_EditValueChanged);
            // 
            // bAddCustomer
            // 
            this.bAddCustomer.AllowFocus = false;
            this.bAddCustomer.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bAddCustomer.Appearance.Font = new System.Drawing.Font("Poppins", 11F);
            this.bAddCustomer.Appearance.Options.UseBackColor = true;
            this.bAddCustomer.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.bAddCustomer, 0);
            this.bAddCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAddCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.bAddCustomer.ImageOptions.SvgImage = global::Barcode_Sales.Properties.Resources.add_svg;
            this.bAddCustomer.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.bAddCustomer.Location = new System.Drawing.Point(0, 591);
            this.bAddCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.bAddCustomer.Name = "bAddCustomer";
            this.tablePanel1.SetRow(this.bAddCustomer, 2);
            this.bAddCustomer.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bAddCustomer.Size = new System.Drawing.Size(568, 35);
            this.bAddCustomer.TabIndex = 15;
            this.bAddCustomer.Text = "Yeni müştəri";
            this.bAddCustomer.Click += new System.EventHandler(this.bAddCustomer_Click);
            // 
            // fSelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(568, 626);
            this.Controls.Add(this.tablePanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 660);
            this.MinimumSize = new System.Drawing.Size(570, 660);
            this.Name = "fSelectCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müştəri seçimi";
            this.Shown += new System.EventHandler(this.fSelectCustomer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tSearchCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCustomers;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bProductDelete;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ButtonEdit tSearchCustomer;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.TileViewColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.TileViewColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton bAddCustomer;
    }
}