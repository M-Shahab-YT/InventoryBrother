namespace CustomerDisplay
{
    partial class frmCustomerDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtTotalDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timr = new System.Windows.Forms.Timer(this.components);
            this.lblWelcome = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUB TOTAL:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.Font = new System.Drawing.Font("Digital-7", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.White;
            this.txtSubTotal.Location = new System.Drawing.Point(243, 78);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(671, 95);
            this.txtSubTotal.TabIndex = 1;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.txtTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Digital-7", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.txtTotalDiscount.Location = new System.Drawing.Point(243, 186);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.ReadOnly = true;
            this.txtTotalDiscount.Size = new System.Drawing.Size(671, 95);
            this.txtTotalDiscount.TabIndex = 3;
            this.txtTotalDiscount.TabStop = false;
            this.txtTotalDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "TOTAL DISCOUNT:";
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.txtNetTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNetTotal.Font = new System.Drawing.Font("Digital-7", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetTotal.ForeColor = System.Drawing.Color.White;
            this.txtNetTotal.Location = new System.Drawing.Point(243, 294);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.Size = new System.Drawing.Size(671, 95);
            this.txtNetTotal.TabIndex = 5;
            this.txtNetTotal.TabStop = false;
            this.txtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "NET TOTAL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWelcome);
            this.groupBox1.Controls.Add(this.txtNetTotal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTotalDiscount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSubTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(93, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 462);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YOUR SALES ORDER SUMMARY";
            // 
            // timr
            // 
            this.timr.Enabled = true;
            this.timr.Tick += new System.EventHandler(this.timr_Tick);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            this.lblWelcome.Location = new System.Drawing.Point(344, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(440, 25);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.Text = "WELCOME TO HEELA KAMALI PHARMACY";
            // 
            // frmCustomerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1371, 601);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerDisplay";
            this.Text = "Customer Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomerDisplay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtTotalDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timr;
        private System.Windows.Forms.Label lblWelcome;
    }
}