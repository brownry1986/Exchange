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
            this.buySell = new System.Windows.Forms.Label();
            this.productBox = new System.Windows.Forms.ComboBox();
            this.productListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product = new System.Windows.Forms.Label();
            this.buySellBox = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderGroupBox = new System.Windows.Forms.GroupBox();
            this.activeOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.submitOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.orderType = new System.Windows.Forms.Label();
            this.orderTypeBox = new System.Windows.Forms.ComboBox();
            this.trader = new System.Windows.Forms.Label();
            this.traderBox = new System.Windows.Forms.ComboBox();
            this.productGroupBox = new System.Windows.Forms.GroupBox();
            this.executedTradesGroupBox = new System.Windows.Forms.GroupBox();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buySellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.orderGroupBox.SuspendLayout();
            this.activeOrderGroupBox.SuspendLayout();
            this.submitOrderGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(428, 28);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 1;
            this.quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(600, 28);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(23, 65);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // quantityValue
            // 
            this.quantityValue.Location = new System.Drawing.Point(480, 25);
            this.quantityValue.Name = "quantityValue";
            this.quantityValue.Size = new System.Drawing.Size(100, 20);
            this.quantityValue.TabIndex = 5;
            // 
            // priceValue
            // 
            this.priceValue.Location = new System.Drawing.Point(637, 25);
            this.priceValue.Name = "priceValue";
            this.priceValue.Size = new System.Drawing.Size(100, 20);
            this.priceValue.TabIndex = 6;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(23, 270);
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
            this.orderDataGridView1.AllowUserToAddRows = false;
            this.orderDataGridView1.AllowUserToDeleteRows = false;
            this.orderDataGridView1.AutoGenerateColumns = false;
            this.orderDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderTypeDataGridViewTextBoxColumn,
            this.buySellDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.submitTimeDataGridViewTextBoxColumn,
            this.matchedDataGridViewCheckBoxColumn});
            this.orderDataGridView1.DataSource = this.orderBindingSource1;
            this.orderDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.orderDataGridView1.Enabled = false;
            this.orderDataGridView1.Location = new System.Drawing.Point(23, 30);
            this.orderDataGridView1.MultiSelect = false;
            this.orderDataGridView1.Name = "orderDataGridView1";
            this.orderDataGridView1.ReadOnly = true;
            this.orderDataGridView1.Size = new System.Drawing.Size(731, 220);
            this.orderDataGridView1.TabIndex = 10;
            // 
            // buySell
            // 
            this.buySell.AutoSize = true;
            this.buySell.Location = new System.Drawing.Point(227, 28);
            this.buySell.Name = "buySell";
            this.buySell.Size = new System.Drawing.Size(47, 13);
            this.buySell.TabIndex = 11;
            this.buySell.Text = "Buy/Sell";
            // 
            // productBox
            // 
            this.productBox.DataSource = ClassLibrary.ProductList.products;
            this.productBox.DisplayMember = "name";
            this.productBox.Location = new System.Drawing.Point(83, 56);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(186, 21);
            this.productBox.TabIndex = 12;
            this.productBox.ValueMember = "productId";
            this.productBox.Visible = false;
            this.productBox.SelectedIndexChanged += new System.EventHandler(this.productBox_SelectedIndexChanged);
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.Location = new System.Drawing.Point(13, 59);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(44, 13);
            this.product.TabIndex = 13;
            this.product.Text = "Product";
            this.product.Visible = false;
            // 
            // buySellBox
            // 
            this.buySellBox.FormattingEnabled = true;
            this.buySellBox.Items.AddRange(new object[] {
            ClassLibrary.BuySell.Buy,
            ClassLibrary.BuySell.Sell});
            this.buySellBox.Location = new System.Drawing.Point(280, 25);
            this.buySellBox.Name = "buySellBox";
            this.buySellBox.Size = new System.Drawing.Size(121, 21);
            this.buySellBox.TabIndex = 14;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(ClassLibrary.Product);
            // 
            // orderGroupBox
            // 
            this.orderGroupBox.Controls.Add(this.activeOrderGroupBox);
            this.orderGroupBox.Controls.Add(this.submitOrderGroupBox);
            this.orderGroupBox.Location = new System.Drawing.Point(16, 220);
            this.orderGroupBox.Name = "orderGroupBox";
            this.orderGroupBox.Size = new System.Drawing.Size(805, 493);
            this.orderGroupBox.TabIndex = 15;
            this.orderGroupBox.TabStop = false;
            this.orderGroupBox.Text = "Order Information";
            this.orderGroupBox.Visible = false;
            // 
            // activeOrderGroupBox
            // 
            this.activeOrderGroupBox.Controls.Add(this.orderDataGridView1);
            this.activeOrderGroupBox.Controls.Add(this.refreshButton);
            this.activeOrderGroupBox.Location = new System.Drawing.Point(21, 154);
            this.activeOrderGroupBox.Name = "activeOrderGroupBox";
            this.activeOrderGroupBox.Size = new System.Drawing.Size(760, 314);
            this.activeOrderGroupBox.TabIndex = 18;
            this.activeOrderGroupBox.TabStop = false;
            this.activeOrderGroupBox.Text = "Active Orders";
            // 
            // submitOrderGroupBox
            // 
            this.submitOrderGroupBox.Controls.Add(this.orderType);
            this.submitOrderGroupBox.Controls.Add(this.submitButton);
            this.submitOrderGroupBox.Controls.Add(this.orderTypeBox);
            this.submitOrderGroupBox.Controls.Add(this.priceValue);
            this.submitOrderGroupBox.Controls.Add(this.quantityValue);
            this.submitOrderGroupBox.Controls.Add(this.buySellBox);
            this.submitOrderGroupBox.Controls.Add(this.buySell);
            this.submitOrderGroupBox.Controls.Add(this.quantityLabel);
            this.submitOrderGroupBox.Controls.Add(this.priceLabel);
            this.submitOrderGroupBox.Location = new System.Drawing.Point(21, 28);
            this.submitOrderGroupBox.Name = "submitOrderGroupBox";
            this.submitOrderGroupBox.Size = new System.Drawing.Size(760, 105);
            this.submitOrderGroupBox.TabIndex = 17;
            this.submitOrderGroupBox.TabStop = false;
            this.submitOrderGroupBox.Text = "Submit Order";
            // 
            // orderType
            // 
            this.orderType.AutoSize = true;
            this.orderType.Location = new System.Drawing.Point(20, 28);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(60, 13);
            this.orderType.TabIndex = 15;
            this.orderType.Text = "Order Type";
            // 
            // orderTypeBox
            // 
            this.orderTypeBox.FormattingEnabled = true;
            this.orderTypeBox.Items.AddRange(new object[] {
            ClassLibrary.OrderType.Market,
            ClassLibrary.OrderType.Limit});
            this.orderTypeBox.Location = new System.Drawing.Point(86, 25);
            this.orderTypeBox.Name = "orderTypeBox";
            this.orderTypeBox.Size = new System.Drawing.Size(121, 21);
            this.orderTypeBox.TabIndex = 16;
            // 
            // trader
            // 
            this.trader.AutoSize = true;
            this.trader.Location = new System.Drawing.Point(13, 22);
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
            this.traderBox.Location = new System.Drawing.Point(83, 19);
            this.traderBox.Name = "traderBox";
            this.traderBox.Size = new System.Drawing.Size(121, 21);
            this.traderBox.TabIndex = 17;
            this.traderBox.ValueMember = "traderId";
            this.traderBox.SelectedIndexChanged += new System.EventHandler(this.traderBox_SelectedIndexChanged);
            // 
            // productGroupBox
            // 
            this.productGroupBox.Location = new System.Drawing.Point(16, 99);
            this.productGroupBox.Name = "productGroupBox";
            this.productGroupBox.Size = new System.Drawing.Size(805, 100);
            this.productGroupBox.TabIndex = 18;
            this.productGroupBox.TabStop = false;
            this.productGroupBox.Text = "Product Information";
            this.productGroupBox.Visible = false;
            // 
            // executedTradesGroupBox
            // 
            this.executedTradesGroupBox.Location = new System.Drawing.Point(16, 729);
            this.executedTradesGroupBox.Name = "executedTradesGroupBox";
            this.executedTradesGroupBox.Size = new System.Drawing.Size(805, 150);
            this.executedTradesGroupBox.TabIndex = 19;
            this.executedTradesGroupBox.TabStop = false;
            this.executedTradesGroupBox.Text = "Executed Trades";
            this.executedTradesGroupBox.Visible = false;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "orderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Order Type";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buySellDataGridViewTextBoxColumn
            // 
            this.buySellDataGridViewTextBoxColumn.DataPropertyName = "buySell";
            this.buySellDataGridViewTextBoxColumn.HeaderText = "Buy / Sell";
            this.buySellDataGridViewTextBoxColumn.Name = "buySellDataGridViewTextBoxColumn";
            this.buySellDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // submitTimeDataGridViewTextBoxColumn
            // 
            this.submitTimeDataGridViewTextBoxColumn.DataPropertyName = "submitTime";
            this.submitTimeDataGridViewTextBoxColumn.HeaderText = "Submit Time";
            this.submitTimeDataGridViewTextBoxColumn.Name = "submitTimeDataGridViewTextBoxColumn";
            this.submitTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.submitTimeDataGridViewTextBoxColumn.Width = 200;
            // 
            // matchedDataGridViewCheckBoxColumn
            // 
            this.matchedDataGridViewCheckBoxColumn.DataPropertyName = "matched";
            this.matchedDataGridViewCheckBoxColumn.HeaderText = "Executed";
            this.matchedDataGridViewCheckBoxColumn.Name = "matchedDataGridViewCheckBoxColumn";
            this.matchedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // SubmitOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 894);
            this.Controls.Add(this.product);
            this.Controls.Add(this.productBox);
            this.Controls.Add(this.executedTradesGroupBox);
            this.Controls.Add(this.productGroupBox);
            this.Controls.Add(this.traderBox);
            this.Controls.Add(this.trader);
            this.Controls.Add(this.orderGroupBox);
            this.Name = "SubmitOrderForm";
            this.Text = "Submit Order";
            this.Load += new System.EventHandler(this.SubmitOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.orderGroupBox.ResumeLayout(false);
            this.activeOrderGroupBox.ResumeLayout(false);
            this.submitOrderGroupBox.ResumeLayout(false);
            this.submitOrderGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label buySell;
        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.BindingSource productListBindingSource;
        private System.Windows.Forms.Label product;
        private System.Windows.Forms.ComboBox buySellBox;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.GroupBox orderGroupBox;
        private System.Windows.Forms.ComboBox orderTypeBox;
        private System.Windows.Forms.Label orderType;
        private System.Windows.Forms.Label trader;
        private System.Windows.Forms.ComboBox traderBox;
        private System.Windows.Forms.GroupBox productGroupBox;
        private System.Windows.Forms.GroupBox activeOrderGroupBox;
        private System.Windows.Forms.GroupBox submitOrderGroupBox;
        private System.Windows.Forms.GroupBox executedTradesGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buySellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submitTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchedDataGridViewCheckBoxColumn;
    }
}

