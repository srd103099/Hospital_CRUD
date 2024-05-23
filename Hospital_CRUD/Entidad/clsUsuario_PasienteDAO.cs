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
    internal class clsUsuario_PasienteDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;

        // Coneccion de SQL Server para poder obtener Usuario Pasiente

        public static List<clsUsuario_Pasiente> ObtenerUsuarioPasiente()
        {
            List<clsUsuario_Pasiente> InicioSesionPasiente = new List<clsUsuario_Pasiente>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO_PASIENTE", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsUsuario_Pasiente InicioSesionPasientes = new clsUsuario_Pasiente
                    {
                        Id_Hospital = (int)reader["Id_Hospital"],
                        Id_Pasiente = (int)reader["Id_Pasiente"],
                        Usuario_Pasiente = (string)reader["Usuario_Pasiente"],
                        Contrasena = (string)reader["Contrasena"],
                    };
                    InicioSesionPasiente.Add(InicioSesionPasientes);
                }
            }
            return InicioSesionPasiente;
        }

        // Coneccion de SQL Server para agregar Usuario
        public static void AgregarUsuarioPasiente(clsUsuario_Pasiente InicioSesionPasiente)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearUsuarioPasiente", conexion);
                comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado
                comando.Parameters.AddWithValue("@Id_Hospital", InicioSesionPasiente.Id_Hospital);
                comando.Parameters.AddWithValue("@Usuario_Pasiente", InicioSesionPasiente.Usuario_Pasiente);
                comando.Parameters.AddWithValue("@Contrasena", InicioSesionPasiente.Contrasena);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

    }







}
