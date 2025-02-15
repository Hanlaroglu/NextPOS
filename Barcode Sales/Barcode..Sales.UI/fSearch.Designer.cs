
namespace Barcode_Sales.Barcode.Sales.UI
{
    partial class fSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSearch));
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageNull = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pageProduct = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lStock = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lBarcode = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lPrice = new DevExpress.XtraEditors.LabelControl();
            this.lComment = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lProductName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.listComplete = new DevExpress.XtraEditors.ListBoxControl();
            this.tBarcode = new DevExpress.XtraEditors.TextEdit();
            this.tName = new DevExpress.XtraEditors.TextEdit();
            this.tCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.pageNull.SuspendLayout();
            this.pageProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.navigationFrame1.Controls.Add(this.pageNull);
            this.navigationFrame1.Controls.Add(this.pageProduct);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(500, 0);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageNull,
            this.pageProduct});
            this.navigationFrame1.SelectedPage = this.pageNull;
            this.navigationFrame1.Size = new System.Drawing.Size(698, 768);
            this.navigationFrame1.TabIndex = 9;
            // 
            // pageNull
            // 
            this.pageNull.Caption = "pageNull";
            this.pageNull.Controls.Add(this.labelControl3);
            this.pageNull.Name = "pageNull";
            this.pageNull.Size = new System.Drawing.Size(698, 768);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 26F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(111)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.labelControl3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl3.ImageOptions.SvgImage")));
            this.labelControl3.ImageOptions.SvgImageSize = new System.Drawing.Size(96, 96);
            this.labelControl3.Location = new System.Drawing.Point(0, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl3.Size = new System.Drawing.Size(698, 768);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Məhsul seçimi edilmədi";
            this.labelControl3.UseMnemonic = false;
            // 
            // pageProduct
            // 
            this.pageProduct.Caption = "pageProduct";
            this.pageProduct.Controls.Add(this.panelControl2);
            this.pageProduct.Name = "pageProduct";
            this.pageProduct.Size = new System.Drawing.Size(698, 768);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl2.Controls.Add(this.tablePanel1);
            this.panelControl2.Controls.Add(this.lProductName);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(698, 200);
            this.panelControl2.TabIndex = 15;
            // 
            // tablePanel1
            // 
            this.tablePanel1.AutoSize = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 11F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 49.14F)});
            this.tablePanel1.Controls.Add(this.lStock);
            this.tablePanel1.Controls.Add(this.separatorControl1);
            this.tablePanel1.Controls.Add(this.labelControl6);
            this.tablePanel1.Controls.Add(this.lBarcode);
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.lPrice);
            this.tablePanel1.Controls.Add(this.lComment);
            this.tablePanel1.Controls.Add(this.labelControl4);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(2, 63);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 85.53F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 14.47F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 31F)});
            this.tablePanel1.Size = new System.Drawing.Size(694, 135);
            this.tablePanel1.TabIndex = 16;
            // 
            // lStock
            // 
            this.lStock.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.lStock.Appearance.Options.UseFont = true;
            this.lStock.Appearance.Options.UseTextOptions = true;
            this.lStock.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lStock.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lStock, 1);
            this.lStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lStock.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lStock.Location = new System.Drawing.Point(23, 83);
            this.lStock.Name = "lStock";
            this.lStock.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.lStock, 4);
            this.lStock.Size = new System.Drawing.Size(668, 49);
            this.lStock.TabIndex = 17;
            this.lStock.Text = "0";
            this.lStock.UseMnemonic = false;
            // 
            // separatorControl1
            // 
            this.separatorControl1.AutoSizeMode = true;
            this.tablePanel1.SetColumn(this.separatorControl1, 0);
            this.tablePanel1.SetColumnSpan(this.separatorControl1, 2);
            this.separatorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separatorControl1.LineThickness = 1;
            this.separatorControl1.Location = new System.Drawing.Point(3, 63);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tablePanel1.SetRow(this.separatorControl1, 3);
            this.separatorControl1.Size = new System.Drawing.Size(688, 14);
            this.separatorControl1.TabIndex = 18;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.tablePanel1.SetColumn(this.labelControl6, 0);
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl6.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl6.ImageOptions.Image")));
            this.labelControl6.Location = new System.Drawing.Point(0, 80);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.labelControl6, 4);
            this.labelControl6.Size = new System.Drawing.Size(20, 55);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Miqdar     :";
            this.labelControl6.UseMnemonic = false;
            // 
            // lBarcode
            // 
            this.lBarcode.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.lBarcode.Appearance.Options.UseFont = true;
            this.lBarcode.Appearance.Options.UseTextOptions = true;
            this.lBarcode.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lBarcode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lBarcode, 1);
            this.lBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBarcode.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lBarcode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lBarcode.ImageOptions.SvgImage")));
            this.lBarcode.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.lBarcode.Location = new System.Drawing.Point(23, 3);
            this.lBarcode.Name = "lBarcode";
            this.lBarcode.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.lBarcode, 0);
            this.lBarcode.Size = new System.Drawing.Size(668, 14);
            this.lBarcode.TabIndex = 17;
            this.lBarcode.Text = "Null";
            this.lBarcode.UseMnemonic = false;
            this.lBarcode.Click += new System.EventHandler(this.lBarcode_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.tablePanel1.SetColumn(this.labelControl2, 0);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl2.ImageOptions.SvgImage")));
            this.labelControl2.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl2.Location = new System.Drawing.Point(0, 40);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.labelControl2, 2);
            this.labelControl2.Size = new System.Drawing.Size(20, 20);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Açıqlama :";
            this.labelControl2.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl1.Location = new System.Drawing.Point(0, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.labelControl1, 1);
            this.labelControl1.Size = new System.Drawing.Size(20, 20);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Qiymət     :";
            this.labelControl1.UseMnemonic = false;
            // 
            // lPrice
            // 
            this.lPrice.Appearance.Font = new System.Drawing.Font("Nunito", 14F, System.Drawing.FontStyle.Bold);
            this.lPrice.Appearance.Options.UseFont = true;
            this.lPrice.Appearance.Options.UseTextOptions = true;
            this.lPrice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lPrice.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lPrice.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lPrice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lPrice, 1);
            this.lPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPrice.Location = new System.Drawing.Point(23, 23);
            this.lPrice.Name = "lPrice";
            this.lPrice.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.lPrice, 1);
            this.lPrice.Size = new System.Drawing.Size(668, 14);
            this.lPrice.TabIndex = 16;
            this.lPrice.Text = "0.00";
            this.lPrice.UseMnemonic = false;
            // 
            // lComment
            // 
            this.lComment.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.lComment.Appearance.Options.UseFont = true;
            this.lComment.Appearance.Options.UseTextOptions = true;
            this.lComment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lComment.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lComment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lComment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lComment, 1);
            this.lComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lComment.Location = new System.Drawing.Point(23, 43);
            this.lComment.Name = "lComment";
            this.lComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.lComment, 2);
            this.lComment.Size = new System.Drawing.Size(668, 14);
            this.lComment.TabIndex = 16;
            this.lComment.Text = "Null";
            this.lComment.UseMnemonic = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.tablePanel1.SetColumn(this.labelControl4, 0);
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl4.ImageOptions.SvgImage")));
            this.labelControl4.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelControl4.Location = new System.Drawing.Point(0, 0);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tablePanel1.SetRow(this.labelControl4, 0);
            this.labelControl4.Size = new System.Drawing.Size(20, 20);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Barkod     :";
            this.labelControl4.UseMnemonic = false;
            // 
            // lProductName
            // 
            this.lProductName.Appearance.Font = new System.Drawing.Font("Nunito Black", 20F, System.Drawing.FontStyle.Bold);
            this.lProductName.Appearance.Options.UseFont = true;
            this.lProductName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lProductName.Location = new System.Drawing.Point(2, 2);
            this.lProductName.Name = "lProductName";
            this.lProductName.Padding = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lProductName.Size = new System.Drawing.Size(694, 61);
            this.lProductName.TabIndex = 16;
            this.lProductName.Text = "Məhsul adı";
            this.lProductName.UseMnemonic = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tBarcode);
            this.panelControl1.Controls.Add(this.tName);
            this.panelControl1.Controls.Add(this.tCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(496, 134);
            this.panelControl1.TabIndex = 15;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.listComplete);
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(500, 768);
            this.panelControl3.TabIndex = 15;
            // 
            // listComplete
            // 
            this.listComplete.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.listComplete.Appearance.Options.UseFont = true;
            this.listComplete.Appearance.Options.UseTextOptions = true;
            this.listComplete.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.listComplete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.listComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listComplete.Location = new System.Drawing.Point(2, 136);
            this.listComplete.LookAndFeel.SkinName = "Office 2019 White";
            this.listComplete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.listComplete.Name = "listComplete";
            this.listComplete.ShowFocusRect = false;
            this.listComplete.Size = new System.Drawing.Size(496, 630);
            this.listComplete.TabIndex = 16;
            this.listComplete.TabStop = false;
            this.listComplete.SelectedIndexChanged += new System.EventHandler(this.listComplete_SelectedIndexChanged);
            // 
            // tBarcode
            // 
            this.tBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBarcode.Location = new System.Drawing.Point(7, 89);
            this.tBarcode.Name = "tBarcode";
            this.tBarcode.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tBarcode.Properties.Appearance.Options.UseFont = true;
            this.tBarcode.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tBarcode.Properties.ContextImageOptions.SvgImage")));
            this.tBarcode.Properties.ContextImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.tBarcode.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.tBarcode.Properties.Mask.EditMask = "d";
            this.tBarcode.Properties.NullValuePrompt = "Barkod";
            this.tBarcode.Size = new System.Drawing.Size(481, 32);
            this.tBarcode.TabIndex = 2;
            this.tBarcode.EditValueChanged += new System.EventHandler(this.tBarcode_EditValueChanged);
            // 
            // tName
            // 
            this.tName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tName.Location = new System.Drawing.Point(5, 11);
            this.tName.Name = "tName";
            this.tName.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tName.Properties.Appearance.Options.UseFont = true;
            this.tName.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tName.Properties.ContextImageOptions.SvgImage")));
            this.tName.Properties.ContextImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.tName.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.tName.Properties.NullValuePrompt = "Məhsul adı";
            this.tName.Size = new System.Drawing.Size(483, 32);
            this.tName.TabIndex = 0;
            this.tName.EditValueChanged += new System.EventHandler(this.tName_EditValueChanged);
            // 
            // tCode
            // 
            this.tCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCode.Location = new System.Drawing.Point(5, 49);
            this.tCode.Name = "tCode";
            this.tCode.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.tCode.Properties.Appearance.Options.UseFont = true;
            this.tCode.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("tCode.Properties.ContextImageOptions.SvgImage")));
            this.tCode.Properties.ContextImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.tCode.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.tCode.Properties.NullValuePrompt = "Məhsul kodu";
            this.tCode.Size = new System.Drawing.Size(483, 32);
            this.tCode.TabIndex = 1;
            this.tCode.EditValueChanged += new System.EventHandler(this.tCode_EditValueChanged);
            // 
            // fSearch
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1198, 768);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.panelControl3);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul axtarışı et";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.pageNull.ResumeLayout(false);
            this.pageProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage pageNull;
        private DevExpress.XtraBars.Navigation.NavigationPage pageProduct;
        private DevExpress.XtraEditors.TextEdit tBarcode;
        private DevExpress.XtraEditors.TextEdit tCode;
        private DevExpress.XtraEditors.TextEdit tName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lPrice;
        private DevExpress.XtraEditors.LabelControl lComment;
        private DevExpress.XtraEditors.LabelControl lProductName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ListBoxControl listComplete;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lBarcode;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl lStock;
    }
}