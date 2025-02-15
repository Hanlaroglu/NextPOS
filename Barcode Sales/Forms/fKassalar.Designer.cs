
namespace Barcode_Sales.Forms
{
    partial class fKassalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fKassalar));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tMerchantId = new DevExpress.XtraEditors.TextEdit();
            this.tIpAdress = new DevExpress.XtraEditors.TextEdit();
            this.lookUser = new DevExpress.XtraEditors.LookUpEdit();
            this.lookKassa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.bCheckConnection = new DevExpress.XtraEditors.SimpleButton();
            this.bRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIpAdress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookKassa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl4.Location = new System.Drawing.Point(8, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl4.Size = new System.Drawing.Size(71, 22);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Operator";
            this.labelControl4.UseMnemonic = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tMerchantId);
            this.groupControl1.Controls.Add(this.tIpAdress);
            this.groupControl1.Controls.Add(this.lookUser);
            this.groupControl1.Controls.Add(this.lookKassa);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.SkinName = "WXI";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.MaximumSize = new System.Drawing.Size(0, 165);
            this.groupControl1.MinimumSize = new System.Drawing.Size(0, 123);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(868, 123);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "groupControl1";
            // 
            // tMerchantId
            // 
            this.tMerchantId.Location = new System.Drawing.Point(126, 122);
            this.tMerchantId.Name = "tMerchantId";
            this.tMerchantId.Properties.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.tMerchantId.Properties.Appearance.Options.UseFont = true;
            this.tMerchantId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tMerchantId.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tMerchantId.Properties.NullValuePrompt = "Merchant ID ünvanını daxil edin";
            this.tMerchantId.Size = new System.Drawing.Size(300, 32);
            this.tMerchantId.TabIndex = 3;
            this.tMerchantId.Visible = false;
            // 
            // tIpAdress
            // 
            this.tIpAdress.Location = new System.Drawing.Point(126, 46);
            this.tIpAdress.Name = "tIpAdress";
            this.tIpAdress.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tIpAdress.Properties.MaskSettings.Set("mask", "(999) 000-00-00");
            this.tIpAdress.Properties.MaxLength = 20;
            this.tIpAdress.Properties.NullValuePrompt = "192.168.1.26:1234";
            this.tIpAdress.Size = new System.Drawing.Size(300, 32);
            this.tIpAdress.TabIndex = 1;
            // 
            // lookUser
            // 
            this.lookUser.Location = new System.Drawing.Point(126, 84);
            this.lookUser.Name = "lookUser";
            this.lookUser.Properties.AllowFocused = false;
            this.lookUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUser.Properties.NullText = "";
            this.lookUser.Properties.NullValuePrompt = "İstifadəçi seç";
            this.lookUser.Properties.ShowFooter = false;
            this.lookUser.Properties.ShowHeader = false;
            this.lookUser.Size = new System.Drawing.Size(300, 32);
            this.lookUser.TabIndex = 2;
            // 
            // lookKassa
            // 
            this.lookKassa.Location = new System.Drawing.Point(126, 8);
            this.lookKassa.Name = "lookKassa";
            this.lookKassa.Properties.AllowFocused = false;
            this.lookKassa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookKassa.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lookKassa.Properties.HideSelection = false;
            this.lookKassa.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lookKassa.Properties.HotTrackItems = false;
            this.lookKassa.Properties.NullText = "";
            this.lookKassa.Properties.NullValuePrompt = "Operator seç";
            this.lookKassa.Properties.ShowFooter = false;
            this.lookKassa.Properties.ShowHeader = false;
            this.lookKassa.Size = new System.Drawing.Size(300, 32);
            this.lookKassa.TabIndex = 0;
            this.lookKassa.TextChanged += new System.EventHandler(this.lookKassa_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl3.Location = new System.Drawing.Point(8, 127);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl3.Size = new System.Drawing.Size(94, 22);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Merchant ID";
            this.labelControl3.UseMnemonic = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl2.Location = new System.Drawing.Point(8, 89);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl2.Size = new System.Drawing.Size(70, 22);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "İstifadəçi";
            this.labelControl2.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Nunito", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(8, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(106, 22);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "IP:Port ünvanı";
            this.labelControl1.UseMnemonic = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.bCheckConnection);
            this.groupControl2.Controls.Add(this.bRefresh);
            this.groupControl2.Controls.Add(this.bSave);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(0, 130);
            this.groupControl2.LookAndFeel.SkinName = "WXI";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(868, 40);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "groupControl2";
            // 
            // bCheckConnection
            // 
            this.bCheckConnection.AllowFocus = false;
            this.bCheckConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCheckConnection.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.bCheckConnection.Appearance.Options.UseBackColor = true;
            this.bCheckConnection.Location = new System.Drawing.Point(734, 5);
            this.bCheckConnection.Name = "bCheckConnection";
            this.bCheckConnection.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bCheckConnection.Size = new System.Drawing.Size(129, 30);
            this.bCheckConnection.TabIndex = 14;
            this.bCheckConnection.TabStop = false;
            this.bCheckConnection.Text = "ƏLAQƏNİ YOXLA";
            this.bCheckConnection.Click += new System.EventHandler(this.bCheckConnection_Click);
            // 
            // bRefresh
            // 
            this.bRefresh.AllowFocus = false;
            this.bRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.bRefresh.Appearance.Options.UseBackColor = true;
            this.bRefresh.Location = new System.Drawing.Point(140, 5);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bRefresh.Size = new System.Drawing.Size(129, 30);
            this.bRefresh.TabIndex = 14;
            this.bRefresh.TabStop = false;
            this.bRefresh.Text = "YENİLƏ";
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // bSave
            // 
            this.bSave.AllowFocus = false;
            this.bSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.bSave.Appearance.Options.UseBackColor = true;
            this.bSave.Location = new System.Drawing.Point(5, 5);
            this.bSave.Name = "bSave";
            this.bSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bSave.Size = new System.Drawing.Size(129, 30);
            this.bSave.TabIndex = 14;
            this.bSave.TabStop = false;
            this.bSave.Text = "ƏLAVƏ ET";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Font = new System.Drawing.Font("Comfortaa", 10F);
            this.gridControl1.Location = new System.Drawing.Point(5, 176);
            this.gridControl1.LookAndFeel.SkinName = "WXI";
            this.gridControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bDelete,
            this.bEdit});
            this.gridControl1.Size = new System.Drawing.Size(858, 518);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.TabStop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colOperator,
            this.colIp,
            this.colUser,
            this.colEdit,
            this.colDelete});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 35;
            // 
            // colNo
            // 
            this.colNo.AppearanceCell.Options.UseTextOptions = true;
            this.colNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNo.Caption = "#";
            this.colNo.FieldName = "#";
            this.colNo.MaxWidth = 60;
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 60;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "OPERATOR";
            this.colOperator.FieldName = "Name";
            this.colOperator.Name = "colOperator";
            this.colOperator.OptionsColumn.AllowEdit = false;
            this.colOperator.Visible = true;
            this.colOperator.VisibleIndex = 1;
            this.colOperator.Width = 211;
            // 
            // colIp
            // 
            this.colIp.Caption = "İP ÜNVANI";
            this.colIp.FieldName = "IpAddress";
            this.colIp.Name = "colIp";
            this.colIp.OptionsColumn.AllowEdit = false;
            this.colIp.Visible = true;
            this.colIp.VisibleIndex = 2;
            this.colIp.Width = 241;
            // 
            // colUser
            // 
            this.colUser.Caption = "İSTİFADƏÇİ";
            this.colUser.FieldName = "Users.NameSurname";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 3;
            this.colUser.Width = 292;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Edit";
            this.colEdit.ColumnEdit = this.bEdit;
            this.colEdit.MaxWidth = 50;
            this.colEdit.MinWidth = 50;
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.ShowCaption = false;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 4;
            this.colEdit.Width = 50;
            // 
            // bEdit
            // 
            this.bEdit.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.bEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bEdit.Name = "bEdit";
            this.bEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.bEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bEdit_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.AppearanceHeader.ForeColor = System.Drawing.Color.Crimson;
            this.colDelete.AppearanceHeader.Options.UseForeColor = true;
            this.colDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDelete.Caption = "SİL";
            this.colDelete.ColumnEdit = this.bDelete;
            this.colDelete.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colDelete.MaxWidth = 50;
            this.colDelete.MinWidth = 50;
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.ShowCaption = false;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 5;
            this.colDelete.Width = 50;
            // 
            // bDelete
            // 
            this.bDelete.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            this.bDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.bDelete.Name = "bDelete";
            this.bDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.bDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bDelete_ButtonClick);
            // 
            // fKassalar
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(868, 698);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.LookAndFeel.SkinName = "WXI";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(870, 732);
            this.Name = "fKassalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Kassa";
            this.Load += new System.EventHandler(this.fKassalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIpAdress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookKassa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookKassa;
        private DevExpress.XtraEditors.TextEdit tIpAdress;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tMerchantId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colIp;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraEditors.SimpleButton bSave;
        private DevExpress.XtraEditors.SimpleButton bCheckConnection;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit bEdit;
        private DevExpress.XtraEditors.SimpleButton bRefresh;
    }
}