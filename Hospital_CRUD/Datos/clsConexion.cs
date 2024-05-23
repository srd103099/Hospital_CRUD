using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProyectoFinal2.Clases
{
    internal class clsConexion
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
