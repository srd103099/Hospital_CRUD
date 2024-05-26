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
    public partial class frmHistorialPasiente : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        public frmHistorialPasiente()
        {
            InitializeComponent();
        }

        private void ModificarHistorial(int idHistorial, int idCedula, string descripcion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SP_ActualizarHistorialClinico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Historial", idHistorial);
                comando.Parameters.AddWithValue("@Id_Cedula", idCedula);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        private void EliminarHistorial(int idHistorial)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SP_EliminarHistorialClinico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Historial", idHistorial);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        private clsHistorialClinico BuscarHistorial(int idCedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SP_ObtenerHistorialClinico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Cedula", idCedula);

                conexion.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new clsHistorialClinico
                        {
                            Id_Historial = reader.GetInt32(reader.GetOrdinal("Id_Historial")),
                            Id_Cedula = reader.GetInt32(reader.GetOrdinal("Id_Cedula")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                        };
                    }
                }
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor InicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            InicioSesionDoctor.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idCedula = Convert.ToInt32(txtCedula.Text);
            string descripcion = txtDescripcion.Text;

            if (ExisteCedula(idCedula))
            {
                AgregarHistorial(idCedula, descripcion);
                Historial();
            }
            else
            {
                MessageBox.Show("La cédula ingresada no está registrada en la base de datos.");
            }
        }
        private bool ExisteCedula(int idCedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT COUNT(1) FROM PASIENTE WHERE Id_Cedula = @IdCedula";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdCedula", idCedula);

                conexion.Open();
                int count = Convert.ToInt32(comando.ExecuteScalar());
                return count > 0;
            }
        }

        private void AgregarHistorial(int idCedula, string descripcion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SP_CrearHistorialClinico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Cedula", idCedula);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        private void Historial()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM HISTORIA_CLINICA";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvHistorial.DataSource = dt;
            }
        }

        /*private void frmHistorialPasiente_Load(object sender, EventArgs e)
        {
            Historial();
        }

        private void Historial()
        {
            dgvHistorial.DataSource = clsHistorialCLinicoDAO.ObtenerHistorial();
        }*/

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int idHistorial = ObtenerIdHistorialSeleccionado(); // Necesitas implementar este método.
            int idCedula = Convert.ToInt32(txtCedula.Text);
            string descripcion = txtDescripcion.Text;

            ModificarHistorial(idHistorial, idCedula, descripcion);
            Historial();

            /*clsHistorialClinico clienteModificado = new clsHistorialClinico
            {
                Id_Cedula = Convert.ToInt32(txtCedula.Text),
                Descripcion = txtDescripcion.Text,
            };
            txtCedula.Enabled = true;
            txtDescripcion.Enabled = true;
            clsHistorialCLinicoDAO.ModificarHistoriale(clienteModificado);
            Historial();*/
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idHistorial = ObtenerIdHistorialSeleccionado(); // Necesitas implementar este método.

            EliminarHistorial(idHistorial);
            Historial();
            /*
            int Id_Cedula = int.Parse(txtCedula.Text);
            clsHistorialCLinicoDAO.EliminarHistorial(Id_Cedula);
            Historial();*/
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idCedula = int.Parse(txtCedula.Text);
            clsHistorialClinico historial = BuscarHistorial(idCedula);
            if (historial != null)
            {
                txtCedula.Text = historial.Id_Cedula.ToString();
                txtDescripcion.Text = historial.Descripcion;
            }
            else
            {
                MessageBox.Show("No se encontró el historial clínico.");
            }
            /*int Id_Cedula = int.Parse(txtCedula.Text);
            clsHistorialClinico clienteModificado = clsHistorialCLinicoDAO.BuscarHistorial(Id_Cedula);
            if (clienteModificado != null)
            {
                txtCedula.Text = clienteModificado.Id_Cedula.ToString();
                txtDescripcion.Text = clienteModificado.Descripcion.ToString();
            }
            txtCedula.Enabled = false;
            txtDescripcion.Enabled = false;
            btnAgregar.Enabled = true;*/
        }

        private int ObtenerIdHistorialSeleccionado()
        {
            // Asegúrate de que hay una fila seleccionada y de obtener el valor de la columna correcta que contiene el Id_Historial.
            if (dgvHistorial.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvHistorial.SelectedRows[0].Cells["Id_Historial"].Value);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un historial clínico de la lista.");
                return 0; // O maneja esta situación como prefieras.
            }
        }
    }
}
