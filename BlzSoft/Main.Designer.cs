namespace BlzSoft
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionBalanzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxSerial = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbrirCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.indicadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxIndicador = new System.Windows.Forms.ToolStripComboBox();
            this.conexionBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracionServidor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConexionCamra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.operadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plataformaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certificadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarifaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.formatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarConfiguracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despachosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anuladosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiaDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtSerialData = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusCom = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDataSerial = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.configuracionToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.informacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1158, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoREToolStripMenuItem,
            this.nuevoRSToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // nuevoREToolStripMenuItem
            // 
            this.nuevoREToolStripMenuItem.Name = "nuevoREToolStripMenuItem";
            this.nuevoREToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nuevoREToolStripMenuItem.Text = "Registro de entrada";
            this.nuevoREToolStripMenuItem.Click += new System.EventHandler(this.nuevoREToolStripMenuItem_Click);
            // 
            // nuevoRSToolStripMenuItem
            // 
            this.nuevoRSToolStripMenuItem.Name = "nuevoRSToolStripMenuItem";
            this.nuevoRSToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nuevoRSToolStripMenuItem.Text = "Registro de salida";
            this.nuevoRSToolStripMenuItem.Click += new System.EventHandler(this.nuevoRSToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexionBalanzaToolStripMenuItem,
            this.conexionBaseDeDatosToolStripMenuItem,
            this.btnConexionCamra,
            this.toolStripSeparator1,
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.toolStripSeparator2,
            this.operadorToolStripMenuItem,
            this.plataformaToolStripMenuItem,
            this.toolStripSeparator3,
            this.formatosToolStripMenuItem,
            this.toolStripSeparator4,
            this.guardarConfiguracionToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // conexionBalanzaToolStripMenuItem
            // 
            this.conexionBalanzaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.indicadorToolStripMenuItem});
            this.conexionBalanzaToolStripMenuItem.Name = "conexionBalanzaToolStripMenuItem";
            this.conexionBalanzaToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.conexionBalanzaToolStripMenuItem.Text = "Conexion balanza";
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxSerial,
            this.toolStripMenuItem2});
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.serialToolStripMenuItem.Text = "Serial";
            // 
            // toolStripComboBoxSerial
            // 
            this.toolStripComboBoxSerial.Name = "toolStripComboBoxSerial";
            this.toolStripComboBoxSerial.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxSerial.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSerial_SelectedIndexChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbrirCOM,
            this.menuCerrarCOM});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "Conexion";
            // 
            // menuAbrirCOM
            // 
            this.menuAbrirCOM.Name = "menuAbrirCOM";
            this.menuAbrirCOM.Size = new System.Drawing.Size(106, 22);
            this.menuAbrirCOM.Text = "Abrir";
            this.menuAbrirCOM.Click += new System.EventHandler(this.menuAbrirCOM_Click);
            // 
            // menuCerrarCOM
            // 
            this.menuCerrarCOM.Name = "menuCerrarCOM";
            this.menuCerrarCOM.Size = new System.Drawing.Size(106, 22);
            this.menuCerrarCOM.Text = "Cerrar";
            this.menuCerrarCOM.Click += new System.EventHandler(this.menuCerrarCOM_Click);
            // 
            // indicadorToolStripMenuItem
            // 
            this.indicadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxIndicador});
            this.indicadorToolStripMenuItem.Name = "indicadorToolStripMenuItem";
            this.indicadorToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.indicadorToolStripMenuItem.Text = "Indicador";
            // 
            // toolStripComboBoxIndicador
            // 
            this.toolStripComboBoxIndicador.Items.AddRange(new object[] {
            "TransCELL TI1520",
            "Flintec FT11",
            "Generic XKR",
            "Precia Molen"});
            this.toolStripComboBoxIndicador.Name = "toolStripComboBoxIndicador";
            this.toolStripComboBoxIndicador.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxIndicador.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxIndicador_SelectedIndexChanged);
            // 
            // conexionBaseDeDatosToolStripMenuItem
            // 
            this.conexionBaseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfiguracionServidor});
            this.conexionBaseDeDatosToolStripMenuItem.Name = "conexionBaseDeDatosToolStripMenuItem";
            this.conexionBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.conexionBaseDeDatosToolStripMenuItem.Text = "Conexion Base de datos";
            // 
            // menuConfiguracionServidor
            // 
            this.menuConfiguracionServidor.Enabled = false;
            this.menuConfiguracionServidor.Name = "menuConfiguracionServidor";
            this.menuConfiguracionServidor.Size = new System.Drawing.Size(211, 22);
            this.menuConfiguracionServidor.Text = "Configuracion de servidor";
            this.menuConfiguracionServidor.Click += new System.EventHandler(this.menuConfiguracionServidor_Click);
            // 
            // btnConexionCamra
            // 
            this.btnConexionCamra.Name = "btnConexionCamra";
            this.btnConexionCamra.Size = new System.Drawing.Size(237, 22);
            this.btnConexionCamra.Text = "Conexion camara";
            this.btnConexionCamra.Click += new System.EventHandler(this.btnConexionCamra_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.clientesToolStripMenuItem.Text = "Registro de Clientes/Proveedor";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // operadorToolStripMenuItem
            // 
            this.operadorToolStripMenuItem.Name = "operadorToolStripMenuItem";
            this.operadorToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.operadorToolStripMenuItem.Text = "Operador";
            this.operadorToolStripMenuItem.Click += new System.EventHandler(this.operadorToolStripMenuItem_Click);
            // 
            // plataformaToolStripMenuItem
            // 
            this.plataformaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.certificadoToolStripMenuItem,
            this.tarifaToolStripMenuItem});
            this.plataformaToolStripMenuItem.Enabled = false;
            this.plataformaToolStripMenuItem.Name = "plataformaToolStripMenuItem";
            this.plataformaToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.plataformaToolStripMenuItem.Text = "Plataforma";
            // 
            // certificadoToolStripMenuItem
            // 
            this.certificadoToolStripMenuItem.Name = "certificadoToolStripMenuItem";
            this.certificadoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.certificadoToolStripMenuItem.Text = "Certificado";
            // 
            // tarifaToolStripMenuItem
            // 
            this.tarifaToolStripMenuItem.Name = "tarifaToolStripMenuItem";
            this.tarifaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.tarifaToolStripMenuItem.Text = "Tarifa";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // formatosToolStripMenuItem
            // 
            this.formatosToolStripMenuItem.Name = "formatosToolStripMenuItem";
            this.formatosToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.formatosToolStripMenuItem.Text = "Formatos";
            this.formatosToolStripMenuItem.Click += new System.EventHandler(this.formatosToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // guardarConfiguracionToolStripMenuItem
            // 
            this.guardarConfiguracionToolStripMenuItem.Name = "guardarConfiguracionToolStripMenuItem";
            this.guardarConfiguracionToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.guardarConfiguracionToolStripMenuItem.Text = "Guardar Configuracion";
            this.guardarConfiguracionToolStripMenuItem.Click += new System.EventHandler(this.guardarConfiguracionToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despachosToolStripMenuItem,
            this.anuladosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // despachosToolStripMenuItem
            // 
            this.despachosToolStripMenuItem.Name = "despachosToolStripMenuItem";
            this.despachosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.despachosToolStripMenuItem.Text = "Registros despachos";
            this.despachosToolStripMenuItem.Click += new System.EventHandler(this.despachosToolStripMenuItem_Click);
            // 
            // anuladosToolStripMenuItem
            // 
            this.anuladosToolStripMenuItem.Enabled = false;
            this.anuladosToolStripMenuItem.Name = "anuladosToolStripMenuItem";
            this.anuladosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.anuladosToolStripMenuItem.Text = "Registros anulados";
            this.anuladosToolStripMenuItem.Click += new System.EventHandler(this.anuladosToolStripMenuItem_Click);
            // 
            // informacionToolStripMenuItem
            // 
            this.informacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guiaDeUsuarioToolStripMenuItem,
            this.acercaToolStripMenuItem});
            this.informacionToolStripMenuItem.Name = "informacionToolStripMenuItem";
            this.informacionToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.informacionToolStripMenuItem.Text = "Informacion";
            // 
            // guiaDeUsuarioToolStripMenuItem
            // 
            this.guiaDeUsuarioToolStripMenuItem.Enabled = false;
            this.guiaDeUsuarioToolStripMenuItem.Name = "guiaDeUsuarioToolStripMenuItem";
            this.guiaDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guiaDeUsuarioToolStripMenuItem.Text = "Guia de usuario";
            // 
            // acercaToolStripMenuItem
            // 
            this.acercaToolStripMenuItem.Name = "acercaToolStripMenuItem";
            this.acercaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.acercaToolStripMenuItem.Text = "Creditos";
            this.acercaToolStripMenuItem.Click += new System.EventHandler(this.acercaToolStripMenuItem_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ReceivedBytesThreshold = 64;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // txtSerialData
            // 
            this.txtSerialData.BackColor = System.Drawing.Color.GreenYellow;
            this.txtSerialData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialData.Location = new System.Drawing.Point(680, 280);
            this.txtSerialData.Name = "txtSerialData";
            this.txtSerialData.ReadOnly = true;
            this.txtSerialData.Size = new System.Drawing.Size(184, 38);
            this.txtSerialData.TabIndex = 2;
            this.txtSerialData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatusCom,
            this.lblStatusDataSerial});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1158, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 19);
            this.toolStripStatusLabel1.Text = "Conexion Balanza:";
            // 
            // lblStatusCom
            // 
            this.lblStatusCom.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatusCom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblStatusCom.ForeColor = System.Drawing.Color.Red;
            this.lblStatusCom.Name = "lblStatusCom";
            this.lblStatusCom.Size = new System.Drawing.Size(85, 19);
            this.lblStatusCom.Text = "desconectado";
            // 
            // lblStatusDataSerial
            // 
            this.lblStatusDataSerial.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatusDataSerial.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblStatusDataSerial.ForeColor = System.Drawing.Color.Red;
            this.lblStatusDataSerial.Name = "lblStatusDataSerial";
            this.lblStatusDataSerial.Size = new System.Drawing.Size(51, 19);
            this.lblStatusDataSerial.Text = "no data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(680, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "PESO BALANZA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTipo);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(888, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 144);
            this.panel1.TabIndex = 24;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Yellow;
            this.lblUser.Location = new System.Drawing.Point(71, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(39, 16);
            this.lblUser.TabIndex = 25;
            this.lblUser.Text = "Fred";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 146;
            this.label5.Text = "Tipo:";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTipo.Location = new System.Drawing.Point(71, 103);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(113, 20);
            this.txtTipo.TabIndex = 147;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtName.Location = new System.Drawing.Point(71, 72);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(112, 20);
            this.txtName.TabIndex = 146;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 16);
            this.label12.TabIndex = 145;
            this.label12.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "OPERADOR";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(658, 40);
            this.label6.TabIndex = 27;
            this.label6.Text = "VIA.PANAMERICANA SUR KM. 616 SEC. QUEBRADA TOTORAL LA AGUADITA\r\nCHALA - CARAVELI " +
    "- AREQUIPA ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(835, 68);
            this.label2.TabIndex = 29;
            this.label2.Text = "COMERSA INGENIERIA E.I.R.L.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BlzSoft.Properties.Resources.CAMION;
            this.pictureBox4.Location = new System.Drawing.Point(48, 256);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(584, 264);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(968, 480);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalida
            // 
            this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.Image = ((System.Drawing.Image)(resources.GetObject("btnSalida.Image")));
            this.btnSalida.Location = new System.Drawing.Point(896, 352);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(184, 88);
            this.btnSalida.TabIndex = 18;
            this.btnSalida.Text = "SEGUNDA PESADA";
            this.btnSalida.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrada.Image")));
            this.btnEntrada.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEntrada.Location = new System.Drawing.Point(680, 352);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(184, 88);
            this.btnEntrada.TabIndex = 11;
            this.btnEntrada.Text = "PRIMERA PESADA";
            this.btnEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1158, 609);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtSerialData);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BALANZA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoRSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionBalanzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despachosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anuladosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guiaDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSerial;
        private System.Windows.Forms.ToolStripMenuItem indicadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxIndicador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem operadorToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirCOM;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarCOM;
        private System.Windows.Forms.TextBox txtSerialData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCom;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDataSerial;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracionServidor;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem plataformaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certificadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarifaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem formatosToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem guardarConfiguracionToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem btnConexionCamra;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}