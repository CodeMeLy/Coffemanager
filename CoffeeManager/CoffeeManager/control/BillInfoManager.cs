using CoffeeManager.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.control
{
    public class BillInfoManager
    {
        public void addBillInfo(CoffeeManager.model.BillInfo billInfo)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert into BillInfo(id_bill, id_drink, amount, bill_date, bill_creator) "
                                                 + " values (@id_bill, @id_drink, @amount,@bill_date, @bill_creator) ";//2 thuộc tính thêm ssau

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@id_drink", SqlDbType.Int).Value = billInfo.IdDrink;
                cmd.Parameters.Add("@id_bill", SqlDbType.NVarChar).Value = billInfo.IdBill;
                cmd.Parameters.Add("@amount", SqlDbType.Int).Value = billInfo.Amount;
                cmd.Parameters.Add("@bill_date", SqlDbType.Date).Value = billInfo.BillDate;
                cmd.Parameters.Add("@bill_creator", SqlDbType.NVarChar).Value = billInfo.BillCreator;
                // Thực thi Command (Dùng cho delete, insert, update). 
                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
        public void updateAmount(string bill,int drink, int amount)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Update BillInfo set amount = amount + @amount where id_bill = @id_bill and id_drink = @id_drink ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter idParam = cmd.Parameters.Add("@amount", SqlDbType.Int);
                idParam.Value = amount;
                SqlParameter nameParam = cmd.Parameters.Add("@id_bill", SqlDbType.NVarChar);
                nameParam.Value = bill;
                cmd.Parameters.Add("@id_drink", SqlDbType.Int).Value = drink;
                // Thực thi Command (Dùng cho delete, insert, update). 
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
        public List<CoffeeManager.model.BillInfo> GetBillInfos()
        {
            List<CoffeeManager.model.BillInfo> billinfos = new List<CoffeeManager.model.BillInfo>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select id_bill,id_drink, bill_creator,bill_date,amount From BillInfo " +
                    "inner join bill " +
                    "on billinfo.id_bill = bill.id and bill.status = 'call'";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var idBill = reader["id_bill"].ToString();
                    var idDrink = int.Parse(reader["id_drink"].ToString());
                    var billCreator = reader["bill_creator"].ToString();
                    var billDate = DateTime.Parse(reader["bill_date"].ToString());
                    var amount = int.Parse(reader["amount"].ToString());
                    billinfos.Add(new CoffeeManager.model.BillInfo(idBill,idDrink,amount,billDate,billCreator));
                }
            }
            return billinfos;
        }
        public List<CoffeeManager.model.BillInfo> findBillInfo(int sitter)
        {
            List<CoffeeManager.model.BillInfo> billinfos = new List<CoffeeManager.model.BillInfo>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select id_bill,id_drink, bill_creator,bill_date,amount From BillInfo " +
                    "inner join bill " +
                    "on billinfo.id_bill = bill.id and bill.status = 'call' and bill.id_sitter = @id_sitter";

                command.Parameters.Add("@id_sitter", SqlDbType.Int).Value = sitter;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var idBill = reader["id_bill"].ToString();
                    var idDrink = int.Parse(reader["id_drink"].ToString());
                    var billCreator = reader["bill_creator"].ToString();
                    var billDate = DateTime.Parse(reader["bill_date"].ToString());
                    var amount = int.Parse(reader["amount"].ToString());
                    billinfos.Add(new CoffeeManager.model.BillInfo(idBill, idDrink, amount, billDate, billCreator));
                }
            }
            return billinfos;
        }
        public List<CoffeeManager.model.BillInfo> findBillInfo(DateTime from, DateTime to)
        {
            List<CoffeeManager.model.BillInfo> billinfos = new List<CoffeeManager.model.BillInfo>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select id_bill,id_drink, bill_creator,bill_date,amount From BillInfo " +
                    "inner join bill " +
                    "on billinfo.id_bill = bill.id and bill.status = 'paid' and bill_date between @from and @to";

                command.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
                command.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var idBill = reader["id_bill"].ToString();
                    var idDrink = int.Parse(reader["id_drink"].ToString());
                    var billCreator = reader["bill_creator"].ToString();
                    var billDate = DateTime.Parse(reader["bill_date"].ToString());
                    var amount = int.Parse(reader["amount"].ToString());
                    billinfos.Add(new CoffeeManager.model.BillInfo(idBill, idDrink, amount, billDate, billCreator));
                }
            }
            return billinfos;
        }
        public float payBill(int sitter)
        {
            float total = 0;
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select billinfo.amount,drink.cost From BillInfo,drink,bill " +
                    "where bill.id_sitter = @id_sitter and billInfo.id_drink = drink.id and billInfo.id_bill = bill.id";
                command.Parameters.Add("@id_sitter", SqlDbType.Int).Value = sitter;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var amount = int.Parse(reader["amount"].ToString());
                    var cost = float.Parse(reader["cost"].ToString());
                    total += amount * cost;
                }
            }
            return total;
        }
        public float sumRevenue(DateTime from, DateTime to)// tổng doanh thu
        {
            float total = 0;
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select billinfo.amount,drink.cost From BillInfo,drink " +
                    "where billInfo.id_drink = drink.id and billinfo.bill_date between @from and @to";
                command.Parameters.Add("@from", SqlDbType.DateTime).Value = from;
                command.Parameters.Add("@to", SqlDbType.DateTime).Value = to;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var amount = int.Parse(reader["amount"].ToString());
                    var cost = float.Parse(reader["cost"].ToString());
                    total += amount * cost;
                }
            }
            return total;
        }
        
    }
}
