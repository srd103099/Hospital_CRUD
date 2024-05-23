using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Entidad
{
    internal class clsUsuario_DoctorDOA
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;

        // Coneccion de SQL Server para poder obtener Usuario Doctor
        public static List<clsUsuario_Doctor> ObtenerUsuarioDoctor()
        {
            List<clsUsuario_Doctor> InicioSesionDoctor = new List<clsUsuario_Doctor>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO_DOCOTR", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsUsuario_Doctor IniciarSesionDoctores = new clsUsuario_Doctor
                    {
                        Id_Doctor = (int)reader["Id_Doctor"],
                        Usuario_Doctor = (string)reader["Usuario_Doctor"],
                        Contrasena = (string)reader["Contrasena"],
                    };
                    InicioSesionDoctor.Add(IniciarSesionDoctores);
                }
            }
            return InicioSesionDoctor;
        }

    }
}

