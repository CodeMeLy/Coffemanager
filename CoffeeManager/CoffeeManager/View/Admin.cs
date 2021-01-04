using CoffeeManager.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager
{
    public partial class Admin : MetroFramework.Forms.MetroForm
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel17_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BillInfoManager billInfoManager = new BillInfoManager();
            total2.Text = billInfoManager.sumRevenue(fromdate.Value, todate.Value).ToString();
            dataGridView1.DataSource = billInfoManager.findBillInfo(fromdate.Value, todate.Value);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            BillInfoManager billInfoManager = new BillInfoManager();
            dataGridView1.DataSource = billInfoManager.findBillInfo(fromdate.Value, todate.Value);
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("User");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().ToString() == "" || txtPassword.Text.Trim().ToString() == "")
            {
                txtError.Text = "!!! tên và mật khẩu không được để trống";
            }
            if (txtPassword.Text.Trim().ToString() != txtPassword2.Text.Trim().ToString())
            {
                txtError.Text = "!!! mật khẩu nhập lại không trùng khớp";
            }
            else
            {
                txtError.Text = "";
                AccountManager accountManager = new AccountManager();
                bool success = accountManager.createAccount(new model.Account(txtUsername.Text.Trim().ToString(), txtPassword.Text.Trim().ToString(),
                    cbRole.SelectedItem.ToString() == "Admin" ? model.Role.ADMIN : model.Role.EMPLOYEE));
                if (success)
                {
                    MessageBox.Show("Đăng kí thành công!");
                }
                else
                {
                    MessageBox.Show("Đăng kí thất bại!");
                }
            }
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Visible = false;
            Login.ShowDialog();
            this.Close();
        }
    }
}
