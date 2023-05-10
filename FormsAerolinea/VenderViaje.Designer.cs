namespace FormsAerolinea
{
    partial class VenderViaje
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
            this.cmbxListaVuelos = new System.Windows.Forms.ComboBox();
            this.lblTituloVenderViaje = new System.Windows.Forms.Label();
            this.lblListaViajes = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lbldentificador = new System.Windows.Forms.Label();
            this.gbxVenderPasaje = new System.Windows.Forms.GroupBox();
            this.chbTipoPasajero = new System.Windows.Forms.CheckBox();
            this.chbDestino = new System.Windows.Forms.CheckBox();
            this.lblCostoPasaje = new System.Windows.Forms.Label();
            this.btnVenderPasaje = new System.Windows.Forms.Button();
            this.lblListaPasajeros = new System.Windows.Forms.Label();
            this.cmbxListaPasajeros = new System.Windows.Forms.ComboBox();
            this.lblPrecioPasaje = new System.Windows.Forms.Label();
            this.gbxVenderPasaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxListaVuelos
            // 
            this.cmbxListaVuelos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbxListaVuelos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaVuelos.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaVuelos.FormattingEnabled = true;
            this.cmbxListaVuelos.Location = new System.Drawing.Point(151, 99);
            this.cmbxListaVuelos.Name = "cmbxListaVuelos";
            this.cmbxListaVuelos.Size = new System.Drawing.Size(178, 27);
            this.cmbxListaVuelos.TabIndex = 0;
            this.cmbxListaVuelos.SelectedIndexChanged += new System.EventHandler(this.cmbxListaVuelos_SelectedIndexChanged);
            // 
            // lblTituloVenderViaje
            // 
            this.lblTituloVenderViaje.AutoSize = true;
            this.lblTituloVenderViaje.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTituloVenderViaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloVenderViaje.Font = new System.Drawing.Font("Sitka Subheading", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVenderViaje.Location = new System.Drawing.Point(367, 158);
            this.lblTituloVenderViaje.Name = "lblTituloVenderViaje";
            this.lblTituloVenderViaje.Size = new System.Drawing.Size(526, 88);
            this.lblTituloVenderViaje.TabIndex = 1;
            this.lblTituloVenderViaje.Text = "VENDER UN VIAJE";
            // 
            // lblListaViajes
            // 
            this.lblListaViajes.AutoSize = true;
            this.lblListaViajes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblListaViajes.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajes.Location = new System.Drawing.Point(6, 99);
            this.lblListaViajes.Name = "lblListaViajes";
            this.lblListaViajes.Size = new System.Drawing.Size(115, 23);
            this.lblListaViajes.TabIndex = 2;
            this.lblListaViajes.Text = "Lista de vuelos";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegresar.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(535, 499);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 40);
            this.btnRegresar.TabIndex = 38;
            this.btnRegresar.Text = "Regresar al menú anterior";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lbldentificador
            // 
            this.lbldentificador.AutoSize = true;
            this.lbldentificador.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldentificador.Location = new System.Drawing.Point(879, 53);
            this.lbldentificador.Name = "lbldentificador";
            this.lbldentificador.Size = new System.Drawing.Size(14, 19);
            this.lbldentificador.TabIndex = 39;
            this.lbldentificador.Text = "-";
            // 
            // gbxVenderPasaje
            // 
            this.gbxVenderPasaje.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbxVenderPasaje.Controls.Add(this.lblPrecioPasaje);
            this.gbxVenderPasaje.Controls.Add(this.cmbxListaPasajeros);
            this.gbxVenderPasaje.Controls.Add(this.lblListaPasajeros);
            this.gbxVenderPasaje.Controls.Add(this.chbTipoPasajero);
            this.gbxVenderPasaje.Controls.Add(this.chbDestino);
            this.gbxVenderPasaje.Controls.Add(this.lblListaViajes);
            this.gbxVenderPasaje.Controls.Add(this.cmbxListaVuelos);
            this.gbxVenderPasaje.Controls.Add(this.lblCostoPasaje);
            this.gbxVenderPasaje.Controls.Add(this.btnVenderPasaje);
            this.gbxVenderPasaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxVenderPasaje.Font = new System.Drawing.Font("Sitka Subheading", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxVenderPasaje.Location = new System.Drawing.Point(440, 249);
            this.gbxVenderPasaje.Name = "gbxVenderPasaje";
            this.gbxVenderPasaje.Size = new System.Drawing.Size(361, 244);
            this.gbxVenderPasaje.TabIndex = 46;
            this.gbxVenderPasaje.TabStop = false;
            this.gbxVenderPasaje.Text = "Vender un pasaje";
            // 
            // chbTipoPasajero
            // 
            this.chbTipoPasajero.AutoSize = true;
            this.chbTipoPasajero.Location = new System.Drawing.Point(15, 59);
            this.chbTipoPasajero.Name = "chbTipoPasajero";
            this.chbTipoPasajero.Size = new System.Drawing.Size(156, 20);
            this.chbTipoPasajero.TabIndex = 57;
            this.chbTipoPasajero.Text = "¿Desea viajar en premium?";
            this.chbTipoPasajero.UseVisualStyleBackColor = true;
            // 
            // chbDestino
            // 
            this.chbDestino.AutoSize = true;
            this.chbDestino.Location = new System.Drawing.Point(15, 33);
            this.chbDestino.Name = "chbDestino";
            this.chbDestino.Size = new System.Drawing.Size(216, 20);
            this.chbDestino.TabIndex = 56;
            this.chbDestino.Text = "¿Desea realizar un vuelo internacional?";
            this.chbDestino.UseVisualStyleBackColor = true;
            this.chbDestino.CheckedChanged += new System.EventHandler(this.chbDestino_CheckedChanged);
            // 
            // lblCostoPasaje
            // 
            this.lblCostoPasaje.AutoSize = true;
            this.lblCostoPasaje.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoPasaje.Location = new System.Drawing.Point(6, 170);
            this.lblCostoPasaje.Name = "lblCostoPasaje";
            this.lblCostoPasaje.Size = new System.Drawing.Size(124, 23);
            this.lblCostoPasaje.TabIndex = 52;
            this.lblCostoPasaje.Text = "Costo del pasaje";
            // 
            // btnVenderPasaje
            // 
            this.btnVenderPasaje.Location = new System.Drawing.Point(122, 210);
            this.btnVenderPasaje.Name = "btnVenderPasaje";
            this.btnVenderPasaje.Size = new System.Drawing.Size(137, 28);
            this.btnVenderPasaje.TabIndex = 39;
            this.btnVenderPasaje.Text = "Vender pasaje";
            this.btnVenderPasaje.UseVisualStyleBackColor = true;
            this.btnVenderPasaje.Click += new System.EventHandler(this.btnVenderPasaje_Click);
            // 
            // lblListaPasajeros
            // 
            this.lblListaPasajeros.AutoSize = true;
            this.lblListaPasajeros.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblListaPasajeros.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaPasajeros.Location = new System.Drawing.Point(6, 132);
            this.lblListaPasajeros.Name = "lblListaPasajeros";
            this.lblListaPasajeros.Size = new System.Drawing.Size(137, 23);
            this.lblListaPasajeros.TabIndex = 58;
            this.lblListaPasajeros.Text = "Lista de pasajeros";
            // 
            // cmbxListaPasajeros
            // 
            this.cmbxListaPasajeros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbxListaPasajeros.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaPasajeros.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaPasajeros.FormattingEnabled = true;
            this.cmbxListaPasajeros.Location = new System.Drawing.Point(151, 132);
            this.cmbxListaPasajeros.Name = "cmbxListaPasajeros";
            this.cmbxListaPasajeros.Size = new System.Drawing.Size(178, 27);
            this.cmbxListaPasajeros.TabIndex = 59;
            // 
            // lblPrecioPasaje
            // 
            this.lblPrecioPasaje.AutoSize = true;
            this.lblPrecioPasaje.Font = new System.Drawing.Font("Sitka Subheading", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioPasaje.Location = new System.Drawing.Point(148, 175);
            this.lblPrecioPasaje.Name = "lblPrecioPasaje";
            this.lblPrecioPasaje.Size = new System.Drawing.Size(0, 18);
            this.lblPrecioPasaje.TabIndex = 60;
            // 
            // VenderViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1241, 809);
            this.Controls.Add(this.gbxVenderPasaje);
            this.Controls.Add(this.lbldentificador);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblTituloVenderViaje);
            this.Name = "VenderViaje";
            this.Text = "Venta de Viajes";
            this.gbxVenderPasaje.ResumeLayout(false);
            this.gbxVenderPasaje.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxListaVuelos;
        private System.Windows.Forms.Label lblTituloVenderViaje;
        private System.Windows.Forms.Label lblListaViajes;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lbldentificador;
        private System.Windows.Forms.GroupBox gbxVenderPasaje;
        private System.Windows.Forms.CheckBox chbTipoPasajero;
        private System.Windows.Forms.CheckBox chbDestino;
        private System.Windows.Forms.Label lblCostoPasaje;
        private System.Windows.Forms.Button btnVenderPasaje;
        private System.Windows.Forms.ComboBox cmbxListaPasajeros;
        private System.Windows.Forms.Label lblListaPasajeros;
        private System.Windows.Forms.Label lblPrecioPasaje;
    }
}