namespace Barcode_Sales.Forms
{
    partial class fChartTest
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView1 = new DevExpress.XtraCharts.DoughnutSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView2 = new DevExpress.XtraCharts.DoughnutSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartTop5Product = new DevExpress.XtraCharts.ChartControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop5Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTop5Product
            // 
            this.chartTop5Product.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartTop5Product.Location = new System.Drawing.Point(0, 0);
            this.chartTop5Product.Name = "chartTop5Product";
            series1.Name = "Series 1";
            series1.SeriesID = 0;
            series1.View = doughnutSeriesView1;
            this.chartTop5Product.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartTop5Product.Size = new System.Drawing.Size(1185, 404);
            this.chartTop5Product.TabIndex = 0;
            chartTitle1.MaxLineCount = 2;
            chartTitle1.TitleID = 0;
            chartTitle1.WordWrap = true;
            this.chartTop5Product.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // chartControl2
            // 
            this.chartControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chartControl2.Location = new System.Drawing.Point(0, 424);
            this.chartControl2.Name = "chartControl2";
            series2.Name = "Series 1";
            series2.SeriesID = 0;
            series2.View = doughnutSeriesView2;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl2.Size = new System.Drawing.Size(1185, 393);
            this.chartControl2.TabIndex = 1;
            chartTitle2.MaxLineCount = 2;
            chartTitle2.TitleID = 0;
            chartTitle2.WordWrap = true;
            this.chartControl2.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // fChartTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 817);
            this.Controls.Add(this.chartControl2);
            this.Controls.Add(this.chartTop5Product);
            this.Name = "fChartTest";
            this.Text = "fChartTest";
            this.Shown += new System.EventHandler(this.fChartTest_Shown);
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop5Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartTop5Product;
        private DevExpress.XtraCharts.ChartControl chartControl2;
    }
}