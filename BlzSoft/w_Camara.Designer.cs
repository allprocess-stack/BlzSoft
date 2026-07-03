namespace BlzSoft
{
    partial class w_Camara
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblRtsp = new System.Windows.Forms.Label();
            this.lblRutaFotoEntrada = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtRtsp = new System.Windows.Forms.TextBox();
            this.txtRutaFotoEntrada = new System.Windows.Forms.TextBox();
            this.btnBrowseEntrada = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblRutaFotoSalida = new System.Windows.Forms.Label();
            this.txtRutaFotoSalida = new System.Windows.Forms.TextBox();
            this.btnBrowseFotoSalida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(30, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(30, 110);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(17, 13);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "IP";
            // 
            // lblRtsp
            // 
            this.lblRtsp.AutoSize = true;
            this.lblRtsp.Location = new System.Drawing.Point(30, 150);
            this.lblRtsp.Name = "lblRtsp";
            this.lblRtsp.Size = new System.Drawing.Size(36, 13);
            this.lblRtsp.TabIndex = 3;
            this.lblRtsp.Text = "RTSP";
            // 
            // lblRutaFotoEntrada
            // 
            this.lblRutaFotoEntrada.AutoSize = true;
            this.lblRutaFotoEntrada.Location = new System.Drawing.Point(30, 190);
            this.lblRutaFotoEntrada.Name = "lblRutaFotoEntrada";
            this.lblRutaFotoEntrada.Size = new System.Drawing.Size(94, 13);
            this.lblRutaFotoEntrada.TabIndex = 10;
            this.lblRutaFotoEntrada.Text = "Ruta Foto Entrada";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(143, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(270, 20);
            this.txtUser.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(143, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(270, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(143, 107);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(270, 20);
            this.txtIp.TabIndex = 6;
            // 
            // txtRtsp
            // 
            this.txtRtsp.Location = new System.Drawing.Point(143, 147);
            this.txtRtsp.Name = "txtRtsp";
            this.txtRtsp.Size = new System.Drawing.Size(270, 20);
            this.txtRtsp.TabIndex = 7;
            // 
            // txtRutaFotoEntrada
            // 
            this.txtRutaFotoEntrada.Location = new System.Drawing.Point(143, 187);
            this.txtRutaFotoEntrada.Name = "txtRutaFotoEntrada";
            this.txtRutaFotoEntrada.Size = new System.Drawing.Size(200, 20);
            this.txtRutaFotoEntrada.TabIndex = 11;
            // 
            // btnBrowseEntrada
            // 
            this.btnBrowseEntrada.Location = new System.Drawing.Point(349, 185);
            this.btnBrowseEntrada.Name = "btnBrowseEntrada";
            this.btnBrowseEntrada.Size = new System.Drawing.Size(64, 23);
            this.btnBrowseEntrada.TabIndex = 12;
            this.btnBrowseEntrada.Text = "Examinar";
            this.btnBrowseEntrada.UseVisualStyleBackColor = true;
            this.btnBrowseEntrada.Click += new System.EventHandler(this.btnBrowseEntrada_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Seleccione la carpeta para guardar las fotos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 282);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(243, 282);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 30);
            this.btnCargar.TabIndex = 9;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblRutaFotoSalida
            // 
            this.lblRutaFotoSalida.AutoSize = true;
            this.lblRutaFotoSalida.Location = new System.Drawing.Point(33, 236);
            this.lblRutaFotoSalida.Name = "lblRutaFotoSalida";
            this.lblRutaFotoSalida.Size = new System.Drawing.Size(86, 13);
            this.lblRutaFotoSalida.TabIndex = 13;
            this.lblRutaFotoSalida.Text = "Ruta Foto Salida";
            // 
            // txtRutaFotoSalida
            // 
            this.txtRutaFotoSalida.Location = new System.Drawing.Point(143, 236);
            this.txtRutaFotoSalida.Name = "txtRutaFotoSalida";
            this.txtRutaFotoSalida.Size = new System.Drawing.Size(200, 20);
            this.txtRutaFotoSalida.TabIndex = 14;
            // 
            // btnBrowseFotoSalida
            // 
            this.btnBrowseFotoSalida.Location = new System.Drawing.Point(349, 236);
            this.btnBrowseFotoSalida.Name = "btnBrowseFotoSalida";
            this.btnBrowseFotoSalida.Size = new System.Drawing.Size(64, 23);
            this.btnBrowseFotoSalida.TabIndex = 15;
            this.btnBrowseFotoSalida.Text = "Examinar";
            this.btnBrowseFotoSalida.UseVisualStyleBackColor = true;
            this.btnBrowseFotoSalida.Click += new System.EventHandler(this.btnBrowseFotoSalida_Click);
            // 
            // w_Camara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 324);
            this.Controls.Add(this.btnBrowseFotoSalida);
            this.Controls.Add(this.txtRutaFotoSalida);
            this.Controls.Add(this.lblRutaFotoSalida);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBrowseEntrada);
            this.Controls.Add(this.txtRutaFotoEntrada);
            this.Controls.Add(this.txtRtsp);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblRutaFotoEntrada);
            this.Controls.Add(this.lblRtsp);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Name = "w_Camara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Camara";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblRtsp;
        private System.Windows.Forms.Label lblRutaFotoEntrada;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtRtsp;
        private System.Windows.Forms.TextBox txtRutaFotoEntrada;
        private System.Windows.Forms.Button btnBrowseEntrada;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblRutaFotoSalida;
        private System.Windows.Forms.TextBox txtRutaFotoSalida;
        private System.Windows.Forms.Button btnBrowseFotoSalida;
    }
}
