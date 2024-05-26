using Hospital_CRUD.Entidad;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD
{
    internal class clsCitaDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsCita> ObtenerCita()
        {
            List<clsCita> Cita = new List<clsCita>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM CITA", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsCita CitasMedicas = new clsCita
                    {
                        Id_Cita = (int)reader["Id_Cita"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Cedula = (int)reader["Id_Cedula"],
                        //Fecha = (DateTime)reader["Fecha"],
                        Hora = (string)reader["Hora"],
                    };
                    Cita.Add(CitasMedicas);
                }
            }
            return Cita;
        }
        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarCita(clsCita CitasMedicas)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearCita", conexion);
                comando.Parameters.AddWithValue("@Id_Cita", CitasMedicas.Id_Cita);
                comando.Parameters.AddWithValue("@Id_Consultorio", CitasMedicas.Id_Consultorio);
                comando.Parameters.AddWithValue("@Id_Servicios", CitasMedicas.Id_Servicios);
                comando.Parameters.AddWithValue("@Id_Cedula", CitasMedicas.Id_Cedula);
                comando.Parameters.AddWithValue("@Fecha", CitasMedicas.Fecha);
                comando.Parameters.AddWithValue("@Hora", CitasMedicas.Hora);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarCita(clsCita CitasMedicas)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarCita", conexion);
                comando.Parameters.AddWithValue("@Id_Cita", CitasMedicas.Id_Cita);
                comando.Parameters.AddWithValue("@Id_Consultorio", CitasMedicas.Id_Consultorio);
                comando.Parameters.AddWithValue("@Id_Servicios", CitasMedicas.Id_Servicios);
                comando.Parameters.AddWithValue("@Id_Cedula", CitasMedicas.Id_Cedula);
                //comando.Parameters.AddWithValue("@Fecha", CitasMedicas.Fecha);
                comando.Parameters.AddWithValue("@Hora", CitasMedicas.Hora);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarCita(int id_Cita)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarCita", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", id_Cita);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsCita BuscarCita(int id_Cita)
        {
            clsCita Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerCita", conexion);
                comando.Parameters.AddWithValue("@id_Cita", id_Cita);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsCita
                    {
                        Id_Cita = (int)reader["Id_Cita"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Fecha = (DateTime)reader["Fecha"],
                        Hora = (string)reader["Hora"],
                    };
                }
            }
            return Buscar;
        }
    }
}


        
