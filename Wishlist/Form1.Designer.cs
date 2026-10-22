namespace Wishlist
{
    partial class Form1
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
            this.dgvWishlist = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddToWishlist = new System.Windows.Forms.Button();
            this.txtWishlistName = new System.Windows.Forms.TextBox();
            this.txtItem1 = new System.Windows.Forms.TextBox();
            this.txtItem2 = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWishlist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWishlist
            // 
            this.dgvWishlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWishlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colItem1,
            this.colItem2,
            this.colAmount});
            this.dgvWishlist.Location = new System.Drawing.Point(295, 30);
            this.dgvWishlist.Name = "dgvWishlist";
            this.dgvWishlist.Size = new System.Drawing.Size(448, 200);
            this.dgvWishlist.TabIndex = 0;
            this.dgvWishlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWishlist_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colItem1
            // 
            this.colItem1.HeaderText = "Item 1";
            this.colItem1.Name = "colItem1";
            // 
            // colItem2
            // 
            this.colItem2.HeaderText = "Item 2";
            this.colItem2.Name = "colItem2";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // btnAddToWishlist
            // 
            this.btnAddToWishlist.Location = new System.Drawing.Point(127, 182);
            this.btnAddToWishlist.Name = "btnAddToWishlist";
            this.btnAddToWishlist.Size = new System.Drawing.Size(112, 27);
            this.btnAddToWishlist.TabIndex = 1;
            this.btnAddToWishlist.Text = "Add to Wishlist";
            this.btnAddToWishlist.UseVisualStyleBackColor = true;
            this.btnAddToWishlist.Click += new System.EventHandler(this.btnAddToWishlist_Click_1);
            // 
            // txtWishlistName
            // 
            this.txtWishlistName.Location = new System.Drawing.Point(96, 45);
            this.txtWishlistName.Name = "txtWishlistName";
            this.txtWishlistName.Size = new System.Drawing.Size(185, 20);
            this.txtWishlistName.TabIndex = 2;
            // 
            // txtItem1
            // 
            this.txtItem1.Location = new System.Drawing.Point(96, 77);
            this.txtItem1.Name = "txtItem1";
            this.txtItem1.Size = new System.Drawing.Size(185, 20);
            this.txtItem1.TabIndex = 3;
            // 
            // txtItem2
            // 
            this.txtItem2.Location = new System.Drawing.Point(96, 109);
            this.txtItem2.Name = "txtItem2";
            this.txtItem2.Size = new System.Drawing.Size(185, 20);
            this.txtItem2.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(96, 138);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(185, 20);
            this.txtAmount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wishlist Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Amount:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 277);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtItem2);
            this.Controls.Add(this.txtItem1);
            this.Controls.Add(this.txtWishlistName);
            this.Controls.Add(this.btnAddToWishlist);
            this.Controls.Add(this.dgvWishlist);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWishlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWishlist;
        private System.Windows.Forms.Button btnAddToWishlist;
        private System.Windows.Forms.TextBox txtWishlistName;
        private System.Windows.Forms.TextBox txtItem1;
        private System.Windows.Forms.TextBox txtItem2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}

