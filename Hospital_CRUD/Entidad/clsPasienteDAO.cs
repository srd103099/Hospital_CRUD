using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Entidad
{
    internal class clsPasienteDAO
    {

        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsPasiente> ObtenerPasiente()
        {
            List<clsPasiente> Registro = new List<clsPasiente>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM PASIENTE", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsPasiente Registros = new clsPasiente
                    {
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Id_UsuarioPasiente = (int)reader["Id_UsuarioPasiente"],
                        Nombre = (string)reader["Nombre"],
                        Apellido = (string)reader["Apellido"],
                        Telefono = (int)reader["Telefono"],
                        Correo = (string)reader["Correo"],
                    };
                    Registro.Add(Registros);
                }
            }
            return Registro;
        }

        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarPasiente(clsPasiente Registros)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearPasiente", conexion);
                comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado
                comando.Parameters.AddWithValue("@Id_Cedula", Registros.Id_Cedula);
                comando.Parameters.AddWithValue("@Nombre", Registros.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Registros.Apellido);
                comando.Parameters.AddWithValue("@Telefono", Registros.Telefono);
                comando.Parameters.AddWithValue("@Correo", Registros.Correo);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarPasiente(clsPasiente Registros)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarPasiente", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Registros.Id_Cedula);
                comando.Parameters.AddWithValue("@Id_UsuarioPasiente", Registros.Id_UsuarioPasiente);
                comando.Parameters.AddWithValue("@Nombre", Registros.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Registros.Apellido);
                comando.Parameters.AddWithValue("@Telefono", Registros.Telefono);
                comando.Parameters.AddWithValue("@Correo", Registros.Correo);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarPasiente(int Id_Cedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarPaciente", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Id_Cedula);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsPasiente BuscarPasiente(int Id_Cedula)
        {
            clsPasiente Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerPasientePorId", conexion);
                comando.Parameters.AddWithValue("@Id_Cedula", Id_Cedula);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsPasiente
                    {
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Id_UsuarioPasiente = (int)reader["Id_UsuarioPasiente"],
                        Nombre = (string)reader["Nombre"],
                        Apellido = (string)reader["Apellido"],
                        Telefono = (int)reader["Telefono"],
                        Correo = (string)reader["Correo"],
                    };
                }
            }
            return Buscar;
        }
    }
}
