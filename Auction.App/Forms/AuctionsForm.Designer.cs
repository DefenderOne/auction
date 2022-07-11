namespace Auction.App.Forms
{
    partial class AuctionsForm
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
            this.auctionGrid = new System.Windows.Forms.DataGridView();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.auctionGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // auctionGrid
            // 
            this.auctionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.auctionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.auctionGrid.Location = new System.Drawing.Point(12, 12);
            this.auctionGrid.Name = "auctionGrid";
            this.auctionGrid.ReadOnly = true;
            this.auctionGrid.RowTemplate.Height = 25;
            this.auctionGrid.Size = new System.Drawing.Size(482, 369);
            this.auctionGrid.TabIndex = 0;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(256, 387);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(238, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 387);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(238, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AuctionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 418);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.auctionGrid);
            this.Name = "AuctionsForm";
            this.Text = "Информация об аукционах";
            ((System.ComponentModel.ISupportInitialize)(this.auctionGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView auctionGrid;
        private Button removeButton;
        private Button addButton;
    }
}