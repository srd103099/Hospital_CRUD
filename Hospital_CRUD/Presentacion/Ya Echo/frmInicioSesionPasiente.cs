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
    public partial class frmInicioSesionPasiente : Form
    {
        public frmInicioSesionPasiente()
        {
            InitializeComponent();
        }
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            List<clsUsuario_Pasiente> InicioSesionPasiente = new List<clsUsuario_Pasiente>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT Usuario_Pasiente, Contrasena FROM USUARIO_PASIENTE WHERE Usuario_Pasiente = @Usuario_Pasiente AND Contrasena = @Contrasena", conexion); conexion.Open();


                    comando.Parameters.AddWithValue("Usuario_Pasiente", txtUsuario.Text);
                    comando.Parameters.AddWithValue("Contrasena", txtContrasena.Text);

                    SqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        MessageBox.Show("Haz registrado con exito.");
                        conexion.Close();

                        frmPasienteInicio PasienteInicio = new frmPasienteInicio();
                        this.Hide();
                        PasienteInicio.Show(); 
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
