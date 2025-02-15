namespace Barcode_Sales.Forms
{
    partial class fSupplierPaidData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSupplierPaidData));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel5 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bSearch = new DevExpress.XtraEditors.SimpleButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateFinish = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.gridControlSupplierDebt = new DevExpress.XtraGrid.GridControl();
            this.gridSupplierDebt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn71 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn72 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bPaySuppliersDebt = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel5)).BeginInit();
            this.tablePanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSupplierDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPaySuppliersDebt)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel5
            // 
            this.tablePanel5.Appearance.BackColor = System.Drawing.Color.White;
            this.tablePanel5.Appearance.Options.UseBackColor = true;
            this.tablePanel5.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel5.Controls.Add(this.panelControl1);
            this.tablePanel5.Controls.Add(this.gridControlSupplierDebt);
            this.tablePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel5.Location = new System.Drawing.Point(0, 0);
            this.tablePanel5.LookAndFeel.SkinName = "WXI";
            this.tablePanel5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tablePanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanel5.Name = "tablePanel5";
            this.tablePanel5.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel5.Size = new System.Drawing.Size(998, 766);
            this.tablePanel5.TabIndex = 7;
            // 
            // panelControl1
            // 
            this.tablePanel5.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.bSearch);
            this.panelControl1.Controls.Add(this.label10);
            this.panelControl1.Controls.Add(this.label11);
            this.panelControl1.Controls.Add(this.dateFinish);
            this.panelControl1.Controls.Add(this.dateStart);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel5.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(998, 40);
            this.panelControl1.TabIndex = 14;
            // 
            // bSearch
            // 
            this.bSearch.AllowFocus = false;
            this.bSearch.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.bSearch.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Appearance.Options.UseFont = true;
            this.bSearch.Appearance.Options.UseForeColor = true;
            this.bSearch.AppearanceDisabled.ForeColor = System.Drawing.Color.White;
            this.bSearch.AppearanceDisabled.Options.UseForeColor = true;
            this.bSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bSearch.ImageOptions.SvgImage")));
            this.bSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.bSearch.Location = new System.Drawing.Point(447, 4);
            this.bSearch.Margin = new System.Windows.Forms.Padding(0);
            this.bSearch.Name = "bSearch";
            this.bSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSearch.Size = new System.Drawing.Size(104, 32);
            this.bSearch.TabIndex = 18;
            this.bSearch.Text = "Axtar";
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.Location = new System.Drawing.Point(12, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "Tarixdən";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 12F);
            this.label11.Location = new System.Drawing.Point(227, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 18);
            this.label11.TabIndex = 17;
            this.label11.Text = "Tarixədək";
            // 
            // dateFinish
            // 
            this.dateFinish.EditValue = null;
            this.dateFinish.Location = new System.Drawing.Point(308, 4);
            this.dateFinish.Name = "dateFinish";
            this.dateFinish.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateFinish.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dateFinish.Properties.Appearance.Options.UseFont = true;
            this.dateFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFinish.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.False;
            this.dateFinish.Size = new System.Drawing.Size(130, 32);
            this.dateFinish.TabIndex = 14;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(84, 4);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dateStart.Properties.Appearance.Options.UseFont = true;
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.False;
            this.dateStart.Size = new System.Drawing.Size(130, 32);
            this.dateStart.TabIndex = 15;
            // 
            // gridControlSupplierDebt
            // 
            this.tablePanel5.SetColumn(this.gridControlSupplierDebt, 0);
            this.gridControlSupplierDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSupplierDebt.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridControlSupplierDebt.Location = new System.Drawing.Point(3, 43);
            this.gridControlSupplierDebt.LookAndFeel.SkinName = "WXI";
            this.gridControlSupplierDebt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlSupplierDebt.MainView = this.gridSupplierDebt;
            this.gridControlSupplierDebt.Name = "gridControlSupplierDebt";
            this.gridControlSupplierDebt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bPaySuppliersDebt});
            this.tablePanel5.SetRow(this.gridControlSupplierDebt, 1);
            this.gridControlSupplierDebt.Size = new System.Drawing.Size(992, 720);
            this.gridControlSupplierDebt.TabIndex = 13;
            this.gridControlSupplierDebt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSupplierDebt});
            // 
            // gridSupplierDebt
            // 
            this.gridSupplierDebt.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridSupplierDebt.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridSupplierDebt.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridSupplierDebt.Appearance.OddRow.Options.UseBackColor = true;
            this.gridSupplierDebt.ColumnPanelRowHeight = 35;
            this.gridSupplierDebt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn53,
            this.gridColumn71,
            this.gridColumn65,
            this.gridColumn1,
            this.gridColumn67,
            this.gridColumn69,
            this.gridColumn72,
            this.gridColumn66});
            this.gridSupplierDebt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridSupplierDebt.GridControl = this.gridControlSupplierDebt;
            this.gridSupplierDebt.Name = "gridSupplierDebt";
            this.gridSupplierDebt.OptionsMenu.EnableColumnMenu = false;
            this.gridSupplierDebt.OptionsMenu.EnableFooterMenu = false;
            this.gridSupplierDebt.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridSupplierDebt.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridSupplierDebt.OptionsView.ShowIndicator = false;
            this.gridSupplierDebt.RowHeight = 35;
            // 
            // gridColumn53
            // 
            this.gridColumn53.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn53.AppearanceCell.Options.UseFont = true;
            this.gridColumn53.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn53.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn53.AppearanceHeader.Options.UseFont = true;
            this.gridColumn53.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn53.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn53.Caption = "#";
            this.gridColumn53.FieldName = "#";
            this.gridColumn53.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.AllowEdit = false;
            this.gridColumn53.OptionsColumn.ReadOnly = true;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 0;
            this.gridColumn53.Width = 39;
            // 
            // gridColumn71
            // 
            this.gridColumn71.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn71.AppearanceCell.Options.UseFont = true;
            this.gridColumn71.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn71.AppearanceHeader.Options.UseFont = true;
            this.gridColumn71.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn71.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn71.Caption = "Təchizatçı";
            this.gridColumn71.FieldName = "SuppliersDebt.Supplier.SupplierName";
            this.gridColumn71.Name = "gridColumn71";
            this.gridColumn71.OptionsColumn.AllowEdit = false;
            this.gridColumn71.Visible = true;
            this.gridColumn71.VisibleIndex = 1;
            this.gridColumn71.Width = 189;
            // 
            // gridColumn65
            // 
            this.gridColumn65.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn65.AppearanceCell.Options.UseFont = true;
            this.gridColumn65.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn65.AppearanceHeader.Options.UseFont = true;
            this.gridColumn65.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn65.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn65.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn65.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn65.Caption = "Borc adı";
            this.gridColumn65.FieldName = "SuppliersDebt.Name";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsColumn.AllowEdit = false;
            this.gridColumn65.OptionsColumn.ReadOnly = true;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 2;
            this.gridColumn65.Width = 177;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Ödəniş tarixi";
            this.gridColumn1.DisplayFormat.FormatString = "d";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "PayDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn67
            // 
            this.gridColumn67.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn67.AppearanceCell.Options.UseFont = true;
            this.gridColumn67.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn67.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn67.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn67.AppearanceHeader.Options.UseFont = true;
            this.gridColumn67.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn67.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn67.Caption = "Əsas ödəniş";
            this.gridColumn67.DisplayFormat.FormatString = "C2";
            this.gridColumn67.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn67.FieldName = "DebtPaid";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.AllowEdit = false;
            this.gridColumn67.OptionsColumn.ReadOnly = true;
            this.gridColumn67.Visible = true;
            this.gridColumn67.VisibleIndex = 4;
            this.gridColumn67.Width = 92;
            // 
            // gridColumn69
            // 
            this.gridColumn69.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn69.AppearanceCell.Options.UseFont = true;
            this.gridColumn69.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn69.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn69.AppearanceHeader.Options.UseFont = true;
            this.gridColumn69.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn69.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn69.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn69.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn69.Caption = "ƏDV ödənişi";
            this.gridColumn69.DisplayFormat.FormatString = "C2";
            this.gridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn69.FieldName = "TaxPaid";
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn69.OptionsColumn.AllowEdit = false;
            this.gridColumn69.OptionsColumn.ReadOnly = true;
            this.gridColumn69.Visible = true;
            this.gridColumn69.VisibleIndex = 5;
            this.gridColumn69.Width = 94;
            // 
            // gridColumn72
            // 
            this.gridColumn72.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn72.AppearanceCell.Options.UseFont = true;
            this.gridColumn72.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn72.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn72.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn72.AppearanceHeader.Options.UseFont = true;
            this.gridColumn72.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn72.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn72.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn72.Caption = "Toplam Ödənilən məbləğ";
            this.gridColumn72.DisplayFormat.FormatString = "C2";
            this.gridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn72.FieldName = "TotalPaid";
            this.gridColumn72.Name = "gridColumn72";
            this.gridColumn72.OptionsColumn.AllowEdit = false;
            this.gridColumn72.Visible = true;
            this.gridColumn72.VisibleIndex = 6;
            this.gridColumn72.Width = 141;
            // 
            // gridColumn66
            // 
            this.gridColumn66.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn66.AppearanceCell.Options.UseFont = true;
            this.gridColumn66.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn66.AppearanceHeader.Options.UseFont = true;
            this.gridColumn66.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn66.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn66.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn66.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn66.Caption = "Qeyd";
            this.gridColumn66.FieldName = "Comment";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.AllowEdit = false;
            this.gridColumn66.OptionsColumn.ReadOnly = true;
            this.gridColumn66.Visible = true;
            this.gridColumn66.VisibleIndex = 7;
            this.gridColumn66.Width = 146;
            // 
            // bPaySuppliersDebt
            // 
            this.bPaySuppliersDebt.AutoHeight = false;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(133)))), ((int)(((byte)(116)))));
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            this.bPaySuppliersDebt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "ÖDƏNİŞ ET", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bPaySuppliersDebt.Name = "bPaySuppliersDebt";
            this.bPaySuppliersDebt.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // fSupplierPaidData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(998, 766);
            this.Controls.Add(this.tablePanel5);
            this.Name = "fSupplierPaidData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Təchizatçı ödənişləri";
            this.Load += new System.EventHandler(this.fSupplierPaidData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel5)).EndInit();
            this.tablePanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSupplierDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPaySuppliersDebt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel5;
        private DevExpress.XtraGrid.GridControl gridControlSupplierDebt;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSupplierDebt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn71;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn65;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn67;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn69;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn72;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bPaySuppliersDebt;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton bSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.DateEdit dateFinish;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}