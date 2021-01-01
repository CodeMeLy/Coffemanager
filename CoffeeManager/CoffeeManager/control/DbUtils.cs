using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.control
{
    public static class DbUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-RK8FNMH";
            string database = "CoffeeManager";
            string user_id = "sa";
            string password = "28091998";
            return DBSQLServerUtils.GetDBConnection(datasource, database, user_id, password);
        }
    }
}
