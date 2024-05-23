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
    public partial class frmInicioSesionDoctor : Form
    {
        public frmInicioSesionDoctor()
        {
            InitializeComponent();
        }
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            List<clsUsuario_Doctor> InicioSesionDoctor = new List<clsUsuario_Doctor>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT Usuario_Doctor, Contrasena FROM USUARIO_DOCTOR WHERE Usuario_Doctor = @Usuario_Doctor AND Contrasena = @Contrasena", conexion); conexion.Open();


                    comando.Parameters.AddWithValue("Usuario_Doctor", txtUsuario.Text);
                    comando.Parameters.AddWithValue("Contrasena", txtContrasena.Text);

                    SqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        conexion.Close();

                        frmDoctorInicio DoctorInicio = new frmDoctorInicio();
                        this.Hide();
                        DoctorInicio.Show(); ;
                    }
                    else
                    {
                        // Validar que los campos de usuario y contraseña no estén vacíos antes de mostrar el mensaje de error
                        if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == "Usuario")
                        {
                            MessageBox.Show("El Campo usuario no puede quedar vacío");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(txtContrasena.Text) || txtContrasena.Text == "Contraseña")
                        {
                            MessageBox.Show("El Campo Contraseña no puede quedar vacío");
                            return;
                        }

                        MessageBox.Show("El usuario o contraseña es incorrecto");
                        conexion.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}

