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

namespace Hospital_CRUD.Presentacion.Ya_revisado_sin_CRUD
{
    public partial class frmCRUDPasiente : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["PROYECTO_FINAL3"].ConnectionString;
        public frmCRUDPasiente()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM PASIENTE", conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvPacientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los pacientes: " + ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                int idCedula = Convert.ToInt32(txtCedula.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);
                string correo = txtCorreo.Text;

                ActualizarPaciente(idCedula, nombre, apellido, telefono, correo);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente de la lista para modificar.");
            }
        }

            private void ActualizarPaciente(int idCedula, string nombre, string apellido, int telefono, string correo)
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    SqlCommand comando = new SqlCommand("SP_ActualizarPasiente", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_Cedula", idCedula);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Apellido", apellido);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Correo", correo);

                    try
                    {
                        conexion.Open();
                        int resultado = comando.ExecuteNonQuery();
                        if (resultado > 0)
                        {
                            MessageBox.Show("Paciente actualizado correctamente.");
                            CargarPacientes(); // Recargar los datos en el DataGridView
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el paciente: " + ex.Message);
                    }
                }
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                int idCedula = Convert.ToInt32(dgvPacientes.CurrentRow.Cells["Id_Cedula"].Value);

                if (MessageBox.Show("¿Está seguro de que desea eliminar este paciente?", "Eliminar Paciente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EliminarPaciente(idCedula);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente de la lista para eliminar.");
            }
        }

        private void EliminarPaciente(int idCedula)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SP_EliminarPaciente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Cedula", idCedula);

                try
                {
                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        MessageBox.Show("Paciente eliminado correctamente.");
                        CargarPacientes(); // Recargar los datos en el DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el paciente: " + ex.Message);
                }
            }
        }

        private void dgvPacientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow != null)
            {
                txtCedula.Text = dgvPacientes.CurrentRow.Cells["Id_Cedula"].Value.ToString();
                txtNombre.Text = dgvPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPacientes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvPacientes.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvPacientes.CurrentRow.Cells["Correo"].Value.ToString();
            }
            else
            {
                txtCedula.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
            }
        }
    }
}
