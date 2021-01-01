using CoffeeManager.control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System;

namespace Test
{
    [TestClass]
    public class Connection
    {
        [TestMethod]
        public void TestConnection()
        {
            SqlConnection conn = DbUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();
                conn.Close();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
