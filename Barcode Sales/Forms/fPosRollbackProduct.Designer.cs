namespace Barcode_Sales.Forms
{
    partial class fPosRollbackProduct
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPosRollbackProduct));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlSalesData = new DevExpress.XtraGrid.GridControl();
            this.gridSalesData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinReturnAmount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bReturnSale = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tCustomer = new DevExpress.XtraEditors.TextEdit();
            this.tCashier = new DevExpress.XtraEditors.TextEdit();
            this.tPaymentType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tReceiptNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tSaleDatetime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinReturnAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bReturnSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCashier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tReceiptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSaleDatetime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.gridControlSalesData);
            this.tablePanel1.Controls.Add(this.groupControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 231F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 49F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1171, 711);
            this.tablePanel1.TabIndex = 1;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.bSubmit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(4, 235);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(1163, 43);
            this.panelControl1.TabIndex = 14;
            // 
            // bSubmit
            // 
            this.bSubmit.AllowFocus = false;
            this.bSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bSubmit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.bSubmit.Appearance.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.bSubmit.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bSubmit.Appearance.Options.UseBackColor = true;
            this.bSubmit.Appearance.Options.UseFont = true;
            this.bSubmit.Appearance.Options.UseForeColor = true;
            this.bSubmit.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSubmit.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bSubmit.AppearanceHovered.Options.UseBackColor = true;
            this.bSubmit.ImageOptions.SvgImageSize = new System.Drawing.Size(28, 28);
            this.bSubmit.Location = new System.Drawing.Point(8, 4);
            this.bSubmit.LookAndFeel.SkinName = "WXI";
            this.bSubmit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Padding = new System.Windows.Forms.Padding(3);
            this.bSubmit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSubmit.Size = new System.Drawing.Size(163, 34);
            this.bSubmit.TabIndex = 25;
            this.bSubmit.TabStop = false;
            this.bSubmit.Text = "Qaytar";
            // 
            // gridControlSalesData
            // 
            this.gridControlSalesData.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.tablePanel1.SetColumn(this.gridControlSalesData, 0);
            this.gridControlSalesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSalesData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSalesData.Location = new System.Drawing.Point(2, 282);
            this.gridControlSalesData.LookAndFeel.SkinName = "WXI";
            this.gridControlSalesData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlSalesData.MainView = this.gridSalesData;
            this.gridControlSalesData.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlSalesData.Name = "gridControlSalesData";
            this.gridControlSalesData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.spinReturnAmount,
            this.bReturnSale});
            this.tablePanel1.SetRow(this.gridControlSalesData, 2);
            this.gridControlSalesData.Size = new System.Drawing.Size(1167, 427);
            this.gridControlSalesData.TabIndex = 13;
            this.gridControlSalesData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSalesData});
            // 
            // gridSalesData
            // 
            this.gridSalesData.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridSalesData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridSalesData.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridSalesData.Appearance.OddRow.Options.UseBackColor = true;
            this.gridSalesData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridSalesData.ColumnPanelRowHeight = 40;
            this.gridSalesData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colBarcode,
            this.colProductName,
            this.colQuantity,
            this.colUnitName,
            this.colSalePrice,
            this.colTotal,
            this.colTaxName,
            this.colReturnQuantity});
            this.gridSalesData.DetailHeight = 485;
            this.gridSalesData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridSalesData.GridControl = this.gridControlSalesData;
            this.gridSalesData.Name = "gridSalesData";
            this.gridSalesData.OptionsDetail.ShowDetailTabs = false;
            this.gridSalesData.OptionsEditForm.PopupEditFormWidth = 1067;
            this.gridSalesData.OptionsMenu.EnableColumnMenu = false;
            this.gridSalesData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridSalesData.OptionsSelection.MultiSelect = true;
            this.gridSalesData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridSalesData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridSalesData.OptionsView.ShowGroupPanel = false;
            this.gridSalesData.OptionsView.ShowIndicator = false;
            this.gridSalesData.RowHeight = 40;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // colBarcode
            // 
            this.colBarcode.AppearanceHeader.Options.UseTextOptions = true;
            this.colBarcode.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colBarcode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBarcode.Caption = "Barkod";
            this.colBarcode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.AllowEdit = false;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            this.colBarcode.Width = 164;
            // 
            // colProductName
            // 
            this.colProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colProductName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductName.Caption = "Məhsul adı";
            this.colProductName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsColumn.AllowEdit = false;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            this.colProductName.Width = 237;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQuantity.Caption = "Miqdar";
            this.colQuantity.DisplayFormat.FormatString = "N3";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            this.colQuantity.Width = 112;
            // 
            // colUnitName
            // 
            this.colUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colUnitName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUnitName.Caption = "Vahid";
            this.colUnitName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.OptionsColumn.AllowEdit = false;
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 4;
            this.colUnitName.Width = 114;
            // 
            // colSalePrice
            // 
            this.colSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSalePrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colSalePrice.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colSalePrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSalePrice.Caption = "Satış qiyməti";
            this.colSalePrice.DisplayFormat.FormatString = "C2";
            this.colSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalePrice.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.OptionsColumn.AllowEdit = false;
            this.colSalePrice.Visible = true;
            this.colSalePrice.VisibleIndex = 5;
            this.colSalePrice.Width = 139;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotal.Caption = "Ümumi məbləğ";
            this.colTotal.DisplayFormat.FormatString = "C2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 6;
            this.colTotal.Width = 132;
            // 
            // colTaxName
            // 
            this.colTaxName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTaxName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colTaxName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTaxName.Caption = "Vergi dərəcəsi";
            this.colTaxName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colTaxName.Name = "colTaxName";
            this.colTaxName.OptionsColumn.AllowEdit = false;
            this.colTaxName.Visible = true;
            this.colTaxName.VisibleIndex = 7;
            this.colTaxName.Width = 117;
            // 
            // colReturnQuantity
            // 
            this.colReturnQuantity.AppearanceCell.BackColor = System.Drawing.Color.DarkOrange;
            this.colReturnQuantity.AppearanceCell.Options.UseBackColor = true;
            this.colReturnQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colReturnQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colReturnQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colReturnQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReturnQuantity.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colReturnQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colReturnQuantity.Caption = "Qaytarılacaq miqdar";
            this.colReturnQuantity.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colReturnQuantity.Name = "colReturnQuantity";
            this.colReturnQuantity.OptionsFilter.AllowAutoFilter = false;
            this.colReturnQuantity.OptionsFilter.AllowFilter = false;
            this.colReturnQuantity.Visible = true;
            this.colReturnQuantity.VisibleIndex = 8;
            this.colReturnQuantity.Width = 152;
            // 
            // spinReturnAmount
            // 
            this.spinReturnAmount.AutoHeight = false;
            this.spinReturnAmount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinReturnAmount.Name = "spinReturnAmount";
            // 
            // bReturnSale
            // 
            this.bReturnSale.AutoHeight = false;
            editorButtonImageOptions3.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            editorButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions3.SvgImage")));
            editorButtonImageOptions3.SvgImageSize = new System.Drawing.Size(24, 24);
            serializableAppearanceObject9.Font = new System.Drawing.Font("Nunito", 11F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject9.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            serializableAppearanceObject9.Options.UseFont = true;
            serializableAppearanceObject9.Options.UseForeColor = true;
            this.bReturnSale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "QAYTAR", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bReturnSale.Name = "bReturnSale";
            this.bReturnSale.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl1
            // 
            this.tablePanel1.SetColumn(this.groupControl1, 0);
            this.groupControl1.Controls.Add(this.tCustomer);
            this.groupControl1.Controls.Add(this.tCashier);
            this.groupControl1.Controls.Add(this.tPaymentType);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.tTotal);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tReceiptNo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tSaleDatetime);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.tablePanel1.SetRow(this.groupControl1, 0);
            this.groupControl1.Size = new System.Drawing.Size(1163, 225);
            this.groupControl1.TabIndex = 0;
            // 
            // tCustomer
            // 
            this.tCustomer.EditValue = "";
            this.tCustomer.Location = new System.Drawing.Point(8, 188);
            this.tCustomer.Name = "tCustomer";
            this.tCustomer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tCustomer.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tCustomer.Properties.ReadOnly = true;
            this.tCustomer.Size = new System.Drawing.Size(234, 32);
            this.tCustomer.TabIndex = 24;
            // 
            // tCashier
            // 
            this.tCashier.EditValue = "";
            this.tCashier.Location = new System.Drawing.Point(8, 122);
            this.tCashier.Name = "tCashier";
            this.tCashier.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tCashier.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tCashier.Properties.ReadOnly = true;
            this.tCashier.Size = new System.Drawing.Size(234, 32);
            this.tCashier.TabIndex = 24;
            // 
            // tPaymentType
            // 
            this.tPaymentType.EditValue = "";
            this.tPaymentType.Location = new System.Drawing.Point(337, 188);
            this.tPaymentType.Name = "tPaymentType";
            this.tPaymentType.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tPaymentType.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tPaymentType.Properties.ReadOnly = true;
            this.tPaymentType.Size = new System.Drawing.Size(234, 32);
            this.tPaymentType.TabIndex = 24;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(337, 162);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(85, 20);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Ödəniş növü";
            // 
            // tTotal
            // 
            this.tTotal.EditValue = "26.00 ₼";
            this.tTotal.Location = new System.Drawing.Point(337, 122);
            this.tTotal.Name = "tTotal";
            this.tTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.tTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tTotal.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tTotal.Properties.ReadOnly = true;
            this.tTotal.Size = new System.Drawing.Size(234, 32);
            this.tTotal.TabIndex = 24;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(337, 96);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(103, 20);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Ümumi məbləğ";
            // 
            // tReceiptNo
            // 
            this.tReceiptNo.EditValue = "";
            this.tReceiptNo.Location = new System.Drawing.Point(337, 58);
            this.tReceiptNo.Name = "tReceiptNo";
            this.tReceiptNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tReceiptNo.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tReceiptNo.Properties.ReadOnly = true;
            this.tReceiptNo.Size = new System.Drawing.Size(234, 32);
            this.tReceiptNo.TabIndex = 24;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(337, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 20);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Çek nömrəsi";
            // 
            // tSaleDatetime
            // 
            this.tSaleDatetime.EditValue = "";
            this.tSaleDatetime.Location = new System.Drawing.Point(8, 58);
            this.tSaleDatetime.Name = "tSaleDatetime";
            this.tSaleDatetime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tSaleDatetime.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tSaleDatetime.Properties.ReadOnly = true;
            this.tSaleDatetime.Size = new System.Drawing.Size(234, 32);
            this.tSaleDatetime.TabIndex = 24;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(124, 20);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Satış tarixi və vaxtı";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(8, 162);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 20);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Müştəri";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(8, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(115, 20);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "Satışı edən kassir";
            // 
            // fPosRollbackProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1171, 711);
            this.Controls.Add(this.tablePanel1);
            this.Name = "fPosRollbackProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSalesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinReturnAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bReturnSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCashier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tReceiptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSaleDatetime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControlSalesData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSalesData;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bReturnSale;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinReturnAmount;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit tCustomer;
        private DevExpress.XtraEditors.TextEdit tCashier;
        private DevExpress.XtraEditors.TextEdit tSaleDatetime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit tPaymentType;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit tTotal;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit tReceiptNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxName;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnQuantity;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton bSubmit;
    }
}