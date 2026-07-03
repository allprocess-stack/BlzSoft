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
    public partial class w_operadorAdd : Form
    {
        public w_operadorAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] text = new string[4];

            if (txtName.Text.Trim() == "")
            { MessageBox.Show("Debe insertar el nombre de Usuario");return; }
            if (txtUser.Text.Trim() == "")
            { MessageBox.Show("Debe insertar el Login de Usuario"); return; }
            if (txtPassword.Text.Trim() == "")
            { MessageBox.Show("Debe ingresar su password"); return; }

            text[0] = txtName.Text;
            text[1] = txtUser.Text;
            text[2] = txtPassword.Text;
            text[3] = comboBox1.Text;

            int check = BDuser.Add(text);
            if (check > 0)
            {
                MessageBox.Show("Usuario creado correctamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            { MessageBox.Show("No se pudo Crear Usuario", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void w_operadorAdd_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
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
