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
    public partial class w_operadorMod : Form
    {
        int ID;
        public w_operadorMod(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void w_operadorMod_Load(object sender, EventArgs e)
        {
            Usuario p = new Usuario();
            p = BDuser.Info(ID);

            //agrega en controles datos de empresa
            txtName.Text = p.nombre;
            txtUser.Text = p.user;
            txtPassword.Text = p.password;
            comboBox1.Text = p.tipo;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] text = new string[4];

            if (txtName.Text.Trim() == "")
            { MessageBox.Show("Debe insertar el nombre de Usuario"); return; }
            if (txtUser.Text.Trim() == "")
            { MessageBox.Show("Debe insertar el Login de Usuario"); return; }
            if (txtPassword.Text.Trim() == "")
            { MessageBox.Show("Debe ingresar su password"); return; }

            text[0] = txtName.Text;
            text[1] = txtUser.Text;
            text[2] = txtPassword.Text;
            text[3] = comboBox1.Text;

            int check = BDuser.Mod(ID,text);
            if (check > 0)
            {
                MessageBox.Show("Usuario modificado correctamente", "Modificacion de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            { MessageBox.Show("No se pudo modificar datos de Usuario", "Modificacion de usuario Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
