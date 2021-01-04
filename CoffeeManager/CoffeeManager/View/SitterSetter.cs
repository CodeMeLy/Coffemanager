using CoffeeManager.control;
using CoffeeManager.model;
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
    public partial class SitterSetter : MetroFramework.Forms.MetroForm
    {
        List<int> idDrinks = new List<int>();
        List<int> selectSitter = new List<int>();
        List<Bill> bills = new List<Bill>();
        List<BillInfo> billInfos = new List<BillInfo>();
        BillInfoManager billInfoManager = new BillInfoManager();
        int currentSelect = 0;
        string idBill;
        public SitterSetter()
        {
            InitializeComponent();
        }

        private void TableSetter_Load(object sender, EventArgs e)
        {
            DrinkManager drinkManager = new DrinkManager();
            List<model.Drink> drinks = new List<model.Drink>();
            BillManager billManager = new BillManager();
            drinks = drinkManager.GetDrinks();
            foreach (CoffeeManager.model.Drink drink in drinks)
            {
                cbDrink.Items.Add(drink.Id);
            }
            // quan li bill
            bills = billManager.GetCallBills();
            if (selectSitter.Count != 0)
            {
                selectSitter.Clear();
            }
            foreach (Bill bill in bills)
            {
                if (bill.Status == "call")
                {
                    cbSitter.Items.Add(bill.IdSitter);
                    cbSitter2.Items.Add(bill.IdSitter);
                }
            }
            loadColorTable();
            display();
        } 
        public void display()
        {
            BillManager billManager = new BillManager();
            BillInfoManager billInfoManager = new BillInfoManager();
            bills = billManager.GetCallBills();
            billInfos = billInfoManager.GetBillInfos(); 
            //Tải dữ liệu lên dataGridView
            dataGridView1.DataSource = bills;
            dataGridView2.DataSource = billInfos;
            dataGridView3.DataSource = bills;

        }
        public void loadColorTable()
        {
            BillManager billManager = new BillManager();
            bills = billManager.GetCallBills();
            if (selectSitter.Count != 0)
            {
                selectSitter.Clear();
            }
                foreach (Bill bill in bills)
            {
                if(bill.Status=="call")
                    selectSitter.Add(bill.IdSitter);
            }
            if (selectSitter.Contains(1))
            {
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(2))
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(3))
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(4))
            {
                button4.BackColor = Color.Red;
            }
            else
            {
                button4.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(5))
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(6))
            {
                button6.BackColor = Color.Red;
            }
            else
            {
                button6.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(7))
            {
                button7.BackColor = Color.Red;
            }
            else
            {
                button7.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(8))
            {
                button8.BackColor = Color.Red;
            }
            else
            {
                button8.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(9))
            {
                button9.BackColor = Color.Red;
            }
            else
            {
                button9.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(10))
            {
                button10.BackColor = Color.Red;
            }
            else
            {
                button10.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(11))
            {
                button11.BackColor = Color.Red;
            }
            else
            {
                button11.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(12))
            {
                button12.BackColor = Color.Red;
            }
            else
            {
                button12.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(13))
            {
                button13.BackColor = Color.Red;
            }
            else
            {
                button13.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(14))
            {
                button14.BackColor = Color.Red;
            }
            else
            {
                button14.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(15))
            {
                button15.BackColor = Color.Red;
            }
            else
            {
                button15.BackColor = Color.Gray;
            }
            if (selectSitter.Contains(16))
            {
                button16.BackColor = Color.Red;
            }
            else
            {
                button16.BackColor = Color.Gray;
            }

        }
        private void metroButton3_Click(object sender, EventArgs e)
        {

        }
        bool wasSetter(int sitterChecker)
        {
            bool flag = false;
            foreach (int sitter in selectSitter)
            {
                if (sitter == sitterChecker)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!wasSetter(1) && emptySitter(1))
            {
                selectSitter.Add(1);
                refreshColor();
                button1.BackColor = Color.Yellow;
                currentSelect = 1;
            }
            else if(wasSetter(1) && emptySitter(1))
            {
                button1.BackColor = Color.Gray;
                selectSitter.Remove(1);
                currentSelect = 0;
            }
        }
        bool emptySitter(int sitter)
        {
            bool flag = true;
            BillManager billManager = new BillManager();
            bills = billManager.GetCallBills();
            foreach(Bill bill in bills)
            {
                if(sitter == bill.IdSitter && bill.Status == "call")
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        private void metroButton1_Click(object sender, EventArgs e)
        {
            BillManager billManager = new BillManager();
            BillInfoManager billInfoManager = new BillInfoManager();
            string idBill = DateTime.Now.ToString();
            if (emptySitter(currentSelect))
            {
                billManager.addBill(new model.Bill(idBill, currentSelect, "call"));
                cbSitter.Items.Add(currentSelect);
                cbSitter2.Items.Add(currentSelect);

            }
            display();
            loadColorTable();
        }
        void refreshColor()
        {
            
        button1.BackColor = Color.Gray;
        button2.BackColor = Color.Gray;
        button3.BackColor = Color.Gray;
        button4.BackColor = Color.Gray;
        button5.BackColor = Color.Gray;
        button6.BackColor = Color.Gray;
        button7.BackColor = Color.Gray;
        button8.BackColor = Color.Gray;
        button9.BackColor = Color.Gray;
        button10.BackColor = Color.Gray;
        button11.BackColor = Color.Gray;
        button12.BackColor = Color.Gray;
        button13.BackColor = Color.Gray;
        button14.BackColor = Color.Gray;
        button15.BackColor = Color.Gray;
        button16.BackColor = Color.Gray;
        loadColorTable();
}
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!wasSetter(2) && emptySitter(2))
            {
                selectSitter.Add(2);
                refreshColor();
                button2.BackColor = Color.Yellow;
                currentSelect = 2;
            }
            else if (wasSetter(2) && emptySitter(2))
            {
                button2.BackColor = Color.Gray;
                selectSitter.Remove(2);
                currentSelect = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!wasSetter(3) && emptySitter(3))
            {
                selectSitter.Add(3);
                refreshColor();
                button3.BackColor = Color.Yellow;
                currentSelect = 3;
            }
            else if (wasSetter(3) && emptySitter(3))
            {
                button3.BackColor = Color.Gray;
                selectSitter.Remove(3);
                currentSelect = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!wasSetter(4) && emptySitter(4))
            {
                selectSitter.Add(4);
                refreshColor();
                button4.BackColor = Color.Yellow;
                currentSelect = 4;
            }
            else if (wasSetter(4) && emptySitter(4))
            {
                button4.BackColor = Color.Gray;
                selectSitter.Remove(4);
                currentSelect = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!wasSetter(5) && emptySitter(5))
            {
                selectSitter.Add(5);
                refreshColor();
                button5.BackColor = Color.Yellow;
                currentSelect = 5;
            }
            else if (wasSetter(5) && emptySitter(5))
            {
                button5.BackColor = Color.Gray;
                selectSitter.Remove(5);
                currentSelect = 0;
            }
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            if (!wasSetter(6) && emptySitter(6))
            {
                selectSitter.Add(6);
                refreshColor();
                button6.BackColor = Color.Yellow;
                currentSelect = 6;
            }
            else if (wasSetter(6) && emptySitter(6))
            {
                button6.BackColor = Color.Gray;
                selectSitter.Remove(6);
                currentSelect = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!wasSetter(7) && emptySitter(7))
            {
                selectSitter.Add(7);
                refreshColor();
                button7.BackColor = Color.Yellow;
                currentSelect = 7;
            }
            else if (wasSetter(7) && emptySitter(7))
            {
                button7.BackColor = Color.Gray;
                selectSitter.Remove(7);
                currentSelect = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!wasSetter(8) && emptySitter(8))
            {
                selectSitter.Add(8);
                refreshColor();
                button8.BackColor = Color.Yellow;
                currentSelect = 8;
            }
            else if (wasSetter(8) && emptySitter(8))
            {
                button8.BackColor = Color.Gray;
                selectSitter.Remove(8);
                currentSelect = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!wasSetter(9) && emptySitter(9))
            {
                selectSitter.Add(9);
                refreshColor();
                button9.BackColor = Color.Yellow;
                button9.BackColor = Color.Yellow;
                currentSelect = 9;
            }
            else if (wasSetter(9) && emptySitter(9))
            {
                button9.BackColor = Color.Gray;
                selectSitter.Remove(9);
                currentSelect = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!wasSetter(10) && emptySitter(10))
            {
                selectSitter.Add(10);
                refreshColor();
                button10.BackColor = Color.Yellow;
                currentSelect = 10;
            }
            else if (wasSetter(10) && emptySitter(10))
            {
                button10.BackColor = Color.Gray;
                selectSitter.Remove(10);
                currentSelect = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!wasSetter(11) && emptySitter(11))
            {
                selectSitter.Add(11);
                refreshColor();
                button11.BackColor = Color.Yellow;
                currentSelect = 11;
            }
            else if (wasSetter(11) && emptySitter(11))
            {
                button11.BackColor = Color.Gray;
                selectSitter.Remove(11);
                currentSelect = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!wasSetter(12) && emptySitter(12))
            {
                selectSitter.Add(12);
                refreshColor();
                button12.BackColor = Color.Yellow;
                currentSelect = 12;
            }
            else if (wasSetter(12) && emptySitter(12))
            {
                button12.BackColor = Color.Gray;
                selectSitter.Remove(12);
                currentSelect = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!wasSetter(13) && emptySitter(13))
            {
                selectSitter.Add(13);
                refreshColor();
                button13.BackColor = Color.Yellow;
                currentSelect = 13;
            }
            else if (wasSetter(13) && emptySitter(13))
            {
                button13.BackColor = Color.Gray;
                selectSitter.Remove(13);
                currentSelect = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!wasSetter(14) && emptySitter(14))
            {
                selectSitter.Add(14);
                refreshColor();
                button14.BackColor = Color.Yellow;
                currentSelect = 14;
            }
            else if (wasSetter(14) && emptySitter(14))
            {
                button14.BackColor = Color.Gray;
                selectSitter.Remove(14);
                currentSelect = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!wasSetter(15) && emptySitter(15))
            {
                selectSitter.Add(15);
                refreshColor();
                button15.BackColor = Color.Yellow;
                currentSelect = 15;
            }
            else if (wasSetter(15) && emptySitter(15))
            {
                button15.BackColor = Color.Gray;
                selectSitter.Remove(15);
                currentSelect = 0;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!wasSetter(16) && emptySitter(16))
            {
                selectSitter.Add(16);
                refreshColor();
                button16.BackColor = Color.Yellow;
                currentSelect = 16;
            }
            else if (wasSetter(16) && emptySitter(16))
            {
                button16.BackColor = Color.Gray;
                selectSitter.Remove(16);
                currentSelect = 0;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e) {
            BillManager billManager = new BillManager();
            List<Bill> bills = new List<Bill>();
            bills = billManager.GetCallBills();
            if(bills.Count != 0)
             {
                foreach (Bill bill in bills)
                {
                        if(int.Parse(cbSitter.SelectedItem.ToString())== bill.IdSitter)
                        {
                            idBill = bill.Id;
                            break;
                        }
                }
                bool wasUpdate = false;
                billInfos = billInfoManager.GetBillInfos();
                BillInfo billInfo = new BillInfo(idBill, int.Parse(cbDrink.SelectedItem.ToString()), int.Parse(txtAmount.Text.ToString()), DateTime.Now, "team-2");
                foreach(BillInfo item in billInfos)
                {
                    if (item.IdDrink == int.Parse(cbDrink.SelectedItem.ToString()) && idBill == item.IdBill)
                    {
                        billInfoManager.updateAmount(idBill, int.Parse(cbDrink.SelectedItem.ToString()), int.Parse(txtAmount.Text.ToString()));
                        wasUpdate = true;
                        break;
                    }
                }
                if(!wasUpdate)
                    billInfoManager.addBillInfo(billInfo);

            }
            if(cbSitter.SelectedItem!=null)
                dataGridView2.DataSource = billInfoManager.findBillInfo(int.Parse(cbSitter.SelectedItem.ToString()));
        }
        private void metroTabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void cbSitter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BillInfoManager billInfoManager = new BillInfoManager();
            dataGridView2.DataSource = billInfoManager.findBillInfo(int.Parse(cbSitter.SelectedItem.ToString()));
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            BillManager billManager = new BillManager();
            billManager.removeBill(currentSelect);
            loadColorTable();
            bills = billManager.GetCallBills();
            cbSitter.Items.Clear();
            cbSitter2.Items.Clear();
            foreach(Bill bill in bills)
            {
                cbSitter.Items.Add(bill.IdSitter);
                cbSitter2.Items.Add(bill.IdSitter);
            }
            display();
        }

        private void cbSitter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            total.Text = (billInfoManager.payBill(int.Parse(cbSitter2.SelectedItem.ToString()))).ToString();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            BillManager billManager = new BillManager();
            billManager.updateStatus(int.Parse(cbSitter2.SelectedItem.ToString()));
            bills = billManager.GetCallBills();
            if (selectSitter.Count != 0)
            {
               
                cbSitter.Items.Clear();
                cbSitter2.Items.Clear();
                selectSitter.Clear();
            }
            foreach (Bill bill in bills)
            {
                if (bill.Status == "call")
                {
                    cbSitter.Items.Add(bill.IdSitter);
                    cbSitter2.Items.Add(bill.IdSitter);
                }
            }
            loadColorTable();
            display();
            total.Text = "0";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BillManager billManager = new BillManager();
            bills = billManager.GetCallBills();
            bool existSitter = false;
            foreach(Bill bill in bills)
            {
                if (txtTo.Text.ToString() == bill.IdSitter.ToString())
                {
                    MessageBox.Show("Vị trí đã có khách khác đặt chỗ!");
                    existSitter = true;
                }
            }
            if (!existSitter)
            {
                billManager.updateSitter(int.Parse(txtFrom.Text.ToString()), int.Parse(txtTo.Text.ToString()));
                loadColorTable();
                cbSitter.Items.Clear();
                cbSitter2.Items.Clear();
                foreach (Bill bill in bills)
                {
                    cbSitter.Items.Add(bill.IdSitter);
                    cbSitter2.Items.Add(bill.IdSitter);
                }
                display();
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Visible = false;
            Login.ShowDialog();
            this.Close();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            this.Visible = false;
            employee.ShowDialog();
            this.Close();
        }
    }
}
