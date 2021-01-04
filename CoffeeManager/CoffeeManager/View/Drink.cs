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

namespace CoffeeManager.View
{
    public partial class Drink : MetroFramework.Forms.MetroForm
    {
        List<int> idDrinkTypes = new List<int>();
        List<CoffeeManager.model.Drink> drinks = new List<CoffeeManager.model.Drink>();
        public Drink()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DrinkManager drinkManager = new DrinkManager();
                drinkManager.addDrink(new CoffeeManager.model.Drink(int.Parse(txtId.Text.ToString()), txtName.Text.ToString(),int.Parse(cbDrinkType.SelectedItem.ToString()),int.Parse(txtCost.Text.ToString())));
                drinks.Add(new CoffeeManager.model.Drink(int.Parse(txtId.Text.ToString()), txtName.Text.ToString(), int.Parse(cbDrinkType.SelectedItem.ToString()), float.Parse(txtCost.Text.ToString())));
              display();
            }
            catch (Exception)
            {
                MessageBox.Show("thêm vào thất bại");
            }
        }
        public void display()
        {
            DrinkManager drinkManager = new DrinkManager();
            drinks = drinkManager.GetDrinks();
            //Tải dữ liệu lên dataGridView
            dataGridView1.DataSource = drinks;
        }
        private void Drink_Load(object sender, EventArgs e)
        {
            DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
            List<model.DrinkType> drinkTypes = new List<model.DrinkType>();
            drinkTypes = drinkTypeManager.GetDrinkTypes();
            foreach(CoffeeManager.model.DrinkType drinkType in drinkTypes)
            {
                idDrinkTypes.Add(drinkType.Id);
            }
            foreach(int idDrinkType in idDrinkTypes)
            {
                cbDrinkType.Items.Add(idDrinkType);
            }
            display();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DrinkManager drinkManager = new DrinkManager();
                drinkManager.removeDrink(int.Parse(txtId.Text.ToString()));
                display();
            }
            catch (Exception)
            {
                MessageBox.Show("xóa thất bại");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

            DrinkManager drinkManager = new DrinkManager();
            CoffeeManager.model.Drink drink = new CoffeeManager.model.Drink(int.Parse(txtId.Text.ToString()), txtName.Text.ToString(), int.Parse(cbDrinkType.SelectedItem.ToString()), float.Parse(txtCost.Text.ToString()));
            drinkManager.updateDrink(int.Parse(txtId.Text.ToString()), drink);
            display();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DrinkManager drinkManager = new DrinkManager();
                drinks = drinkManager.findDrinks(int.Parse(txtSearchBox.Text.ToString()));
                if (drinks.Count == 0)
                {
                    display();

                }
                //Tải dữ liệu lên dataGridView
                dataGridView1.DataSource = drinks;
            }
            catch (Exception)
            {
                display();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Visible = false;
            Login.ShowDialog();
            this.Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            this.Visible = false;
            employee.ShowDialog();
            this.Close();
        }
    }
}
