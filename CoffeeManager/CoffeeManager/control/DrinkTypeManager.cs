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
    public class DrinkTypeManager
    {
        public void addDrinkType(CoffeeManager.model.DrinkType drinkType)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert into DrinkType(id, name) "
                                                 + " values (@id, @name) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;


                SqlParameter highSalaryParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                highSalaryParam.Value = drinkType.Id;

                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = drinkType.Name;
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
        public void removeDrinkType(int id)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "delete from DrinkType where id = @id ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter highSalaryParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                highSalaryParam.Value = id;

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
        public void updateDrinkType(int id, CoffeeManager.model.DrinkType drinkType)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Update DrinkType set name = @name where id = @id ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter idParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                idParam.Value = id;
                SqlParameter nameParam = cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                nameParam.Value = drinkType.Name;
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

        public List<CoffeeManager.model.DrinkType> GetDrinkTypes()
        {
            List<CoffeeManager.model.DrinkType> drinkTypes = new List<CoffeeManager.model.DrinkType>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * From DrinkType";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["id"].ToString());
                    var name = reader["name"].ToString();
                    drinkTypes.Add(new CoffeeManager.model.DrinkType(id, name));
                }
            }
            return drinkTypes;
        }
        public List<CoffeeManager.model.DrinkType> findDrinkTypes(int idsearch)
        {
            List<CoffeeManager.model.DrinkType> drinkTypes = new List<CoffeeManager.model.DrinkType>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * From DrinkType where id = @id";
                SqlParameter idParam = command.Parameters.Add("@id", SqlDbType.Int);
                idParam.Value = idsearch;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["id"].ToString());
                    var name = reader["name"].ToString();
                    drinkTypes.Add(new CoffeeManager.model.DrinkType(id, name));
                }
            }
            return drinkTypes;
        }
    }

}
