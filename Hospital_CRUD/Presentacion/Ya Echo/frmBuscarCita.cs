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
    public partial class frmBuscarCita : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        public frmBuscarCita()
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
            int idCedula;
            if (int.TryParse(txtCedula.Text, out idCedula))
            {
                BuscarCitaPaciente(idCedula);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de cédula válido.");
            }
        }
        private void BuscarCitaPaciente(int idCedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = @"
            SELECT C.Fecha, C.Hora, CO.Nombre AS Consultorio, D.Nombre + ' ' + D.Apellido AS Doctor, D.Especialidad
            FROM CITA C
            INNER JOIN CONSULTORIO CO ON C.Id_Consultorio = CO.Id_Consultorio
            INNER JOIN DOCTOR D ON CO.Id_Consultorio = D.Id_Consultorio
            WHERE C.Id_Cedula = @IdCedula";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdCedula", idCedula);

                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvCitas.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ninguna cita para la cédula proporcionada.");
                        dgvCitas.DataSource = null; // Limpiar el DataGridView si no hay datos
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar la cita: " + ex.Message);
                }
            }
        }
    }
}
