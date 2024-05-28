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
    public partial class frmInfoPasientes : Form
    {
        public frmInfoPasientes()
        {
            InitializeComponent();
        }
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;


        //Malo
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<clsPasiente> InfoPasiente = new List<clsPasiente>();
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SP_CrearPasiente", conexion); conexion.Open();
                    comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado
                    comando.Parameters.AddWithValue("Id_Cedula", txtCedula.Text);
                    comando.Parameters.AddWithValue("Nombre", txtNombre.Text);
                    comando.Parameters.AddWithValue("Apellido", txtApellido.Text);
                    comando.Parameters.AddWithValue("Telefono", txtTelefono.Text);
                    comando.Parameters.AddWithValue("Correo", txtCorreo.Text);
                    //SqlDataReader lector = comando.ExecuteReader();
                    int filasAfectadas = comando.ExecuteNonQuery();


                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Te haz registrado tu informacion con exito.");
                        conexion.Close();

                        frmPasienteInicio PasienteInicio = new frmPasienteInicio();
                        this.Hide();
                        PasienteInicio.Show(); 
                    }
                    /*else
                    {
                        if (string.IsNullOrWhiteSpace(txtCedula.Text) || txtCedula.Text == "Id_Cedula")
                        {
                            MessageBox.Show("El Campo cedula no puede quedar vacío");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Nombre")
                        {
                            MessageBox.Show("El Campo nombre no puede quedar vacío");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text == "Apellido")
                        {
                            MessageBox.Show("El Campo apellido no puede quedar vacío");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text == "Telefono")
                        {
                            MessageBox.Show("El Campo telefono no puede quedar vacío");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Correo")
                        {
                            MessageBox.Show("El Campo correo no puede quedar vacío");
                            return;
                        }

                        MessageBox.Show("La informacion no es valida");
                        conexion.Close();
                    }*/
                }
                catch (Exception) /* <------------ (MALO) */
                {

                    throw;
                }
            }
        }
    }
}
