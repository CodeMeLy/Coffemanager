using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.control
{
    public class BillManager
    {
        public void addBill(CoffeeManager.model.Bill bill)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert into Bill(id, id_sitter, status) "
                                                 + " values (@id, @id_sitter, @status) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                SqlParameter highSalaryParam = cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                highSalaryParam.Value = bill.Id;
                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@id_sitter", SqlDbType.Int).Value = bill.IdSitter;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = bill.Status;
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
        public List<CoffeeManager.model.Bill> GetCallBills()
        {
            List<CoffeeManager.model.Bill> bills = new List<CoffeeManager.model.Bill>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * From Bill where status = 'call'";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["id"].ToString();
                    var idSitter = int.Parse(reader["id_sitter"].ToString());
                    var status = reader["status"].ToString();
                    bills.Add(new CoffeeManager.model.Bill(id,idSitter,status));
                }
            }
            return bills;
        }
        
        public void removeBill(int sitter)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "delete from Bill where id_sitter = @id_sitter and status = 'call' ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter highSalaryParam = cmd.Parameters.Add("@id_sitter", SqlDbType.Int);
                highSalaryParam.Value = sitter;

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
        public void updateStatus(int sitter)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Update Bill set status = 'paid' where id_sitter = @id_sitter and status = 'call'";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter highSalaryParam = cmd.Parameters.Add("@id_sitter", SqlDbType.Int);
                highSalaryParam.Value = sitter;

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
        public void updateSitter(int from, int to)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Update Bill set id_sitter = @to where id_sitter = @from and status = 'call'";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter fromParam = cmd.Parameters.Add("@from", SqlDbType.Int);
                fromParam.Value = from;
                SqlParameter toParam = cmd.Parameters.Add("@to", SqlDbType.Int);
                toParam.Value = to;
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
    }
}
