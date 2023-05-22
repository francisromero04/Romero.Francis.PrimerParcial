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
            this.lblPasajeros = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbxAviones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHorasVuelo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListaViajesRealizados
            // 
            this.lblListaViajesRealizados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblListaViajesRealizados.AutoSize = true;
            this.lblListaViajesRealizados.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajesRealizados.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaViajesRealizados.Location = new System.Drawing.Point(125, 292);
            this.lblListaViajesRealizados.Name = "lblListaViajesRealizados";
            this.lblListaViajesRealizados.Size = new System.Drawing.Size(320, 34);
            this.lblListaViajesRealizados.TabIndex = 3;
            this.lblListaViajesRealizados.Text = "Lista de viajes realizados:";
            // 
            // cmbxListaViajesRealizados
            // 
            this.cmbxListaViajesRealizados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxListaViajesRealizados.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaViajesRealizados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaViajesRealizados.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaViajesRealizados.FormattingEnabled = true;
            this.cmbxListaViajesRealizados.Location = new System.Drawing.Point(471, 303);
            this.cmbxListaViajesRealizados.Name = "cmbxListaViajesRealizados";
            this.cmbxListaViajesRealizados.Size = new System.Drawing.Size(441, 23);
            this.cmbxListaViajesRealizados.TabIndex = 4;
            this.cmbxListaViajesRealizados.SelectedIndexChanged += new System.EventHandler(this.cmbxListaViajesRealizados_SelectedIndexChanged);
            // 
            // lblTituloConsultar
            // 
            this.lblTituloConsultar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloConsultar.AutoSize = true;
            this.lblTituloConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblTituloConsultar.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloConsultar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloConsultar.Location = new System.Drawing.Point(306, 236);
            this.lblTituloConsultar.Name = "lblTituloConsultar";
            this.lblTituloConsultar.Size = new System.Drawing.Size(471, 54);
            this.lblTituloConsultar.TabIndex = 5;
            this.lblTituloConsultar.Text = "Estadísticas Históricas";
            // 
            // lblDineroTotal
            // 
            this.lblDineroTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDineroTotal.AutoSize = true;
            this.lblDineroTotal.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDineroTotal.Location = new System.Drawing.Point(125, 346);
            this.lblDineroTotal.Name = "lblDineroTotal";
            this.lblDineroTotal.Size = new System.Drawing.Size(31, 31);
            this.lblDineroTotal.TabIndex = 40;
            this.lblDineroTotal.Text = "A";
            // 
            // lblDestino
            // 
            this.lblDestino.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDestino.Location = new System.Drawing.Point(125, 393);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(31, 31);
            this.lblDestino.TabIndex = 41;
            this.lblDestino.Text = "A";
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPasajeros.Location = new System.Drawing.Point(125, 441);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(31, 31);
            this.lblPasajeros.TabIndex = 43;
            this.lblPasajeros.Text = "A";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(433, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 197);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // cmbxAviones
            // 
            this.cmbxAviones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxAviones.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxAviones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAviones.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAviones.FormattingEnabled = true;
            this.cmbxAviones.Location = new System.Drawing.Point(471, 502);
            this.cmbxAviones.Name = "cmbxAviones";
            this.cmbxAviones.Size = new System.Drawing.Size(441, 23);
            this.cmbxAviones.TabIndex = 46;
            this.cmbxAviones.SelectedIndexChanged += new System.EventHandler(this.cmbxAviones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(125, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 34);
            this.label1.TabIndex = 45;
            this.label1.Text = "Lista de Aviones:";
            // 
            // lblHorasVuelo
            // 
            this.lblHorasVuelo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHorasVuelo.AutoSize = true;
            this.lblHorasVuelo.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasVuelo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHorasVuelo.Location = new System.Drawing.Point(125, 545);
            this.lblHorasVuelo.Name = "lblHorasVuelo";
            this.lblHorasVuelo.Size = new System.Drawing.Size(31, 31);
            this.lblHorasVuelo.TabIndex = 47;
            this.lblHorasVuelo.Text = "A";
            // 
            // ConsultarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1064, 686);
            this.Controls.Add(this.lblHorasVuelo);
            this.Controls.Add(this.cmbxAviones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblDineroTotal);
            this.Controls.Add(this.lblTituloConsultar);
            this.Controls.Add(this.cmbxListaViajesRealizados);
            this.Controls.Add(this.lblListaViajesRealizados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarEstadisticas";
            this.Text = "Consultar Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblListaViajesRealizados;
        private System.Windows.Forms.ComboBox cmbxListaViajesRealizados;
        private System.Windows.Forms.Label lblTituloConsultar;
        private System.Windows.Forms.Label lblDineroTotal;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblPasajeros;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbxAviones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHorasVuelo;
    }
}