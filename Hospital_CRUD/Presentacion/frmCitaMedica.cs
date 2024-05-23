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
    public partial class frmCitaMedica : Form
    {
        public frmCitaMedica()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsCita Cita = new clsCita
            {
                Id_Cita = Convert.ToInt32(txt.Text),
                Id_Consultorio = txtDescripcion.Text,
                Id_Servicios = txtDescripcion.Text,
                Id_Cedula = txtDescripcion.Text,
                Fecha = txtDescripcion.Text,
                Hora = txtDescripcion.Text,

            };
            clsCitaDAO.AgregarHistorial(nuevoHistorial);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor InicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            InicioSesionDoctor.Show();
        }
    }
}
