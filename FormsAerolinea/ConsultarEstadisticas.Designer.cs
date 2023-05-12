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
            this.dgvEstadisticas = new System.Windows.Forms.DataGridView();
            this.Recaudacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPasajeros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinoMasElegido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListaViajesRealizados = new System.Windows.Forms.Label();
            this.cmbxListaViajesRealizados = new System.Windows.Forms.ComboBox();
            this.lblTituloConsultar = new System.Windows.Forms.Label();
            this.lbldentificador = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnOpcionSeis = new System.Windows.Forms.Button();
            this.btnOpcionCuatro = new System.Windows.Forms.Button();
            this.btnOpcionCinco = new System.Windows.Forms.Button();
            this.btnOpcionTres = new System.Windows.Forms.Button();
            this.btnOpcionDos = new System.Windows.Forms.Button();
            this.btnOpcionUno = new System.Windows.Forms.Button();
            this.lblTituloMenu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstadisticas
            // 
            this.dgvEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadisticas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Recaudacion,
            this.CantidadPasajeros,
            this.DestinoMasElegido});
            this.dgvEstadisticas.Location = new System.Drawing.Point(342, 406);
            this.dgvEstadisticas.Name = "dgvEstadisticas";
            this.dgvEstadisticas.Size = new System.Drawing.Size(344, 58);
            this.dgvEstadisticas.TabIndex = 0;
            // 
            // Recaudacion
            // 
            this.Recaudacion.HeaderText = "Recaudacion";
            this.Recaudacion.Name = "Recaudacion";
            // 
            // CantidadPasajeros
            // 
            this.CantidadPasajeros.HeaderText = "Cantidad de Pasajeros";
            this.CantidadPasajeros.Name = "CantidadPasajeros";
            // 
            // DestinoMasElegido
            // 
            this.DestinoMasElegido.HeaderText = "Destino más elegido";
            this.DestinoMasElegido.Name = "DestinoMasElegido";
            // 
            // lblListaViajesRealizados
            // 
            this.lblListaViajesRealizados.AutoSize = true;
            this.lblListaViajesRealizados.Font = new System.Drawing.Font("Sitka Subheading", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaViajesRealizados.Location = new System.Drawing.Point(338, 338);
            this.lblListaViajesRealizados.Name = "lblListaViajesRealizados";
            this.lblListaViajesRealizados.Size = new System.Drawing.Size(348, 42);
            this.lblListaViajesRealizados.TabIndex = 3;
            this.lblListaViajesRealizados.Text = "Lista de viajes realizados:";
            // 
            // cmbxListaViajesRealizados
            // 
            this.cmbxListaViajesRealizados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbxListaViajesRealizados.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxListaViajesRealizados.Font = new System.Drawing.Font("Sitka Subheading", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxListaViajesRealizados.FormattingEnabled = true;
            this.cmbxListaViajesRealizados.Location = new System.Drawing.Point(711, 346);
            this.cmbxListaViajesRealizados.Name = "cmbxListaViajesRealizados";
            this.cmbxListaViajesRealizados.Size = new System.Drawing.Size(232, 29);
            this.cmbxListaViajesRealizados.TabIndex = 4;
            // 
            // lblTituloConsultar
            // 
            this.lblTituloConsultar.AutoSize = true;
            this.lblTituloConsultar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTituloConsultar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloConsultar.Font = new System.Drawing.Font("Sitka Subheading", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloConsultar.Location = new System.Drawing.Point(331, 245);
            this.lblTituloConsultar.Name = "lblTituloConsultar";
            this.lblTituloConsultar.Size = new System.Drawing.Size(622, 71);
            this.lblTituloConsultar.TabIndex = 5;
            this.lblTituloConsultar.Text = "CONSULTAR ESTADÍSTICAS";
            // 
            // lbldentificador
            // 
            this.lbldentificador.AutoSize = true;
            this.lbldentificador.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldentificador.Location = new System.Drawing.Point(939, 91);
            this.lbldentificador.Name = "lbldentificador";
            this.lbldentificador.Size = new System.Drawing.Size(14, 19);
            this.lbldentificador.TabIndex = 22;
            this.lbldentificador.Text = "-";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegresar.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(573, 492);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 40);
            this.btnRegresar.TabIndex = 39;
            this.btnRegresar.Text = "Regresar al menú anterior";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(936, 816);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(147, 38);
            this.btnCerrarSesion.TabIndex = 47;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // btnOpcionSeis
            // 
            this.btnOpcionSeis.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionSeis.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionSeis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionSeis.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionSeis.Location = new System.Drawing.Point(815, 758);
            this.btnOpcionSeis.Name = "btnOpcionSeis";
            this.btnOpcionSeis.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionSeis.TabIndex = 46;
            this.btnOpcionSeis.Text = "6. Crear, modificar y eliminar aeronaves.";
            this.btnOpcionSeis.UseVisualStyleBackColor = false;
            // 
            // btnOpcionCuatro
            // 
            this.btnOpcionCuatro.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCuatro.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCuatro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionCuatro.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionCuatro.Location = new System.Drawing.Point(815, 642);
            this.btnOpcionCuatro.Name = "btnOpcionCuatro";
            this.btnOpcionCuatro.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionCuatro.TabIndex = 45;
            this.btnOpcionCuatro.Text = "4. Crear, modificar y eliminar viajes.";
            this.btnOpcionCuatro.UseVisualStyleBackColor = false;
            // 
            // btnOpcionCinco
            // 
            this.btnOpcionCinco.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCinco.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCinco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionCinco.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionCinco.Location = new System.Drawing.Point(815, 700);
            this.btnOpcionCinco.Name = "btnOpcionCinco";
            this.btnOpcionCinco.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionCinco.TabIndex = 44;
            this.btnOpcionCinco.Text = "5. Crear, modificar y eliminar pasajeros.";
            this.btnOpcionCinco.UseVisualStyleBackColor = false;
            // 
            // btnOpcionTres
            // 
            this.btnOpcionTres.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionTres.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionTres.Location = new System.Drawing.Point(815, 584);
            this.btnOpcionTres.Name = "btnOpcionTres";
            this.btnOpcionTres.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionTres.TabIndex = 43;
            this.btnOpcionTres.Text = "3. Consultar estadísticas históricas.";
            this.btnOpcionTres.UseVisualStyleBackColor = false;
            // 
            // btnOpcionDos
            // 
            this.btnOpcionDos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionDos.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionDos.Location = new System.Drawing.Point(815, 526);
            this.btnOpcionDos.Name = "btnOpcionDos";
            this.btnOpcionDos.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionDos.TabIndex = 42;
            this.btnOpcionDos.Text = "2. Vender un viaje a un pasajero.";
            this.btnOpcionDos.UseVisualStyleBackColor = false;
            // 
            // btnOpcionUno
            // 
            this.btnOpcionUno.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionUno.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionUno.Location = new System.Drawing.Point(815, 468);
            this.btnOpcionUno.Name = "btnOpcionUno";
            this.btnOpcionUno.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionUno.TabIndex = 41;
            this.btnOpcionUno.Text = "1. Visualizar la lista de viajes disponibles.";
            this.btnOpcionUno.UseVisualStyleBackColor = false;
            // 
            // lblTituloMenu
            // 
            this.lblTituloMenu.AutoSize = true;
            this.lblTituloMenu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTituloMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloMenu.Font = new System.Drawing.Font("Sitka Subheading", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMenu.Location = new System.Drawing.Point(813, 393);
            this.lblTituloMenu.Name = "lblTituloMenu";
            this.lblTituloMenu.Size = new System.Drawing.Size(412, 71);
            this.lblTituloMenu.TabIndex = 40;
            this.lblTituloMenu.Text = "MENÚ PRINCIPAL";
            // 
            // ConsultarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1237, 847);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnOpcionSeis);
            this.Controls.Add(this.btnOpcionCuatro);
            this.Controls.Add(this.btnOpcionCinco);
            this.Controls.Add(this.btnOpcionTres);
            this.Controls.Add(this.btnOpcionDos);
            this.Controls.Add(this.btnOpcionUno);
            this.Controls.Add(this.lblTituloMenu);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lbldentificador);
            this.Controls.Add(this.lblTituloConsultar);
            this.Controls.Add(this.cmbxListaViajesRealizados);
            this.Controls.Add(this.lblListaViajesRealizados);
            this.Controls.Add(this.dgvEstadisticas);
            this.Name = "ConsultarEstadisticas";
            this.Text = "Consultar Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstadisticas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recaudacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPasajeros;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinoMasElegido;
        private System.Windows.Forms.Label lblListaViajesRealizados;
        private System.Windows.Forms.ComboBox cmbxListaViajesRealizados;
        private System.Windows.Forms.Label lblTituloConsultar;
        private System.Windows.Forms.Label lbldentificador;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnOpcionSeis;
        private System.Windows.Forms.Button btnOpcionCuatro;
        private System.Windows.Forms.Button btnOpcionCinco;
        private System.Windows.Forms.Button btnOpcionTres;
        private System.Windows.Forms.Button btnOpcionDos;
        private System.Windows.Forms.Button btnOpcionUno;
        private System.Windows.Forms.Label lblTituloMenu;
    }
}