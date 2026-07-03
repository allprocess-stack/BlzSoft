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
    public partial class wOperadores : Form
    {
        public List<Usuario> listaUsuarios;

        public wOperadores()
        {
            InitializeComponent();
        }

        private void wOperadores_Load(object sender, EventArgs e)
        {
            listaUsuarios = BDuser.Buscar();
            dataGridView1.DataSource = listaUsuarios;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[3].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new w_operadorAdd().ShowDialog();
            dataGridView1.DataSource = BDuser.Buscar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_operadorMod(Id).ShowDialog();
                dataGridView1.DataSource = BDuser.Buscar();
            }
            else
            {
                MessageBox.Show("no se ha seleccionado ningun usuario");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar Operador?", "ELIMINAR USUARIO", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int check = BDuser.Delete(Id);

                    if (check == 0)
                    { MessageBox.Show("No se pudo eliminar usuario registrado", "ELiminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { dataGridView1.DataSource = BDuser.Buscar(); }
                }

            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun operador");
            }
        }
    }
}
