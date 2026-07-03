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
    public partial class w_clienteDel : Form
    {
        int ID;

        public w_clienteDel(int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void w_clienteDel_Load(object sender, EventArgs e)
        {
            Empresa p = new Empresa();
            p = BDempresas.InfoEmpresa(ID);

            //agrega en controles datos de empresa
            this.textBox1.Text = p.id.ToString();
            this.textBox2.Text = p.empresa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check = BDempresas.DeleteEmpresa(ID);

            if (check > 0)
            { MessageBox.Show("Se ha eliminado registro de informacion de cliente", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { MessageBox.Show("No se pudo eliminar datos", "Eiminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
