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
    internal class clsDoctorDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsDoctor> ObtenerDoctor()
        {
            List<clsDoctor> Doctor = new List<clsDoctor>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM DOCTOR", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsDoctor Doctores = new clsDoctor
                    {
                        Id_Doctor = (int)reader["Id_Doctor"],
                        Id_UsuarioDoctor = (int)reader["Id_UsuarioDoctor"],
                        Nombre = (string)reader["Nombre"],
                        Apellido = (string)reader["Apellido"],
                        Especialidad = (string)reader["Especialidad"],
                 
                    };
                    Doctor.Add(Doctores);
                }
            }
            return Doctor;
        }

        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarDoctor(clsDoctor Doctores)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearDoctor", conexion);
                comando.Parameters.AddWithValue("@Id_Doctor", Doctores.Id_Doctor);
                comando.Parameters.AddWithValue("@Id_UsuarioDoctor", Doctores.Id_UsuarioDoctor);
                comando.Parameters.AddWithValue("@Nombre", Doctores.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Doctores.Apellido);
                comando.Parameters.AddWithValue("@Especialidad", Doctores.Especialidad);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarDoctor(clsDoctor Doctores)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarDoctor", conexion);
                comando.Parameters.AddWithValue("@Id_Doctor", Doctores.Id_Doctor);
                comando.Parameters.AddWithValue("@Id_UsuarioDoctor", Doctores.Id_UsuarioDoctor);
                comando.Parameters.AddWithValue("@Nombre", Doctores.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Doctores.Apellido);
                comando.Parameters.AddWithValue("@Especialidad", Doctores.Especialidad);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarDoctor(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarDoctor", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", id);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsDoctor BuscarDoctor(int Id_Cedula)
        {
            clsDoctor Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerDoctor", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Id_Cedula);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsDoctor
                    {
                        Id_Doctor = (int)reader["Id_Doctor"],
                        Id_UsuarioDoctor = (int)reader["Id_UsuarioDoctor"],
                        Nombre = (string)reader["Nombre"],
                        Apellido = (string)reader["Apellido"],
                        Especialidad = (string)reader["Especialidad"],
                    };
                }
            }
            return Buscar;
        }
    }
}
