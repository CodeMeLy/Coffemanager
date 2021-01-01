using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager
{
    public static class DBSQLServerUtils
    {
        public static SqlConnection
                GetDBConnection(string datasource, string database, string user_id, string password)
        {
            //Data Source=DESKTOP-RK8FNMH;Initial Catalog=QLCF_MILANNO;Integrated Security=True;User ID=sa;Password=***********
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;" + "User ID=" + user_id + ";Password =" + password;

            return new SqlConnection(connString);
        }
    }
}