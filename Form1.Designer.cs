
namespace WindowsFormsApp5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDish = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDel1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboCook = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.comboOrders = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(321, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Choose a cafe...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(284, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAKE A ORDER!";
            // 
            // comboBoxDish
            // 
            this.comboBoxDish.FormattingEnabled = true;
            this.comboBoxDish.Location = new System.Drawing.Point(321, 190);
            this.comboBoxDish.Name = "comboBoxDish";
            this.comboBoxDish.Size = new System.Drawing.Size(142, 24);
            this.comboBoxDish.TabIndex = 4;
            this.comboBoxDish.Text = "Choose a dish...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add to order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 6;
            // 
            // comboDel1
            // 
            this.comboDel1.FormattingEnabled = true;
            this.comboDel1.Location = new System.Drawing.Point(129, 160);
            this.comboDel1.Name = "comboDel1";
            this.comboDel1.Size = new System.Drawing.Size(146, 24);
            this.comboDel1.TabIndex = 7;
            this.comboDel1.Text = "Choose to delete...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(129, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Short/Full INFO";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Sort by price";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 29);
            this.button5.TabIndex = 11;
            this.button5.Text = "Filter by Cook";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboCook
            // 
            this.comboCook.FormattingEnabled = true;
            this.comboCook.Location = new System.Drawing.Point(12, 13);
            this.comboCook.Name = "comboCook";
            this.comboCook.Size = new System.Drawing.Size(144, 24);
            this.comboCook.TabIndex = 12;
            this.comboCook.Text = "Choose a cook...";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 401);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 37);
            this.button6.TabIndex = 13;
            this.button6.Text = "Save your order";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(321, 250);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(142, 31);
            this.buttonPay.TabIndex = 14;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // comboOrders
            // 
            this.comboOrders.FormattingEnabled = true;
            this.comboOrders.Location = new System.Drawing.Point(628, 16);
            this.comboOrders.Name = "comboOrders";
            this.comboOrders.Size = new System.Drawing.Size(160, 24);
            this.comboOrders.TabIndex = 15;
            this.comboOrders.Text = "Choose payed order...";
            this.comboOrders.SelectedIndexChanged += new System.EventHandler(this.comboOrders_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(628, 46);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 30);
            this.button7.TabIndex = 16;
            this.button7.Text = "Release pay-menu";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.comboOrders);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.comboCook);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboDel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxDish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDish;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboCook;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.ComboBox comboOrders;
        private System.Windows.Forms.Button button7;
    }
}

