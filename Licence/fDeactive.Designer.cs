
namespace Licence
{
    partial class fDeactive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDeactive));
            this.pic2 = new DevExpress.XtraEditors.PictureEdit();
            this.lVersion = new DevExpress.XtraEditors.LabelControl();
            this.lKey = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.bExit = new NextPOS.UserControls.ButtonRadius();
            this.toolsBorderRadius1 = new NextPOS.UserControls.ToolsBorderRadius();
            ((System.ComponentModel.ISupportInitialize)(this.pic2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pic2
            // 
            this.pic2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic2.EditValue = ((object)(resources.GetObject("pic2.EditValue")));
            this.pic2.Location = new System.Drawing.Point(0, 0);
            this.pic2.Name = "pic2";
            this.pic2.Properties.AllowFocused = false;
            this.pic2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pic2.Properties.Appearance.Options.UseBackColor = true;
            this.pic2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic2.Properties.NullText = " ";
            this.pic2.Properties.ShowMenu = false;
            this.pic2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic2.Size = new System.Drawing.Size(957, 645);
            this.pic2.TabIndex = 6;
            // 
            // lVersion
            // 
            this.lVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lVersion.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lVersion.Appearance.Options.UseFont = true;
            this.lVersion.Location = new System.Drawing.Point(880, 615);
            this.lVersion.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(44, 18);
            this.lVersion.TabIndex = 9;
            this.lVersion.Text = "Version";
            // 
            // lKey
            // 
            this.lKey.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lKey.Appearance.Font = new System.Drawing.Font("Nunito", 10F);
            this.lKey.Appearance.Options.UseFont = true;
            this.lKey.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lKey.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lKey.ImageOptions.SvgImage")));
            this.lKey.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lKey.Location = new System.Drawing.Point(324, 618);
            this.lKey.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.lKey.Name = "lKey";
            this.lKey.Size = new System.Drawing.Size(21, 20);
            this.lKey.TabIndex = 9;
            this.lKey.Click += new System.EventHandler(this.lKey_Click);
            // 
            // picLogo
            // 
            this.picLogo.EditValue = ((object)(resources.GetObject("picLogo.EditValue")));
            this.picLogo.Location = new System.Drawing.Point(15, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.AllowFocused = false;
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.NullText = " ";
            this.picLogo.Properties.ShowMenu = false;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(61, 57);
            this.picLogo.TabIndex = 10;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(62)))));
            this.bExit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(62)))));
            this.bExit.BorderColor = System.Drawing.Color.Empty;
            this.bExit.BorderRadius = 20;
            this.bExit.BorderSize = 0;
            this.bExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(191)))), ((int)(((byte)(107)))));
            this.bExit.FlatAppearance.BorderSize = 0;
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExit.Font = new System.Drawing.Font("Nunito", 18F, System.Drawing.FontStyle.Bold);
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(340, 565);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(269, 46);
            this.bExit.TabIndex = 8;
            this.bExit.TabStop = false;
            this.bExit.Text = "Çıxış";
            this.bExit.TextColor = System.Drawing.Color.White;
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // toolsBorderRadius1
            // 
            this.toolsBorderRadius1.CornerRadius = 20;
            this.toolsBorderRadius1.TargetControl = this;
            // 
            // fDeactive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 645);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lKey);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.pic2);
            this.Font = new System.Drawing.Font("Nunito", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDeactive";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pic2;
        private NextPOS.UserControls.ToolsBorderRadius toolsBorderRadius1;
        private DevExpress.XtraEditors.LabelControl lVersion;
        private DevExpress.XtraEditors.LabelControl lKey;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private NextPOS.UserControls.ButtonRadius bExit;
    }
}

