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
    public partial class wConsolidado : Form
    {
        public List<Registro> listaRegistros;

        public wConsolidado()
        {
            InitializeComponent();
        }

        private void wConsolidado_Load(object sender, EventArgs e)
        {
            //carga ajustes por default
            //opciones de busqueda general - con intervalo de tiempo
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            cboTipo.Enabled = true;
            cboSub.Enabled = true;
            cboCliente.Enabled = false;
            cboPlaca.Enabled = false;
            cboBusqueda.Enabled = false;
            txtBusqueda.Enabled = false;

            //carga items en combo's box
            //-----------------------------
            cboCliente.DataSource = BDempresas.ClientList().OrderBy(q => q).ToList();

            cboTipo.SelectedIndex = 0;
            cboSub.SelectedIndex = 0;
            //cboCliente.SelectedIndex = 0;
            cboPlaca.SelectedIndex = 0;
            cboBusqueda.SelectedIndex = 0;

            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void optGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (optGeneral.Checked)
            {
                cboTipo.Enabled = true;
                cboSub.Enabled = true;
                cboCliente.Enabled = false;
                cboPlaca.Enabled = false;
                cboBusqueda.Enabled = false;
                txtBusqueda.Enabled = false;
            }
        }

        private void optCliente_CheckedChanged(object sender, EventArgs e)
        {
            if(optCliente.Checked)
            {
                cboTipo.Enabled = false;
                cboSub.Enabled = false;
                cboCliente.Enabled = true;
                cboPlaca.Enabled = true;
                cboBusqueda.Enabled = false;
                txtBusqueda.Enabled = false;
            }
            
        }

        private void optEspecifica_CheckedChanged(object sender, EventArgs e)
        {
            if (optEspecifica.Checked)
            {
                cboTipo.Enabled = false;
                cboSub.Enabled = false;
                cboCliente.Enabled = false;
                cboPlaca.Enabled = false;
                cboBusqueda.Enabled = true;
                txtBusqueda.Enabled = true;
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        public void update_grid()
        {
            string tipo, subtipo, cliente, placa, clase, search ;

            //evalua que modo esta seleccionado chekeando los radio buttton
            if (optGeneral.Checked)
            {
                if (cboTipo.SelectedIndex == 0)
                { tipo = "%"; }
                else
                { tipo = cboTipo.Text; }

                if (cboSub.SelectedIndex == 0)
                { subtipo = "%"; }
                else
                { subtipo = cboSub.Text; }

                if(checkBox1.Checked)
                { listaRegistros = BDregistros.HysGeneral(tipo, subtipo, dateTimePicker1.Value, dateTimePicker2.Value); }
                else
                {
                    if (tipo != subtipo)
                    { listaRegistros = BDregistros.HysGeneral(tipo, subtipo); }
                    else
                    { listaRegistros = BDregistros.Buscar("%","%"); }
                }             
                
            }

            if (optCliente.Checked)
            {
                //carga opciones de busqueda por cliente y placa correspondiente
                if (cboCliente.SelectedIndex == 0)
                { cliente = "%"; }
                else
                { cliente = cboCliente.Text; }
                if (cboPlaca.SelectedIndex == 0)
                { placa = "%"; }
                else
                { placa = cboPlaca.Text; }

                if (checkBox1.Checked)
                { listaRegistros = BDregistros.Buscar(cliente, placa, "%", dateTimePicker1.Value, dateTimePicker2.Value,0); }
                else
                { listaRegistros = BDregistros.Buscar(cliente, placa); }
            }

            if(optEspecifica.Checked)
            {
                //carga opciones de busqueda  personalizada
                if (cboBusqueda.SelectedIndex == 0)     //selecciona todo segun rango de fecha
                {
                    if (checkBox1.Checked)
                    { listaRegistros = BDregistros.HysGeneral("%", "%", dateTimePicker1.Value, dateTimePicker2.Value); }
                    else
                    { listaRegistros = BDregistros.HysGeneral("%", "%"); }
                }
                else
                {
                    clase = cboBusqueda.Text;
                    search = txtBusqueda.Text + "%";

                    if (checkBox1.Checked)
                    { listaRegistros = BDregistros.HysSearch(clase, search, dateTimePicker1.Value, dateTimePicker2.Value); }
                    else
                    { listaRegistros = BDregistros.HysSearch(clase, search); }

                }

                
            }

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

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string client;
            //actualizan seleccion de clientes---> debera actualizar checbox de placas

            if (cboCliente.SelectedIndex == 0)
            { client = "%"; }
            else
            { client = cboCliente.Text; }

            //cboPlaca.DataSource = BDregistros.PlacasList(client).OrderBy(q => q).ToList();
            cboPlaca.DataSource = BDregistros.PlacasList(client);
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            update_grid();

            //agrega instancia para nueva ventana de reporte
            w_consolidadoReport windowReport = new w_consolidadoReport();
                                
            //agrego datos de variables en reporte
            VarRPT3 var = new VarRPT3();

            if (checkBox1.Checked)
            { var.fin = dateTimePicker1.Text; var.fout = dateTimePicker2.Text; }
            else
            { var.fin = "---";var.fout = "---"; }
            
            if(optGeneral.Checked)
            { var.option = "General";var.opt1 = "Tipo: " + cboTipo.Text;var.opt2 = "Sub: " + cboSub.Text; }
            if(optCliente.Checked)
            { var.option = "por Cliente";var.opt1 = cboCliente.Text;var.opt2 = "Placa: "+ cboPlaca.Text; }
            if(optEspecifica.Checked)
            { var.option = "especifica"; var.opt1 = cboBusqueda.Text; var.opt2 = txtBusqueda.Text; }

            windowReport.datos.Add(var);
            windowReport.dataDespachos = listaRegistros;
            windowReport.ShowDialog();
        }
    }
}
