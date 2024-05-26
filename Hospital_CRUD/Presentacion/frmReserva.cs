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
            List<clsPasiente> InfoPasiente = new List<clsPasiente>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("Select *", conexion); conexion.Open();
                    comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado
                    comando.Parameters.AddWithValue("Id_Consultorio", txtConsultorio.Text);
                    comando.Parameters.AddWithValue("Id_Servicios", cboEspecialista.Text);
                    comando.Parameters.AddWithValue("Id_Cedula", txtCedula.Text);
                    comando.Parameters.AddWithValue("Fecha", monthCalendar1.Text);
                    comando.Parameters.AddWithValue("Hora", cboHora.Text);

                    SqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        MessageBox.Show("Te haz registrado tu informacion con exito.");
                        conexion.Close();

                        frmPasienteInicio PasienteInicio = new frmPasienteInicio();
                        this.Hide();
                        PasienteInicio.Show(); ;
                    }
                    
                }
                catch (Exception) /* <------------ (MALO) */
                {

                    //throw;
                }
            }

        }

    
        private void cboEspecialista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDoctorSeleccionado = Convert.ToInt32(cboEspecialista.SelectedValue);
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Nombre FROM CONSULTORIO WHERE Id_Consultorio = (SELECT Id_Consultorio FROM DOCTOR WHERE Id_Doctor = @IdDoctor)", conexion);
                comando.Parameters.AddWithValue("@IdDoctor", idDoctorSeleccionado);
                try
                {
                    conexion.Open();
                    var nombreConsultorio = comando.ExecuteScalar();
                    if (nombreConsultorio != null)
                    {
                        txtConsultorio.Text = nombreConsultorio.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el consultorio: " + ex.Message);
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

