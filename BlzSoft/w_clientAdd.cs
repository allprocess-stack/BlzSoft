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
    public partial class w_clientAdd : Form
    {
        public w_clientAdd()
        {
            InitializeComponent();
        }

  
 
        private void w_clientAdd_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
            cboSub.SelectedIndex = 0;
            txtUsuario.Text = Main.usuario;
            txtFecha.Text = DateTime.Now.ToString("G");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRazon.Text.Trim() == "")
            {
                MessageBox.Show("Debe insertar al menos el nombre de la empresa");
                return;
            }

            //guarda informacion de nuevo cliente en base de datos
            Empresa cliente = new Empresa();
            cliente.tipo = cboTipo.Text;
            cliente.subtipo = cboSub.Text;
            cliente.empresa = txtRazon.Text;
            cliente.ruc = txtRuc.Text;
            cliente.dirreccion = txtDirreccion.Text;
            cliente.telefono = txtTelefono.Text;
            cliente.correo = txtCorreo.Text;
            cliente.contacto = txtContacto.Text;
            cliente.informacion = txtInformacion.Text;
            cliente.fechacreacion = txtFecha.Text;
            cliente.usuario = txtUsuario.Text;

            int check = BDempresas.AddEmpresa(cliente);

            if (check > 0)
            { MessageBox.Show("Datos guardados correctamente", "Guardado de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);this.Close(); }
            else
            { MessageBox.Show("No se pudo guardar los datos", "Guardado de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
