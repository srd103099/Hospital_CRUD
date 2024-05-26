using Hospital_CRUD.Presentacion.Ya_revisado_sin_CRUD;
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
    public partial class frmDoctorInicio : Form
    {
        public frmDoctorInicio()
        {
            InitializeComponent();
        }

        private void historialPasienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorialPasiente historialPasiente = new frmHistorialPasiente();
            this.Hide();
            historialPasiente.Show();

        }

        private void citaMedicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmCitaMedica CitaMedica = new frmCitaMedica();
            this.Hide();
            CitaMedica.Show();*/
        }

        private void pasienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCRUDPasiente pasiente = new frmCRUDPasiente();
            this.Hide();
            pasiente.Show();
        }
    }
}
