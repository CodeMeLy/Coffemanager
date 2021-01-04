using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.control
{
    public class DrinkManager
    {
        public void addDrink(CoffeeManager.model.Drink drink)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert into Drink(id, name, id_drinktype, cost) "
                                                 + " values (@id, @name, @id_drinktype, @cost) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                SqlParameter highSalaryParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                highSalaryParam.Value = drink.Id;
                // Thêm tham số @lowSalary (Viết ngắn hơn nữa).
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = drink.Name;
                cmd.Parameters.Add("@id_drinktype", SqlDbType.Int).Value = drink.IdDrinkType;
                cmd.Parameters.Add("@cost", SqlDbType.Float).Value = drink.Cost;
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
        public void removeDrink(int id)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "delete from Drink where id = @id ";
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
        public void updateDrink(int id, CoffeeManager.model.Drink drink)
        {
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Update Drink set name = @name,id_drinktype = @id_drinktype, cost = @cost where id = @id ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                SqlParameter idParam = cmd.Parameters.Add("@id", SqlDbType.Int);
                idParam.Value = id;
                SqlParameter nameParam = cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                nameParam.Value = drink.Name;
                cmd.Parameters.Add("@id_drinktype", SqlDbType.Int).Value = drink.IdDrinkType;
                cmd.Parameters.Add("@cost", SqlDbType.Float).Value = drink.Cost;
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
        public List<CoffeeManager.model.Drink> GetDrinks()
        {
            List<CoffeeManager.model.Drink> drinks = new List<CoffeeManager.model.Drink>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * From Drink";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["id"].ToString());
                    var name = reader["name"].ToString();
                    var idDrinkType = int.Parse(reader["id_drinktype"].ToString());
                    var cost = float.Parse(reader["cost"].ToString());
                    drinks.Add(new CoffeeManager.model.Drink(id, name, idDrinkType, cost));
                }
            }
            return drinks;
        }
        public List<CoffeeManager.model.Drink> findDrinks(int idsearch)
        {
            List<CoffeeManager.model.Drink> drinks = new List<CoffeeManager.model.Drink>();
            SqlConnection connection = DbUtils.GetDBConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * From Drink where id = @id";
                SqlParameter idParam = command.Parameters.Add("@id", SqlDbType.Int);
                idParam.Value = idsearch;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["id"].ToString());
                    var name = reader["name"].ToString();
                    var idDrinkType = int.Parse(reader["id_drinktype"].ToString());
                    var cost = float.Parse(reader["cost"].ToString());
                    drinks.Add(new CoffeeManager.model.Drink(id, name, idDrinkType, cost));
                }
            }
            return drinks;
        }
    }
}
