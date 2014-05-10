namespace OrderClient
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
            this.productLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.productValue = new System.Windows.Forms.TextBox();
            this.quantityValue = new System.Windows.Forms.TextBox();
            this.priceValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(12, 9);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(44, 13);
            this.productLabel.TabIndex = 0;
            this.productLabel.Text = "Product";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(12, 50);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 1;
            this.quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(12, 92);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(15, 133);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // productValue
            // 
            this.productValue.Location = new System.Drawing.Point(63, 2);
            this.productValue.Name = "productValue";
            this.productValue.Size = new System.Drawing.Size(100, 20);
            this.productValue.TabIndex = 4;
            // 
            // quantityValue
            // 
            this.quantityValue.Location = new System.Drawing.Point(63, 43);
            this.quantityValue.Name = "quantityValue";
            this.quantityValue.Size = new System.Drawing.Size(100, 20);
            this.quantityValue.TabIndex = 5;
            // 
            // priceValue
            // 
            this.priceValue.Location = new System.Drawing.Point(63, 84);
            this.priceValue.Name = "priceValue";
            this.priceValue.Size = new System.Drawing.Size(100, 20);
            this.priceValue.TabIndex = 6;
            // 
            // SubmitOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.priceValue);
            this.Controls.Add(this.quantityValue);
            this.Controls.Add(this.productValue);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.productLabel);
            this.Name = "SubmitOrderForm";
            this.Text = "Submit Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox productValue;
        private System.Windows.Forms.TextBox quantityValue;
        private System.Windows.Forms.TextBox priceValue;
    }
}

