
namespace Barcode_Sales.Forms
{
    partial class fSelected
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
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageCategory = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControlCategories = new DevExpress.XtraGrid.GridControl();
            this.gridCategories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bRefresh = new NextPOS.UserControls.ButtonRadius();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.pageCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Appearance.BackColor = System.Drawing.Color.White;
            this.navigationFrame1.Appearance.Options.UseBackColor = true;
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Controls.Add(this.pageCategory);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 40);
            this.navigationFrame1.LookAndFeel.SkinName = "Office 2019 White";
            this.navigationFrame1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageCategory,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.pageCategory;
            this.navigationFrame1.Size = new System.Drawing.Size(704, 561);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(704, 561);
            // 
            // pageCategory
            // 
            this.pageCategory.Caption = "pageCategory";
            this.pageCategory.Controls.Add(this.gridControlCategories);
            this.pageCategory.Name = "pageCategory";
            this.pageCategory.Size = new System.Drawing.Size(704, 561);
            // 
            // gridControlCategories
            // 
            this.gridControlCategories.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControlCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCategories.Location = new System.Drawing.Point(0, 0);
            this.gridControlCategories.LookAndFeel.SkinName = "Office 2013";
            this.gridControlCategories.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlCategories.MainView = this.gridCategories;
            this.gridControlCategories.Margin = new System.Windows.Forms.Padding(1);
            this.gridControlCategories.Name = "gridControlCategories";
            this.gridControlCategories.Size = new System.Drawing.Size(704, 561);
            this.gridControlCategories.TabIndex = 7;
            this.gridControlCategories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridCategories});
            // 
            // gridCategories
            // 
            this.gridCategories.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridCategories.Appearance.FocusedRow.Options.UseFont = true;
            this.gridCategories.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.gridCategories.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridCategories.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridCategories.Appearance.Row.Options.UseFont = true;
            this.gridCategories.ColumnPanelRowHeight = 35;
            this.gridCategories.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategoryName});
            this.gridCategories.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridCategories.GridControl = this.gridControlCategories;
            this.gridCategories.Name = "gridCategories";
            this.gridCategories.OptionsMenu.EnableColumnMenu = false;
            this.gridCategories.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridCategories.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridCategories.OptionsView.ShowIndicator = false;
            this.gridCategories.RowHeight = 35;
            this.gridCategories.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridCategories_RowClick);
            // 
            // colCategoryName
            // 
            this.colCategoryName.AppearanceCell.Font = new System.Drawing.Font("Nunito", 12F);
            this.colCategoryName.AppearanceCell.Options.UseFont = true;
            this.colCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.colCategoryName.AppearanceHeader.Options.UseFont = true;
            this.colCategoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCategoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategoryName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colCategoryName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCategoryName.Caption = "Kateqoriya adı";
            this.colCategoryName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.OptionsColumn.AllowEdit = false;
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 0;
            this.colCategoryName.Width = 155;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bRefresh);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.dateStart);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Office 2019 White";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(704, 40);
            this.panelControl1.TabIndex = 1;
            // 
            // bRefresh
            // 
            this.bRefresh.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.bRefresh.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.bRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.bRefresh.BorderRadius = 10;
            this.bRefresh.BorderSize = 0;
            this.bRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.bRefresh.FlatAppearance.BorderSize = 0;
            this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRefresh.Font = new System.Drawing.Font("Comfortaa", 12F);
            this.bRefresh.ForeColor = System.Drawing.Color.White;
            this.bRefresh.Location = new System.Drawing.Point(599, 2);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(103, 36);
            this.bRefresh.TabIndex = 14;
            this.bRefresh.Text = "Yenilə";
            this.bRefresh.TextColor = System.Drawing.Color.White;
            this.bRefresh.UseVisualStyleBackColor = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(326, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 21);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tarixədək";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(77, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 21);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Tarixdən";
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(399, 8);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 8F);
            this.dateEnd.Properties.Appearance.Options.UseFont = true;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(139, 24);
            this.dateEnd.TabIndex = 2;
            // 
            // dateStart
            // 
            this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(144, 8);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Appearance.Font = new System.Drawing.Font("Comfortaa", 8F);
            this.dateStart.Properties.Appearance.Options.UseFont = true;
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Size = new System.Drawing.Size(139, 24);
            this.dateStart.TabIndex = 2;
            // 
            // fSelected
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.LookAndFeel.SkinName = "Office 2019 White";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "fSelected";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fSelected_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.pageCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage pageCategory;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private NextPOS.UserControls.ButtonRadius bRefresh;
        private DevExpress.XtraGrid.GridControl gridControlCategories;
        private DevExpress.XtraGrid.Views.Grid.GridView gridCategories;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
    }
}