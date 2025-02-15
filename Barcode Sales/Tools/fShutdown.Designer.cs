
namespace Barcode_Sales.UserControls
{
    partial class fShutdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fShutdown));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.bExit = new DevExpress.XtraEditors.SimpleButton();
            this.bEndDay = new DevExpress.XtraEditors.SimpleButton();
            this.bShutdown = new DevExpress.XtraEditors.SimpleButton();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel1.Controls.Add(this.bCancel);
            this.tablePanel1.Controls.Add(this.bExit);
            this.tablePanel1.Controls.Add(this.bEndDay);
            this.tablePanel1.Controls.Add(this.bShutdown);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 163F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(800, 200);
            this.tablePanel1.TabIndex = 0;
            // 
            // bExit
            // 
            this.bExit.AllowFocus = false;
            this.bExit.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bExit.Appearance.Font = new System.Drawing.Font("Nunito", 16F);
            this.bExit.Appearance.Options.UseBackColor = true;
            this.bExit.Appearance.Options.UseFont = true;
            this.bExit.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bExit.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bExit.AppearanceHovered.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.bExit, 1);
            this.bExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bExit.ImageOptions.SvgImage")));
            this.bExit.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.bExit.Location = new System.Drawing.Point(269, 1);
            this.bExit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.bExit.Name = "bExit";
            this.tablePanel1.SetRow(this.bExit, 0);
            this.bExit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bExit.Size = new System.Drawing.Size(263, 161);
            this.bExit.TabIndex = 2;
            this.bExit.TabStop = false;
            this.bExit.Text = "Çıxış et";
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bEndDay
            // 
            this.bEndDay.AllowFocus = false;
            this.bEndDay.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bEndDay.Appearance.Font = new System.Drawing.Font("Nunito", 16F);
            this.bEndDay.Appearance.Options.UseBackColor = true;
            this.bEndDay.Appearance.Options.UseFont = true;
            this.bEndDay.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bEndDay.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bEndDay.AppearanceHovered.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.bEndDay, 0);
            this.bEndDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEndDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bEndDay.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bEndDay.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bEndDay.ImageOptions.SvgImage")));
            this.bEndDay.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.bEndDay.Location = new System.Drawing.Point(1, 1);
            this.bEndDay.Margin = new System.Windows.Forms.Padding(1, 1, 2, 1);
            this.bEndDay.Name = "bEndDay";
            this.tablePanel1.SetRow(this.bEndDay, 0);
            this.bEndDay.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bEndDay.Size = new System.Drawing.Size(264, 161);
            this.bEndDay.TabIndex = 2;
            this.bEndDay.TabStop = false;
            this.bEndDay.Text = "Günü sonlandır və \r\nÇıxış et";
            this.bEndDay.Click += new System.EventHandler(this.bEndDay_Click);
            // 
            // bShutdown
            // 
            this.bShutdown.AllowFocus = false;
            this.bShutdown.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bShutdown.Appearance.Font = new System.Drawing.Font("Nunito", 16F);
            this.bShutdown.Appearance.Options.UseBackColor = true;
            this.bShutdown.Appearance.Options.UseFont = true;
            this.bShutdown.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bShutdown.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bShutdown.AppearanceHovered.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.bShutdown, 2);
            this.bShutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bShutdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bShutdown.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bShutdown.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bShutdown.ImageOptions.SvgImage")));
            this.bShutdown.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.bShutdown.Location = new System.Drawing.Point(535, 1);
            this.bShutdown.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.bShutdown.Name = "bShutdown";
            this.tablePanel1.SetRow(this.bShutdown, 0);
            this.bShutdown.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bShutdown.Size = new System.Drawing.Size(264, 161);
            this.bShutdown.TabIndex = 2;
            this.bShutdown.TabStop = false;
            this.bShutdown.Text = "Kompüteri söndür";
            this.bShutdown.Click += new System.EventHandler(this.bShutdown_Click);
            // 
            // bCancel
            // 
            this.bCancel.AllowFocus = false;
            this.bCancel.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bCancel.Appearance.Font = new System.Drawing.Font("Nunito", 14F);
            this.bCancel.Appearance.Options.UseBackColor = true;
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bCancel.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.bCancel.AppearanceHovered.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.bCancel, 1);
            this.bCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.bCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(90, 90);
            this.bCancel.Location = new System.Drawing.Point(267, 166);
            this.bCancel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.bCancel.Name = "bCancel";
            this.tablePanel1.SetRow(this.bCancel, 1);
            this.bCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bCancel.Size = new System.Drawing.Size(267, 31);
            this.bCancel.TabIndex = 3;
            this.bCancel.TabStop = false;
            this.bCancel.Text = "Ləğv et";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // fShutdown
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 200);
            this.ControlBox = false;
            this.Controls.Add(this.tablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fShutdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fShutdown";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        public DevExpress.XtraEditors.SimpleButton bExit;
        public DevExpress.XtraEditors.SimpleButton bEndDay;
        public DevExpress.XtraEditors.SimpleButton bShutdown;
        public DevExpress.XtraEditors.SimpleButton bCancel;
    }
}