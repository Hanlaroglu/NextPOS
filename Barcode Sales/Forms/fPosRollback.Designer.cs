namespace Barcode_Sales.Forms
{
    partial class fPosRollback
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPosRollback));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlSalesData = new DevExpress.XtraGrid.GridControl();
            this.gridSalesData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bReturnSale = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageDate = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.dateFinish = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pageFıscal = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.tFiscalId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pageReceiptNo = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.tReceiptNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chFiscalId = new DevExpress.XtraEditors.CheckEdit();
            this.chReceiptNo = new DevExpress.XtraEditors.CheckEdit();
            this.chDate = new DevExpress.XtraEditors.CheckEdit();
            this.bSearch = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtnReturn = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bReturnSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.pageDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            this.pageFıscal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tFiscalId.Properties)).BeginInit();
            this.pageReceiptNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tReceiptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFiscalId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chReceiptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlSalesData
            // 
            this.gridControlSalesData.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.SetColumn(this.gridControlSalesData, 0);
            this.gridControlSalesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSalesData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSalesData.Location = new System.Drawing.Point(2, 218);
            this.gridControlSalesData.LookAndFeel.SkinName = "WXI";
            this.gridControlSalesData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlSalesData.MainView = this.gridSalesData;
            this.gridControlSalesData.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlSalesData.Name = "gridControlSalesData";
            this.gridControlSalesData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bReturnSale});
            this.tablePanel1.SetRow(this.gridControlSalesData, 1);
            this.gridControlSalesData.Size = new System.Drawing.Size(1362, 599);
            this.gridControlSalesData.TabIndex = 13;
            this.gridControlSalesData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSalesData});
            // 
            // gridSalesData
            // 
            this.gridSalesData.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridSalesData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridSalesData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 11F, System.Drawing.FontStyle.Bold);
            this.gridSalesData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridSalesData.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridSalesData.Appearance.OddRow.Options.UseBackColor = true;
            this.gridSalesData.Appearance.Row.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridSalesData.Appearance.Row.Options.UseFont = true;
            this.gridSalesData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridSalesData.ColumnPanelRowHeight = 40;
            this.gridSalesData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7});
            this.gridSalesData.DetailHeight = 485;
            this.gridSalesData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridSalesData.GridControl = this.gridControlSalesData;
            this.gridSalesData.Name = "gridSalesData";
            this.gridSalesData.OptionsDetail.ShowDetailTabs = false;
            this.gridSalesData.OptionsEditForm.PopupEditFormWidth = 1067;
            this.gridSalesData.OptionsMenu.EnableColumnMenu = false;
            this.gridSalesData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridSalesData.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridSalesData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridSalesData.OptionsView.ShowGroupPanel = false;
            this.gridSalesData.RowHeight = 40;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Satış tarixi";
            this.gridColumn1.DisplayFormat.FormatString = "dd.MM.yyyy - HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "SaleDateTime";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 194;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "Kassir";
            this.gridColumn5.FieldName = "Cashier";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 194;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.Caption = "Müştəri";
            this.gridColumn6.FieldName = "CustomerName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 194;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Çek nömrəsi";
            this.gridColumn2.FieldName = "ReceiptNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 211;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.Caption = "Ödəniş növü";
            this.gridColumn3.FieldName = "PaymentType";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 235;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "Ümumi məbləğ";
            this.gridColumn4.DisplayFormat.FormatString = "C2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Total";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 215;
            // 
            // gridColumn7
            // 
            this.gridColumn7.ColumnEdit = this.bReturnSale;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ShowCaption = false;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 119;
            // 
            // bReturnSale
            // 
            this.bReturnSale.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(24, 24);
            serializableAppearanceObject5.Font = new System.Drawing.Font("Nunito", 11F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject5.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            serializableAppearanceObject5.Options.UseFont = true;
            serializableAppearanceObject5.Options.UseForeColor = true;
            this.bReturnSale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bReturnSale.Name = "bReturnSale";
            this.bReturnSale.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.bReturnSale.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bReturnSale_ButtonClick);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.gridControlSalesData);
            this.tablePanel1.Controls.Add(this.groupControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 216F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1366, 819);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Nunito", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.groupControl1, 0);
            this.groupControl1.Controls.Add(this.navigationFrame1);
            this.groupControl1.Controls.Add(this.chFiscalId);
            this.groupControl1.Controls.Add(this.chReceiptNo);
            this.groupControl1.Controls.Add(this.chDate);
            this.groupControl1.Controls.Add(this.bSearch);
            this.groupControl1.Controls.Add(this.separatorControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.tablePanel1.SetRow(this.groupControl1, 0);
            this.groupControl1.Size = new System.Drawing.Size(1358, 210);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Geri qaytarma && Ləğv etmə";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.navigationFrame1.Controls.Add(this.pageDate);
            this.navigationFrame1.Controls.Add(this.pageFıscal);
            this.navigationFrame1.Controls.Add(this.pageReceiptNo);
            this.navigationFrame1.Location = new System.Drawing.Point(152, 32);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageDate,
            this.pageReceiptNo,
            this.pageFıscal});
            this.navigationFrame1.SelectedPage = this.pageDate;
            this.navigationFrame1.Size = new System.Drawing.Size(244, 133);
            this.navigationFrame1.TabIndex = 20;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // pageDate
            // 
            this.pageDate.Caption = "pageDate";
            this.pageDate.Controls.Add(this.dateFinish);
            this.pageDate.Controls.Add(this.dateStart);
            this.pageDate.Controls.Add(this.labelControl1);
            this.pageDate.Controls.Add(this.labelControl2);
            this.pageDate.Name = "pageDate";
            this.pageDate.Size = new System.Drawing.Size(244, 133);
            // 
            // dateFinish
            // 
            this.dateFinish.EditValue = null;
            this.dateFinish.Location = new System.Drawing.Point(7, 96);
            this.dateFinish.Name = "dateFinish";
            this.dateFinish.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateFinish.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateFinish.Properties.Appearance.Options.UseFont = true;
            this.dateFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Size = new System.Drawing.Size(234, 32);
            this.dateFinish.TabIndex = 0;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(7, 32);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.dateStart.Properties.Appearance.Options.UseFont = true;
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(234, 32);
            this.dateStart.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(7, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 20);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tarixdən";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tarixədək";
            // 
            // pageFıscal
            // 
            this.pageFıscal.Caption = "pageFıscal";
            this.pageFıscal.Controls.Add(this.tFiscalId);
            this.pageFıscal.Controls.Add(this.labelControl3);
            this.pageFıscal.Name = "pageFıscal";
            this.pageFıscal.Size = new System.Drawing.Size(244, 133);
            // 
            // tFiscalId
            // 
            this.tFiscalId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tFiscalId.EditValue = "";
            this.tFiscalId.Location = new System.Drawing.Point(7, 32);
            this.tFiscalId.Name = "tFiscalId";
            this.tFiscalId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tFiscalId.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tFiscalId.Size = new System.Drawing.Size(234, 28);
            this.tFiscalId.TabIndex = 18;
            this.tFiscalId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tFiscalId_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(7, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 20);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Fiskal ID";
            // 
            // pageReceiptNo
            // 
            this.pageReceiptNo.Caption = "pageReceiptNo";
            this.pageReceiptNo.Controls.Add(this.tReceiptNo);
            this.pageReceiptNo.Controls.Add(this.labelControl4);
            this.pageReceiptNo.Name = "pageReceiptNo";
            this.pageReceiptNo.Size = new System.Drawing.Size(244, 133);
            // 
            // tReceiptNo
            // 
            this.tReceiptNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tReceiptNo.EditValue = "";
            this.tReceiptNo.Location = new System.Drawing.Point(7, 32);
            this.tReceiptNo.Name = "tReceiptNo";
            this.tReceiptNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tReceiptNo.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tReceiptNo.Size = new System.Drawing.Size(234, 28);
            this.tReceiptNo.TabIndex = 22;
            this.tReceiptNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tReceiptNo_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(7, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(82, 20);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Çek nömrəsi";
            // 
            // chFiscalId
            // 
            this.chFiscalId.Location = new System.Drawing.Point(8, 123);
            this.chFiscalId.Name = "chFiscalId";
            this.chFiscalId.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.chFiscalId.Properties.Appearance.Options.UseFont = true;
            this.chFiscalId.Properties.AutoWidth = true;
            this.chFiscalId.Properties.Caption = "Fiskal ID";
            this.chFiscalId.Properties.RadioGroupIndex = 1;
            this.chFiscalId.Size = new System.Drawing.Size(84, 24);
            this.chFiscalId.TabIndex = 19;
            this.chFiscalId.TabStop = false;
            this.chFiscalId.Tag = "FiscalID";
            this.chFiscalId.CheckedChanged += new System.EventHandler(this.SelectedType);
            // 
            // chReceiptNo
            // 
            this.chReceiptNo.Location = new System.Drawing.Point(8, 80);
            this.chReceiptNo.Name = "chReceiptNo";
            this.chReceiptNo.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.chReceiptNo.Properties.Appearance.Options.UseFont = true;
            this.chReceiptNo.Properties.AutoWidth = true;
            this.chReceiptNo.Properties.Caption = "Çek nömrəsi";
            this.chReceiptNo.Properties.RadioGroupIndex = 1;
            this.chReceiptNo.Size = new System.Drawing.Size(110, 24);
            this.chReceiptNo.TabIndex = 19;
            this.chReceiptNo.TabStop = false;
            this.chReceiptNo.Tag = "ReceiptNo";
            this.chReceiptNo.CheckedChanged += new System.EventHandler(this.SelectedType);
            // 
            // chDate
            // 
            this.chDate.EditValue = true;
            this.chDate.Location = new System.Drawing.Point(8, 40);
            this.chDate.Name = "chDate";
            this.chDate.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.chDate.Properties.Appearance.Options.UseFont = true;
            this.chDate.Properties.AutoWidth = true;
            this.chDate.Properties.Caption = "Tarixə görə";
            this.chDate.Properties.RadioGroupIndex = 1;
            this.chDate.Size = new System.Drawing.Size(103, 24);
            this.chDate.TabIndex = 19;
            this.chDate.Tag = "Date";
            this.chDate.CheckedChanged += new System.EventHandler(this.SelectedType);
            // 
            // bSearch
            // 
            this.bSearch.AllowFocus = false;
            this.bSearch.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.bSearch.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.bSearch.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Appearance.Options.UseBackColor = true;
            this.bSearch.Appearance.Options.UseFont = true;
            this.bSearch.Appearance.Options.UseForeColor = true;
            this.bSearch.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSearch.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSearch.AppearanceHovered.Options.UseBackColor = true;
            this.bSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(28, 28);
            this.bSearch.Location = new System.Drawing.Point(159, 171);
            this.bSearch.LookAndFeel.SkinName = "WXI";
            this.bSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bSearch.Name = "bSearch";
            this.bSearch.Padding = new System.Windows.Forms.Padding(3);
            this.bSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSearch.Size = new System.Drawing.Size(234, 32);
            this.bSearch.TabIndex = 17;
            this.bSearch.TabStop = false;
            this.bSearch.Text = "Axtar";
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // separatorControl1
            // 
            this.separatorControl1.AutoSizeMode = true;
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(134, 32);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(19, 155);
            this.separatorControl1.TabIndex = 2;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnReturn,
            this.barBtnCancel});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1366, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 819);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1366, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 819);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1366, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 819);
            // 
            // barBtnReturn
            // 
            this.barBtnReturn.Caption = "Qaytar";
            this.barBtnReturn.Id = 0;
            this.barBtnReturn.ItemAppearance.Disabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnReturn.ItemAppearance.Disabled.Options.UseFont = true;
            this.barBtnReturn.ItemAppearance.Hovered.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnReturn.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnReturn.ItemAppearance.Normal.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnReturn.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnReturn.ItemAppearance.Pressed.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Bold);
            this.barBtnReturn.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnReturn.Name = "barBtnReturn";
            this.barBtnReturn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnReturn.Size = new System.Drawing.Size(100, 50);
            this.barBtnReturn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnReturn_ItemClick);
            // 
            // barBtnCancel
            // 
            this.barBtnCancel.Caption = "Ləğv et";
            this.barBtnCancel.Id = 1;
            this.barBtnCancel.ItemAppearance.Disabled.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnCancel.ItemAppearance.Disabled.Options.UseFont = true;
            this.barBtnCancel.ItemAppearance.Hovered.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnCancel.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnCancel.ItemAppearance.Normal.Font = new System.Drawing.Font("Nunito", 10F);
            this.barBtnCancel.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnCancel.ItemAppearance.Pressed.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Bold);
            this.barBtnCancel.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnCancel.Name = "barBtnCancel";
            this.barBtnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.barBtnCancel.Size = new System.Drawing.Size(100, 50);
            this.barBtnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCancel_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnReturn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCancel)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // fPosRollback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1366, 819);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "fPosRollback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qaytarma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSalesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bReturnSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.pageDate.ResumeLayout(false);
            this.pageDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            this.pageFıscal.ResumeLayout(false);
            this.pageFıscal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tFiscalId.Properties)).EndInit();
            this.pageReceiptNo.ResumeLayout(false);
            this.pageReceiptNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tReceiptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFiscalId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chReceiptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateFinish;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.SimpleButton bSearch;
        private DevExpress.XtraEditors.TextEdit tFiscalId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gridControlSalesData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSalesData;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage pageFıscal;
        private DevExpress.XtraEditors.CheckEdit chFiscalId;
        private DevExpress.XtraEditors.CheckEdit chReceiptNo;
        private DevExpress.XtraEditors.CheckEdit chDate;
        private DevExpress.XtraEditors.TextEdit tReceiptNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraBars.Navigation.NavigationPage pageDate;
        private DevExpress.XtraBars.Navigation.NavigationPage pageReceiptNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bReturnSale;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtnReturn;
        private DevExpress.XtraBars.BarButtonItem barBtnCancel;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}