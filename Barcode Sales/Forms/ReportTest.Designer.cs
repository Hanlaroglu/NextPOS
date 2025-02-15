
namespace Barcode_Sales.Forms
{
    partial class ReportTest
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComponentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFontSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOX = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(150, 108);
            this.gridControl1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(773, 384);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Nunito", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComponentName,
            this.colFontSize,
            this.colVisible,
            this.colX,
            this.colY,
            this.colAX,
            this.colBL,
            this.colIT,
            this.colOX});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colComponentName
            // 
            this.colComponentName.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.colComponentName.AppearanceHeader.Options.UseFont = true;
            this.colComponentName.AppearanceHeader.Options.UseTextOptions = true;
            this.colComponentName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colComponentName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colComponentName.Caption = "Komponentin adı";
            this.colComponentName.Name = "colComponentName";
            this.colComponentName.Visible = true;
            this.colComponentName.VisibleIndex = 0;
            this.colComponentName.Width = 371;
            // 
            // colFontSize
            // 
            this.colFontSize.AppearanceCell.Options.UseTextOptions = true;
            this.colFontSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFontSize.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.colFontSize.AppearanceHeader.Options.UseFont = true;
            this.colFontSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colFontSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFontSize.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colFontSize.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFontSize.Caption = "Şiriftin ölçüsü";
            this.colFontSize.MaxWidth = 80;
            this.colFontSize.MinWidth = 80;
            this.colFontSize.Name = "colFontSize";
            this.colFontSize.Visible = true;
            this.colFontSize.VisibleIndex = 1;
            this.colFontSize.Width = 80;
            // 
            // colVisible
            // 
            this.colVisible.AppearanceCell.Options.UseTextOptions = true;
            this.colVisible.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVisible.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.colVisible.AppearanceHeader.Options.UseFont = true;
            this.colVisible.AppearanceHeader.Options.UseTextOptions = true;
            this.colVisible.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVisible.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colVisible.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVisible.Caption = "Görünmə Statusu";
            this.colVisible.MaxWidth = 80;
            this.colVisible.MinWidth = 80;
            this.colVisible.Name = "colVisible";
            this.colVisible.Visible = true;
            this.colVisible.VisibleIndex = 2;
            this.colVisible.Width = 80;
            // 
            // colX
            // 
            this.colX.AppearanceCell.Options.UseTextOptions = true;
            this.colX.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colX.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.colX.AppearanceHeader.Options.UseFont = true;
            this.colX.AppearanceHeader.Options.UseTextOptions = true;
            this.colX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colX.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colX.Caption = "X";
            this.colX.MaxWidth = 40;
            this.colX.MinWidth = 40;
            this.colX.Name = "colX";
            this.colX.Visible = true;
            this.colX.VisibleIndex = 3;
            this.colX.Width = 40;
            // 
            // colY
            // 
            this.colY.AppearanceCell.Options.UseTextOptions = true;
            this.colY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colY.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F);
            this.colY.AppearanceHeader.Options.UseFont = true;
            this.colY.AppearanceHeader.Options.UseTextOptions = true;
            this.colY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colY.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colY.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colY.Caption = "Y";
            this.colY.MaxWidth = 40;
            this.colY.MinWidth = 40;
            this.colY.Name = "colY";
            this.colY.Visible = true;
            this.colY.VisibleIndex = 4;
            this.colY.Width = 40;
            // 
            // colAX
            // 
            this.colAX.AppearanceCell.Options.UseTextOptions = true;
            this.colAX.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAX.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Underline);
            this.colAX.AppearanceHeader.Options.UseFont = true;
            this.colAX.AppearanceHeader.Options.UseTextOptions = true;
            this.colAX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAX.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colAX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAX.Caption = "AX";
            this.colAX.MaxWidth = 35;
            this.colAX.MinWidth = 35;
            this.colAX.Name = "colAX";
            this.colAX.Visible = true;
            this.colAX.VisibleIndex = 5;
            this.colAX.Width = 35;
            // 
            // colBL
            // 
            this.colBL.AppearanceCell.Options.UseTextOptions = true;
            this.colBL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBL.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Bold);
            this.colBL.AppearanceHeader.Options.UseFont = true;
            this.colBL.AppearanceHeader.Options.UseTextOptions = true;
            this.colBL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBL.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colBL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBL.Caption = "BL";
            this.colBL.MaxWidth = 35;
            this.colBL.MinWidth = 35;
            this.colBL.Name = "colBL";
            this.colBL.Visible = true;
            this.colBL.VisibleIndex = 6;
            this.colBL.Width = 35;
            // 
            // colIT
            // 
            this.colIT.AppearanceCell.Options.UseTextOptions = true;
            this.colIT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIT.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Italic);
            this.colIT.AppearanceHeader.Options.UseFont = true;
            this.colIT.AppearanceHeader.Options.UseTextOptions = true;
            this.colIT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIT.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colIT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIT.Caption = "IT";
            this.colIT.MaxWidth = 35;
            this.colIT.MinWidth = 35;
            this.colIT.Name = "colIT";
            this.colIT.Visible = true;
            this.colIT.VisibleIndex = 7;
            this.colIT.Width = 35;
            // 
            // colOX
            // 
            this.colOX.AppearanceCell.Options.UseTextOptions = true;
            this.colOX.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOX.AppearanceHeader.Font = new System.Drawing.Font("Nunito", 10F, System.Drawing.FontStyle.Strikeout);
            this.colOX.AppearanceHeader.Options.UseFont = true;
            this.colOX.AppearanceHeader.Options.UseTextOptions = true;
            this.colOX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOX.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.colOX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOX.Caption = "OX";
            this.colOX.MaxWidth = 35;
            this.colOX.MinWidth = 35;
            this.colOX.Name = "colOX";
            this.colOX.Visible = true;
            this.colOX.VisibleIndex = 8;
            this.colOX.Width = 35;
            // 
            // ReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 600);
            this.Controls.Add(this.gridControl1);
            this.Name = "ReportTest";
            this.Text = "ReportTest";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colComponentName;
        private DevExpress.XtraGrid.Columns.GridColumn colFontSize;
        private DevExpress.XtraGrid.Columns.GridColumn colVisible;
        private DevExpress.XtraGrid.Columns.GridColumn colX;
        private DevExpress.XtraGrid.Columns.GridColumn colY;
        private DevExpress.XtraGrid.Columns.GridColumn colAX;
        private DevExpress.XtraGrid.Columns.GridColumn colBL;
        private DevExpress.XtraGrid.Columns.GridColumn colIT;
        private DevExpress.XtraGrid.Columns.GridColumn colOX;
    }
}