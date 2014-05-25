namespace ExchangeClient
{
    partial class SubmitOrderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitOrderForm));
            this.quantityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.quantityValue = new System.Windows.Forms.TextBox();
            this.priceValue = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.orderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.orderDataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buySell = new System.Windows.Forms.Label();
            this.productBox = new System.Windows.Forms.ComboBox();
            this.productListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product = new System.Windows.Forms.Label();
            this.buySellBox = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderTypeBox = new System.Windows.Forms.ComboBox();
            this.orderType = new System.Windows.Forms.Label();
            this.trader = new System.Windows.Forms.Label();
            this.traderBox = new System.Windows.Forms.ComboBox();
            //this.traderBox = new System.Web.UI.WebControls.DropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(24, 141);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 1;
            this.quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(24, 176);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(27, 224);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // quantityValue
            // 
            this.quantityValue.Location = new System.Drawing.Point(92, 138);
            this.quantityValue.Name = "quantityValue";
            this.quantityValue.Size = new System.Drawing.Size(100, 20);
            this.quantityValue.TabIndex = 5;
            // 
            // priceValue
            // 
            this.priceValue.Location = new System.Drawing.Point(92, 173);
            this.priceValue.Name = "priceValue";
            this.priceValue.Size = new System.Drawing.Size(100, 20);
            this.priceValue.TabIndex = 6;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(27, 511);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // orderBindingSource1
            // 
            this.orderBindingSource1.DataSource = typeof(ClassLibrary.Order);
            // 
            // orderDataGridView1
            // 
            this.orderDataGridView1.AutoGenerateColumns = false;
            this.orderDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewCheckBoxColumn4});
            this.orderDataGridView1.DataSource = this.orderBindingSource1;
            this.orderDataGridView1.Location = new System.Drawing.Point(27, 269);
            this.orderDataGridView1.Name = "orderDataGridView1";
            this.orderDataGridView1.Size = new System.Drawing.Size(717, 220);
            this.orderDataGridView1.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "orderNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "orderNumber";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "orderType";
            this.dataGridViewTextBoxColumn10.HeaderText = "orderType";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "buySell";
            this.dataGridViewTextBoxColumn11.HeaderText = "buySell";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "productId";
            this.dataGridViewTextBoxColumn12.HeaderText = "productId";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "quantity";
            this.dataGridViewTextBoxColumn13.HeaderText = "quantity";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn14.HeaderText = "price";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "submitTime";
            this.dataGridViewTextBoxColumn15.HeaderText = "submitTime";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "traderId";
            this.dataGridViewTextBoxColumn16.HeaderText = "traderId";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "cancelled";
            this.dataGridViewCheckBoxColumn3.HeaderText = "cancelled";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "matched";
            this.dataGridViewCheckBoxColumn4.HeaderText = "matched";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            // 
            // buySell
            // 
            this.buySell.AutoSize = true;
            this.buySell.Location = new System.Drawing.Point(22, 103);
            this.buySell.Name = "buySell";
            this.buySell.Size = new System.Drawing.Size(47, 13);
            this.buySell.TabIndex = 11;
            this.buySell.Text = "Buy/Sell";
            // 
            // productBox
            // 
            this.productBox.DataSource = ClassLibrary.ProductList.products;
            this.productBox.DisplayMember = "name";
            this.productBox.FormattingEnabled = true;
            this.productBox.Location = new System.Drawing.Point(92, 29);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(186, 21);
            this.productBox.TabIndex = 12;
            this.productBox.ValueMember = "productId";
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.Location = new System.Drawing.Point(22, 32);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(44, 13);
            this.product.TabIndex = 13;
            this.product.Text = "Product";
            // 
            // buySellBox
            // 
            this.buySellBox.FormattingEnabled = true;
            this.buySellBox.Items.AddRange(new object[] {
            ClassLibrary.BuySell.Buy,
            ClassLibrary.BuySell.Sell});
            this.buySellBox.Location = new System.Drawing.Point(92, 100);
            this.buySellBox.Name = "buySellBox";
            this.buySellBox.Size = new System.Drawing.Size(121, 21);
            this.buySellBox.TabIndex = 14;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(ClassLibrary.Product);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orderTypeBox);
            this.groupBox1.Controls.Add(this.orderType);
            this.groupBox1.Controls.Add(this.product);
            this.groupBox1.Controls.Add(this.buySellBox);
            this.groupBox1.Controls.Add(this.quantityLabel);
            this.groupBox1.Controls.Add(this.priceLabel);
            this.groupBox1.Controls.Add(this.productBox);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Controls.Add(this.buySell);
            this.groupBox1.Controls.Add(this.quantityValue);
            this.groupBox1.Controls.Add(this.orderDataGridView1);
            this.groupBox1.Controls.Add(this.priceValue);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 752);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // orderTypeBox
            // 
            this.orderTypeBox.FormattingEnabled = true;
            this.orderTypeBox.Items.AddRange(new object[] {
            ClassLibrary.OrderType.Market,
            ClassLibrary.OrderType.Limit});
            this.orderTypeBox.Location = new System.Drawing.Point(92, 66);
            this.orderTypeBox.Name = "orderTypeBox";
            this.orderTypeBox.Size = new System.Drawing.Size(121, 21);
            this.orderTypeBox.TabIndex = 16;
            // 
            // orderType
            // 
            this.orderType.AutoSize = true;
            this.orderType.Location = new System.Drawing.Point(24, 69);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(60, 13);
            this.orderType.TabIndex = 15;
            this.orderType.Text = "Order Type";
            // 
            // trader
            // 
            this.trader.AutoSize = true;
            this.trader.Location = new System.Drawing.Point(13, 30);
            this.trader.Name = "trader";
            this.trader.Size = new System.Drawing.Size(38, 13);
            this.trader.TabIndex = 16;
            this.trader.Text = "Trader";
            // 
            // traderBox
            // 
            this.traderBox.DataSource = ClassLibrary.TraderList.traders;
            this.traderBox.DisplayMember = "name";
            this.traderBox.FormattingEnabled = true;
            this.traderBox.Location = new System.Drawing.Point(83, 27);
            this.traderBox.Name = "traderBox";
            this.traderBox.Size = new System.Drawing.Size(121, 21);
            this.traderBox.TabIndex = 17;
            this.traderBox.ValueMember = "traderId";
            this.traderBox.SelectedIndexChanged += new System.EventHandler(this.traderBox_SelectedIndexChanged);
            // 
            // SubmitOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 863);
            this.Controls.Add(this.traderBox);
            this.Controls.Add(this.trader);
            this.Controls.Add(this.groupBox1);
            this.Name = "SubmitOrderForm";
            this.Text = "Submit Order";
            this.Load += new System.EventHandler(this.SubmitOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox quantityValue;
        private System.Windows.Forms.TextBox priceValue;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.BindingSource orderBindingSource1;
        private System.Windows.Forms.DataGridView orderDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.Label buySell;
        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.BindingSource productListBindingSource;
        private System.Windows.Forms.Label product;
        private System.Windows.Forms.ComboBox buySellBox;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox orderTypeBox;
        private System.Windows.Forms.Label orderType;
        private System.Windows.Forms.Label trader;
        private System.Windows.Forms.ComboBox traderBox;
    }
}

