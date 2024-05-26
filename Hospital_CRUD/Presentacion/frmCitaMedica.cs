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
           
            #region[Lista Hora]
            List<string> horas = new List<string>();
            cboHora.Items.Add("05:00");
            cboHora.Items.Add("06:00");
            cboHora.Items.Add("07:00");
            cboHora.Items.Add("08:00");
            cboHora.Items.Add("09:00");
            cboHora.Items.Add("10:00");
            cboHora.Items.Add("11:00");
            cboHora.Items.Add("12:00");
            cboHora.Items.Add("13:00");
            cboHora.Items.Add("14:00");
            cboHora.Items.Add("15:00");
            cboHora.Items.Add("16:00");
            cboHora.Items.Add("17:00");
            cboHora.Items.Add("18:00");
            cboHora.Items.Add("19:00");
            cboHora.Items.Add("20:00");


            #endregion
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsCita Cita = new clsCita
            {
               // Id_Cita = Convert.ToInt32(txt.Text),
                Id_Consultorio = Convert.ToInt32(txtConsultorio.Text),
                Id_Servicios = Convert.ToInt32(txtServicio.Text),
                Id_Cedula = Convert.ToInt32(txtCedula.Text),
                Hora = cboHora.Text,

            };
            clsCitaDAO.AgregarCita(Cita);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor InicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            InicioSesionDoctor.Show();
        }

       
    }
}
