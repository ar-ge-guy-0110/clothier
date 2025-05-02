using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClothierProject
{
    class class_dbconnections
    {
        public static SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothierProject.Properties.Settings.clothierdbConnectionString"].ConnectionString);
        
    }
}
