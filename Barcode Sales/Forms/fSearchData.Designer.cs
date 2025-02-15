
namespace Barcode_Sales.Forms
{
    partial class fSearchData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSearchData));
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControlSelected = new DevExpress.XtraGrid.GridControl();
            this.gridSelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.bHesabatSearch = new DevExpress.XtraEditors.SimpleButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateHesabat2 = new DevExpress.XtraEditors.DateEdit();
            this.dateHesabat1 = new DevExpress.XtraEditors.DateEdit();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat1.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame1.Margin = new System.Windows.Forms.Padding(0);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage1;
            this.navigationFrame1.Size = new System.Drawing.Size(618, 568);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.gridControlSelected);
            this.navigationPage1.Controls.Add(this.panelControl4);
            this.navigationPage1.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(618, 568);
            // 
            // gridControlSelected
            // 
            this.gridControlSelected.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSelected.Location = new System.Drawing.Point(0, 43);
            this.gridControlSelected.LookAndFeel.SkinName = "Office 2013";
            this.gridControlSelected.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlSelected.MainView = this.gridSelected;
            this.gridControlSelected.Name = "gridControlSelected";
            this.gridControlSelected.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bDetail});
            this.gridControlSelected.Size = new System.Drawing.Size(618, 525);
            this.gridControlSelected.TabIndex = 16;
            this.gridControlSelected.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSelected});
            // 
            // gridSelected
            // 
            this.gridSelected.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.gridSelected.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridSelected.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridSelected.Appearance.FocusedRow.Options.UseFont = true;
            this.gridSelected.Appearance.GroupPanel.Font = new System.Drawing.Font("Nunito", 10F);
            this.gridSelected.Appearance.GroupPanel.Options.UseFont = true;
            this.gridSelected.Appearance.GroupRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridSelected.Appearance.GroupRow.Options.UseFont = true;
            this.gridSelected.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridSelected.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridSelected.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridSelected.Appearance.Row.Options.UseFont = true;
            this.gridSelected.ColumnPanelRowHeight = 35;
            this.gridSelected.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn1});
            this.gridSelected.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridSelected.GridControl = this.gridControlSelected;
            this.gridSelected.Name = "gridSelected";
            this.gridSelected.OptionsMenu.EnableColumnMenu = false;
            this.gridSelected.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridSelected.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridSelected.OptionsView.ShowGroupPanel = false;
            this.gridSelected.OptionsView.ShowIndicator = false;
            this.gridSelected.RowHeight = 35;
            this.gridSelected.DoubleClick += new System.EventHandler(this.gridSelected_DoubleClick);
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
            this.gridColumn39.Caption = "Ad soyad";
            this.gridColumn39.FieldName = "NameSurname";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 0;
            this.gridColumn39.Width = 234;
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
            this.gridColumn40.Caption = "Telefon";
            this.gridColumn40.FieldName = "Phone";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 1;
            this.gridColumn40.Width = 138;
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
            this.gridColumn41.Caption = "Vöen";
            this.gridColumn41.FieldName = "Voen";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
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
            this.gridColumn42.Caption = "Ünvan";
            this.gridColumn42.FieldName = "Address";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
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
            this.gridColumn43.Caption = "Qeyd";
            this.gridColumn43.FieldName = "Comment";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.AllowEdit = false;
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 2;
            this.gridColumn43.Width = 172;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Comfortaa SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Ətraflı";
            this.gridColumn1.ColumnEdit = this.bDetail;
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn1.MaxWidth = 65;
            this.gridColumn1.MinWidth = 65;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 65;
            // 
            // bDetail
            // 
            this.bDetail.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = global::Barcode_Sales.Properties.Resources.showcomments1;
            editorButtonImageOptions1.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.bDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bDetail.LookAndFeel.SkinName = "Office 2019 White";
            this.bDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bDetail.Name = "bDetail";
            this.bDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.bDetail.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bDetail_ButtonClick);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.bHesabatSearch);
            this.panelControl4.Controls.Add(this.label10);
            this.panelControl4.Controls.Add(this.label11);
            this.panelControl4.Controls.Add(this.dateHesabat2);
            this.panelControl4.Controls.Add(this.dateHesabat1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.LookAndFeel.SkinName = "Office 2019 White";
            this.panelControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(618, 43);
            this.panelControl4.TabIndex = 15;
            // 
            // bHesabatSearch
            // 
            this.bHesabatSearch.AllowFocus = false;
            this.bHesabatSearch.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.bHesabatSearch.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bHesabatSearch.Appearance.Options.UseFont = true;
            this.bHesabatSearch.Appearance.Options.UseForeColor = true;
            this.bHesabatSearch.AppearanceDisabled.ForeColor = System.Drawing.Color.White;
            this.bHesabatSearch.AppearanceDisabled.Options.UseForeColor = true;
            this.bHesabatSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bHesabatSearch.ImageOptions.SvgImage")));
            this.bHesabatSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.bHesabatSearch.Location = new System.Drawing.Point(446, 9);
            this.bHesabatSearch.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.bHesabatSearch.Name = "bHesabatSearch";
            this.bHesabatSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bHesabatSearch.Size = new System.Drawing.Size(86, 24);
            this.bHesabatSearch.TabIndex = 13;
            this.bHesabatSearch.Text = "Axtar";
            this.bHesabatSearch.Click += new System.EventHandler(this.bHesabatSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.Location = new System.Drawing.Point(11, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Tarixdən";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 12F);
            this.label11.Location = new System.Drawing.Point(226, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "Tarixədək";
            // 
            // dateHesabat2
            // 
            this.dateHesabat2.EditValue = null;
            this.dateHesabat2.Location = new System.Drawing.Point(307, 9);
            this.dateHesabat2.Name = "dateHesabat2";
            this.dateHesabat2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateHesabat2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dateHesabat2.Properties.Appearance.Options.UseFont = true;
            this.dateHesabat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateHesabat2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateHesabat2.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.dateHesabat2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateHesabat2.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.False;
            this.dateHesabat2.Size = new System.Drawing.Size(130, 24);
            this.dateHesabat2.TabIndex = 11;
            // 
            // dateHesabat1
            // 
            this.dateHesabat1.EditValue = null;
            this.dateHesabat1.Location = new System.Drawing.Point(83, 9);
            this.dateHesabat1.Name = "dateHesabat1";
            this.dateHesabat1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateHesabat1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.dateHesabat1.Properties.Appearance.Options.UseFont = true;
            this.dateHesabat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateHesabat1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateHesabat1.Properties.LookAndFeel.SkinName = "Office 2019 White";
            this.dateHesabat1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateHesabat1.Properties.ShowOk = DevExpress.Utils.DefaultBoolean.False;
            this.dateHesabat1.Size = new System.Drawing.Size(130, 24);
            this.dateHesabat1.TabIndex = 11;
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(618, 568);
            // 
            // colComment
            // 
            this.colComment.AppearanceCell.Font = new System.Drawing.Font("Cera Pro", 16F);
            this.colComment.AppearanceCell.Options.UseFont = true;
            this.colComment.AppearanceHeader.Font = new System.Drawing.Font("Cera Pro", 16F, System.Drawing.FontStyle.Bold);
            this.colComment.AppearanceHeader.Options.UseFont = true;
            this.colComment.Caption = "Qeyd";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.OptionsColumn.AllowEdit = false;
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 0;
            this.colComment.Width = 338;
            // 
            // fSearchData
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(618, 568);
            this.Controls.Add(this.navigationFrame1);
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fSearchData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Axtar";
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHesabat1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton bHesabatSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.DateEdit dateHesabat2;
        private DevExpress.XtraEditors.DateEdit dateHesabat1;
        private DevExpress.XtraGrid.GridControl gridControlSelected;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bDetail;
    }
}