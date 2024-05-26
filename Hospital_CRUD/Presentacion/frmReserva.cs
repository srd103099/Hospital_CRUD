using Hospital_CRUD.Entidad;
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
    public partial class frmReserva : Form
    {
        public frmReserva()
        {
            InitializeComponent();
            CargarEspecialidades();
            CargarDoctores();



            #region[Lista Hora]
            List<string> horas = new List<string>();
            cboHora.Items.Add("05:00");
            cboHora.Items.Add("06:00");
            cboHora.Items.Add("07:00");
            cboHora.Items.Add("08:00");
            cboHora.Items.Add("09:00"); 
            cboHora.Items.Add("10:00");
            cboHora.Items.Add("11:00");
            cboHora.Items.Add("12:00");
            cboHora.Items.Add("13:00");
            cboHora.Items.Add("14:00");
            cboHora.Items.Add("15:00");
            cboHora.Items.Add("16:00");
            cboHora.Items.Add("17:00");
            cboHora.Items.Add("18:00");
            cboHora.Items.Add("19:00");
            cboHora.Items.Add("20:00");


            #endregion

        }
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        private bool ConsultorioExiste(int idConsultorio)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT COUNT(1) FROM CONSULTORIO WHERE Id_Consultorio = @IdConsultorio", conexion);
                comando.Parameters.AddWithValue("@IdConsultorio", idConsultorio);
                conexion.Open();
                int count = Convert.ToInt32(comando.ExecuteScalar());
                return count > 0;
            }
        }

        //Traer elementos a la tabla de datos
        /*private void CargarEspecialidades()
        {
            cboEspecialista.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT Especialidad FROM Doctor", conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string especialidad = reader.GetString(0);
                    cboEspecialista.Items.Add(especialidad);
                }
                reader.Close();
            }
        }*/

        private void CargarEspecialidades()
        {
            cboEspecialista.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT Servicio FROM Servicios", conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string servicio = reader.GetString(0);
                    cboEspecialista.Items.Add(servicio);
                }
                reader.Close();
            }
        }






        private void btnReservar_Click(object sender, EventArgs e)
        {

            // Asegúrate de que el valor de txtConsultorio.Text sea un número válido antes de convertirlo.
            if (!int.TryParse(txtConsultorio.Text, out int idConsultorio))
            {
                MessageBox.Show("Por favor, ingrese un ID de consultorio válido.");
                return;
            }

            if (!ConsultorioExiste(idConsultorio))
            {
                MessageBox.Show("El consultorio seleccionado no existe.");
                return;
            }
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SP_CrearCita", conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id_Consultorio", Convert.ToInt32(txtConsultorio.Text)); 
                    comando.Parameters.AddWithValue("@Id_Servicios", Convert.ToInt32(cboEspecialista.SelectedValue)); 
                    comando.Parameters.AddWithValue("@Id_Cedula", Convert.ToInt32(txtCedula.Text)); 
                    comando.Parameters.AddWithValue("@Fecha", monthCalendar1.SelectionRange.Start); 
                    comando.Parameters.AddWithValue("@Hora", TimeSpan.Parse(cboHora.SelectedItem.ToString()));
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        MessageBox.Show("La cita ha sido reservada con éxito.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo reservar la cita.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al reservar la cita: " + ex.Message);
                }
            }

        }

    
        private void cboEspecialista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEspecialista.SelectedValue is int idDoctorSeleccionado)
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    SqlCommand comando = new SqlCommand("SELECT Id_Consultorio FROM DOCTOR WHERE Id_Doctor = @IdDoctor", conexion);
                    comando.Parameters.AddWithValue("@IdDoctor", idDoctorSeleccionado);
                    try
                    {
                        conexion.Open();
                        var idConsultorio = comando.ExecuteScalar();
                        if (idConsultorio != null)
                        {
                            txtConsultorio.Text = idConsultorio.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener el consultorio: " + ex.Message);
                    }
                }
            }
        }
        private void CargarDoctores()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Id_Doctor, Especialidad FROM DOCTOR", conexion);
                DataTable dtDoctores = new DataTable();
                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    dtDoctores.Load(reader);
                    cboEspecialista.DisplayMember = "Especialidad";
                    cboEspecialista.ValueMember = "Id_Doctor";
                    cboEspecialista.DataSource = dtDoctores;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los doctores: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente inicioSesionPasiente = new frmInicioSesionPasiente();
            this.Hide();
            inicioSesionPasiente.Show();
        }
        

    }
    
}

