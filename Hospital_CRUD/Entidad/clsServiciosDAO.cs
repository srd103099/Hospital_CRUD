using Hospital_CRUD.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsServiciosDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsServicio> ObtenerServicio()
        {
            List<clsServicio> Servicioa = new List<clsServicio>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM SERVICIOS", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsServicio Servicios = new clsServicio
                    {
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Servicio = (string)reader["Servicio"],
                 
                    };
                    Servicioa.Add(Servicios);
                }
            }
            return Servicioa;
        }
        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarServicio(clsServicio Servicios)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearServicio", conexion);
                comando.Parameters.AddWithValue("@Id_Servicios", Servicios.Id_Servicios);
                comando.Parameters.AddWithValue("@Id_Consultorio", Servicios.Id_Consultorio);
                comando.Parameters.AddWithValue("@Servicio", Servicios.Servicio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarServicio(clsServicio Servicios)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarServicio", conexion);
                comando.Parameters.AddWithValue("@Id_Servicios", Servicios.Id_Servicios);
                comando.Parameters.AddWithValue("@Id_Consultorio", Servicios.Id_Consultorio);
                comando.Parameters.AddWithValue("@Servicio", Servicios.Servicio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarServicio(int Id_Servicios)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarServicio", conexion);
                comando.Parameters.AddWithValue("@Id_Servicios", Id_Servicios);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsServicio BuscarServicio(int Id_Servicios)
        {
            clsServicio Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerServicio", conexion);
                comando.Parameters.AddWithValue("@Id_Servicios", Id_Servicios);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsServicio
                    {
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Servicio = (string)reader["Servicio"],
                    };
                }
            }
            return Buscar;
        }
    }
}
