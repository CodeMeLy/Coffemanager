using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public class BillInfo
    {
        private string idBill;
        private int idDrink;
        private int amount;
        private DateTime billDate;
        private string billCreator;

        public BillInfo(string idBill, int idDrink, int amount, DateTime billDate, string billCreator)
        {
            this.idBill = idBill;
            this.idDrink = idDrink;
            this.amount = amount;
            this.billDate = billDate;
            this.billCreator = billCreator;
        }

        public string IdBill { get => idBill; set => idBill = value; }
        public int IdDrink { get => idDrink; set => idDrink = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime BillDate { get => billDate; set => billDate = value; }
        public string BillCreator { get => billCreator; set => billCreator = value; }
    }
}
