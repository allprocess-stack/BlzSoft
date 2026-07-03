using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BlzSoft
{
    public partial class wConnectionBD : Form
    {
        public wConnectionBD()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //agrega a configuracion de servidor
            ConnFile.SERVIDOR = this.textBox1.Text;
            ConnFile.BD = this.textBox2.Text;
            ConnFile.userAccess = this.textBox3.Text;
            ConnFile.password = this.textBox4.Text;

            int key = ConnFile.Save();
            if (key == 2)
            { MessageBox.Show("error al guardar archivo de configuracion"); }
            else
            { MessageBox.Show("Configuracion guardada con exito, ruta de acceso: " + Application.StartupPath, "Configuracion de base de datos"); }

            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                ConnFile.Load();
                conn.ConnectionString =
                "Data Source= " + this.textBox1.Text +               //nombre de servidor
                ";Initial Catalog=" + this.textBox2.Text +           //nombre de la base de datos
                ";User Id=" + this.textBox3.Text +                                    //";Integrated Security=True;" cuando no se usa contraseña                 
                ";Password=" + this.textBox4.Text + ";";
                conn.Open();
                MessageBox.Show("Conexion exitosa", "Test de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se puede establecer conexion", "Test de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void wConnectionBD_Load(object sender, EventArgs e)
        {
            //rellena al inicio textboxes
            this.textBox1.Text = ConnFile.SERVIDOR;
            this.textBox2.Text = ConnFile.BD;
            this.textBox3.Text = ConnFile.userAccess;
            this.textBox4.Text = ConnFile.password;
            this.textBox5.Text = Application.StartupPath + "\\" + "CfgBalanza";
        }
    }
}
