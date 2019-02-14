using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using Test.Models;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
   public class SqlConn
    {
        static public string CurrentConnectionString = ConnectionString.defaultString;
        static public string UserConnectionString = ConnectionString.user;
        public class ConnectionString
        {
            static public string defaultString = "Data Source=DESKTOP-RV3DCL8\\SQLEXPRESS;Initial Catalog=KP;Integrated Security=true;";
            static public string user = "Data Source=DESKTOP-RV3DCL8\\SQLEXPRESS;Integrated Security = False; ;Initial Catalog=KP; User ID = AnnaSavenko; Password=anna;ApplicationIntent=ReadWrite;";

            //Data Source=DESKTOP-RV3DCL8\\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=true;"
            // DESKTOP-GGFT0KG\\SQLEXPRESS;
            // static public string user = "Data Source=DESKTOP-GGFT0KG\\SQLEXPRESS;Integrated Security = False; User ID = AnnaSavenko; Password=qwertyuiop1234567890QWE;ApplicationIntent=ReadWrite;";
            //static public string admin = "Data Source=DESKTOP-FFV5E68\\SQLEXPRESS;Integrated Security=False;User ID=adminln;Password=admin;ApplicationIntent=ReadWrite;";
        }

    }
    
}
