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
    internal class clsConsultorioDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsConsultorio> ObtenerConsultorio()
        {
            List<clsConsultorio> Consultorio = new List<clsConsultorio>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM CONSULTORIO", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsConsultorio Consultorios = new clsConsultorio
                    {
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Hospital = (int)reader["Id_Hospital"],
                        Nombre = (string)reader["Nombre"],
                        Disponibilidad = (string)reader["Disponibilidad"],
                    };
                    Consultorio.Add(Consultorios);
                }
            }
            return Consultorio;
        }
        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarConsultorio(clsConsultorio Consultorios)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearConsultorio", conexion);
                comando.Parameters.AddWithValue("@Id_Consultorio", Consultorios.Id_Consultorio);
                comando.Parameters.AddWithValue("@Id_Hospital", Consultorios.Id_Hospital);
                comando.Parameters.AddWithValue("@Nombre", Consultorios.Nombre);
                comando.Parameters.AddWithValue("@Disponibilidad", Consultorios.Disponibilidad);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarConsultorio(clsConsultorio Consultorios)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarConsultorio", conexion);
                comando.Parameters.AddWithValue("@Id_Consultorio", Consultorios.Id_Consultorio);
                comando.Parameters.AddWithValue("@Id_Hospital", Consultorios.Id_Hospital);
                comando.Parameters.AddWithValue("@Nombre", Consultorios.Nombre);
                comando.Parameters.AddWithValue("@Disponibilidad", Consultorios.Disponibilidad);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarConsultorio(int Id_Consultorio)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarConsultorio", conexion);
                comando.Parameters.AddWithValue("@Id_Consultorio", Id_Consultorio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsConsultorio BuscarConsultorio(int Id_Consultorio)
        {
            clsConsultorio Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerConsultorio", conexion);
                comando.Parameters.AddWithValue("@id_Cita", Id_Consultorio);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsConsultorio
                    {
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Hospital = (int)reader["Id_Hospital"],
                        Nombre = (string)reader["Nombre"],
                        Disponibilidad = (string)reader["Disponibilidad"],
                    };
                }
            }
            return Buscar;
        }
    }
}
