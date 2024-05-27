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
    public partial class frmEvaluacion : Form
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        public frmEvaluacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente inicioSesionPasiente = new frmInicioSesionPasiente();
            this.Hide();
            inicioSesionPasiente.Show();
        }

        private void btnBuscarCita_Click(object sender, EventArgs e)
        {
            int cedula;
            if (int.TryParse(txtCedula.Text, out cedula))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(cadenaConexion))
                    {
                        string query = @"
                        SELECT 
                        C.Id_Cita,
                        D.Id_Doctor,
                        C.Fecha, 
                        C.Hora, 
                        D.Nombre + ' ' + D.Apellido AS 'Especialista', 
                        D.Especialidad
                        FROM CITA C
                        INNER JOIN CONSULTORIO CO ON C.Id_Consultorio = CO.Id_Consultorio
                        INNER JOIN DOCTOR D ON CO.Id_Consultorio = D.Id_Consultorio
                        WHERE C.Id_Cedula = @Cedula";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Cedula", cedula);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dgvCitas.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron citas para la cédula proporcionada.");
                                dgvCitas.DataSource = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la información de la cita: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
            }
        }

        private void GuardarEvaluacion(int idDoctor, int idCita, int calificacionProfesional, int calificacionServicio)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    string storedProcedure = "SP_CrearEvaluacion";
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id_Doctor", idDoctor);
                        command.Parameters.AddWithValue("@Id_Cita", idCita);
                        command.Parameters.AddWithValue("@Calificacion_Profesional", calificacionProfesional);
                        command.Parameters.AddWithValue("@Calificasion_Servicio", calificacionServicio);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Evaluación guardada con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la evaluación: " + ex.Message);
            }
        }

        private void btnCalificacion_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una cita de la lista.");
                return;
            }

            var selectedRow = dgvCitas.SelectedRows[0];

            if (selectedRow.Cells["Id_Cita"].Value == null || selectedRow.Cells["Id_Doctor"].Value == null)
            {
                MessageBox.Show("La cita seleccionada no tiene toda la información necesaria.");
                return;
            }

            int idCita = Convert.ToInt32(selectedRow.Cells["Id_Cita"].Value);
            int idDoctor = Convert.ToInt32(selectedRow.Cells["Id_Doctor"].Value);

            int calificacionProfesional = (int)nudEspecialista.Value;
            int calificacionServicio = (int)nudCita.Value;

            GuardarEvaluacion(idDoctor, idCita, calificacionProfesional, calificacionServicio);
        }
    }
}
