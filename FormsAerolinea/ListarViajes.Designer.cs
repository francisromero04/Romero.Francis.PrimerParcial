namespace FormsAerolinea
{
    partial class ViajesDisponibles
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
            this.cmbxListaViajes = new System.Windows.Forms.ComboBox();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadPasajeros = new System.Windows.Forms.TextBox();
            this.lstPasajerosViaje = new System.Windows.Forms.ListBox();
            this.txtAvionAutilizar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbxListaViajes
            // 
            this.cmbxListaViajes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxListaViajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cmbxListaViajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaViajes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaViajes.ForeColor = System.Drawing.SystemColors.Control;
            this.cmbxListaViajes.FormattingEnabled = true;
            this.cmbxListaViajes.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbxListaViajes.Location = new System.Drawing.Point(150, 182);
            this.cmbxListaViajes.Name = "cmbxListaViajes";
            this.cmbxListaViajes.Size = new System.Drawing.Size(777, 27);
            this.cmbxListaViajes.TabIndex = 1;
            this.cmbxListaViajes.SelectedIndexChanged += new System.EventHandler(this.cmbxListaViajes_SelectedIndexChanged);
            // 
            // txtOrigen
            // 
            this.txtOrigen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOrigen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrigen.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigen.ForeColor = System.Drawing.SystemColors.Control;
            this.txtOrigen.Location = new System.Drawing.Point(220, 474);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(418, 37);
            this.txtOrigen.TabIndex = 3;
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.SystemColors.Control;
            this.txtDestino.Location = new System.Drawing.Point(220, 512);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(418, 37);
            this.txtDestino.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.SystemColors.Control;
            this.txtPrecio.Location = new System.Drawing.Point(150, 228);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(777, 28);
            this.txtPrecio.TabIndex = 2;
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.SystemColors.Control;
            this.txtFecha.Location = new System.Drawing.Point(220, 550);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(418, 37);
            this.txtFecha.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(349, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 61);
            this.label1.TabIndex = 30;
            this.label1.Text = "Viajes Disponibles";
            // 
            // txtCantidadPasajeros
            // 
            this.txtCantidadPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCantidadPasajeros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCantidadPasajeros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadPasajeros.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.txtCantidadPasajeros.Location = new System.Drawing.Point(220, 588);
            this.txtCantidadPasajeros.Name = "txtCantidadPasajeros";
            this.txtCantidadPasajeros.ReadOnly = true;
            this.txtCantidadPasajeros.Size = new System.Drawing.Size(418, 37);
            this.txtCantidadPasajeros.TabIndex = 31;
            // 
            // lstPasajerosViaje
            // 
            this.lstPasajerosViaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lstPasajerosViaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lstPasajerosViaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPasajerosViaje.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPasajerosViaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lstPasajerosViaje.FormattingEnabled = true;
            this.lstPasajerosViaje.ItemHeight = 19;
            this.lstPasajerosViaje.Location = new System.Drawing.Point(219, 270);
            this.lstPasajerosViaje.Name = "lstPasajerosViaje";
            this.lstPasajerosViaje.Size = new System.Drawing.Size(617, 190);
            this.lstPasajerosViaje.TabIndex = 32;
            // 
            // txtAvionAutilizar
            // 
            this.txtAvionAutilizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAvionAutilizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtAvionAutilizar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAvionAutilizar.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvionAutilizar.ForeColor = System.Drawing.SystemColors.Control;
            this.txtAvionAutilizar.Location = new System.Drawing.Point(220, 631);
            this.txtAvionAutilizar.Name = "txtAvionAutilizar";
            this.txtAvionAutilizar.ReadOnly = true;
            this.txtAvionAutilizar.Size = new System.Drawing.Size(418, 37);
            this.txtAvionAutilizar.TabIndex = 33;
            // 
            // ViajesDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1064, 680);
            this.Controls.Add(this.txtAvionAutilizar);
            this.Controls.Add(this.lstPasajerosViaje);
            this.Controls.Add(this.txtCantidadPasajeros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxListaViajes);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViajesDisponibles";
            this.Opacity = 0.9D;
            this.Text = "Lista de Viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbxListaViajes;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidadPasajeros;
        private System.Windows.Forms.ListBox lstPasajerosViaje;
        private System.Windows.Forms.TextBox txtAvionAutilizar;
    }
}