using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CRUD.Datos
{
    internal class clsServiciosDoctorDAO
    {
        public static List<clsServiciosDoctor> ObtenerServiciosDoctor(string cadenaConexion)
        {
            List<clsServiciosDoctor> serviciosDoctor = new List<clsServiciosDoctor>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT Id_Servicio, Id_Doctor, Id_ServicioDoctor FROM SERVICIOS_DOCTOR", conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    clsServiciosDoctor servicioDoctor = new clsServiciosDoctor();
                    servicioDoctor.Id_ServicioDoctor = reader.GetInt32(0);
                    servicioDoctor.Id_Doctor = reader.GetInt32(1);
                    servicioDoctor.Id_Servicio = reader.GetInt32(3);

                    serviciosDoctor.Add(servicioDoctor);
                }

                reader.Close();
            }

            return serviciosDoctor;
        }
    }
}
