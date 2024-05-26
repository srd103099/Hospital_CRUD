namespace Hospital_CRUD
{
    partial class frmDoctorInicio
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialPasienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citaMedicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panelContenedor.Controls.Add(this.pictureBox1);
            this.panelContenedor.Controls.Add(this.menuStrip1);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1282, 653);
            this.panelContenedor.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 593);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.historialPasienteToolStripMenuItem,
            this.citaMedicaToolStripMenuItem,
            this.pasienteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
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
            // historialPasienteToolStripMenuItem
            // 
            this.historialPasienteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.historialPasienteToolStripMenuItem.Name = "historialPasienteToolStripMenuItem";
            this.historialPasienteToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.historialPasienteToolStripMenuItem.Text = "&HistorialPasiente";
            this.historialPasienteToolStripMenuItem.Click += new System.EventHandler(this.historialPasienteToolStripMenuItem_Click);
            // 
            // citaMedicaToolStripMenuItem
            // 
            this.citaMedicaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.citaMedicaToolStripMenuItem.Name = "citaMedicaToolStripMenuItem";
            this.citaMedicaToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.citaMedicaToolStripMenuItem.Text = "&CitaMedica";
            this.citaMedicaToolStripMenuItem.Click += new System.EventHandler(this.citaMedicaToolStripMenuItem_Click);
            // 
            // pasienteToolStripMenuItem
            // 
            this.pasienteToolStripMenuItem.Name = "pasienteToolStripMenuItem";
            this.pasienteToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.pasienteToolStripMenuItem.Text = "&Pasiente";
            this.pasienteToolStripMenuItem.Click += new System.EventHandler(this.pasienteToolStripMenuItem_Click);
            // 
            // frmDoctorInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panelContenedor);
            this.Name = "frmDoctorInicio";
            this.Text = "frmDoctorInicio";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialPasienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citaMedicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasienteToolStripMenuItem;
    }
}