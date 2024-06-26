﻿namespace Hospital_CRUD
{
    partial class frmEvaluacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.btnBuscarCita = new System.Windows.Forms.Button();
            this.btnCalificacion = new System.Windows.Forms.Button();
            this.nudEspecialista = new System.Windows.Forms.NumericUpDown();
            this.lblEspecialista = new System.Windows.Forms.Label();
            this.lblCita = new System.Windows.Forms.Label();
            this.nudCita = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInfoPasiente = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEspecialista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panelContenedor.Controls.Add(this.dgvCitas);
            this.panelContenedor.Controls.Add(this.txtCedula);
            this.panelContenedor.Controls.Add(this.lblCedula);
            this.panelContenedor.Controls.Add(this.btnBuscarCita);
            this.panelContenedor.Controls.Add(this.btnCalificacion);
            this.panelContenedor.Controls.Add(this.nudEspecialista);
            this.panelContenedor.Controls.Add(this.lblEspecialista);
            this.panelContenedor.Controls.Add(this.lblCita);
            this.panelContenedor.Controls.Add(this.nudCita);
            this.panelContenedor.Controls.Add(this.button1);
            this.panelContenedor.Controls.Add(this.lblInfoPasiente);
            this.panelContenedor.Controls.Add(this.pictureBox2);
            this.panelContenedor.Controls.Add(this.menuStrip1);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1282, 653);
            this.panelContenedor.TabIndex = 7;
            // 
            // dgvCitas
            // 
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(188, 131);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.RowHeadersWidth = 51;
            this.dgvCitas.RowTemplate.Height = 24;
            this.dgvCitas.Size = new System.Drawing.Size(693, 150);
            this.dgvCitas.TabIndex = 28;
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCedula.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.Color.White;
            this.txtCedula.Location = new System.Drawing.Point(272, 81);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(207, 23);
            this.txtCedula.TabIndex = 27;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.White;
            this.lblCedula.Location = new System.Drawing.Point(184, 81);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(76, 23);
            this.lblCedula.TabIndex = 26;
            this.lblCedula.Text = "Cedula:";
            // 
            // btnBuscarCita
            // 
            this.btnBuscarCita.Location = new System.Drawing.Point(532, 74);
            this.btnBuscarCita.Name = "btnBuscarCita";
            this.btnBuscarCita.Size = new System.Drawing.Size(165, 37);
            this.btnBuscarCita.TabIndex = 20;
            this.btnBuscarCita.Text = "Enviar Calificacion";
            this.btnBuscarCita.UseVisualStyleBackColor = true;
            this.btnBuscarCita.Click += new System.EventHandler(this.btnBuscarCita_Click);
            // 
            // btnCalificacion
            // 
            this.btnCalificacion.Location = new System.Drawing.Point(333, 467);
            this.btnCalificacion.Name = "btnCalificacion";
            this.btnCalificacion.Size = new System.Drawing.Size(165, 37);
            this.btnCalificacion.TabIndex = 20;
            this.btnCalificacion.Text = "Enviar Calificacion";
            this.btnCalificacion.UseVisualStyleBackColor = true;
            this.btnCalificacion.Click += new System.EventHandler(this.btnCalificacion_Click);
            // 
            // nudEspecialista
            // 
            this.nudEspecialista.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudEspecialista.Location = new System.Drawing.Point(343, 370);
            this.nudEspecialista.Name = "nudEspecialista";
            this.nudEspecialista.Size = new System.Drawing.Size(120, 45);
            this.nudEspecialista.TabIndex = 19;
            // 
            // lblEspecialista
            // 
            this.lblEspecialista.AutoSize = true;
            this.lblEspecialista.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialista.ForeColor = System.Drawing.Color.White;
            this.lblEspecialista.Location = new System.Drawing.Point(132, 376);
            this.lblEspecialista.Name = "lblEspecialista";
            this.lblEspecialista.Size = new System.Drawing.Size(193, 38);
            this.lblEspecialista.TabIndex = 18;
            this.lblEspecialista.Text = "Especialista:";
            // 
            // lblCita
            // 
            this.lblCita.AutoSize = true;
            this.lblCita.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCita.ForeColor = System.Drawing.Color.White;
            this.lblCita.Location = new System.Drawing.Point(132, 312);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(195, 38);
            this.lblCita.TabIndex = 17;
            this.lblCita.Text = "Cita Medica:";
            // 
            // nudCita
            // 
            this.nudCita.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCita.Location = new System.Drawing.Point(346, 306);
            this.nudCita.Name = "nudCita";
            this.nudCita.Size = new System.Drawing.Size(120, 45);
            this.nudCita.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1154, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInfoPasiente
            // 
            this.lblInfoPasiente.AutoSize = true;
            this.lblInfoPasiente.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPasiente.ForeColor = System.Drawing.Color.White;
            this.lblInfoPasiente.Location = new System.Drawing.Point(391, 24);
            this.lblInfoPasiente.Name = "lblInfoPasiente";
            this.lblInfoPasiente.Size = new System.Drawing.Size(545, 38);
            this.lblInfoPasiente.TabIndex = 14;
            this.lblInfoPasiente.Text = "Evaluacion Cita Medica y Especialista";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 612);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.inicioToolStripMenuItem,
            this.reservarCitaToolStripMenuItem,
            this.buscarCitaToolStripMenuItem,
            this.serviciosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(156, 653);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.inicioToolStripMenuItem.Text = "&Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // reservarCitaToolStripMenuItem
            // 
            this.reservarCitaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reservarCitaToolStripMenuItem.Name = "reservarCitaToolStripMenuItem";
            this.reservarCitaToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.reservarCitaToolStripMenuItem.Text = "&ReservarCita";
            this.reservarCitaToolStripMenuItem.Click += new System.EventHandler(this.reservarCitaToolStripMenuItem_Click);
            // 
            // buscarCitaToolStripMenuItem
            // 
            this.buscarCitaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.buscarCitaToolStripMenuItem.Name = "buscarCitaToolStripMenuItem";
            this.buscarCitaToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.buscarCitaToolStripMenuItem.Text = "&BuscarCita";
            this.buscarCitaToolStripMenuItem.Click += new System.EventHandler(this.buscarCitaToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.serviciosToolStripMenuItem.Text = "&Servicios";
            this.serviciosToolStripMenuItem.Click += new System.EventHandler(this.serviciosToolStripMenuItem_Click);
            // 
            // frmEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panelContenedor);
            this.Name = "frmEvaluacion";
            this.Text = "frmEvaluacion";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEspecialista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservarCitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarCitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.Label lblInfoPasiente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudEspecialista;
        private System.Windows.Forms.Label lblEspecialista;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.NumericUpDown nudCita;
        private System.Windows.Forms.Button btnCalificacion;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Button btnBuscarCita;
    }
}