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
    public partial class w_inputMod : Form
    {
        int ID;

        public w_inputMod(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void w_inputMod_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sourcePlacas = new AutoCompleteStringCollection();
            AutoCompleteStringCollection sourceChoferes = new AutoCompleteStringCollection();

            List<string> listaPlacas = BDregistros.PlacasList();
            listaPlacas.ForEach(el => sourcePlacas.Add(el));
            txtPlaca.AutoCompleteCustomSource = sourcePlacas;

            List<string> listaChoferes = BDregistros.ChoferesList();
            listaChoferes.ForEach(el => sourceChoferes.Add(el));
            txtConductor.AutoCompleteCustomSource = sourceChoferes;


            int i;
            Registro p = new Registro();
            p = BDregistros.Info(ID);       //carga registro de entrada guardado
            DateTime myDateTime = DateTime.Now;
            string fechanew = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            //agrega en controles de datos de Registro ingresado
            txtID.Text = p.Id.ToString();
            txtGuia.Text = p.Guia;
            txtPlaca.Text = p.Placa;
            txtConductor.Text = p.Chofer;
            txtObservaciones.Text = p.Observacion;
            txtFecha.Text = fechanew;
            txtUsuario.Text = p.Usuario;
            txtPeso.Text = p.PesoIn;

            

            //actualiza cliente y producto seleccionado de combo's box
            //-----------------------------
            List<string> lst = BDempresas.ClientList();
            lst.RemoveAt(0);    //quita nombre vacio de empresa
            cboClientes.DataSource = lst;
            cboProducto.DataSource = BDproductos.ProductsList();
            //selecciona cliente y producto guardado                   
            for(i=0;i<cboClientes.Items.Count;i++)
            {
                if(p.Cliente==cboClientes.Items[i].ToString())
                {   cboClientes.SelectedIndex = i;break; }
                     
            }
            for (i = 0; i < cboProducto.Items.Count; i++)
            {
                if (p.Producto == cboProducto.Items[i].ToString())
                { cboProducto.SelectedIndex = i; break; }

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text.Trim() == "")
            {
                MessageBox.Show("Debe insertar al menos La placa del vehiculo");
                return;
            }

            //Obtiene informacion de la empresa seleccionada
            Empresa company = new Empresa();
            List<int> ids = BDempresas.IdList();    //obtiene la lista de IDs
            company = BDempresas.InfoEmpresa(ids[cboClientes.SelectedIndex]);   //carga info en funcion de ID
            //carga fecha y hora actual
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            Registro RE = new Registro();
            RE.Id = ID;
            RE.Guia = txtGuia.Text;
            RE.Placa = txtPlaca.Text;
            RE.Cliente = cboClientes.Text;
            RE.Chofer = txtConductor.Text;
            RE.Estado = "ENTRADA";
            RE.Producto = cboProducto.Text;
            RE.PesoIn = txtPeso.Text;
            RE.PesoOut = "-----";
            RE.Ruc = company.ruc;            
            RE.Observacion = txtObservaciones.Text;
            RE.FechaEntrada = sqlFormattedDate;
            RE.FechaSalida = sqlFormattedDate;
            RE.Usuario = Main.usuario;
            RE.Modo = "MANUAL";

            int check = BDregistros.Mod(RE);

            if (check > 0)
            { MessageBox.Show("Datos modificados correctamente", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { MessageBox.Show("No se pudo mofificar los datos", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            new w_productoNew().ShowDialog();
            if (w_productoNew.flag)
            {
                cboProducto.DataSource = BDproductos.ProductsList();
                cboProducto.SelectedIndex = cboProducto.Items.Count - 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //peso ok
            txtPeso.Text = Main.PesoStr;
        }

        private void cboClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
