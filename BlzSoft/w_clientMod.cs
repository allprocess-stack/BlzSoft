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
    public partial class w_clientMod : Form
    {
        int ID;

        public  w_clientMod(int id)
        {
            ID = id;
            InitializeComponent();

        }

        private void w_clientMod_Load(object sender, EventArgs e)
        {
            Empresa p = new Empresa();
            p = BDempresas.InfoEmpresa(ID);

            //agrega en controles datos de empresa
            txtID.Text = p.id.ToString();
            cboTipo.Text = p.tipo; 
            cboSub.Text = p.subtipo;
            txtRazon.Text = p.empresa;
            txtRuc.Text = p.ruc;
            txtDirreccion.Text = p.dirreccion;
            txtTelefono.Text = p.telefono;
            txtCorreo.Text = p.correo;
            txtContacto.Text = p.contacto; 
            txtInformacion.Text = p.informacion; 
            txtFecha.Text = p.fechacreacion;
            txtUsuario.Text = p.usuario; 
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
            cliente.id = ID;
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

            int check = BDempresas.ModEmpresa(cliente);

            if (check > 0)
            { MessageBox.Show("Datos modificados correctamente", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { MessageBox.Show("No se pudo mofificar los datos", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
