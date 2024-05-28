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
    public partial class frmRegistrarse : Form
    {
        public frmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clsUsuario_Pasiente nuevoUsuarioPasiente = new clsUsuario_Pasiente
            {
                Usuario_Pasiente = txtUsuario.Text,
                Contrasena = txtContrasena.Text,
            };
            clsUsuario_PasienteDAO.AgregarUsuarioPasiente(nuevoUsuarioPasiente);

            frmInfoPasientes InfoPasientes= new frmInfoPasientes();
            this.Hide();
            InfoPasientes.Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor InicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            InicioSesionDoctor.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();

        }

        private void pasienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente frmPasienteInicio = new frmInicioSesionPasiente();
            this.Hide();
            frmPasienteInicio.Show();
        }
    }
}
