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
            // ConsultarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1237, 847);
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
    }
}