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
            this.lblListaViajes = new System.Windows.Forms.Label();
            this.lblPrecioPasaje = new System.Windows.Forms.Label();
            this.lblListaPasajeros = new System.Windows.Forms.Label();
            this.chbTipoPasajero = new System.Windows.Forms.CheckBox();
            this.lblCostoPasaje = new System.Windows.Forms.Label();
            this.btnVenderPasaje = new System.Windows.Forms.Button();
            this.cmbxListaVuelos = new System.Windows.Forms.ComboBox();
            this.cmbxListaPasajeros = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesoEquipajeTurista = new System.Windows.Forms.TextBox();
            this.rdbBolsoMano = new System.Windows.Forms.RadioButton();
            this.lblEquipaje = new System.Windows.Forms.Label();
            this.lblIngresar = new System.Windows.Forms.Label();
            this.txtPesoEquipajePdos = new System.Windows.Forms.TextBox();
            this.lblIngresarDos = new System.Windows.Forms.Label();
            this.txtPesoEquipajePuno = new System.Windows.Forms.TextBox();
            this.lblIngresarTres = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblListaViajes
            // 
            this.lblListaViajes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblListaViajes.AutoSize = true;
            this.lblListaViajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblListaViajes.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajes.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaViajes.Location = new System.Drawing.Point(50, 263);
            this.lblListaViajes.Name = "lblListaViajes";
            this.lblListaViajes.Size = new System.Drawing.Size(184, 31);
            this.lblListaViajes.TabIndex = 2;
            this.lblListaViajes.Text = "Lista de vuelos";
            // 
            // lblPrecioPasaje
            // 
            this.lblPrecioPasaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrecioPasaje.AutoSize = true;
            this.lblPrecioPasaje.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioPasaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPrecioPasaje.Location = new System.Drawing.Point(278, 419);
            this.lblPrecioPasaje.Name = "lblPrecioPasaje";
            this.lblPrecioPasaje.Size = new System.Drawing.Size(0, 31);
            this.lblPrecioPasaje.TabIndex = 60;
            // 
            // lblListaPasajeros
            // 
            this.lblListaPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblListaPasajeros.AutoSize = true;
            this.lblListaPasajeros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblListaPasajeros.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaPasajeros.Location = new System.Drawing.Point(50, 347);
            this.lblListaPasajeros.Name = "lblListaPasajeros";
            this.lblListaPasajeros.Size = new System.Drawing.Size(188, 31);
            this.lblListaPasajeros.TabIndex = 58;
            this.lblListaPasajeros.Text = "Lista pasajeros";
            // 
            // chbTipoPasajero
            // 
            this.chbTipoPasajero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chbTipoPasajero.AutoSize = true;
            this.chbTipoPasajero.FlatAppearance.BorderSize = 0;
            this.chbTipoPasajero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.chbTipoPasajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbTipoPasajero.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTipoPasajero.ForeColor = System.Drawing.SystemColors.Control;
            this.chbTipoPasajero.Location = new System.Drawing.Point(56, 189);
            this.chbTipoPasajero.Name = "chbTipoPasajero";
            this.chbTipoPasajero.Size = new System.Drawing.Size(339, 35);
            this.chbTipoPasajero.TabIndex = 57;
            this.chbTipoPasajero.Text = "¿Desea viajar en premium?";
            this.chbTipoPasajero.UseVisualStyleBackColor = true;
            this.chbTipoPasajero.CheckedChanged += new System.EventHandler(this.chbTipoPasajero_CheckedChanged);
            // 
            // lblCostoPasaje
            // 
            this.lblCostoPasaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCostoPasaje.AutoSize = true;
            this.lblCostoPasaje.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoPasaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCostoPasaje.Location = new System.Drawing.Point(50, 419);
            this.lblCostoPasaje.Name = "lblCostoPasaje";
            this.lblCostoPasaje.Size = new System.Drawing.Size(222, 31);
            this.lblCostoPasaje.TabIndex = 52;
            this.lblCostoPasaje.Text = "Costo del pasaje =";
            // 
            // btnVenderPasaje
            // 
            this.btnVenderPasaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVenderPasaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnVenderPasaje.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnVenderPasaje.FlatAppearance.BorderSize = 0;
            this.btnVenderPasaje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVenderPasaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenderPasaje.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenderPasaje.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVenderPasaje.Location = new System.Drawing.Point(56, 579);
            this.btnVenderPasaje.Name = "btnVenderPasaje";
            this.btnVenderPasaje.Size = new System.Drawing.Size(972, 51);
            this.btnVenderPasaje.TabIndex = 39;
            this.btnVenderPasaje.Text = "Vender pasaje";
            this.btnVenderPasaje.UseVisualStyleBackColor = false;
            this.btnVenderPasaje.Click += new System.EventHandler(this.btnVenderPasaje_Click);
            // 
            // cmbxListaVuelos
            // 
            this.cmbxListaVuelos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxListaVuelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaVuelos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaVuelos.FormattingEnabled = true;
            this.cmbxListaVuelos.Location = new System.Drawing.Point(258, 270);
            this.cmbxListaVuelos.Name = "cmbxListaVuelos";
            this.cmbxListaVuelos.Size = new System.Drawing.Size(770, 27);
            this.cmbxListaVuelos.TabIndex = 61;
            this.cmbxListaVuelos.SelectedIndexChanged += new System.EventHandler(this.cmbxListaVuelos_SelectedIndexChanged);
            // 
            // cmbxListaPasajeros
            // 
            this.cmbxListaPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbxListaPasajeros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaPasajeros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaPasajeros.FormattingEnabled = true;
            this.cmbxListaPasajeros.Location = new System.Drawing.Point(258, 347);
            this.cmbxListaPasajeros.Name = "cmbxListaPasajeros";
            this.cmbxListaPasajeros.Size = new System.Drawing.Size(770, 27);
            this.cmbxListaPasajeros.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(348, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 61);
            this.label1.TabIndex = 63;
            this.label1.Text = "Venta de Pasajes";
            // 
            // txtPesoEquipajeTurista
            // 
            this.txtPesoEquipajeTurista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPesoEquipajeTurista.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoEquipajeTurista.Location = new System.Drawing.Point(708, 493);
            this.txtPesoEquipajeTurista.Name = "txtPesoEquipajeTurista";
            this.txtPesoEquipajeTurista.Size = new System.Drawing.Size(104, 20);
            this.txtPesoEquipajeTurista.TabIndex = 64;
            this.txtPesoEquipajeTurista.Visible = false;
            // 
            // rdbBolsoMano
            // 
            this.rdbBolsoMano.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdbBolsoMano.AutoSize = true;
            this.rdbBolsoMano.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBolsoMano.ForeColor = System.Drawing.SystemColors.Control;
            this.rdbBolsoMano.Location = new System.Drawing.Point(356, 494);
            this.rdbBolsoMano.Name = "rdbBolsoMano";
            this.rdbBolsoMano.Size = new System.Drawing.Size(121, 23);
            this.rdbBolsoMano.TabIndex = 65;
            this.rdbBolsoMano.TabStop = true;
            this.rdbBolsoMano.Text = "Bolso de mano";
            this.rdbBolsoMano.UseVisualStyleBackColor = true;
            this.rdbBolsoMano.Visible = false;
            // 
            // lblEquipaje
            // 
            this.lblEquipaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEquipaje.AutoSize = true;
            this.lblEquipaje.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEquipaje.Location = new System.Drawing.Point(50, 488);
            this.lblEquipaje.Name = "lblEquipaje";
            this.lblEquipaje.Size = new System.Drawing.Size(263, 31);
            this.lblEquipaje.TabIndex = 66;
            this.lblEquipaje.Text = "Equipaje del pasajero";
            // 
            // lblIngresar
            // 
            this.lblIngresar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIngresar.AutoSize = true;
            this.lblIngresar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblIngresar.Location = new System.Drawing.Point(541, 494);
            this.lblIngresar.Name = "lblIngresar";
            this.lblIngresar.Size = new System.Drawing.Size(155, 38);
            this.lblIngresar.TabIndex = 67;
            this.lblIngresar.Text = "Ingresa el peso en KG:\r\n     (Hasta 21 KG)\r\n";
            this.lblIngresar.Visible = false;
            // 
            // txtPesoEquipajePdos
            // 
            this.txtPesoEquipajePdos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPesoEquipajePdos.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoEquipajePdos.Location = new System.Drawing.Point(839, 495);
            this.txtPesoEquipajePdos.Name = "txtPesoEquipajePdos";
            this.txtPesoEquipajePdos.Size = new System.Drawing.Size(104, 20);
            this.txtPesoEquipajePdos.TabIndex = 68;
            this.txtPesoEquipajePdos.Visible = false;
            // 
            // lblIngresarDos
            // 
            this.lblIngresarDos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIngresarDos.AutoSize = true;
            this.lblIngresarDos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresarDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblIngresarDos.Location = new System.Drawing.Point(355, 498);
            this.lblIngresarDos.Name = "lblIngresarDos";
            this.lblIngresarDos.Size = new System.Drawing.Size(155, 38);
            this.lblIngresarDos.TabIndex = 71;
            this.lblIngresarDos.Text = "Ingresa el peso en KG:\r\n     (Hasta 25 KG)\r\n";
            this.lblIngresarDos.Visible = false;
            // 
            // txtPesoEquipajePuno
            // 
            this.txtPesoEquipajePuno.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPesoEquipajePuno.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoEquipajePuno.Location = new System.Drawing.Point(522, 497);
            this.txtPesoEquipajePuno.Name = "txtPesoEquipajePuno";
            this.txtPesoEquipajePuno.Size = new System.Drawing.Size(104, 20);
            this.txtPesoEquipajePuno.TabIndex = 70;
            this.txtPesoEquipajePuno.Visible = false;
            // 
            // lblIngresarTres
            // 
            this.lblIngresarTres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIngresarTres.AutoSize = true;
            this.lblIngresarTres.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresarTres.ForeColor = System.Drawing.SystemColors.Control;
            this.lblIngresarTres.Location = new System.Drawing.Point(672, 496);
            this.lblIngresarTres.Name = "lblIngresarTres";
            this.lblIngresarTres.Size = new System.Drawing.Size(155, 38);
            this.lblIngresarTres.TabIndex = 69;
            this.lblIngresarTres.Text = "Ingresa el peso en KG:\r\n     (Hasta 25 KG)\r\n";
            this.lblIngresarTres.Visible = false;
            // 
            // VenderViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1064, 680);
            this.Controls.Add(this.lblIngresarDos);
            this.Controls.Add(this.txtPesoEquipajePuno);
            this.Controls.Add(this.lblIngresarTres);
            this.Controls.Add(this.txtPesoEquipajePdos);
            this.Controls.Add(this.lblIngresar);
            this.Controls.Add(this.lblEquipaje);
            this.Controls.Add(this.rdbBolsoMano);
            this.Controls.Add(this.txtPesoEquipajeTurista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxListaPasajeros);
            this.Controls.Add(this.cmbxListaVuelos);
            this.Controls.Add(this.btnVenderPasaje);
            this.Controls.Add(this.lblPrecioPasaje);
            this.Controls.Add(this.lblCostoPasaje);
            this.Controls.Add(this.lblListaPasajeros);
            this.Controls.Add(this.chbTipoPasajero);
            this.Controls.Add(this.lblListaViajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VenderViaje";
            this.Text = "Venta de Viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblListaViajes;
        private System.Windows.Forms.CheckBox chbTipoPasajero;
        private System.Windows.Forms.Label lblCostoPasaje;
        private System.Windows.Forms.Button btnVenderPasaje;
        private System.Windows.Forms.Label lblListaPasajeros;
        private System.Windows.Forms.Label lblPrecioPasaje;
        private System.Windows.Forms.ComboBox cmbxListaVuelos;
        private System.Windows.Forms.ComboBox cmbxListaPasajeros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesoEquipajeTurista;
        private System.Windows.Forms.RadioButton rdbBolsoMano;
        private System.Windows.Forms.Label lblEquipaje;
        private System.Windows.Forms.Label lblIngresar;
        private System.Windows.Forms.TextBox txtPesoEquipajePdos;
        private System.Windows.Forms.Label lblIngresarDos;
        private System.Windows.Forms.TextBox txtPesoEquipajePuno;
        private System.Windows.Forms.Label lblIngresarTres;
    }
}