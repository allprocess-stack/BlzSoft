namespace BlzSoft
{
    partial class wConsolidado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wConsolidado));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPlaca = new System.Windows.Forms.ComboBox();
            this.cboSub = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.optCliente = new System.Windows.Forms.RadioButton();
            this.optGeneral = new System.Windows.Forms.RadioButton();
            this.optEspecifica = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(968, 352);
            this.dataGridView1.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboPlaca);
            this.groupBox1.Controls.Add(this.cboSub);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Controls.Add(this.cboBusqueda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(520, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 152);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(243, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "Unidad (Placa):";
            // 
            // cboPlaca
            // 
            this.cboPlaca.FormattingEnabled = true;
            this.cboPlaca.Location = new System.Drawing.Point(339, 74);
            this.cboPlaca.Name = "cboPlaca";
            this.cboPlaca.Size = new System.Drawing.Size(112, 21);
            this.cboPlaca.TabIndex = 31;
            // 
            // cboSub
            // 
            this.cboSub.FormattingEnabled = true;
            this.cboSub.Items.AddRange(new object[] {
            "todos",
            "CLIENTE",
            "PROVEEDOR"});
            this.cboSub.Location = new System.Drawing.Point(339, 42);
            this.cboSub.Name = "cboSub";
            this.cboSub.Size = new System.Drawing.Size(112, 21);
            this.cboSub.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(243, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Sub tipo:";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(99, 74);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(120, 21);
            this.cboCliente.TabIndex = 28;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "todos",
            "EMPRESA",
            "PERSONA"});
            this.cboTipo.Location = new System.Drawing.Point(99, 42);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(120, 21);
            this.cboTipo.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Cliente :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tipo:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Location = new System.Drawing.Point(243, 106);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(208, 20);
            this.txtBusqueda.TabIndex = 6;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Items.AddRange(new object[] {
            "",
            "Ruc",
            "Cliente",
            "Chofer",
            "Usuario",
            "Guia",
            "Estado",
            "Modo"});
            this.cboBusqueda.Location = new System.Drawing.Point(99, 106);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(120, 21);
            this.cboBusqueda.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar por:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(184, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Especificar intervalo de tiempo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(184, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.Image")));
            this.btnBusqueda.Location = new System.Drawing.Point(24, 160);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(96, 48);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // optCliente
            // 
            this.optCliente.AutoSize = true;
            this.optCliente.Location = new System.Drawing.Point(24, 57);
            this.optCliente.Name = "optCliente";
            this.optCliente.Size = new System.Drawing.Size(126, 17);
            this.optCliente.TabIndex = 33;
            this.optCliente.Text = "Busqueda por Cliente";
            this.optCliente.UseVisualStyleBackColor = true;
            this.optCliente.CheckedChanged += new System.EventHandler(this.optCliente_CheckedChanged);
            // 
            // optGeneral
            // 
            this.optGeneral.AutoSize = true;
            this.optGeneral.Checked = true;
            this.optGeneral.Location = new System.Drawing.Point(24, 32);
            this.optGeneral.Name = "optGeneral";
            this.optGeneral.Size = new System.Drawing.Size(111, 17);
            this.optGeneral.TabIndex = 34;
            this.optGeneral.TabStop = true;
            this.optGeneral.Text = "Busqueda general";
            this.optGeneral.UseVisualStyleBackColor = true;
            this.optGeneral.CheckedChanged += new System.EventHandler(this.optGeneral_CheckedChanged);
            // 
            // optEspecifica
            // 
            this.optEspecifica.AutoSize = true;
            this.optEspecifica.Location = new System.Drawing.Point(24, 82);
            this.optEspecifica.Name = "optEspecifica";
            this.optEspecifica.Size = new System.Drawing.Size(125, 17);
            this.optEspecifica.TabIndex = 35;
            this.optEspecifica.Text = "Busqueda Especifica";
            this.optEspecifica.UseVisualStyleBackColor = true;
            this.optEspecifica.CheckedChanged += new System.EventHandler(this.optEspecifica_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.optEspecifica);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.optCliente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.optGeneral);
            this.groupBox2.Location = new System.Drawing.Point(24, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 120);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones de Busqueda";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(240, 80);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 37;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(240, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // btnReportar
            // 
            this.btnReportar.Image = ((System.Drawing.Image)(resources.GetObject("btnReportar.Image")));
            this.btnReportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportar.Location = new System.Drawing.Point(152, 160);
            this.btnReportar.Name = "btnReportar";
            this.btnReportar.Size = new System.Drawing.Size(96, 48);
            this.btnReportar.TabIndex = 26;
            this.btnReportar.Text = "Reportar";
            this.btnReportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportar.UseVisualStyleBackColor = true;
            this.btnReportar.Click += new System.EventHandler(this.btnReportar_Click);
            // 
            // wConsolidado
            // 
            this.AcceptButton = this.btnBusqueda;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1017, 603);
            this.Controls.Add(this.btnReportar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wConsolidado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRO CONSOLIDADO DE DESPACHOS";
            this.Load += new System.EventHandler(this.wConsolidado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSub;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPlaca;
        private System.Windows.Forms.RadioButton optGeneral;
        private System.Windows.Forms.RadioButton optCliente;
        private System.Windows.Forms.RadioButton optEspecifica;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReportar;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}