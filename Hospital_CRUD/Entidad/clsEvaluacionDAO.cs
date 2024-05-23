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
    internal class clsEvaluacionDAO
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        // Coneccion de SQL Server para poder obtener la informacion de la base de datos
        public static List<clsEvaluacion> ObtenerEvaluacion()
        {
            List<clsEvaluacion> Evaluacion = new List<clsEvaluacion>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM EVALUACION", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsEvaluacion Evaluaciones = new clsEvaluacion
                    {
                        Id_Evaluacion = (int)reader["Id_Evaluacion"],
                        Id_Doctor = (int)reader["Id_Doctor"],
                        Id_Cita = (int)reader["Id_Cita"],
                        Calificacion_Profesional = (int)reader["Calificacion_Profesional"],
                        Calificasion_Servicio = (int)reader["Calificasion_Servicio"],
                    };
                    Evaluacion.Add(Evaluaciones);
                }
            }
            return Evaluacion;
        }

        // Coneccion de SQL Server para poder agregar los procedimientos CRUD
        public static void AgregarEvaluacion(clsEvaluacion Evaluaciones)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_CrearEvaluacion", conexion);
                comando.Parameters.AddWithValue("@Id_Evaluacion", Evaluaciones.Id_Evaluacion);
                comando.Parameters.AddWithValue("@Id_Doctor", Evaluaciones.Id_Doctor);
                comando.Parameters.AddWithValue("@Id_Cita", Evaluaciones.Id_Cita);
                comando.Parameters.AddWithValue("@Calificacion_Profesional", Evaluaciones.Calificacion_Profesional);
                comando.Parameters.AddWithValue("@Calificasion_Servicio", Evaluaciones.Calificasion_Servicio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder modificar los procedimientos CRUD

        public static void ModificarEvaluacion(clsEvaluacion Evaluaciones)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarEvaluacion", conexion);
                comando.Parameters.AddWithValue("@Id_Evaluacion", Evaluaciones.Id_Evaluacion);
                comando.Parameters.AddWithValue("@Id_Doctor", Evaluaciones.Id_Doctor);
                comando.Parameters.AddWithValue("@Id_Cita", Evaluaciones.Id_Cita);
                comando.Parameters.AddWithValue("@Calificacion_Profesional", Evaluaciones.Calificacion_Profesional);
                comando.Parameters.AddWithValue("@Calificasion_Servicio", Evaluaciones.Calificasion_Servicio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder eliminar los procedimientos CRUD
        public static void EliminarEvaluacion(int Id_Evaluacion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarEvaluacion", conexion);
                comando.Parameters.AddWithValue("@Id_Evaluacion", Id_Evaluacion);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        // Coneccion de SQL Server para poder buscar los procedimientos CRUD
        public static clsEvaluacion BuscarEvaluacion(int Id_Evaluacion)
        {
            clsEvaluacion Buscar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_ObtenerEvaluacion", conexion);
                comando.Parameters.AddWithValue("@Id_Evaluacion", Id_Evaluacion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    Buscar = new clsEvaluacion
                    {
                        Id_Evaluacion = (int)reader["Id_Evaluacion"],
                        Id_Doctor = (int)reader["Id_Doctor"],
                        Id_Cita = (int)reader["Id_Cita"],
                        Calificacion_Profesional = (int)reader["Calificacion_Profesional"],
                        Calificasion_Servicio = (int)reader["Calificasion_Servicio"],
                    };
                }
            }
            return Buscar;
        }
    }
}

