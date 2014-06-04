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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buyOrdersBox = new System.Windows.Forms.TextBox();
            this.buyQuantityBox = new System.Windows.Forms.TextBox();
            this.buyOrders = new System.Windows.Forms.Label();
            this.buyQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sellQuantity = new System.Windows.Forms.Label();
            this.sellOrders = new System.Windows.Forms.Label();
            this.sellQuantityBox = new System.Windows.Forms.TextBox();
            this.sellOrdersBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(13, 13);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series2";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1105, 185);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea5.AxisY.IsStartedFromZero = false;
            chartArea5.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart2.Legends.Add(legend5);
            this.chart2.Location = new System.Drawing.Point(13, 204);
            this.chart2.Name = "chart2";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart2.Series.Add(series7);
            this.chart2.Size = new System.Drawing.Size(1105, 246);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea6.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart3.Legends.Add(legend6);
            this.chart3.Location = new System.Drawing.Point(13, 456);
            this.chart3.Name = "chart3";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart3.Series.Add(series8);
            this.chart3.Size = new System.Drawing.Size(1105, 235);
            this.chart3.TabIndex = 2;
            this.chart3.Text = "chart3";
            // 
            // buyOrdersBox
            // 
            this.buyOrdersBox.Location = new System.Drawing.Point(1027, 71);
            this.buyOrdersBox.Name = "buyOrdersBox";
            this.buyOrdersBox.ReadOnly = true;
            this.buyOrdersBox.Size = new System.Drawing.Size(79, 20);
            this.buyOrdersBox.TabIndex = 3;
            // 
            // buyQuantityBox
            // 
            this.buyQuantityBox.Location = new System.Drawing.Point(1027, 97);
            this.buyQuantityBox.Name = "buyQuantityBox";
            this.buyQuantityBox.ReadOnly = true;
            this.buyQuantityBox.Size = new System.Drawing.Size(79, 20);
            this.buyQuantityBox.TabIndex = 4;
            // 
            // buyOrders
            // 
            this.buyOrders.AutoSize = true;
            this.buyOrders.Location = new System.Drawing.Point(965, 74);
            this.buyOrders.Name = "buyOrders";
            this.buyOrders.Size = new System.Drawing.Size(59, 13);
            this.buyOrders.TabIndex = 5;
            this.buyOrders.Text = "Buy Orders";
            // 
            // buyQuantity
            // 
            this.buyQuantity.AutoSize = true;
            this.buyQuantity.Location = new System.Drawing.Point(965, 100);
            this.buyQuantity.Name = "buyQuantity";
            this.buyQuantity.Size = new System.Drawing.Size(44, 13);
            this.buyQuantity.TabIndex = 6;
            this.buyQuantity.Text = "Buy Qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(965, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buy Orders";
            // 
            // sellQuantity
            // 
            this.sellQuantity.AutoSize = true;
            this.sellQuantity.Location = new System.Drawing.Point(965, 152);
            this.sellQuantity.Name = "sellQuantity";
            this.sellQuantity.Size = new System.Drawing.Size(43, 13);
            this.sellQuantity.TabIndex = 10;
            this.sellQuantity.Text = "Sell Qty";
            // 
            // sellOrders
            // 
            this.sellOrders.AutoSize = true;
            this.sellOrders.Location = new System.Drawing.Point(965, 126);
            this.sellOrders.Name = "sellOrders";
            this.sellOrders.Size = new System.Drawing.Size(58, 13);
            this.sellOrders.TabIndex = 9;
            this.sellOrders.Text = "Sell Orders";
            // 
            // sellQuantityBox
            // 
            this.sellQuantityBox.Location = new System.Drawing.Point(1027, 149);
            this.sellQuantityBox.Name = "sellQuantityBox";
            this.sellQuantityBox.ReadOnly = true;
            this.sellQuantityBox.Size = new System.Drawing.Size(79, 20);
            this.sellQuantityBox.TabIndex = 8;
            // 
            // sellOrdersBox
            // 
            this.sellOrdersBox.Location = new System.Drawing.Point(1027, 123);
            this.sellOrdersBox.Name = "sellOrdersBox";
            this.sellOrdersBox.ReadOnly = true;
            this.sellOrdersBox.Size = new System.Drawing.Size(79, 20);
            this.sellOrdersBox.TabIndex = 7;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 724);
            this.Controls.Add(this.sellQuantity);
            this.Controls.Add(this.sellOrders);
            this.Controls.Add(this.sellQuantityBox);
            this.Controls.Add(this.sellOrdersBox);
            this.Controls.Add(this.buyQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buyOrders);
            this.Controls.Add(this.buyQuantityBox);
            this.Controls.Add(this.buyOrdersBox);
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
        private System.Windows.Forms.TextBox buyOrdersBox;
        private System.Windows.Forms.TextBox buyQuantityBox;
        private System.Windows.Forms.Label buyOrders;
        private System.Windows.Forms.Label buyQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sellQuantity;
        private System.Windows.Forms.Label sellOrders;
        private System.Windows.Forms.TextBox sellQuantityBox;
        private System.Windows.Forms.TextBox sellOrdersBox;
    }
}

