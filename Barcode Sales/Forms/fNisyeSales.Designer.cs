
namespace Barcode_Sales.Forms
{
    partial class fNisyeSales
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bAddCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.bCustomerSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lDebt = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.tNameSurname = new DevExpress.XtraEditors.TextEdit();
            this.gridControlProducts = new DevExpress.XtraGrid.GridControl();
            this.gridProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chCustomerStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.userSaveFooter1 = new NextPOS.UserControls.userSaveFooter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNameSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCustomerStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.bAddCustomer);
            this.panelControl1.Controls.Add(this.bCustomerSearch);
            this.panelControl1.Controls.Add(this.lDebt);
            this.panelControl1.Controls.Add(this.labelControl24);
            this.panelControl1.Controls.Add(this.tNameSurname);
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(595, 114);
            this.panelControl1.TabIndex = 0;
            // 
            // bAddCustomer
            // 
            this.bAddCustomer.AllowFocus = false;
            this.bAddCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddCustomer.Appearance.Font = new System.Drawing.Font("Comfortaa", 11F);
            this.bAddCustomer.Appearance.Options.UseFont = true;
            this.bAddCustomer.Appearance.Options.UseTextOptions = true;
            this.bAddCustomer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bAddCustomer.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.bAddCustomer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bAddCustomer.Location = new System.Drawing.Point(486, 68);
            this.bAddCustomer.Name = "bAddCustomer";
            this.bAddCustomer.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bAddCustomer.Size = new System.Drawing.Size(104, 30);
            this.bAddCustomer.TabIndex = 7;
            this.bAddCustomer.Text = "Yeni";
            this.bAddCustomer.Click += new System.EventHandler(this.bAddCustomer_Click);
            // 
            // bCustomerSearch
            // 
            this.bCustomerSearch.AllowFocus = false;
            this.bCustomerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCustomerSearch.Appearance.Font = new System.Drawing.Font("Comfortaa", 11F);
            this.bCustomerSearch.Appearance.Options.UseFont = true;
            this.bCustomerSearch.Appearance.Options.UseTextOptions = true;
            this.bCustomerSearch.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bCustomerSearch.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.bCustomerSearch.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bCustomerSearch.Location = new System.Drawing.Point(376, 68);
            this.bCustomerSearch.Name = "bCustomerSearch";
            this.bCustomerSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bCustomerSearch.Size = new System.Drawing.Size(104, 30);
            this.bCustomerSearch.TabIndex = 7;
            this.bCustomerSearch.Text = "Axtar";
            this.bCustomerSearch.Click += new System.EventHandler(this.bCustomerSearch_Click);
            // 
            // lDebt
            // 
            this.lDebt.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F, System.Drawing.FontStyle.Bold);
            this.lDebt.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.lDebt.Appearance.Options.UseFont = true;
            this.lDebt.Appearance.Options.UseForeColor = true;
            this.lDebt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lDebt.Location = new System.Drawing.Point(5, 74);
            this.lDebt.Name = "lDebt";
            this.lDebt.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lDebt.Size = new System.Drawing.Size(52, 21);
            this.lDebt.TabIndex = 6;
            this.lDebt.Text = "BORC: ";
            this.lDebt.UseMnemonic = false;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl24.Location = new System.Drawing.Point(7, 5);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl24.Size = new System.Drawing.Size(71, 21);
            this.labelControl24.TabIndex = 6;
            this.labelControl24.Text = "Ad Soyad";
            this.labelControl24.UseMnemonic = false;
            // 
            // tNameSurname
            // 
            this.tNameSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tNameSurname.Enabled = false;
            this.tNameSurname.Location = new System.Drawing.Point(7, 30);
            this.tNameSurname.Name = "tNameSurname";
            this.tNameSurname.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.tNameSurname.Properties.Appearance.Options.UseFont = true;
            this.tNameSurname.Properties.MaxLength = 250;
            this.tNameSurname.Size = new System.Drawing.Size(583, 32);
            this.tNameSurname.TabIndex = 1;
            // 
            // gridControlProducts
            // 
            this.gridControlProducts.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlProducts.Location = new System.Drawing.Point(5, 125);
            this.gridControlProducts.LookAndFeel.SkinName = "Office 2013";
            this.gridControlProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlProducts.MainView = this.gridProducts;
            this.gridControlProducts.Name = "gridControlProducts";
            this.gridControlProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chCustomerStatus});
            this.gridControlProducts.Size = new System.Drawing.Size(595, 405);
            this.gridControlProducts.TabIndex = 10;
            this.gridControlProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProducts});
            // 
            // gridProducts
            // 
            this.gridProducts.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.gridProducts.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridProducts.Appearance.FocusedRow.Options.UseFont = true;
            this.gridProducts.Appearance.GroupPanel.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridProducts.Appearance.GroupPanel.Options.UseFont = true;
            this.gridProducts.Appearance.GroupRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.GroupRow.Options.UseFont = true;
            this.gridProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProducts.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridProducts.Appearance.Row.Options.UseFont = true;
            this.gridProducts.ColumnPanelRowHeight = 35;
            this.gridProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43});
            this.gridProducts.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridProducts.GridControl = this.gridControlProducts;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.OptionsMenu.EnableColumnMenu = false;
            this.gridProducts.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridProducts.OptionsView.ShowGroupPanel = false;
            this.gridProducts.OptionsView.ShowIndicator = false;
            this.gridProducts.RowHeight = 35;
            // 
            // gridColumn39
            // 
            this.gridColumn39.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn39.AppearanceCell.Options.UseFont = true;
            this.gridColumn39.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn39.AppearanceHeader.Options.UseFont = true;
            this.gridColumn39.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn39.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn39.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn39.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn39.Caption = "Miqdar";
            this.gridColumn39.FieldName = "NameSurname";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 0;
            this.gridColumn39.Width = 336;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn40.AppearanceCell.Options.UseFont = true;
            this.gridColumn40.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn40.AppearanceHeader.Options.UseFont = true;
            this.gridColumn40.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn40.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn40.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn40.Caption = "Məhsul adı";
            this.gridColumn40.FieldName = "Phone";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 1;
            this.gridColumn40.Width = 198;
            // 
            // gridColumn41
            // 
            this.gridColumn41.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn41.AppearanceCell.Options.UseFont = true;
            this.gridColumn41.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn41.AppearanceHeader.Options.UseFont = true;
            this.gridColumn41.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn41.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn41.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn41.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn41.Caption = "Vahid";
            this.gridColumn41.FieldName = "Voen";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 3;
            this.gridColumn41.Width = 197;
            // 
            // gridColumn42
            // 
            this.gridColumn42.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn42.AppearanceCell.Options.UseFont = true;
            this.gridColumn42.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn42.AppearanceHeader.Options.UseFont = true;
            this.gridColumn42.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn42.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn42.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn42.Caption = "Satış qiyməti";
            this.gridColumn42.FieldName = "Address";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 2;
            this.gridColumn42.Width = 292;
            // 
            // gridColumn43
            // 
            this.gridColumn43.AppearanceCell.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridColumn43.AppearanceCell.Options.UseFont = true;
            this.gridColumn43.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn43.AppearanceHeader.Options.UseFont = true;
            this.gridColumn43.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn43.Caption = "Toplam";
            this.gridColumn43.FieldName = "Comment";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.AllowEdit = false;
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 4;
            this.gridColumn43.Width = 244;
            // 
            // chCustomerStatus
            // 
            this.chCustomerStatus.AutoHeight = false;
            this.chCustomerStatus.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1;
            this.chCustomerStatus.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.chCustomerStatus.Name = "chCustomerStatus";
            // 
            // userSaveFooter1
            // 
            this.userSaveFooter1.CancelVisible = true;
            this.userSaveFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userSaveFooter1.Location = new System.Drawing.Point(0, 536);
            this.userSaveFooter1.LookAndFeel.SkinName = "Office 2019 White";
            this.userSaveFooter1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.userSaveFooter1.Name = "userSaveFooter1";
            this.userSaveFooter1.SaveButtonText = "Yadda Saxla";
            this.userSaveFooter1.Size = new System.Drawing.Size(607, 53);
            this.userSaveFooter1.TabIndex = 11;
            this.userSaveFooter1.SaveClick += new System.EventHandler(this.userSaveFooter1_SaveClick);
            this.userSaveFooter1.CancelClick += new System.EventHandler(this.userSaveFooter1_CancelClick);
            // 
            // fNisyeSales
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(607, 589);
            this.Controls.Add(this.userSaveFooter1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlProducts);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fNisyeSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nisyə satışı";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNameSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCustomerStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit tNameSurname;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.SimpleButton bCustomerSearch;
        private DevExpress.XtraEditors.LabelControl lDebt;
        private DevExpress.XtraGrid.GridControl gridControlProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chCustomerStatus;
        private NextPOS.UserControls.userSaveFooter userSaveFooter1;
        private DevExpress.XtraEditors.SimpleButton bAddCustomer;
    }
}