using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CoffeeManager.model;
namespace CoffeeManager.control
{
    public class AccountManager
    {
        public void createAccount(Account account)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert into Account(username, password, role) "
                                                 + " values (@username, @password, @role) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

          
                SqlParameter highSalaryParam = cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                highSalaryParam.Value = account.Username;

                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = hash.hashString(account.Password);
                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@role", SqlDbType.Int).Value = account.Role;
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
