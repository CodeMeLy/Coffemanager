using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeManager.control;
using CoffeeManager.model;
namespace CoffeeManager
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AccountManager accountManager = new AccountManager();
            List<Account> accounts = accountManager.getAccountFromDb();
            foreach(Account account in accounts)
            {
                if (txtUserName.Text.ToString() == account.Username && hash.verityPassword(TxtPassword.Text.ToString(),account.Password))
                {
                    MessageBox.Show("have account in db");
                }
            }
        }
    }
}
