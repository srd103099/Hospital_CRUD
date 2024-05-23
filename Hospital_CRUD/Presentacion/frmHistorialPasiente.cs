using Hospital_CRUD.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_CRUD
{
    public partial class frmHistorialPasiente : Form
    {
        public frmHistorialPasiente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor InicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            InicioSesionDoctor.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)

        {
            clsHistorialClinico nuevoHistorial = new clsHistorialClinico
            {
                Id_Cedula = Convert.ToInt32(txtCedula.Text),
                Descripcion = txtDescripcion.Text,
            };
            clsHistorialCLinicoDAO.AgregarHistorial(nuevoHistorial);
        }

        private void frmHistorialPasiente_Load(object sender, EventArgs e)
        {
            Historial();
        }

        private void Historial()
        {
            dgvHistorial.DataSource = clsHistorialCLinicoDAO.ObtenerHistorial();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clsHistorialClinico clienteModificado = new clsHistorialClinico
            {
                Id_Cedula = Convert.ToInt32(txtCedula.Text),
                Descripcion = txtDescripcion.Text,
            };
            txtCedula.Enabled = true;
            txtDescripcion.Enabled = true;
            clsHistorialCLinicoDAO.ModificarHistoriale(clienteModificado);
            Historial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id_Cedula = int.Parse(txtCedula.Text);
            clsHistorialCLinicoDAO.EliminarHistorial(Id_Cedula);
            Historial();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Id_Cedula = int.Parse(txtCedula.Text);
            clsHistorialClinico clienteModificado = clsHistorialCLinicoDAO.BuscarHistorial(Id_Cedula);
            if (clienteModificado != null)
            {
                txtCedula.Text = clienteModificado.Id_Cedula.ToString();
                txtDescripcion.Text = clienteModificado.Descripcion.ToString();
            }
            txtCedula.Enabled = false;
            txtDescripcion.Enabled = false;
            btnAgregar.Enabled = true;
        }
    }
}
