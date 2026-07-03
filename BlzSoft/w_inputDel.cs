using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlzSoft
{
    public partial class w_inputDel : Form
    {
        int ID;

        public w_inputDel(int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void w_inputDel_Load(object sender, EventArgs e)
        {
            Registro RE = new Registro();
            RE = BDregistros.Info(ID);

            //agrega en controles datos de empresa
            this.textBox1.Text = RE.Guia;
            this.textBox2.Text = RE.Placa;
            this.textBox3.Text = RE.Cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check = BDregistros.Delete(ID);

            if (check > 0)
            { MessageBox.Show("Se ha eliminado registro de Entrada", "Registros de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { MessageBox.Show("No se pudo eliminar Registro de Entrada", "Registros de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

 
 
          
