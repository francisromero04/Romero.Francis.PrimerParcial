namespace FormsAerolinea
{
    partial class CrudViajes
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
            this.lbldentificador = new System.Windows.Forms.Label();
            this.btnOpcionUno = new System.Windows.Forms.Button();
            this.btnOpcionTres = new System.Windows.Forms.Button();
            this.btnOpcionDos = new System.Windows.Forms.Button();
            this.gbxCrearViajes = new System.Windows.Forms.GroupBox();
            this.cmbxTipoViaje = new System.Windows.Forms.ComboBox();
            this.lblTipoViaje = new System.Windows.Forms.Label();
            this.cmbxMatriculaAviones = new System.Windows.Forms.ComboBox();
            this.lblAvion = new System.Windows.Forms.Label();
            this.txtAsientosPremium = new System.Windows.Forms.TextBox();
            this.lblAsientosPremium = new System.Windows.Forms.Label();
            this.txtAsientosTuristas = new System.Windows.Forms.TextBox();
            this.dtpFechaVuelo = new System.Windows.Forms.DateTimePicker();
            this.cmbxDestino = new System.Windows.Forms.ComboBox();
            this.cmbxOrigen = new System.Windows.Forms.ComboBox();
            this.lblAsientosTuristas = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnCerrarUno = new System.Windows.Forms.Button();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtCostoTurista = new System.Windows.Forms.TextBox();
            this.lblCostoPremium = new System.Windows.Forms.Label();
            this.txtCostoPremium = new System.Windows.Forms.TextBox();
            this.lblCostoTurista = new System.Windows.Forms.Label();
            this.Origen = new System.Windows.Forms.Label();
            this.btnCrearAvion = new System.Windows.Forms.Button();
            this.gbxModificarViaje = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbxListaVuelos = new System.Windows.Forms.ComboBox();
            this.cmbxTipoViajeDos = new System.Windows.Forms.ComboBox();
            this.lblTipoViajeDos = new System.Windows.Forms.Label();
            this.cmbxMatriculaDos = new System.Windows.Forms.ComboBox();
            this.lblAvionDos = new System.Windows.Forms.Label();
            this.dtpFechaVueloDos = new System.Windows.Forms.DateTimePicker();
            this.cmbxDestinoDos = new System.Windows.Forms.ComboBox();
            this.cmbxOrigenDos = new System.Windows.Forms.ComboBox();
            this.LblFechaDos = new System.Windows.Forms.Label();
            this.btnCerrarDos = new System.Windows.Forms.Button();
            this.lblDestinoDos = new System.Windows.Forms.Label();
            this.txtCostoTuristaDos = new System.Windows.Forms.TextBox();
            this.lblCostoPremiumDos = new System.Windows.Forms.Label();
            this.txtCostoPremiumDos = new System.Windows.Forms.TextBox();
            this.lblCostoTuristaDos = new System.Windows.Forms.Label();
            this.lblOrigenDos = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.gbxEliminarViaje = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrarTres = new System.Windows.Forms.Button();
            this.lblListaPasajeros = new System.Windows.Forms.Label();
            this.cmbxViajes = new System.Windows.Forms.ComboBox();
            this.dgvVuelos = new System.Windows.Forms.DataGridView();
            this.gbxCrearViajes.SuspendLayout();
            this.gbxModificarViaje.SuspendLayout();
            this.gbxEliminarViaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbldentificador
            // 
            this.lbldentificador.AutoSize = true;
            this.lbldentificador.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldentificador.Location = new System.Drawing.Point(1059, 137);
            this.lbldentificador.Name = "lbldentificador";
            this.lbldentificador.Size = new System.Drawing.Size(14, 19);
            this.lbldentificador.TabIndex = 23;
            this.lbldentificador.Text = "-";
            // 
            // btnOpcionUno
            // 
            this.btnOpcionUno.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpcionUno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionUno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionUno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionUno.FlatAppearance.BorderSize = 0;
            this.btnOpcionUno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOpcionUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcionUno.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionUno.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOpcionUno.Location = new System.Drawing.Point(11, 617);
            this.btnOpcionUno.Name = "btnOpcionUno";
            this.btnOpcionUno.Size = new System.Drawing.Size(340, 55);
            this.btnOpcionUno.TabIndex = 59;
            this.btnOpcionUno.Text = "Crear un Vuelo.";
            this.btnOpcionUno.UseVisualStyleBackColor = false;
            this.btnOpcionUno.Click += new System.EventHandler(this.btnOpcionUno_Click);
            // 
            // btnOpcionTres
            // 
            this.btnOpcionTres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpcionTres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionTres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionTres.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionTres.FlatAppearance.BorderSize = 0;
            this.btnOpcionTres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOpcionTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcionTres.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionTres.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOpcionTres.Location = new System.Drawing.Point(729, 617);
            this.btnOpcionTres.Name = "btnOpcionTres";
            this.btnOpcionTres.Size = new System.Drawing.Size(322, 55);
            this.btnOpcionTres.TabIndex = 58;
            this.btnOpcionTres.Text = "Eliminar un Vuelo.";
            this.btnOpcionTres.UseVisualStyleBackColor = false;
            this.btnOpcionTres.Click += new System.EventHandler(this.btnOpcionTres_Click);
            // 
            // btnOpcionDos
            // 
            this.btnOpcionDos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpcionDos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionDos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionDos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOpcionDos.FlatAppearance.BorderSize = 0;
            this.btnOpcionDos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOpcionDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcionDos.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionDos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOpcionDos.Location = new System.Drawing.Point(357, 617);
            this.btnOpcionDos.Name = "btnOpcionDos";
            this.btnOpcionDos.Size = new System.Drawing.Size(366, 55);
            this.btnOpcionDos.TabIndex = 57;
            this.btnOpcionDos.Text = "Modificar un Vuelo.";
            this.btnOpcionDos.UseVisualStyleBackColor = false;
            this.btnOpcionDos.Click += new System.EventHandler(this.btnOpcionDos_Click);
            // 
            // gbxCrearViajes
            // 
            this.gbxCrearViajes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxCrearViajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.gbxCrearViajes.Controls.Add(this.cmbxTipoViaje);
            this.gbxCrearViajes.Controls.Add(this.lblTipoViaje);
            this.gbxCrearViajes.Controls.Add(this.cmbxMatriculaAviones);
            this.gbxCrearViajes.Controls.Add(this.lblAvion);
            this.gbxCrearViajes.Controls.Add(this.txtAsientosPremium);
            this.gbxCrearViajes.Controls.Add(this.lblAsientosPremium);
            this.gbxCrearViajes.Controls.Add(this.txtAsientosTuristas);
            this.gbxCrearViajes.Controls.Add(this.dtpFechaVuelo);
            this.gbxCrearViajes.Controls.Add(this.cmbxDestino);
            this.gbxCrearViajes.Controls.Add(this.cmbxOrigen);
            this.gbxCrearViajes.Controls.Add(this.lblAsientosTuristas);
            this.gbxCrearViajes.Controls.Add(this.lblFecha);
            this.gbxCrearViajes.Controls.Add(this.btnCerrarUno);
            this.gbxCrearViajes.Controls.Add(this.lblDestino);
            this.gbxCrearViajes.Controls.Add(this.txtCostoTurista);
            this.gbxCrearViajes.Controls.Add(this.lblCostoPremium);
            this.gbxCrearViajes.Controls.Add(this.txtCostoPremium);
            this.gbxCrearViajes.Controls.Add(this.lblCostoTurista);
            this.gbxCrearViajes.Controls.Add(this.Origen);
            this.gbxCrearViajes.Controls.Add(this.btnCrearAvion);
            this.gbxCrearViajes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxCrearViajes.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCrearViajes.ForeColor = System.Drawing.SystemColors.Control;
            this.gbxCrearViajes.Location = new System.Drawing.Point(116, 678);
            this.gbxCrearViajes.Name = "gbxCrearViajes";
            this.gbxCrearViajes.Size = new System.Drawing.Size(799, 553);
            this.gbxCrearViajes.TabIndex = 62;
            this.gbxCrearViajes.TabStop = false;
            this.gbxCrearViajes.Text = "Crear un Vuelo";
            this.gbxCrearViajes.Visible = false;
            // 
            // cmbxTipoViaje
            // 
            this.cmbxTipoViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTipoViaje.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxTipoViaje.FormattingEnabled = true;
            this.cmbxTipoViaje.Location = new System.Drawing.Point(329, 36);
            this.cmbxTipoViaje.Name = "cmbxTipoViaje";
            this.cmbxTipoViaje.Size = new System.Drawing.Size(464, 27);
            this.cmbxTipoViaje.TabIndex = 73;
            this.cmbxTipoViaje.SelectedIndexChanged += new System.EventHandler(this.cmbxTipoViaje_SelectedIndexChanged);
            // 
            // lblTipoViaje
            // 
            this.lblTipoViaje.AutoSize = true;
            this.lblTipoViaje.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoViaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTipoViaje.Location = new System.Drawing.Point(24, 44);
            this.lblTipoViaje.Name = "lblTipoViaje";
            this.lblTipoViaje.Size = new System.Drawing.Size(161, 27);
            this.lblTipoViaje.TabIndex = 72;
            this.lblTipoViaje.Text = "Seleccione tipo";
            // 
            // cmbxMatriculaAviones
            // 
            this.cmbxMatriculaAviones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMatriculaAviones.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxMatriculaAviones.FormattingEnabled = true;
            this.cmbxMatriculaAviones.Location = new System.Drawing.Point(329, 384);
            this.cmbxMatriculaAviones.Name = "cmbxMatriculaAviones";
            this.cmbxMatriculaAviones.Size = new System.Drawing.Size(464, 29);
            this.cmbxMatriculaAviones.TabIndex = 71;
            // 
            // lblAvion
            // 
            this.lblAvion.AutoSize = true;
            this.lblAvion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAvion.Location = new System.Drawing.Point(24, 392);
            this.lblAvion.Name = "lblAvion";
            this.lblAvion.Size = new System.Drawing.Size(173, 27);
            this.lblAvion.TabIndex = 70;
            this.lblAvion.Text = "Avion  a Utilizar";
            // 
            // txtAsientosPremium
            // 
            this.txtAsientosPremium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtAsientosPremium.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsientosPremium.ForeColor = System.Drawing.SystemColors.Window;
            this.txtAsientosPremium.Location = new System.Drawing.Point(329, 343);
            this.txtAsientosPremium.Name = "txtAsientosPremium";
            this.txtAsientosPremium.ReadOnly = true;
            this.txtAsientosPremium.Size = new System.Drawing.Size(464, 35);
            this.txtAsientosPremium.TabIndex = 69;
            this.txtAsientosPremium.Text = "20% Asientos Turistas";
            // 
            // lblAsientosPremium
            // 
            this.lblAsientosPremium.AutoSize = true;
            this.lblAsientosPremium.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsientosPremium.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAsientosPremium.Location = new System.Drawing.Point(24, 351);
            this.lblAsientosPremium.Name = "lblAsientosPremium";
            this.lblAsientosPremium.Size = new System.Drawing.Size(187, 27);
            this.lblAsientosPremium.TabIndex = 68;
            this.lblAsientosPremium.Text = "Asientos Premium";
            // 
            // txtAsientosTuristas
            // 
            this.txtAsientosTuristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtAsientosTuristas.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsientosTuristas.ForeColor = System.Drawing.SystemColors.Window;
            this.txtAsientosTuristas.Location = new System.Drawing.Point(329, 302);
            this.txtAsientosTuristas.Name = "txtAsientosTuristas";
            this.txtAsientosTuristas.Size = new System.Drawing.Size(464, 35);
            this.txtAsientosTuristas.TabIndex = 67;
            // 
            // dtpFechaVuelo
            // 
            this.dtpFechaVuelo.CalendarMonthBackground = System.Drawing.SystemColors.ScrollBar;
            this.dtpFechaVuelo.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVuelo.Location = new System.Drawing.Point(329, 261);
            this.dtpFechaVuelo.Name = "dtpFechaVuelo";
            this.dtpFechaVuelo.Size = new System.Drawing.Size(464, 35);
            this.dtpFechaVuelo.TabIndex = 66;
            // 
            // cmbxDestino
            // 
            this.cmbxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDestino.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxDestino.FormattingEnabled = true;
            this.cmbxDestino.Location = new System.Drawing.Point(329, 220);
            this.cmbxDestino.Name = "cmbxDestino";
            this.cmbxDestino.Size = new System.Drawing.Size(464, 29);
            this.cmbxDestino.TabIndex = 65;
            // 
            // cmbxOrigen
            // 
            this.cmbxOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxOrigen.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxOrigen.FormattingEnabled = true;
            this.cmbxOrigen.Location = new System.Drawing.Point(329, 185);
            this.cmbxOrigen.Name = "cmbxOrigen";
            this.cmbxOrigen.Size = new System.Drawing.Size(464, 29);
            this.cmbxOrigen.TabIndex = 64;
            // 
            // lblAsientosTuristas
            // 
            this.lblAsientosTuristas.AutoSize = true;
            this.lblAsientosTuristas.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsientosTuristas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAsientosTuristas.Location = new System.Drawing.Point(24, 310);
            this.lblAsientosTuristas.Name = "lblAsientosTuristas";
            this.lblAsientosTuristas.Size = new System.Drawing.Size(177, 27);
            this.lblAsientosTuristas.TabIndex = 62;
            this.lblAsientosTuristas.Text = "Asientos Turistas";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFecha.Location = new System.Drawing.Point(24, 269);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(163, 27);
            this.lblFecha.TabIndex = 60;
            this.lblFecha.Text = "Fecha de Vuelo";
            // 
            // btnCerrarUno
            // 
            this.btnCerrarUno.FlatAppearance.BorderSize = 0;
            this.btnCerrarUno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCerrarUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarUno.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarUno.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrarUno.Location = new System.Drawing.Point(6, 502);
            this.btnCerrarUno.Name = "btnCerrarUno";
            this.btnCerrarUno.Size = new System.Drawing.Size(786, 41);
            this.btnCerrarUno.TabIndex = 52;
            this.btnCerrarUno.Text = "Guardar y cerrar";
            this.btnCerrarUno.UseVisualStyleBackColor = true;
            this.btnCerrarUno.Click += new System.EventHandler(this.btnCerrarUno_Click);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDestino.Location = new System.Drawing.Point(24, 228);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(87, 27);
            this.lblDestino.TabIndex = 58;
            this.lblDestino.Text = "Destino";
            // 
            // txtCostoTurista
            // 
            this.txtCostoTurista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCostoTurista.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTurista.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCostoTurista.Location = new System.Drawing.Point(329, 99);
            this.txtCostoTurista.Name = "txtCostoTurista";
            this.txtCostoTurista.Size = new System.Drawing.Size(464, 35);
            this.txtCostoTurista.TabIndex = 55;
            // 
            // lblCostoPremium
            // 
            this.lblCostoPremium.AutoSize = true;
            this.lblCostoPremium.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoPremium.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCostoPremium.Location = new System.Drawing.Point(24, 146);
            this.lblCostoPremium.Name = "lblCostoPremium";
            this.lblCostoPremium.Size = new System.Drawing.Size(162, 27);
            this.lblCostoPremium.TabIndex = 50;
            this.lblCostoPremium.Text = "Costo Premium";
            // 
            // txtCostoPremium
            // 
            this.txtCostoPremium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCostoPremium.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoPremium.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCostoPremium.Location = new System.Drawing.Point(329, 138);
            this.txtCostoPremium.Name = "txtCostoPremium";
            this.txtCostoPremium.ReadOnly = true;
            this.txtCostoPremium.Size = new System.Drawing.Size(464, 35);
            this.txtCostoPremium.TabIndex = 51;
            this.txtCostoPremium.Text = "35% Costo Turista";
            // 
            // lblCostoTurista
            // 
            this.lblCostoTurista.AutoSize = true;
            this.lblCostoTurista.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTurista.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCostoTurista.Location = new System.Drawing.Point(24, 107);
            this.lblCostoTurista.Name = "lblCostoTurista";
            this.lblCostoTurista.Size = new System.Drawing.Size(143, 27);
            this.lblCostoTurista.TabIndex = 54;
            this.lblCostoTurista.Text = "Costo Turista";
            // 
            // Origen
            // 
            this.Origen.AutoSize = true;
            this.Origen.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Origen.ForeColor = System.Drawing.SystemColors.Control;
            this.Origen.Location = new System.Drawing.Point(24, 187);
            this.Origen.Name = "Origen";
            this.Origen.Size = new System.Drawing.Size(81, 27);
            this.Origen.TabIndex = 52;
            this.Origen.Text = "Origen";
            // 
            // btnCrearAvion
            // 
            this.btnCrearAvion.FlatAppearance.BorderSize = 0;
            this.btnCrearAvion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCrearAvion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearAvion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearAvion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCrearAvion.Location = new System.Drawing.Point(6, 455);
            this.btnCrearAvion.Name = "btnCrearAvion";
            this.btnCrearAvion.Size = new System.Drawing.Size(786, 41);
            this.btnCrearAvion.TabIndex = 39;
            this.btnCrearAvion.Text = "Crear Vuelo";
            this.btnCrearAvion.UseVisualStyleBackColor = true;
            this.btnCrearAvion.Click += new System.EventHandler(this.btnCrearVuelo_Click);
            // 
            // gbxModificarViaje
            // 
            this.gbxModificarViaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxModificarViaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.gbxModificarViaje.Controls.Add(this.label15);
            this.gbxModificarViaje.Controls.Add(this.cmbxListaVuelos);
            this.gbxModificarViaje.Controls.Add(this.cmbxTipoViajeDos);
            this.gbxModificarViaje.Controls.Add(this.lblTipoViajeDos);
            this.gbxModificarViaje.Controls.Add(this.cmbxMatriculaDos);
            this.gbxModificarViaje.Controls.Add(this.lblAvionDos);
            this.gbxModificarViaje.Controls.Add(this.dtpFechaVueloDos);
            this.gbxModificarViaje.Controls.Add(this.cmbxDestinoDos);
            this.gbxModificarViaje.Controls.Add(this.cmbxOrigenDos);
            this.gbxModificarViaje.Controls.Add(this.LblFechaDos);
            this.gbxModificarViaje.Controls.Add(this.btnCerrarDos);
            this.gbxModificarViaje.Controls.Add(this.lblDestinoDos);
            this.gbxModificarViaje.Controls.Add(this.txtCostoTuristaDos);
            this.gbxModificarViaje.Controls.Add(this.lblCostoPremiumDos);
            this.gbxModificarViaje.Controls.Add(this.txtCostoPremiumDos);
            this.gbxModificarViaje.Controls.Add(this.lblCostoTuristaDos);
            this.gbxModificarViaje.Controls.Add(this.lblOrigenDos);
            this.gbxModificarViaje.Controls.Add(this.btnModificar);
            this.gbxModificarViaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxModificarViaje.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxModificarViaje.ForeColor = System.Drawing.SystemColors.Control;
            this.gbxModificarViaje.Location = new System.Drawing.Point(167, 678);
            this.gbxModificarViaje.Name = "gbxModificarViaje";
            this.gbxModificarViaje.Size = new System.Drawing.Size(799, 487);
            this.gbxModificarViaje.TabIndex = 69;
            this.gbxModificarViaje.TabStop = false;
            this.gbxModificarViaje.Text = "Modificar un vuelo";
            this.gbxModificarViaje.Visible = false;
            this.gbxModificarViaje.VisibleChanged += new System.EventHandler(this.gbxModificarViaje_VisibleChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(27, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 27);
            this.label15.TabIndex = 75;
            this.label15.Text = "Lista de Viajes";
            // 
            // cmbxListaVuelos
            // 
            this.cmbxListaVuelos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaVuelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxListaVuelos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaVuelos.FormattingEnabled = true;
            this.cmbxListaVuelos.Location = new System.Drawing.Point(247, 21);
            this.cmbxListaVuelos.Name = "cmbxListaVuelos";
            this.cmbxListaVuelos.Size = new System.Drawing.Size(546, 27);
            this.cmbxListaVuelos.TabIndex = 74;
            this.cmbxListaVuelos.SelectedIndexChanged += new System.EventHandler(this.cmbxListaVuelos_SelectedIndexChanged);
            // 
            // cmbxTipoViajeDos
            // 
            this.cmbxTipoViajeDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTipoViajeDos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxTipoViajeDos.FormattingEnabled = true;
            this.cmbxTipoViajeDos.Location = new System.Drawing.Point(247, 76);
            this.cmbxTipoViajeDos.Name = "cmbxTipoViajeDos";
            this.cmbxTipoViajeDos.Size = new System.Drawing.Size(546, 27);
            this.cmbxTipoViajeDos.TabIndex = 73;
            this.cmbxTipoViajeDos.SelectedIndexChanged += new System.EventHandler(this.cmbxTipoViajeDos_SelectedIndexChanged);
            // 
            // lblTipoViajeDos
            // 
            this.lblTipoViajeDos.AutoSize = true;
            this.lblTipoViajeDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoViajeDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTipoViajeDos.Location = new System.Drawing.Point(27, 84);
            this.lblTipoViajeDos.Name = "lblTipoViajeDos";
            this.lblTipoViajeDos.Size = new System.Drawing.Size(161, 27);
            this.lblTipoViajeDos.TabIndex = 72;
            this.lblTipoViajeDos.Text = "Seleccione tipo";
            // 
            // cmbxMatriculaDos
            // 
            this.cmbxMatriculaDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMatriculaDos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxMatriculaDos.FormattingEnabled = true;
            this.cmbxMatriculaDos.Location = new System.Drawing.Point(247, 336);
            this.cmbxMatriculaDos.Name = "cmbxMatriculaDos";
            this.cmbxMatriculaDos.Size = new System.Drawing.Size(546, 27);
            this.cmbxMatriculaDos.TabIndex = 71;
            // 
            // lblAvionDos
            // 
            this.lblAvionDos.AutoSize = true;
            this.lblAvionDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvionDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAvionDos.Location = new System.Drawing.Point(27, 336);
            this.lblAvionDos.Name = "lblAvionDos";
            this.lblAvionDos.Size = new System.Drawing.Size(214, 27);
            this.lblAvionDos.TabIndex = 70;
            this.lblAvionDos.Text = "Aviones  Disponibles";
            // 
            // dtpFechaVueloDos
            // 
            this.dtpFechaVueloDos.CalendarMonthBackground = System.Drawing.SystemColors.ScrollBar;
            this.dtpFechaVueloDos.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVueloDos.Location = new System.Drawing.Point(247, 281);
            this.dtpFechaVueloDos.Name = "dtpFechaVueloDos";
            this.dtpFechaVueloDos.Size = new System.Drawing.Size(546, 32);
            this.dtpFechaVueloDos.TabIndex = 66;
            // 
            // cmbxDestinoDos
            // 
            this.cmbxDestinoDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDestinoDos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxDestinoDos.FormattingEnabled = true;
            this.cmbxDestinoDos.Location = new System.Drawing.Point(247, 240);
            this.cmbxDestinoDos.Name = "cmbxDestinoDos";
            this.cmbxDestinoDos.Size = new System.Drawing.Size(546, 27);
            this.cmbxDestinoDos.TabIndex = 65;
            // 
            // cmbxOrigenDos
            // 
            this.cmbxOrigenDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxOrigenDos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxOrigenDos.FormattingEnabled = true;
            this.cmbxOrigenDos.Location = new System.Drawing.Point(247, 199);
            this.cmbxOrigenDos.Name = "cmbxOrigenDos";
            this.cmbxOrigenDos.Size = new System.Drawing.Size(546, 27);
            this.cmbxOrigenDos.TabIndex = 64;
            // 
            // LblFechaDos
            // 
            this.LblFechaDos.AutoSize = true;
            this.LblFechaDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaDos.ForeColor = System.Drawing.SystemColors.Control;
            this.LblFechaDos.Location = new System.Drawing.Point(27, 289);
            this.LblFechaDos.Name = "LblFechaDos";
            this.LblFechaDos.Size = new System.Drawing.Size(163, 27);
            this.LblFechaDos.TabIndex = 60;
            this.LblFechaDos.Text = "Fecha de Vuelo";
            // 
            // btnCerrarDos
            // 
            this.btnCerrarDos.FlatAppearance.BorderSize = 0;
            this.btnCerrarDos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCerrarDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarDos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrarDos.Location = new System.Drawing.Point(6, 428);
            this.btnCerrarDos.Name = "btnCerrarDos";
            this.btnCerrarDos.Size = new System.Drawing.Size(787, 43);
            this.btnCerrarDos.TabIndex = 52;
            this.btnCerrarDos.Text = "Guardar y cerrar";
            this.btnCerrarDos.UseVisualStyleBackColor = true;
            this.btnCerrarDos.Click += new System.EventHandler(this.btnCerrarDos_Click);
            // 
            // lblDestinoDos
            // 
            this.lblDestinoDos.AutoSize = true;
            this.lblDestinoDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinoDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDestinoDos.Location = new System.Drawing.Point(27, 243);
            this.lblDestinoDos.Name = "lblDestinoDos";
            this.lblDestinoDos.Size = new System.Drawing.Size(87, 27);
            this.lblDestinoDos.TabIndex = 58;
            this.lblDestinoDos.Text = "Destino";
            // 
            // txtCostoTuristaDos
            // 
            this.txtCostoTuristaDos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCostoTuristaDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTuristaDos.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCostoTuristaDos.Location = new System.Drawing.Point(247, 117);
            this.txtCostoTuristaDos.Name = "txtCostoTuristaDos";
            this.txtCostoTuristaDos.Size = new System.Drawing.Size(546, 35);
            this.txtCostoTuristaDos.TabIndex = 55;
            // 
            // lblCostoPremiumDos
            // 
            this.lblCostoPremiumDos.AutoSize = true;
            this.lblCostoPremiumDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoPremiumDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCostoPremiumDos.Location = new System.Drawing.Point(27, 166);
            this.lblCostoPremiumDos.Name = "lblCostoPremiumDos";
            this.lblCostoPremiumDos.Size = new System.Drawing.Size(162, 27);
            this.lblCostoPremiumDos.TabIndex = 50;
            this.lblCostoPremiumDos.Text = "Costo Premium";
            // 
            // txtCostoPremiumDos
            // 
            this.txtCostoPremiumDos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCostoPremiumDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoPremiumDos.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCostoPremiumDos.Location = new System.Drawing.Point(247, 158);
            this.txtCostoPremiumDos.Name = "txtCostoPremiumDos";
            this.txtCostoPremiumDos.ReadOnly = true;
            this.txtCostoPremiumDos.Size = new System.Drawing.Size(546, 35);
            this.txtCostoPremiumDos.TabIndex = 51;
            // 
            // lblCostoTuristaDos
            // 
            this.lblCostoTuristaDos.AutoSize = true;
            this.lblCostoTuristaDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTuristaDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCostoTuristaDos.Location = new System.Drawing.Point(27, 125);
            this.lblCostoTuristaDos.Name = "lblCostoTuristaDos";
            this.lblCostoTuristaDos.Size = new System.Drawing.Size(143, 27);
            this.lblCostoTuristaDos.TabIndex = 54;
            this.lblCostoTuristaDos.Text = "Costo Turista";
            // 
            // lblOrigenDos
            // 
            this.lblOrigenDos.AutoSize = true;
            this.lblOrigenDos.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigenDos.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOrigenDos.Location = new System.Drawing.Point(27, 207);
            this.lblOrigenDos.Name = "lblOrigenDos";
            this.lblOrigenDos.Size = new System.Drawing.Size(81, 27);
            this.lblOrigenDos.TabIndex = 52;
            this.lblOrigenDos.Text = "Origen";
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Location = new System.Drawing.Point(6, 377);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(787, 43);
            this.btnModificar.TabIndex = 39;
            this.btnModificar.Text = "Modificar Vuelo";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // gbxEliminarViaje
            // 
            this.gbxEliminarViaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxEliminarViaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.gbxEliminarViaje.Controls.Add(this.btnEliminar);
            this.gbxEliminarViaje.Controls.Add(this.btnCerrarTres);
            this.gbxEliminarViaje.Controls.Add(this.lblListaPasajeros);
            this.gbxEliminarViaje.Controls.Add(this.cmbxViajes);
            this.gbxEliminarViaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxEliminarViaje.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEliminarViaje.ForeColor = System.Drawing.SystemColors.Control;
            this.gbxEliminarViaje.Location = new System.Drawing.Point(1054, 292);
            this.gbxEliminarViaje.Name = "gbxEliminarViaje";
            this.gbxEliminarViaje.Size = new System.Drawing.Size(860, 226);
            this.gbxEliminarViaje.TabIndex = 70;
            this.gbxEliminarViaje.TabStop = false;
            this.gbxEliminarViaje.Text = "Eliminar un Viaje";
            this.gbxEliminarViaje.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(8, 119);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(846, 36);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrarTres
            // 
            this.btnCerrarTres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCerrarTres.FlatAppearance.BorderSize = 0;
            this.btnCerrarTres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCerrarTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarTres.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarTres.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrarTres.Location = new System.Drawing.Point(8, 166);
            this.btnCerrarTres.Name = "btnCerrarTres";
            this.btnCerrarTres.Size = new System.Drawing.Size(846, 40);
            this.btnCerrarTres.TabIndex = 48;
            this.btnCerrarTres.Text = "Guardar y cerrar";
            this.btnCerrarTres.UseVisualStyleBackColor = false;
            this.btnCerrarTres.Click += new System.EventHandler(this.btnCerrarTres_Click);
            // 
            // lblListaPasajeros
            // 
            this.lblListaPasajeros.AutoSize = true;
            this.lblListaPasajeros.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaPasajeros.ForeColor = System.Drawing.SystemColors.Control;
            this.lblListaPasajeros.Location = new System.Drawing.Point(6, 24);
            this.lblListaPasajeros.Name = "lblListaPasajeros";
            this.lblListaPasajeros.Size = new System.Drawing.Size(194, 34);
            this.lblListaPasajeros.TabIndex = 39;
            this.lblListaPasajeros.Text = "Lista de Viajes:";
            // 
            // cmbxViajes
            // 
            this.cmbxViajes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxViajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxViajes.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxViajes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbxViajes.FormattingEnabled = true;
            this.cmbxViajes.Location = new System.Drawing.Point(206, 31);
            this.cmbxViajes.Name = "cmbxViajes";
            this.cmbxViajes.Size = new System.Drawing.Size(648, 23);
            this.cmbxViajes.TabIndex = 38;
            // 
            // dgvVuelos
            // 
            this.dgvVuelos.AllowUserToAddRows = false;
            this.dgvVuelos.AllowUserToDeleteRows = false;
            this.dgvVuelos.AllowUserToResizeRows = false;
            this.dgvVuelos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvVuelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVuelos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dgvVuelos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVuelos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelos.EnableHeadersVisualStyles = false;
            this.dgvVuelos.GridColor = System.Drawing.SystemColors.Control;
            this.dgvVuelos.Location = new System.Drawing.Point(1054, -419);
            this.dgvVuelos.MultiSelect = false;
            this.dgvVuelos.Name = "dgvVuelos";
            this.dgvVuelos.ReadOnly = true;
            this.dgvVuelos.RowHeadersVisible = false;
            this.dgvVuelos.Size = new System.Drawing.Size(1042, 439);
            this.dgvVuelos.TabIndex = 71;
            this.dgvVuelos.TabStop = false;
            this.dgvVuelos.VirtualMode = true;
            this.dgvVuelos.Visible = false;
            this.dgvVuelos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVuelos_CellFormatting);
            // 
            // CrudViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1064, 680);
            this.Controls.Add(this.dgvVuelos);
            this.Controls.Add(this.gbxEliminarViaje);
            this.Controls.Add(this.gbxModificarViaje);
            this.Controls.Add(this.gbxCrearViajes);
            this.Controls.Add(this.btnOpcionUno);
            this.Controls.Add(this.btnOpcionTres);
            this.Controls.Add(this.btnOpcionDos);
            this.Controls.Add(this.lbldentificador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrudViajes";
            this.Text = " ";
            this.gbxCrearViajes.ResumeLayout(false);
            this.gbxCrearViajes.PerformLayout();
            this.gbxModificarViaje.ResumeLayout(false);
            this.gbxModificarViaje.PerformLayout();
            this.gbxEliminarViaje.ResumeLayout(false);
            this.gbxEliminarViaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbldentificador;
        private System.Windows.Forms.Button btnOpcionUno;
        private System.Windows.Forms.Button btnOpcionTres;
        private System.Windows.Forms.Button btnOpcionDos;
        private System.Windows.Forms.GroupBox gbxCrearViajes;
        private System.Windows.Forms.Label lblAsientosTuristas;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnCerrarUno;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtCostoTurista;
        private System.Windows.Forms.Label lblCostoPremium;
        private System.Windows.Forms.TextBox txtCostoPremium;
        private System.Windows.Forms.Label lblCostoTurista;
        private System.Windows.Forms.Label Origen;
        private System.Windows.Forms.Button btnCrearAvion;
        private System.Windows.Forms.ComboBox cmbxOrigen;
        private System.Windows.Forms.ComboBox cmbxDestino;
        private System.Windows.Forms.DateTimePicker dtpFechaVuelo;
        private System.Windows.Forms.ComboBox cmbxMatriculaAviones;
        private System.Windows.Forms.Label lblAvion;
        private System.Windows.Forms.TextBox txtAsientosPremium;
        private System.Windows.Forms.Label lblAsientosPremium;
        private System.Windows.Forms.TextBox txtAsientosTuristas;
        private System.Windows.Forms.ComboBox cmbxTipoViaje;
        private System.Windows.Forms.Label lblTipoViaje;
        private System.Windows.Forms.GroupBox gbxModificarViaje;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbxListaVuelos;
        private System.Windows.Forms.ComboBox cmbxTipoViajeDos;
        private System.Windows.Forms.Label lblTipoViajeDos;
        private System.Windows.Forms.ComboBox cmbxMatriculaDos;
        private System.Windows.Forms.Label lblAvionDos;
        private System.Windows.Forms.DateTimePicker dtpFechaVueloDos;
        private System.Windows.Forms.ComboBox cmbxDestinoDos;
        private System.Windows.Forms.ComboBox cmbxOrigenDos;
        private System.Windows.Forms.Label LblFechaDos;
        private System.Windows.Forms.Button btnCerrarDos;
        private System.Windows.Forms.Label lblDestinoDos;
        private System.Windows.Forms.TextBox txtCostoTuristaDos;
        private System.Windows.Forms.Label lblCostoPremiumDos;
        private System.Windows.Forms.TextBox txtCostoPremiumDos;
        private System.Windows.Forms.Label lblCostoTuristaDos;
        private System.Windows.Forms.Label lblOrigenDos;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox gbxEliminarViaje;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrarTres;
        private System.Windows.Forms.Label lblListaPasajeros;
        private System.Windows.Forms.ComboBox cmbxViajes;
        private System.Windows.Forms.DataGridView dgvVuelos;
    }
}