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
            this.lblListaViajesRealizados = new System.Windows.Forms.Label();
            this.cmbxListaViajesRealizados = new System.Windows.Forms.ComboBox();
            this.lblTituloConsultar = new System.Windows.Forms.Label();
            this.lblDineroTotal = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblPasajeros = new System.Windows.Forms.Label();
            this.cmbxAviones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHorasVuelo = new System.Windows.Forms.Label();
            this.lstPasajerosOrdenados = new System.Windows.Forms.ListBox();
            this.lstDestinos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblListaViajesRealizados
            // 
            this.lblListaViajesRealizados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblListaViajesRealizados.AutoSize = true;
            this.lblListaViajesRealizados.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajesRealizados.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaViajesRealizados.Location = new System.Drawing.Point(82, 230);
            this.lblListaViajesRealizados.Name = "lblListaViajesRealizados";
            this.lblListaViajesRealizados.Size = new System.Drawing.Size(214, 21);
            this.lblListaViajesRealizados.TabIndex = 3;
            this.lblListaViajesRealizados.Text = "Lista de Vuelos realizados:";
            // 
            // cmbxListaViajesRealizados
            // 
            this.cmbxListaViajesRealizados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxListaViajesRealizados.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaViajesRealizados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaViajesRealizados.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaViajesRealizados.FormattingEnabled = true;
            this.cmbxListaViajesRealizados.Location = new System.Drawing.Point(428, 222);
            this.cmbxListaViajesRealizados.Name = "cmbxListaViajesRealizados";
            this.cmbxListaViajesRealizados.Size = new System.Drawing.Size(536, 23);
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
            this.lblTituloConsultar.Location = new System.Drawing.Point(310, 96);
            this.lblTituloConsultar.Name = "lblTituloConsultar";
            this.lblTituloConsultar.Size = new System.Drawing.Size(471, 54);
            this.lblTituloConsultar.TabIndex = 5;
            this.lblTituloConsultar.Text = "Estadísticas Históricas";
            // 
            // lblDineroTotal
            // 
            this.lblDineroTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDineroTotal.AutoSize = true;
            this.lblDineroTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDineroTotal.Location = new System.Drawing.Point(82, 416);
            this.lblDineroTotal.Name = "lblDineroTotal";
            this.lblDineroTotal.Size = new System.Drawing.Size(278, 21);
            this.lblDineroTotal.TabIndex = 40;
            this.lblDineroTotal.Text = "Dinero recaudado de la aerolinea: ";
            // 
            // lblDestino
            // 
            this.lblDestino.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDestino.Location = new System.Drawing.Point(82, 450);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(294, 21);
            this.lblDestino.TabIndex = 41;
            this.lblDestino.Text = "Destino más elegido de la aerolinea: ";
            // 
            // lblPasajeros
            // 
            this.lblPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPasajeros.AutoSize = true;
            this.lblPasajeros.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPasajeros.Location = new System.Drawing.Point(82, 265);
            this.lblPasajeros.Name = "lblPasajeros";
            this.lblPasajeros.Size = new System.Drawing.Size(21, 21);
            this.lblPasajeros.TabIndex = 43;
            this.lblPasajeros.Text = "A";
            // 
            // cmbxAviones
            // 
            this.cmbxAviones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxAviones.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxAviones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAviones.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAviones.FormattingEnabled = true;
            this.cmbxAviones.Location = new System.Drawing.Point(428, 313);
            this.cmbxAviones.Name = "cmbxAviones";
            this.cmbxAviones.Size = new System.Drawing.Size(536, 23);
            this.cmbxAviones.TabIndex = 46;
            this.cmbxAviones.SelectedIndexChanged += new System.EventHandler(this.cmbxAviones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(82, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Aviones de la aerolinea:";
            // 
            // lblHorasVuelo
            // 
            this.lblHorasVuelo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHorasVuelo.AutoSize = true;
            this.lblHorasVuelo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasVuelo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHorasVuelo.Location = new System.Drawing.Point(82, 356);
            this.lblHorasVuelo.Name = "lblHorasVuelo";
            this.lblHorasVuelo.Size = new System.Drawing.Size(21, 21);
            this.lblHorasVuelo.TabIndex = 47;
            this.lblHorasVuelo.Text = "A";
            // 
            // lstPasajerosOrdenados
            // 
            this.lstPasajerosOrdenados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstPasajerosOrdenados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lstPasajerosOrdenados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPasajerosOrdenados.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPasajerosOrdenados.ForeColor = System.Drawing.SystemColors.Control;
            this.lstPasajerosOrdenados.FormattingEnabled = true;
            this.lstPasajerosOrdenados.ItemHeight = 17;
            this.lstPasajerosOrdenados.Location = new System.Drawing.Point(428, 615);
            this.lstPasajerosOrdenados.Name = "lstPasajerosOrdenados";
            this.lstPasajerosOrdenados.Size = new System.Drawing.Size(469, 102);
            this.lstPasajerosOrdenados.TabIndex = 48;
            // 
            // lstDestinos
            // 
            this.lstDestinos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstDestinos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lstDestinos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDestinos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDestinos.ForeColor = System.Drawing.SystemColors.Control;
            this.lstDestinos.FormattingEnabled = true;
            this.lstDestinos.ItemHeight = 19;
            this.lstDestinos.Location = new System.Drawing.Point(428, 516);
            this.lstDestinos.Name = "lstDestinos";
            this.lstDestinos.Size = new System.Drawing.Size(469, 76);
            this.lstDestinos.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(82, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 42);
            this.label2.TabIndex = 50;
            this.label2.Text = "Destinos ordenados \r\npor facturacion:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(82, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 42);
            this.label3.TabIndex = 51;
            this.label3.Text = "Pasajeros ordenados\r\npor cantidad de viajes:";
            // 
            // ConsultarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1064, 724);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstDestinos);
            this.Controls.Add(this.lstPasajerosOrdenados);
            this.Controls.Add(this.lblHorasVuelo);
            this.Controls.Add(this.cmbxAviones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPasajeros);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblDineroTotal);
            this.Controls.Add(this.lblTituloConsultar);
            this.Controls.Add(this.cmbxListaViajesRealizados);
            this.Controls.Add(this.lblListaViajesRealizados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarEstadisticas";
            this.Text = "Consultar Estadisticas";
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
        private System.Windows.Forms.ComboBox cmbxAviones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHorasVuelo;
        private System.Windows.Forms.ListBox lstPasajerosOrdenados;
        private System.Windows.Forms.ListBox lstDestinos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}