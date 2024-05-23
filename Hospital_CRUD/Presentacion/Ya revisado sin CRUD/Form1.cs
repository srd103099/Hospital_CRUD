﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicioSesionDoctor inicioSesionDoctor = new frmInicioSesionDoctor();
            this.Hide();
            inicioSesionDoctor.Show();
        }

        private void pasienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicioSesionPasiente inicioSesionPasiente = new frmInicioSesionPasiente();
            this.Hide();
            inicioSesionPasiente.Show();
        }

        private void registrarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarse Registrarse = new frmRegistrarse();
            this.Hide();
            Registrarse.Show();
        }
    }
}
