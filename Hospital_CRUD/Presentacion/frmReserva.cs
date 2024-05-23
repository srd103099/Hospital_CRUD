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

       /* public static List<clsCita> frmReserva_Load(object sender, EventArgs e)
        {
            // Coneccion de SQL Server para poder obtener la informacion de la base de datos

            List<clsCita> Cita = new List<clsCita>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM CITA", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsCita Citas = new clsCita
                    {
                        Id_Cita = (int)reader["Id_Cita"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Fecha = (DateTime)reader["Fecha"],
                        Hora = (DateTime)reader["Hora"],
                    };
                    Cita.Add(Citas);
                }
            }
            return Cita;
        }*/

        private void cboEspecialista_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Coneccion de SQL Server para poder obtener la informacion de la base de datos

            List<clsCita> Cita = new List<clsCita>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM CITA", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsCita Citas = new clsCita
                    {
                        Id_Cita = (int)reader["Id_Cita"],
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Servicios = (int)reader["Id_Servicios"],
                        Id_Cedula = (int)reader["Id_Cedula"],
                        Fecha = (DateTime)reader["Fecha"],
                        Hora = (DateTime)reader["Hora"],
                    };
                    Cita.Add(Citas);
                }
            }
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

            /*List<clsServicio> Servicio = new List<clsServicio>();
            List<clsConsultorio> Consultorio = new List<clsConsultorio>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM CONSULTORIO INNER JOIN SERVICIOS ON CONSULTORIO.Id_Consultorio = SERVICIOS.Id_Servicios", conexion);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    clsServicio Servicios = new clsServicio
                    { 
                        Id_Consultorio = (int)reader["Id_Consultorio"],
                        Id_Servicios = (int)reader["Id_Servicios"],


                    };
                    Servicio.Add(Servicios);
                    clsConsultorio Consultorios = new clsConsultorio
                    {
                        Id_Hospital = (int)reader["Id_Consultorio"],
                        Nombre = (string)reader["Nombre"],
                        Disponibilidad = (string)reader["Disponibilidad"],

                    };
                    Servicio.Add(Servicios);



                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente inicioSesionPasiente = new frmInicioSesionPasiente();
            this.Hide();
            inicioSesionPasiente.Show();
        }
    }
    
}

