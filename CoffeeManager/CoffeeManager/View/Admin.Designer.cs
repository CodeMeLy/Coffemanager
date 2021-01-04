
namespace CoffeeManager
{
    partial class Admin
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
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btn1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(496, 108);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(191, 132);
            this.metroButton3.TabIndex = 5;
            this.metroButton3.Text = "Đặt đồ uống";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(268, 108);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(191, 132);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Quản lí thức uống";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(29, 108);
            this.btn1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(191, 132);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "Quản lí hóa đơn";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 299);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btn1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Admin";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btn1;
    }
}