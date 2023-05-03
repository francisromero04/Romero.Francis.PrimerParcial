namespace FormsAerolinea
{
    partial class MenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.lblTituloMenu = new System.Windows.Forms.Label();
            this.btnOpcionCinco = new System.Windows.Forms.Button();
            this.btnOpcionTres = new System.Windows.Forms.Button();
            this.btnOpcionDos = new System.Windows.Forms.Button();
            this.btnOpcionUno = new System.Windows.Forms.Button();
            this.btnOpcionCuatro = new System.Windows.Forms.Button();
            this.btnOpcionSeis = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lbldentificador = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTituloMenu
            // 
            this.lblTituloMenu.AutoSize = true;
            this.lblTituloMenu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTituloMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloMenu.Font = new System.Drawing.Font("Sitka Subheading", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMenu.Location = new System.Drawing.Point(438, 153);
            this.lblTituloMenu.Name = "lblTituloMenu";
            this.lblTituloMenu.Size = new System.Drawing.Size(412, 71);
            this.lblTituloMenu.TabIndex = 3;
            this.lblTituloMenu.Text = "MENÚ PRINCIPAL";
            // 
            // btnOpcionCinco
            // 
            this.btnOpcionCinco.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCinco.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCinco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionCinco.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionCinco.Location = new System.Drawing.Point(440, 460);
            this.btnOpcionCinco.Name = "btnOpcionCinco";
            this.btnOpcionCinco.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionCinco.TabIndex = 17;
            this.btnOpcionCinco.Text = "5. Crear, modificar y eliminar pasajeros.";
            this.btnOpcionCinco.UseVisualStyleBackColor = false;
            this.btnOpcionCinco.Click += new System.EventHandler(this.btnOpcionCinco_Click);
            // 
            // btnOpcionTres
            // 
            this.btnOpcionTres.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionTres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionTres.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionTres.Location = new System.Drawing.Point(440, 344);
            this.btnOpcionTres.Name = "btnOpcionTres";
            this.btnOpcionTres.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionTres.TabIndex = 16;
            this.btnOpcionTres.Text = "3. Consultar estadísticas históricas.";
            this.btnOpcionTres.UseVisualStyleBackColor = false;
            this.btnOpcionTres.Click += new System.EventHandler(this.btnOpcionTres_Click);
            // 
            // btnOpcionDos
            // 
            this.btnOpcionDos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionDos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionDos.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionDos.Location = new System.Drawing.Point(440, 286);
            this.btnOpcionDos.Name = "btnOpcionDos";
            this.btnOpcionDos.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionDos.TabIndex = 15;
            this.btnOpcionDos.Text = "2. Vender un viaje a un pasajero.";
            this.btnOpcionDos.UseVisualStyleBackColor = false;
            this.btnOpcionDos.Click += new System.EventHandler(this.btnOpcionDos_Click);
            // 
            // btnOpcionUno
            // 
            this.btnOpcionUno.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionUno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionUno.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionUno.Location = new System.Drawing.Point(440, 228);
            this.btnOpcionUno.Name = "btnOpcionUno";
            this.btnOpcionUno.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionUno.TabIndex = 14;
            this.btnOpcionUno.Text = "1. Visualizar la lista de viajes disponibles.";
            this.btnOpcionUno.UseVisualStyleBackColor = false;
            this.btnOpcionUno.Click += new System.EventHandler(this.btnOpcionUno_Click);
            // 
            // btnOpcionCuatro
            // 
            this.btnOpcionCuatro.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCuatro.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionCuatro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionCuatro.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionCuatro.Location = new System.Drawing.Point(440, 402);
            this.btnOpcionCuatro.Name = "btnOpcionCuatro";
            this.btnOpcionCuatro.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionCuatro.TabIndex = 18;
            this.btnOpcionCuatro.Text = "4. Crear, modificar y eliminar viajes.";
            this.btnOpcionCuatro.UseVisualStyleBackColor = false;
            this.btnOpcionCuatro.Click += new System.EventHandler(this.btnOpcionCuatro_Click);
            // 
            // btnOpcionSeis
            // 
            this.btnOpcionSeis.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionSeis.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOpcionSeis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpcionSeis.Font = new System.Drawing.Font("Sitka Subheading", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcionSeis.Location = new System.Drawing.Point(440, 518);
            this.btnOpcionSeis.Name = "btnOpcionSeis";
            this.btnOpcionSeis.Size = new System.Drawing.Size(407, 52);
            this.btnOpcionSeis.TabIndex = 19;
            this.btnOpcionSeis.Text = "6. Crear, modificar y eliminar aeronaves.";
            this.btnOpcionSeis.UseVisualStyleBackColor = false;
            this.btnOpcionSeis.Click += new System.EventHandler(this.btnOpcionSeis_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(561, 576);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(147, 38);
            this.btnCerrarSesion.TabIndex = 20;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lbldentificador
            // 
            this.lbldentificador.AutoSize = true;
            this.lbldentificador.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldentificador.Location = new System.Drawing.Point(981, 48);
            this.lbldentificador.Name = "lbldentificador";
            this.lbldentificador.Size = new System.Drawing.Size(14, 19);
            this.lbldentificador.TabIndex = 21;
            this.lbldentificador.Text = "-";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1241, 845);
            this.Controls.Add(this.lbldentificador);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnOpcionSeis);
            this.Controls.Add(this.btnOpcionCuatro);
            this.Controls.Add(this.btnOpcionCinco);
            this.Controls.Add(this.btnOpcionTres);
            this.Controls.Add(this.btnOpcionDos);
            this.Controls.Add(this.btnOpcionUno);
            this.Controls.Add(this.lblTituloMenu);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloMenu;
        private System.Windows.Forms.Button btnOpcionCinco;
        private System.Windows.Forms.Button btnOpcionTres;
        private System.Windows.Forms.Button btnOpcionDos;
        private System.Windows.Forms.Button btnOpcionUno;
        private System.Windows.Forms.Button btnOpcionCuatro;
        private System.Windows.Forms.Button btnOpcionSeis;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lbldentificador;
        private System.Windows.Forms.Timer timer1;
    }
}