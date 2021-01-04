using CoffeeManager.View;
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
    public partial class Employee : MetroFramework.Forms.MetroForm
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DrinkType drinkTypeForm = new DrinkType();
            this.Visible = false;
            drinkTypeForm.ShowDialog();
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Drink drink = new Drink();
            this.Visible = false;
            drink.ShowDialog();
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            SitterSetter tableSetter = new SitterSetter();
            this.Visible = false;
            tableSetter.ShowDialog();
            this.Close();
        }
    }
}
