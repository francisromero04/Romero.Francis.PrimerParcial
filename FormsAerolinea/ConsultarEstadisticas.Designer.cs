namespace FormsAerolinea
{
    partial class ConsultarEstadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarEstadisticas));
            this.lblListaViajesRealizados = new System.Windows.Forms.Label();
            this.cmbxListaViajesRealizados = new System.Windows.Forms.ComboBox();
            this.lblTituloConsultar = new System.Windows.Forms.Label();
            this.lblDineroTotal = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPasajeros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListaViajesRealizados
            // 
            this.lblListaViajesRealizados.AutoSize = true;
            this.lblListaViajesRealizados.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajesRealizados.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaViajesRealizados.Location = new System.Drawing.Point(648, 366);
            this.lblListaViajesRealizados.Name = "lblListaViajesRealizados";
            this.lblListaViajesRealizados.Size = new System.Drawing.Size(320, 34);
            this.lblListaViajesRealizados.TabIndex = 3;
            this.lblListaViajesRealizados.Text = "Lista de viajes realizados:";
            // 
            // cmbxListaViajesRealizados
            // 
            this.cmbxListaViajesRealizados.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaViajesRealizados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaViajesRealizados.Font = new System.Drawing.Font("Sitka Subheading", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaViajesRealizados.FormattingEnabled = true;
            this.cmbxListaViajesRealizados.Location = new System.Drawing.Point(991, 366);
            this.cmbxListaViajesRealizados.Name = "cmbxListaViajesRealizados";
            this.cmbxListaViajesRealizados.Size = new System.Drawing.Size(395, 29);
            this.cmbxListaViajesRealizados.TabIndex = 4;
            this.cmbxListaViajesRealizados.SelectedIndexChanged += new System.EventHandler(this.cmbxListaViajesRealizados_SelectedIndexChanged);
            // 
            // lblTituloConsultar
            // 
            this.lblTituloConsultar.AutoSize = true;
            this.lblTituloConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblTituloConsultar.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloConsultar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloConsultar.Location = new System.Drawing.Point(708, 296);
            this.lblTituloConsultar.Name = "lblTituloConsultar";
            this.lblTituloConsultar.Size = new System.Drawing.Size(471, 54);
            this.lblTituloConsultar.TabIndex = 5;
            this.lblTituloConsultar.Text = "Estadísticas Históricas";
            // 
            // lblDineroTotal
            // 
            this.lblDineroTotal.AutoSize = true;
            this.lblDineroTotal.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDineroTotal.Location = new System.Drawing.Point(648, 423);
            this.lblDineroTotal.Name = "lblDineroTotal";
            this.lblDineroTotal.Size = new System.Drawing.Size(0, 31);
            this.lblDineroTotal.TabIndex = 40;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDestino.Location = new System.Drawing.Point(648, 475);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(0, 31);
            this.lblDestino.TabIndex = 41;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(284, 258);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPasajeros.Location = new System.Drawing.Point(648, 524);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(0, 31);
            this.lblPasajeros.TabIndex = 43;
            // 
            // ConsultarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1237, 847);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblDineroTotal);
            this.Controls.Add(this.lblTituloConsultar);
            this.Controls.Add(this.cmbxListaViajesRealizados);
            this.Controls.Add(this.lblListaViajesRealizados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarEstadisticas";
            this.Text = "Consultar Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblListaViajesRealizados;
        private System.Windows.Forms.ComboBox cmbxListaViajesRealizados;
        private System.Windows.Forms.Label lblTituloConsultar;
        private System.Windows.Forms.Label lblDineroTotal;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPasajeros;
    }
}