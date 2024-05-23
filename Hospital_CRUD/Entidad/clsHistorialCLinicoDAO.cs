using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Entidad
{
    internal class clsHistorialCLinicoDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsHistorialClinico> ObtenerHistorial()
        {
            List<clsHistorialClinico> Historial = new List<clsHistorialClinico>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand("SELECT * FROM HISTORIA_CLINICA", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsHistorialClinico HistorialCLinico = new clsHistorialClinico
                    {
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Descripcion = (string)reader["Descripcion"],
                    };
                    Historial.Add(HistorialCLinico);
                }
            }
            return Historial;
        }

        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarHistorial(clsHistorialClinico HistorialCLinico)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearHistorialClinico", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", HistorialCLinico.Id_Cedula);
                comando.Parameters.AddWithValue("@Descripcion", HistorialCLinico.Descripcion);
  
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public static void ModificarHistoriale(clsHistorialClinico HistorialCLinico)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarHistorialClinico", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", HistorialCLinico.Id_Cedula);
                comando.Parameters.AddWithValue("@Descripcion", HistorialCLinico.Descripcion);
      
                comando.ExecuteNonQuery();
            }
        }

        public static void EliminarHistorial(int Id_Cedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarHistorialClinico", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Id_Cedula);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public static clsHistorialClinico BuscarHistorial(int Id_Cedula)
        {
            clsHistorialClinico Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerPasientePorId", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Id_Cedula);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsHistorialClinico
                    {
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Descripcion = (string)reader["Descripcion"],
                    };
                }
            }
            return Buscar;
        }
    }
}
