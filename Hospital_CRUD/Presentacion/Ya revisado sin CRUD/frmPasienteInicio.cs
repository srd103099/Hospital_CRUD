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
    public partial class frmPasienteInicio : Form
    {
        public frmPasienteInicio()
        {
            InitializeComponent();
        }

        private void reservarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReserva reserva = new frmReserva();
            this.Hide();
            reserva.Show(); 
        }

        private void buscarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarCita reserva = new frmBuscarCita();
            this.Hide();
            reserva.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicios servicios = new frmServicios();
            this.Hide();
            servicios.Show();
        }

        private void evaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmEvaluacion evaluacion = new frmEvaluacion();
            this.Hide();
            evaluacion.Show();*/
        }
    }
}
