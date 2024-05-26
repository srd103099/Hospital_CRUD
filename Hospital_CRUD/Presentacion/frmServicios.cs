using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_CRUD
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente inicioSesionPasiente = new frmInicioSesionPasiente();
            this.Hide();
            inicioSesionPasiente.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos
            string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;

            // Consulta SQL para obtener todos los servicios
            string consultaSQL = "SELECT * FROM SERVICIOS";

            // Crear una nueva instancia de SqlConnection
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Crear un adaptador de datos SQL para ejecutar la consulta
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaSQL, conexion))
                {
                    // Crear un DataTable para almacenar los resultados
                    DataTable tablaServicios = new DataTable();

                    try
                    {
                        // Abrir la conexión a la base de datos
                        conexion.Open();

                        // Llenar el DataTable con los resultados de la consulta
                        adaptador.Fill(tablaServicios);

                        // Asignar el DataTable como el DataSource del DataGridView
                        dgvServicios.DataSource = tablaServicios;
                    }
                    catch (Exception ex)
                    {
                        // Mostrar un mensaje de error si algo sale mal
                        MessageBox.Show("Error al obtener los servicios: " + ex.Message);
                    }
                }
            }
        }
    }
}
