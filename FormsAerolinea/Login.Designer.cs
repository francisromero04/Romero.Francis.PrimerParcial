namespace FormsAerolinea
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.barraVertical = new System.Windows.Forms.Panel();
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizarPestaña = new System.Windows.Forms.PictureBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnCerrarPestaña = new System.Windows.Forms.PictureBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.barraVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarPestaña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarPestaña)).BeginInit();
            this.SuspendLayout();
            // 
            // barraVertical
            // 
            this.barraVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.barraVertical.Controls.Add(this.pbxLogin);
            this.barraVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.barraVertical.Location = new System.Drawing.Point(0, 0);
            this.barraVertical.Name = "barraVertical";
            this.barraVertical.Size = new System.Drawing.Size(279, 330);
            this.barraVertical.TabIndex = 7;
            this.barraVertical.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraVertical_MouseDown);
            // 
            // pbxLogin
            // 
            this.pbxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pbxLogin.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogin.Image")));
            this.pbxLogin.Location = new System.Drawing.Point(12, 64);
            this.pbxLogin.Name = "pbxLogin";
            this.pbxLogin.Size = new System.Drawing.Size(234, 164);
            this.pbxLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogin.TabIndex = 0;
            this.pbxLogin.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelContenedor.Controls.Add(this.linkLabel1);
            this.panelContenedor.Controls.Add(this.lblTitulo);
            this.panelContenedor.Controls.Add(this.btnMinimizarPestaña);
            this.panelContenedor.Controls.Add(this.btnIniciarSesion);
            this.panelContenedor.Controls.Add(this.txtContraseña);
            this.panelContenedor.Controls.Add(this.btnCerrarPestaña);
            this.panelContenedor.Controls.Add(this.txtCorreo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(279, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(501, 330);
            this.panelContenedor.TabIndex = 8;
            this.panelContenedor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelContenedor_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(181, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(114, 36);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "LOGIN";
            // 
            // btnMinimizarPestaña
            // 
            this.btnMinimizarPestaña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizarPestaña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizarPestaña.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizarPestaña.Image")));
            this.btnMinimizarPestaña.Location = new System.Drawing.Point(453, 12);
            this.btnMinimizarPestaña.Name = "btnMinimizarPestaña";
            this.btnMinimizarPestaña.Size = new System.Drawing.Size(15, 15);
            this.btnMinimizarPestaña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizarPestaña.TabIndex = 2;
            this.btnMinimizarPestaña.TabStop = false;
            this.btnMinimizarPestaña.Click += new System.EventHandler(this.btnMinimizarPestaña_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnIniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.LightGray;
            this.btnIniciarSesion.Location = new System.Drawing.Point(52, 253);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(408, 40);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "ACCEDER";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txtContraseña.Location = new System.Drawing.Point(52, 155);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(142, 19);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.Text = "CONTRASEÑA";
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // btnCerrarPestaña
            // 
            this.btnCerrarPestaña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarPestaña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarPestaña.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarPestaña.Image")));
            this.btnCerrarPestaña.Location = new System.Drawing.Point(474, 12);
            this.btnCerrarPestaña.Name = "btnCerrarPestaña";
            this.btnCerrarPestaña.Size = new System.Drawing.Size(15, 15);
            this.btnCerrarPestaña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrarPestaña.TabIndex = 0;
            this.btnCerrarPestaña.TabStop = false;
            this.btnCerrarPestaña.Click += new System.EventHandler(this.btnCerrarPestaña_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(52, 113);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(345, 19);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.Text = "USUARIO";
            this.txtCorreo.Enter += new System.EventHandler(this.txtCorreo_Enter);
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.linkLabel1.Location = new System.Drawing.Point(184, 296);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(10, 15);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = ".";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(780, 330);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.barraVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.barraVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarPestaña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarPestaña)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel barraVertical;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnMinimizarPestaña;
        private System.Windows.Forms.PictureBox btnCerrarPestaña;
        private System.Windows.Forms.PictureBox pbxLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

