namespace Barcode_Sales.Forms
{
    partial class fStockReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fStockReport));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bProductDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.bPrint = new DevExpress.XtraEditors.SimpleButton();
            this.bSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 48F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 445F)});
            this.tablePanel1.ShowGrid = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.Size = new System.Drawing.Size(1298, 826);
            this.tablePanel1.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(3, 51);
            this.gridControl1.LookAndFeel.SkinName = "WXI";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bProductDetail});
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(1292, 772);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ActiveFilterEnabled = false;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Hyperlink;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Qruplaşdırmaq üçün sütun başlıqlarını buraya sürükləyin";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 1067;
            this.gridView1.OptionsFind.FindNullPrompt = "Axtarış edin...";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowSeparatorHeight = 1;
            this.gridView1.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView1_CustomDrawFooterCell);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.ColumnEdit = this.bProductDetail;
            this.gridColumn11.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ShowCaption = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // bProductDetail
            // 
            this.bProductDetail.AutoHeight = false;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Nunito", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            serializableAppearanceObject1.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Hyperlink;
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            this.bProductDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Ətraflı", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bProductDetail.Name = "bProductDetail";
            this.bProductDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Təchizatçı adı";
            this.gridColumn1.FieldName = "SupplierName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Kateqoriya";
            this.gridColumn12.FieldName = "CategoryName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Məhsul kodu";
            this.gridColumn3.FieldName = "ProductCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Məhsul adı";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 195;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Barkod";
            this.gridColumn4.FieldName = "Barcode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 97;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Vahid";
            this.gridColumn5.FieldName = "UnitName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 97;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Vergi dərəcəsi";
            this.gridColumn6.FieldName = "TaxName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 97;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Alış qiyməti";
            this.gridColumn7.DisplayFormat.FormatString = "C2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "PurchasePrice";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 97;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Satış qiyməti";
            this.gridColumn8.DisplayFormat.FormatString = "C2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "SalePrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 97;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Təxmini Mənfəət";
            this.gridColumn9.DisplayFormat.FormatString = "C2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Profit";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 97;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Anbar qalığı";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Amount";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 108;
            // 
            // panelControl1
            // 
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.dateStart);
            this.panelControl1.Controls.Add(this.bPrint);
            this.panelControl1.Controls.Add(this.bSearch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(1292, 48);
            this.panelControl1.TabIndex = 0;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = new System.DateTime(2025, 12, 15, 0, 34, 2, 0);
            this.dateStart.Location = new System.Drawing.Point(9, 8);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.AllowFocused = false;
            this.dateStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.Appearance.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.Button.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.Button.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.ButtonHighlighted.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.ButtonHighlighted.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.ButtonPressed.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.ButtonPressed.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.CalendarHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.CalendarHeader.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCell.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellDisabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellDisabled.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellHoliday.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellHoliday.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellInactive.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellInactive.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellPressed.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellPressed.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellSelected.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellSelected.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecial.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecial.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialPressed.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialPressed.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialSelected.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellSpecialSelected.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.DayCellToday.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.DayCellToday.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.HeaderPressed.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.HeaderPressed.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.WeekDay.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.WeekDay.Options.UseFont = true;
            this.dateStart.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dateStart.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dateStart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dateStart.Properties.AppearanceFocused.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceFocused.Options.UseFont = true;
            this.dateStart.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Properties.CalendarTimeProperties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.CalendarTimeProperties.Appearance.Options.UseFont = true;
            this.dateStart.Properties.CalendarTimeProperties.AppearanceDisabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = true;
            this.dateStart.Properties.CalendarTimeProperties.AppearanceFocused.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = true;
            this.dateStart.Properties.CalendarTimeProperties.AppearanceReadOnly.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = true;
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Properties.ShowToday = false;
            this.dateStart.Size = new System.Drawing.Size(138, 32);
            this.dateStart.TabIndex = 3;
            // 
            // bPrint
            // 
            this.bPrint.AllowFocus = false;
            this.bPrint.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bPrint.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.bPrint.Appearance.Options.UseBackColor = true;
            this.bPrint.Appearance.Options.UseFont = true;
            this.bPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.bPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bPrint.ImageOptions.SvgImage")));
            this.bPrint.Location = new System.Drawing.Point(1170, 2);
            this.bPrint.Name = "bPrint";
            this.bPrint.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bPrint.Size = new System.Drawing.Size(120, 44);
            this.bPrint.TabIndex = 2;
            this.bPrint.Text = "Çap et";
            // 
            // bSearch
            // 
            this.bSearch.AllowFocus = false;
            this.bSearch.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.bSearch.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.bSearch.Appearance.Options.UseBackColor = true;
            this.bSearch.Appearance.Options.UseFont = true;
            this.bSearch.Location = new System.Drawing.Point(153, 8);
            this.bSearch.Name = "bSearch";
            this.bSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSearch.Size = new System.Drawing.Size(138, 32);
            this.bSearch.TabIndex = 2;
            this.bSearch.Text = "Axtar";
            // 
            // fStockReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1298, 826);
            this.Controls.Add(this.tablePanel1);
            this.Font = new System.Drawing.Font("Nunito", 10F);
            this.Name = "fStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ANBAR QALIĞI HESABATI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fStockReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProductDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton bSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bProductDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton bPrint;
    }
}