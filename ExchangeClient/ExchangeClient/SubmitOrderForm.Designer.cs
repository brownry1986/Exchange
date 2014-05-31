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
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderDataGridView = new System.Windows.Forms.DataGridView();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buySellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filledQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buySell = new System.Windows.Forms.Label();
            this.productBox = new System.Windows.Forms.ComboBox();
            this.product = new System.Windows.Forms.Label();
            this.buySellBox = new System.Windows.Forms.ComboBox();
            this.orderGroupBox = new System.Windows.Forms.GroupBox();
            this.activeOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.submitOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.orderType = new System.Windows.Forms.Label();
            this.orderTypeBox = new System.Windows.Forms.ComboBox();
            this.trader = new System.Windows.Forms.Label();
            this.traderBox = new System.Windows.Forms.ComboBox();
            this.productGroupBox = new System.Windows.Forms.GroupBox();
            this.executedTradesGroupBox = new System.Windows.Forms.GroupBox();
            this.tradeDataGridView = new System.Windows.Forms.DataGridView();
            this.buySellDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submissionPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executionPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executionTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buySellDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidPriceBox = new System.Windows.Forms.TextBox();
            this.bidPrice = new System.Windows.Forms.Label();
            this.askPrice = new System.Windows.Forms.Label();
            this.askPriceBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            this.orderGroupBox.SuspendLayout();
            this.activeOrderGroupBox.SuspendLayout();
            this.submitOrderGroupBox.SuspendLayout();
            this.productGroupBox.SuspendLayout();
            this.executedTradesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tradeDataGridView)).BeginInit();
            this.SuspendLayout();
            this.Closing += new System.ComponentModel.CancelEventHandler(this.form_Close);

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
            this.submitButton.TabIndex = 7;
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
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(ClassLibrary.Order);
            // 
            // tradeBindingSource
            // 
            this.tradeBindingSource.DataSource = typeof(ClassLibrary.Trade);
            // 
            // orderDataGridView
            // 
            this.orderDataGridView.AllowUserToAddRows = false;
            this.orderDataGridView.AllowUserToDeleteRows = false;
            this.orderDataGridView.AutoGenerateColumns = false;
            this.orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderTypeDataGridViewTextBoxColumn,
            this.buySellDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.filledQuantity,
            this.priceDataGridViewTextBoxColumn,
            this.submitTimeDataGridViewTextBoxColumn});
            this.orderDataGridView.DataSource = this.orderBindingSource;
            this.orderDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.orderDataGridView.Enabled = false;
            this.orderDataGridView.Location = new System.Drawing.Point(23, 30);
            this.orderDataGridView.MultiSelect = false;
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.ReadOnly = true;
            this.orderDataGridView.Size = new System.Drawing.Size(949, 220);
            this.orderDataGridView.TabIndex = 100;
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
            // filledQuantity
            // 
            this.filledQuantity.DataPropertyName = "filledQuantity";
            this.filledQuantity.HeaderText = "Filled Qty";
            this.filledQuantity.Name = "filledQuantity";
            this.filledQuantity.ReadOnly = true;
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
            this.productBox.TabIndex = 1;
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
            this.buySellBox.TabIndex = 4;
            // 
            // orderGroupBox
            // 
            this.orderGroupBox.Controls.Add(this.activeOrderGroupBox);
            this.orderGroupBox.Controls.Add(this.submitOrderGroupBox);
            this.orderGroupBox.Location = new System.Drawing.Point(16, 220);
            this.orderGroupBox.Name = "orderGroupBox";
            this.orderGroupBox.Size = new System.Drawing.Size(1031, 493);
            this.orderGroupBox.TabIndex = 15;
            this.orderGroupBox.TabStop = false;
            this.orderGroupBox.Text = "Order Information";
            this.orderGroupBox.Visible = false;
            // 
            // activeOrderGroupBox
            // 
            this.activeOrderGroupBox.Controls.Add(this.orderDataGridView);
            this.activeOrderGroupBox.Controls.Add(this.refreshButton);
            this.activeOrderGroupBox.Location = new System.Drawing.Point(21, 154);
            this.activeOrderGroupBox.Name = "activeOrderGroupBox";
            this.activeOrderGroupBox.Size = new System.Drawing.Size(991, 314);
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
            this.submitOrderGroupBox.Size = new System.Drawing.Size(991, 105);
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
            this.orderTypeBox.TabIndex = 3;
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
            this.traderBox.TabIndex = 0;
            this.traderBox.ValueMember = "traderId";
            this.traderBox.SelectedIndexChanged += new System.EventHandler(this.traderBox_SelectedIndexChanged);
            // 
            // productGroupBox
            // 
            this.productGroupBox.Controls.Add(this.askPrice);
            this.productGroupBox.Controls.Add(this.askPriceBox);
            this.productGroupBox.Controls.Add(this.bidPrice);
            this.productGroupBox.Controls.Add(this.bidPriceBox);
            this.productGroupBox.Location = new System.Drawing.Point(16, 99);
            this.productGroupBox.Name = "productGroupBox";
            this.productGroupBox.Size = new System.Drawing.Size(1031, 100);
            this.productGroupBox.TabIndex = 18;
            this.productGroupBox.TabStop = false;
            this.productGroupBox.Text = "Product Information";
            this.productGroupBox.Visible = false;
            // 
            // executedTradesGroupBox
            // 
            this.executedTradesGroupBox.Controls.Add(this.tradeDataGridView);
            this.executedTradesGroupBox.Location = new System.Drawing.Point(16, 723);
            this.executedTradesGroupBox.Name = "executedTradesGroupBox";
            this.executedTradesGroupBox.Size = new System.Drawing.Size(1031, 263);
            this.executedTradesGroupBox.TabIndex = 19;
            this.executedTradesGroupBox.TabStop = false;
            this.executedTradesGroupBox.Text = "Executed Trades";
            this.executedTradesGroupBox.Visible = false;
            // 
            // tradeDataGridView
            // 
            this.tradeDataGridView.AllowUserToAddRows = false;
            this.tradeDataGridView.AllowUserToDeleteRows = false;
            this.tradeDataGridView.AutoGenerateColumns = false;
            this.tradeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tradeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buySellDataGridViewTextBoxColumn2,
            this.quantityDataGridViewTextBoxColumn2,
            this.submissionPriceDataGridViewTextBoxColumn,
            this.executionPriceDataGridViewTextBoxColumn,
            this.executionTimeDataGridViewTextBoxColumn,
            this.feeAmountDataGridViewTextBoxColumn});
            this.tradeDataGridView.DataSource = this.tradeBindingSource;
            this.tradeDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tradeDataGridView.Enabled = false;
            this.tradeDataGridView.Location = new System.Drawing.Point(21, 34);
            this.tradeDataGridView.MultiSelect = false;
            this.tradeDataGridView.Name = "tradeDataGridView";
            this.tradeDataGridView.ReadOnly = true;
            this.tradeDataGridView.Size = new System.Drawing.Size(991, 209);
            this.tradeDataGridView.TabIndex = 100;
            // 
            // buySellDataGridViewTextBoxColumn2
            // 
            this.buySellDataGridViewTextBoxColumn2.DataPropertyName = "buySell";
            this.buySellDataGridViewTextBoxColumn2.HeaderText = "Buy / Sell";
            this.buySellDataGridViewTextBoxColumn2.Name = "buySellDataGridViewTextBoxColumn2";
            this.buySellDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn2
            // 
            this.quantityDataGridViewTextBoxColumn2.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn2.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn2.Name = "quantityDataGridViewTextBoxColumn2";
            this.quantityDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // submissionPriceDataGridViewTextBoxColumn
            // 
            this.submissionPriceDataGridViewTextBoxColumn.DataPropertyName = "submissionPrice";
            this.submissionPriceDataGridViewTextBoxColumn.HeaderText = "Submission Price";
            this.submissionPriceDataGridViewTextBoxColumn.Name = "submissionPriceDataGridViewTextBoxColumn";
            this.submissionPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // executionPriceDataGridViewTextBoxColumn
            // 
            this.executionPriceDataGridViewTextBoxColumn.DataPropertyName = "executionPrice";
            this.executionPriceDataGridViewTextBoxColumn.HeaderText = "Execution Price";
            this.executionPriceDataGridViewTextBoxColumn.Name = "executionPriceDataGridViewTextBoxColumn";
            this.executionPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // executionTimeDataGridViewTextBoxColumn
            // 
            this.executionTimeDataGridViewTextBoxColumn.DataPropertyName = "executionTime";
            this.executionTimeDataGridViewTextBoxColumn.HeaderText = "Execution Time";
            this.executionTimeDataGridViewTextBoxColumn.Name = "executionTimeDataGridViewTextBoxColumn";
            this.executionTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.executionTimeDataGridViewTextBoxColumn.Width = 200;
            // 
            // feeAmountDataGridViewTextBoxColumn
            // 
            this.feeAmountDataGridViewTextBoxColumn.DataPropertyName = "feeAmount";
            this.feeAmountDataGridViewTextBoxColumn.HeaderText = "Fee Amount";
            this.feeAmountDataGridViewTextBoxColumn.Name = "feeAmountDataGridViewTextBoxColumn";
            this.feeAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buySellDataGridViewTextBoxColumn1
            // 
            this.buySellDataGridViewTextBoxColumn1.DataPropertyName = "buySell";
            this.buySellDataGridViewTextBoxColumn1.HeaderText = "buySell";
            this.buySellDataGridViewTextBoxColumn1.Name = "buySellDataGridViewTextBoxColumn1";
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "productId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "productId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            // 
            // traderIdDataGridViewTextBoxColumn
            // 
            this.traderIdDataGridViewTextBoxColumn.DataPropertyName = "traderId";
            this.traderIdDataGridViewTextBoxColumn.HeaderText = "traderId";
            this.traderIdDataGridViewTextBoxColumn.Name = "traderIdDataGridViewTextBoxColumn";
            // 
            // bidPriceBox
            // 
            this.bidPriceBox.Enabled = false;
            this.bidPriceBox.Location = new System.Drawing.Point(73, 26);
            this.bidPriceBox.Name = "bidPriceBox";
            this.bidPriceBox.ReadOnly = true;
            this.bidPriceBox.Size = new System.Drawing.Size(100, 20);
            this.bidPriceBox.TabIndex = 2;
            // 
            // bidPrice
            // 
            this.bidPrice.AutoSize = true;
            this.bidPrice.Location = new System.Drawing.Point(18, 29);
            this.bidPrice.Name = "bidPrice";
            this.bidPrice.Size = new System.Drawing.Size(49, 13);
            this.bidPrice.TabIndex = 1;
            this.bidPrice.Text = "Bid Price";
            // 
            // askPrice
            // 
            this.askPrice.AutoSize = true;
            this.askPrice.Location = new System.Drawing.Point(204, 29);
            this.askPrice.Name = "askPrice";
            this.askPrice.Size = new System.Drawing.Size(52, 13);
            this.askPrice.TabIndex = 3;
            this.askPrice.Text = "Ask Price";
            // 
            // askPriceBox
            // 
            this.askPriceBox.Enabled = false;
            this.askPriceBox.Location = new System.Drawing.Point(259, 26);
            this.askPriceBox.Name = "askPriceBox";
            this.askPriceBox.ReadOnly = true;
            this.askPriceBox.Size = new System.Drawing.Size(100, 20);
            this.askPriceBox.TabIndex = 4;
            // 
            // SubmitOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 998);
            this.Controls.Add(this.product);
            this.Controls.Add(this.productBox);
            this.Controls.Add(this.executedTradesGroupBox);
            this.Controls.Add(this.productGroupBox);
            this.Controls.Add(this.traderBox);
            this.Controls.Add(this.trader);
            this.Controls.Add(this.orderGroupBox);
            this.Name = "SubmitOrderForm";
            this.Text = "Exchange";
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            this.orderGroupBox.ResumeLayout(false);
            this.activeOrderGroupBox.ResumeLayout(false);
            this.submitOrderGroupBox.ResumeLayout(false);
            this.submitOrderGroupBox.PerformLayout();
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            this.executedTradesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tradeDataGridView)).EndInit();
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
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource tradeBindingSource;
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.Label buySell;
        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.Label product;
        private System.Windows.Forms.ComboBox buySellBox;
        private System.Windows.Forms.GroupBox orderGroupBox;
        private System.Windows.Forms.ComboBox orderTypeBox;
        private System.Windows.Forms.Label orderType;
        private System.Windows.Forms.Label trader;
        private System.Windows.Forms.ComboBox traderBox;
        private System.Windows.Forms.GroupBox productGroupBox;
        private System.Windows.Forms.GroupBox activeOrderGroupBox;
        private System.Windows.Forms.GroupBox submitOrderGroupBox;
        private System.Windows.Forms.GroupBox executedTradesGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buySellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filledQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submitTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView tradeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn buySellDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn traderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buySellDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn submissionPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executionPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executionTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label askPrice;
        private System.Windows.Forms.TextBox askPriceBox;
        private System.Windows.Forms.Label bidPrice;
        private System.Windows.Forms.TextBox bidPriceBox;
    }
}

