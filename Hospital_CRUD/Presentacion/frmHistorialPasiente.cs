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
            Historial();
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
            // Verifica si el campo txtCedula está vacío
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                // Si está vacío, carga todos los registros
                Historial();
            }
            else
            {
                // Si no está vacío, busca por cédula y actualiza el DataGridView
                int idCedula;
                if (int.TryParse(txtCedula.Text, out idCedula))
                {
                    BuscarYMostrarHistorial(idCedula);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número de cédula válido.");
                }
            }
        }

        private void BuscarYMostrarHistorial(int idCedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SP_ObtenerHistorialClinicoPorCedula";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Cedula", idCedula);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                // Si se encontraron registros, muestra solo esos
                if (dt.Rows.Count > 0)
                {
                    dgvHistorial.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No se encontró el historial clínico para la cédula proporcionada.");
                    dgvHistorial.DataSource = null; 
                }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int idHistorial = ObtenerIdHistorialSeleccionado();
            int idCedula = Convert.ToInt32(txtCedula.Text);
            string descripcion = txtDescripcion.Text;

            ModificarHistorial(idHistorial, idCedula, descripcion);
            Historial();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idHistorial = ObtenerIdHistorialSeleccionado();

            EliminarHistorial(idHistorial);
            Historial();
            
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

        }

        private int ObtenerIdHistorialSeleccionado()
        {
            if (dgvHistorial.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvHistorial.SelectedRows[0].Cells["Id_Historial"].Value);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un historial clínico de la lista.");
                return 0; 
            }
        }
    }
}
