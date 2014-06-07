namespace AdminClient
{
    partial class AdminForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buyCountBox = new System.Windows.Forms.TextBox();
            this.buyQuantityBox = new System.Windows.Forms.TextBox();
            this.buyQuantity = new System.Windows.Forms.Label();
            this.buyCount = new System.Windows.Forms.Label();
            this.sellQuantity = new System.Windows.Forms.Label();
            this.sellCount = new System.Windows.Forms.Label();
            this.sellQuantityBox = new System.Windows.Forms.TextBox();
            this.sellCountBox = new System.Windows.Forms.TextBox();
            this.tradingMode = new System.Windows.Forms.Label();
            this.tradingModeButton = new System.Windows.Forms.Button();
            this.tradingModeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 55);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Buy Orders";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Sell Orders";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1105, 185);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(13, 246);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.Name = "Trade Price  ";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(1105, 225);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(13, 477);
            this.chart3.Name = "chart3";
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Legend = "Legend1";
            series4.Name = "Trade Quant";
            this.chart3.Series.Add(series4);
            this.chart3.Size = new System.Drawing.Size(1105, 235);
            this.chart3.TabIndex = 2;
            this.chart3.Text = "chart3";
            // 
            // buyCountBox
            // 
            this.buyCountBox.Location = new System.Drawing.Point(1014, 109);
            this.buyCountBox.Name = "buyCountBox";
            this.buyCountBox.ReadOnly = true;
            this.buyCountBox.Size = new System.Drawing.Size(79, 20);
            this.buyCountBox.TabIndex = 3;
            // 
            // buyQuantityBox
            // 
            this.buyQuantityBox.Location = new System.Drawing.Point(1014, 135);
            this.buyQuantityBox.Name = "buyQuantityBox";
            this.buyQuantityBox.ReadOnly = true;
            this.buyQuantityBox.Size = new System.Drawing.Size(79, 20);
            this.buyQuantityBox.TabIndex = 4;
            // 
            // buyQuantity
            // 
            this.buyQuantity.AutoSize = true;
            this.buyQuantity.Location = new System.Drawing.Point(952, 138);
            this.buyQuantity.Name = "buyQuantity";
            this.buyQuantity.Size = new System.Drawing.Size(44, 13);
            this.buyQuantity.TabIndex = 6;
            this.buyQuantity.Text = "Buy Qty";
            // 
            // buyCount
            // 
            this.buyCount.AutoSize = true;
            this.buyCount.Location = new System.Drawing.Point(952, 112);
            this.buyCount.Name = "buyCount";
            this.buyCount.Size = new System.Drawing.Size(56, 13);
            this.buyCount.TabIndex = 5;
            this.buyCount.Text = "Buy Count";
            // 
            // sellQuantity
            // 
            this.sellQuantity.AutoSize = true;
            this.sellQuantity.Location = new System.Drawing.Point(952, 190);
            this.sellQuantity.Name = "sellQuantity";
            this.sellQuantity.Size = new System.Drawing.Size(43, 13);
            this.sellQuantity.TabIndex = 10;
            this.sellQuantity.Text = "Sell Qty";
            // 
            // sellCount
            // 
            this.sellCount.AutoSize = true;
            this.sellCount.Location = new System.Drawing.Point(952, 164);
            this.sellCount.Name = "sellCount";
            this.sellCount.Size = new System.Drawing.Size(55, 13);
            this.sellCount.TabIndex = 9;
            this.sellCount.Text = "Sell Count";
            // 
            // sellQuantityBox
            // 
            this.sellQuantityBox.Location = new System.Drawing.Point(1014, 187);
            this.sellQuantityBox.Name = "sellQuantityBox";
            this.sellQuantityBox.ReadOnly = true;
            this.sellQuantityBox.Size = new System.Drawing.Size(79, 20);
            this.sellQuantityBox.TabIndex = 8;
            // 
            // sellCountBox
            // 
            this.sellCountBox.Location = new System.Drawing.Point(1014, 161);
            this.sellCountBox.Name = "sellCountBox";
            this.sellCountBox.ReadOnly = true;
            this.sellCountBox.Size = new System.Drawing.Size(79, 20);
            this.sellCountBox.TabIndex = 7;
            // 
            // tradingMode
            // 
            this.tradingMode.AutoSize = true;
            this.tradingMode.Location = new System.Drawing.Point(13, 29);
            this.tradingMode.Name = "tradingMode";
            this.tradingMode.Size = new System.Drawing.Size(73, 13);
            this.tradingMode.TabIndex = 12;
            this.tradingMode.Text = "Trading Mode";
            // 
            // tradingModeButton
            // 
            this.tradingModeButton.Location = new System.Drawing.Point(198, 24);
            this.tradingModeButton.Name = "tradingModeButton";
            this.tradingModeButton.Size = new System.Drawing.Size(122, 23);
            this.tradingModeButton.TabIndex = 13;
            this.tradingModeButton.Text = "Switch Trading Mode";
            this.tradingModeButton.UseVisualStyleBackColor = true;
            this.tradingModeButton.Click += new System.EventHandler(this.tradingModeButton_Click);
            // 
            // tradingModeBox
            // 
            this.tradingModeBox.Location = new System.Drawing.Point(92, 26);
            this.tradingModeBox.Name = "tradingModeBox";
            this.tradingModeBox.ReadOnly = true;
            this.tradingModeBox.Size = new System.Drawing.Size(100, 20);
            this.tradingModeBox.TabIndex = 14;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 724);
            this.Controls.Add(this.tradingModeBox);
            this.Controls.Add(this.tradingModeButton);
            this.Controls.Add(this.tradingMode);
            this.Controls.Add(this.sellQuantity);
            this.Controls.Add(this.sellCount);
            this.Controls.Add(this.sellQuantityBox);
            this.Controls.Add(this.sellCountBox);
            this.Controls.Add(this.buyQuantity);
            this.Controls.Add(this.buyCount);
            this.Controls.Add(this.buyQuantityBox);
            this.Controls.Add(this.buyCountBox);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "AdminForm";
            this.Text = "Form1";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.form_Close);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TextBox buyCountBox;
        private System.Windows.Forms.TextBox buyQuantityBox;
        private System.Windows.Forms.Label buyQuantity;
        private System.Windows.Forms.Label buyCount;
        private System.Windows.Forms.Label sellQuantity;
        private System.Windows.Forms.Label sellCount;
        private System.Windows.Forms.TextBox sellQuantityBox;
        private System.Windows.Forms.TextBox sellCountBox;
        private System.Windows.Forms.Label tradingMode;
        private System.Windows.Forms.Button tradingModeButton;
        private System.Windows.Forms.TextBox tradingModeBox;
    }
}

