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
    public partial class wCliente : Form
    {
        public List<Empresa> listaEmpresas;
        
        public wCliente()
        {
            InitializeComponent();
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            new w_clientAdd().ShowDialog();
            update_grid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_clientMod(Id).ShowDialog();
                update_grid();
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun cliente");
            }

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            update_grid();

        }

        private void wCliente_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
            cboSub.SelectedIndex = 0;
            cboBusqueda.SelectedIndex = 0;

            if (!Main.admin)
            { btnEliminar.Enabled = false; }
        }

        public void update_grid()
        {
            string tipo, subtipo, empresa, ruc;
            //Selecciona las variables de busqueda segun la configuracion actual
            if (cboTipo.SelectedIndex == 0)
            { tipo = "%"; }
            else
            { tipo = cboTipo.Text; }

            if (cboSub.SelectedIndex == 0)
            { subtipo = "%"; }
            else
            { subtipo = cboSub.Text; }

            switch (cboBusqueda.SelectedIndex)
            {
                case 0: empresa = "%"; ruc = "%"; break;
                case 1: empresa = txtBusqueda.Text+"%"; ruc = "%"; break;
                case 2: empresa = "%"; ruc = txtBusqueda.Text+"%"; break;
                default: empresa = "%"; ruc = "%"; break;
            }

            listaEmpresas = BDempresas.BuscarEmpresas(tipo, subtipo, empresa, ruc);
            dataGridView1.DataSource = listaEmpresas;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[10].Width = 130;
            dataGridView1.Columns[11].Width = 60;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_clienteDel(Id).ShowDialog();
                update_grid();
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun cliente");
            }
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            //Crea instancia para manejar pantalla de reporte guardando datos de formulario

            w_clienteReport windowReport = new w_clienteReport();

            if (listaEmpresas != null)
            {
                //agrego datos de variables en reporte
                VarRPT1 var = new VarRPT1();
                var.numRegistros = dataGridView1.RowCount;
                DateTime myDateTime = DateTime.Now;
                var.Fecha = myDateTime.ToString();
                var.Usuario = Main.usuario;
                var.Tipo = Main.userType;

                //ajuste de datos sobre ventana de reportes
                windowReport.datos.Add(var);                         
                windowReport.dataclient = listaEmpresas;
                windowReport.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar en reporte");
            }
            
        }
    }
}
