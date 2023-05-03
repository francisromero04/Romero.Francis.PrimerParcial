namespace FormsAerolinea
{
    partial class CroodAeronaves
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
            this.gbxModificarAvion = new System.Windows.Forms.GroupBox();
            this.txtBodega = new System.Windows.Forms.TextBox();
            this.lblBodega = new System.Windows.Forms.Label();
            this.chkComida = new System.Windows.Forms.CheckBox();
            this.chkWifi = new System.Windows.Forms.CheckBox();
            this.lblListaViajes = new System.Windows.Forms.Label();
            this.cmbxAviones = new System.Windows.Forms.ComboBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblCantAsientos = new System.Windows.Forms.Label();
            this.txtCantAsientos = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblCantBaños = new System.Windows.Forms.Label();
            this.txtCantBaños = new System.Windows.Forms.TextBox();
            this.btnOpcionTres = new System.Windows.Forms.Button();
            this.btnOpcionDos = new System.Windows.Forms.Button();
            this.btnOpcionUno = new System.Windows.Forms.Button();
            this.lblTituloCroodAviones = new System.Windows.Forms.Label();
            this.lbldentificador = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lstAviones = new System.Windows.Forms.ListBox();
            this.txtIngresar = new System.Windows.Forms.TextBox();
            this.lblIngresar = new System.Windows.Forms.Label();
            this.gbxCrearAvion = new System.Windows.Forms.GroupBox();
            this.gbxModificarAvion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxModificarAvion
            // 
            this.gbxModificarAvion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbxModificarAvion.Controls.Add(this.txtBodega);
            this.gbxModificarAvion.Controls.Add(this.lblBodega);
            this.gbxModificarAvion.Controls.Add(this.chkComida);
            this.gbxModificarAvion.Controls.Add(this.chkWifi);
            this.gbxModificarAvion.Controls.Add(this.lblListaViajes);
            this.gbxModificarAvion.Controls.Add(this.cmbxAviones);
            this.gbxModificarAvion.Controls.Add(this.txtMatricula);
            this.gbxModificarAvion.Controls.Add(this.lblCantAsientos);
            this.gbxModificarAvion.Controls.Add(this.txtCantAsientos);
            this.gbxModificarAvion.Controls.Add(this.lblMatricula);
            this.gbxModificarAvion.Controls.Add(this.lblCantBaños);
            this.gbxModificarAvion.Controls.Add(this.txtCantBaños);
            this.gbxModificarAvion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxModificarAvion.Font = new System.Drawing.Font("Sitka Subheading", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxModificarAvion.Location = new System.Drawing.Point(461, 303);
            this.gbxModificarAvion.Name = "gbxModificarAvion";
            this.gbxModificarAvion.Size = new System.Drawing.Size(367, 212);
            this.gbxModificarAvion.TabIndex = 34;
            this.gbxModificarAvion.TabStop = false;
            this.gbxModificarAvion.Text = "Modificar un avión";
            // 
            // txtBodega
            // 
            this.txtBodega.Location = new System.Drawing.Point(130, 133);
            this.txtBodega.Name = "txtBodega";
            this.txtBodega.Size = new System.Drawing.Size(99, 21);
            this.txtBodega.TabIndex = 49;
            // 
            // lblBodega
            // 
            this.lblBodega.AutoSize = true;
            this.lblBodega.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBodega.Location = new System.Drawing.Point(10, 135);
            this.lblBodega.Name = "lblBodega";
            this.lblBodega.Size = new System.Drawing.Size(111, 19);
            this.lblBodega.TabIndex = 48;
            this.lblBodega.Text = "CapacidadBodega";
            // 
            // chkComida
            // 
            this.chkComida.AutoSize = true;
            this.chkComida.Location = new System.Drawing.Point(6, 176);
            this.chkComida.Name = "chkComida";
            this.chkComida.Size = new System.Drawing.Size(160, 20);
            this.chkComida.TabIndex = 47;
            this.chkComida.Text = "¿Tiene servicio de comidas?";
            this.chkComida.UseVisualStyleBackColor = true;
            // 
            // chkWifi
            // 
            this.chkWifi.AutoSize = true;
            this.chkWifi.Location = new System.Drawing.Point(202, 176);
            this.chkWifi.Name = "chkWifi";
            this.chkWifi.Size = new System.Drawing.Size(159, 20);
            this.chkWifi.TabIndex = 46;
            this.chkWifi.Text = "¿Tiene servicio de Internet?";
            this.chkWifi.UseVisualStyleBackColor = true;
            // 
            // lblListaViajes
            // 
            this.lblListaViajes.AutoSize = true;
            this.lblListaViajes.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F);
            this.lblListaViajes.Location = new System.Drawing.Point(4, 22);
            this.lblListaViajes.Name = "lblListaViajes";
            this.lblListaViajes.Size = new System.Drawing.Size(242, 19);
            this.lblListaViajes.TabIndex = 39;
            this.lblListaViajes.Text = "Lista de aviones disponibles a modificar:";
            // 
            // cmbxAviones
            // 
            this.cmbxAviones.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbxAviones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbxAviones.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAviones.FormattingEnabled = true;
            this.cmbxAviones.Location = new System.Drawing.Point(258, 18);
            this.cmbxAviones.Name = "cmbxAviones";
            this.cmbxAviones.Size = new System.Drawing.Size(103, 27);
            this.cmbxAviones.TabIndex = 38;
            this.cmbxAviones.SelectedIndexChanged += new System.EventHandler(this.cmbxAviones_SelectedIndexChanged);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(130, 54);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(99, 21);
            this.txtMatricula.TabIndex = 45;
            // 
            // lblCantAsientos
            // 
            this.lblCantAsientos.AutoSize = true;
            this.lblCantAsientos.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantAsientos.Location = new System.Drawing.Point(8, 82);
            this.lblCantAsientos.Name = "lblCantAsientos";
            this.lblCantAsientos.Size = new System.Drawing.Size(113, 19);
            this.lblCantAsientos.TabIndex = 40;
            this.lblCantAsientos.Text = "Cantidad Asientos";
            // 
            // txtCantAsientos
            // 
            this.txtCantAsientos.Location = new System.Drawing.Point(130, 80);
            this.txtCantAsientos.Name = "txtCantAsientos";
            this.txtCantAsientos.Size = new System.Drawing.Size(99, 21);
            this.txtCantAsientos.TabIndex = 41;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(8, 56);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(66, 19);
            this.lblMatricula.TabIndex = 44;
            this.lblMatricula.Text = "Matricula";
            // 
            // lblCantBaños
            // 
            this.lblCantBaños.AutoSize = true;
            this.lblCantBaños.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantBaños.Location = new System.Drawing.Point(8, 108);
            this.lblCantBaños.Name = "lblCantBaños";
            this.lblCantBaños.Size = new System.Drawing.Size(99, 19);
            this.lblCantBaños.TabIndex = 42;
            this.lblCantBaños.Text = "Cantidad Baños";
            // 
            // txtCantBaños
            // 
            this.txtCantBaños.Location = new System.Drawing.Point(130, 106);
            this.txtCantBaños.Name = "txtCantBaños";
            this.txtCantBaños.Size = new System.Drawing.Size(99, 21);
            this.txtCantBaños.TabIndex = 43;
            // 
            // btnOpcionTres
            // 
            this.btnOpcionTres.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionTres.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionTres.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionTres.Location = new System.Drawing.Point(741, 257);
            this.btnOpcionTres.Name = "btnOpcionTres";
            this.btnOpcionTres.Size = new System.Drawing.Size(234, 40);
            this.btnOpcionTres.TabIndex = 32;
            this.btnOpcionTres.Text = "3. Eliminar un avión.";
            this.btnOpcionTres.UseVisualStyleBackColor = false;
            this.btnOpcionTres.Click += new System.EventHandler(this.btnOpcionTres_Click);
            // 
            // btnOpcionDos
            // 
            this.btnOpcionDos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionDos.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionDos.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionDos.Location = new System.Drawing.Point(512, 257);
            this.btnOpcionDos.Name = "btnOpcionDos";
            this.btnOpcionDos.Size = new System.Drawing.Size(223, 40);
            this.btnOpcionDos.TabIndex = 31;
            this.btnOpcionDos.Text = "2. Modificar un avión.";
            this.btnOpcionDos.UseVisualStyleBackColor = false;
            this.btnOpcionDos.Click += new System.EventHandler(this.btnOpcionDos_Click);
            // 
            // btnOpcionUno
            // 
            this.btnOpcionUno.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpcionUno.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionUno.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionUno.Location = new System.Drawing.Point(281, 257);
            this.btnOpcionUno.Name = "btnOpcionUno";
            this.btnOpcionUno.Size = new System.Drawing.Size(225, 40);
            this.btnOpcionUno.TabIndex = 30;
            this.btnOpcionUno.Text = "1. Crear un avión.";
            this.btnOpcionUno.UseVisualStyleBackColor = false;
            this.btnOpcionUno.Click += new System.EventHandler(this.btnOpcionUno_Click);
            // 
            // lblTituloCroodAviones
            // 
            this.lblTituloCroodAviones.AutoSize = true;
            this.lblTituloCroodAviones.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTituloCroodAviones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloCroodAviones.Font = new System.Drawing.Font("Sitka Subheading", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCroodAviones.Location = new System.Drawing.Point(281, 174);
            this.lblTituloCroodAviones.Name = "lblTituloCroodAviones";
            this.lblTituloCroodAviones.Size = new System.Drawing.Size(694, 70);
            this.lblTituloCroodAviones.TabIndex = 29;
            this.lblTituloCroodAviones.Text = "ADMINISTRACIÓN DE AVIONES";
            // 
            // lbldentificador
            // 
            this.lbldentificador.AutoSize = true;
            this.lbldentificador.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldentificador.Location = new System.Drawing.Point(961, 51);
            this.lbldentificador.Name = "lbldentificador";
            this.lbldentificador.Size = new System.Drawing.Size(14, 19);
            this.lbldentificador.TabIndex = 35;
            this.lbldentificador.Text = "-";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegresar.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(547, 538);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(188, 38);
            this.btnRegresar.TabIndex = 36;
            this.btnRegresar.Text = "Regresar al menú anterior";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lstAviones
            // 
            this.lstAviones.FormattingEnabled = true;
            this.lstAviones.Location = new System.Drawing.Point(865, 303);
            this.lstAviones.Name = "lstAviones";
            this.lstAviones.Size = new System.Drawing.Size(208, 173);
            this.lstAviones.TabIndex = 37;
            // 
            // txtIngresar
            // 
            this.txtIngresar.Location = new System.Drawing.Point(925, 495);
            this.txtIngresar.Name = "txtIngresar";
            this.txtIngresar.Size = new System.Drawing.Size(100, 20);
            this.txtIngresar.TabIndex = 38;
            // 
            // lblIngresar
            // 
            this.lblIngresar.AutoSize = true;
            this.lblIngresar.Location = new System.Drawing.Point(881, 479);
            this.lblIngresar.Name = "lblIngresar";
            this.lblIngresar.Size = new System.Drawing.Size(192, 13);
            this.lblIngresar.TabIndex = 39;
            this.lblIngresar.Text = "Ingrese la matricula que desea eliminar:";
            // 
            // gbxCrearAvion
            // 
            this.gbxCrearAvion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gbxCrearAvion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxCrearAvion.Font = new System.Drawing.Font("Sitka Subheading", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCrearAvion.Location = new System.Drawing.Point(161, 303);
            this.gbxCrearAvion.Name = "gbxCrearAvion";
            this.gbxCrearAvion.Size = new System.Drawing.Size(280, 171);
            this.gbxCrearAvion.TabIndex = 33;
            this.gbxCrearAvion.TabStop = false;
            this.gbxCrearAvion.Text = "Crear un Avión";
            // 
            // CroodAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1235, 845);
            this.Controls.Add(this.lblIngresar);
            this.Controls.Add(this.txtIngresar);
            this.Controls.Add(this.lstAviones);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lbldentificador);
            this.Controls.Add(this.gbxModificarAvion);
            this.Controls.Add(this.gbxCrearAvion);
            this.Controls.Add(this.btnOpcionTres);
            this.Controls.Add(this.btnOpcionDos);
            this.Controls.Add(this.btnOpcionUno);
            this.Controls.Add(this.lblTituloCroodAviones);
            this.Name = "CroodAeronaves";
            this.Text = "Administrador Aeronaves";
            this.gbxModificarAvion.ResumeLayout(false);
            this.gbxModificarAvion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxModificarAvion;
        private System.Windows.Forms.Label lblListaViajes;
        private System.Windows.Forms.ComboBox cmbxAviones;
        private System.Windows.Forms.Button btnOpcionTres;
        private System.Windows.Forms.Button btnOpcionDos;
        private System.Windows.Forms.Button btnOpcionUno;
        private System.Windows.Forms.Label lblTituloCroodAviones;
        private System.Windows.Forms.Label lbldentificador;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ListBox lstAviones;
        private System.Windows.Forms.TextBox txtIngresar;
        private System.Windows.Forms.Label lblIngresar;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblCantAsientos;
        private System.Windows.Forms.TextBox txtCantAsientos;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblCantBaños;
        private System.Windows.Forms.TextBox txtCantBaños;
        private System.Windows.Forms.CheckBox chkWifi;
        private System.Windows.Forms.TextBox txtBodega;
        private System.Windows.Forms.Label lblBodega;
        private System.Windows.Forms.GroupBox gbxCrearAvion;
        private System.Windows.Forms.CheckBox chkComida;
    }
}