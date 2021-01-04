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
namespace CoffeeManager
{
    public partial class DrinkType : MetroFramework.Forms.MetroForm
    {
        List<model.DrinkType> drinkTypes = new List<model.DrinkType>();
        public DrinkType()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
                drinkTypeManager.addDrinkType(new model.DrinkType(int.Parse(txtId.Text.ToString()), txtName.Text.ToString()));
                drinkTypes.Add(new model.DrinkType(int.Parse(txtId.Text.ToString()), txtName.Text.ToString()));
                display();
            }
            catch (Exception)
            {
                MessageBox.Show("thêm vào thất bại");
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try {
            
                DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
                drinkTypeManager.removeDrinkType(int.Parse(txtId.Text.ToString()));
                display();
            }
            catch (Exception)
            {
                MessageBox.Show("xóa thất bại");
            }
        }
        public void display()
        {
            DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
            drinkTypes = drinkTypeManager.GetDrinkTypes();
            //Tải dữ liệu lên dataGridView
            dataGridView1.DataSource = drinkTypes;
        }
        private void DrinkType_Load(object sender, EventArgs e)
        {
            display();  
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

            DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
            drinkTypeManager.updateDrinkType(int.Parse(txtId.Text.ToString()),new CoffeeManager.model.DrinkType(int.Parse(txtId.Text.ToString()), txtName.Text.ToString()));
            display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DrinkTypeManager drinkTypeManager = new DrinkTypeManager();
                drinkTypes = drinkTypeManager.findDrinkTypes(int.Parse(txtSearch.Text.ToString()));
                if (drinkTypes.Count == 0)
                {
                    display();

                }
                //Tải dữ liệu lên dataGridView
                dataGridView1.DataSource = drinkTypes;
            }
            catch (Exception)
            {
                display();
            }
        }
    }
}
