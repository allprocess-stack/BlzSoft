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
    public partial class wOutputRegister : Form
    {
        public List<Registro> listaRegistros;

        public wOutputRegister()
        {
            InitializeComponent();
            cboOptions.SelectedIndex = 0;
            cboBusqueda.SelectedIndex = 0;
        }

        private void wOutputRegister_Load(object sender, EventArgs e)
        {
            cboClientes.DataSource = BDempresas.ClientList();
            //checkBox1.Checked = false;
            if (!Main.admin)
            { btnEliminar.Enabled = false; }
            else
            { btnEliminar.Enabled = true; }
                   
            txtBusqueda.Enabled = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_outputDel(Id).ShowDialog();
                update_grid();
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Main.timeoutSerial > 10)
            { MessageBox.Show("El sistema no obtiene datos de peso sobre plataforma", "Error de comunicacion con Indicador", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_outputEvent(Id).ShowDialog();
                update_grid();
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        public void update_grid()
        {
            string cliente, placa, estado;
            short evento;
            //Selecciona las variables de busqueda segun la configuracion actual
            if (cboClientes.SelectedIndex == 0)
            { cliente = "%"; }
            else
            { cliente = cboClientes.Text; }

            if (checkBox1.Checked)
            { estado = "SALIDA"; evento = 1; }
            else
            { estado = "ENTRADA"; evento = 0; }

            switch (cboBusqueda.SelectedIndex)
            {
                case 0: placa = "%"; break;
                case 1: placa = txtBusqueda.Text; break;
                default: placa = "%"; break;
            }

            //ejecuta funcion de busqueda normal o busqueda por fecha
            if (cboOptions.SelectedIndex == 0)
            { listaRegistros = BDregistros.Buscar(cliente, placa, estado); }
            else
            { listaRegistros = BDregistros.Buscar(cliente, placa, estado,dateTimePicker1.Value,dateTimePicker2.Value,evento); }

            //rellena data grid
            dataGridView1.DataSource = listaRegistros;
            //nombre de la columnas
            dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "TICKET BALANZA"; dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "ESTADO"; dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "PLACA"; dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "CLIENTE"; dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].HeaderText = "RUC"; dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[6].HeaderText = "CHOFER"; dataGridView1.Columns[6].Width = 140;
            dataGridView1.Columns[7].HeaderText = "PRODUCTO"; dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].HeaderText = "PESO DE ENTRADA (Kg)"; dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].HeaderText = "PESO DE SALIDA (Kg)"; dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].HeaderText = "PESO NETO (Kg)"; dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].HeaderText = "MODO"; dataGridView1.Columns[11].Width = 80;
            dataGridView1.Columns[12].HeaderText = "OBSERVACION"; dataGridView1.Columns[12].Width = 140;
            dataGridView1.Columns[13].HeaderText = "FECHA DE ENTRADA"; dataGridView1.Columns[13].Width = 140;
            dataGridView1.Columns[14].HeaderText = "FECHA DE SALIDA"; dataGridView1.Columns[14].Width = 140;
            dataGridView1.Columns[15].HeaderText = "USUARIO"; dataGridView1.Columns[15].Width = 100;

        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedIndex != 1)
            { txtBusqueda.Enabled = false; }
            else
            { txtBusqueda.Enabled = true; }
        }

        private void cboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOptions.SelectedIndex != 1)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                btnEliminar.Enabled = true;
                btnAgregar.Enabled = false;
                btnReportar.Enabled = true;
                btnReporteCompleto.Enabled = true;                
            }
            else
            {
                btnEliminar.Enabled = false;
                btnAgregar.Enabled = true;
                btnReportar.Enabled = false;
                btnReporteCompleto.Enabled = false;                
            }

            if (!Main.admin)
            { btnEliminar.Enabled = false; }

            update_grid();
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
                return;
            }

            //agrega instancia para nueva ventana de reporte
            w_outputPartialReport windowReport = new w_outputPartialReport();

            //obtiene variables de Registro
            Int32 idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Registro RE = BDregistros.Info(idx);
            List<Registro> lstREG = new List<Registro>();
            lstREG.Add(RE);

            //obtiene variables de datos especiales en reporte
            double pesoin, pesoout, pesoneto;

            pesoin = Convert.ToDouble(RE.PesoIn);
            pesoout = Convert.ToDouble(RE.PesoOut);
            try
            { pesoneto = Convert.ToDouble(RE.PesoNeto); }
            catch
            { pesoneto = 0; }

            VarRPT2 var = new VarRPT2();
            var.pesoNeto = pesoneto;
            if (pesoin > pesoout)
            {
                var.pesoBruto = pesoin.ToString();
                var.pesoTara = pesoout.ToString();
            }
            else
            {
                var.pesoBruto = pesoout.ToString();
                var.pesoTara = pesoin.ToString();
            }

            //obtiene variables de datos especiales en reporte

            //carga datos sobre ventana de reportes    
            windowReport.datos.Add(var);
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_infoRegistro(Id).ShowDialog();
                update_grid();
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
            }
        }

        private void btnReporteCompleto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
                return;
            }

            //agrega instancia para nueva ventana de reporte
            w_outputReport windowReport = new w_outputReport();

            //obtiene variables de Registro
            Int32 idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Registro RE = BDregistros.Info(idx);            

            List<Registro> lstREG = new List<Registro>();
            lstREG.Add(RE);
            
            //obtiene variables de datos especiales en reporte
            double pesoin, pesoout, pesoneto;

            pesoin = Convert.ToDouble(RE.PesoIn);
            pesoout = Convert.ToDouble(RE.PesoOut);
            try
            { pesoneto = Convert.ToDouble(RE.PesoNeto); }
            catch
            { pesoneto = 0; }
            

            VarRPT2 var = new VarRPT2();
            var.pesoNeto = pesoneto;
            if (pesoin > pesoout)
            {
                var.pesoBruto = pesoin.ToString();
                var.pesoTara = pesoout.ToString();
            }
            else
            {
                var.pesoBruto = pesoout.ToString();
                var.pesoTara = pesoin.ToString();
            }

            //obtiene variables de datos especiales en reporte

            //carga datos sobre ventana de reportes    
            windowReport.datos.Add(var);
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();

        }

        private void btnReportarEntrada_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Aun no se ha seleccionado ningun Registro");
                return;
            }

            //agrega instancia para nueva ventana de reporte
            w_inputReport windowReport = new w_inputReport();

            //obtiene variables de Registro
            Int32 idx = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Registro RE = BDregistros.Info(idx);
            List<Registro> lstREG = new List<Registro>();
            lstREG.Add(RE);


            //obtiene variables de datos especiales en reporte
            

            //carga datos sobre ventana de reportes
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
