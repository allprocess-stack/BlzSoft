using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;

namespace BlzSoft
{
    public partial class w_inputEvent : Form
    {       
        public w_inputEvent()
        {
            InitializeComponent();
        }

        private void w_inputEvent_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sourceClients = new AutoCompleteStringCollection();
            AutoCompleteStringCollection sourcePlacas = new AutoCompleteStringCollection();
            AutoCompleteStringCollection sourceChoferes = new AutoCompleteStringCollection();

            List<string> listaClientes = BDempresas.ClientList();
            listaClientes.ForEach(el => sourceClients.Add(el));
            txtCliente.AutoCompleteCustomSource = sourceClients;

            List<string> listaPlacas = BDregistros.PlacasList();
            listaPlacas.ForEach(el => sourcePlacas.Add(el));
            txtPlaca.AutoCompleteCustomSource = sourcePlacas;

            List<string> listaChoferes = BDregistros.ChoferesList();
            listaChoferes.ForEach(el => sourceChoferes.Add(el));
            txtConductor.AutoCompleteCustomSource = sourceChoferes;

            //carga items en combo's box
            //-----------------------------
            cboProducto.DataSource = BDproductos.ProductsList().OrderBy(q => q).ToList();

            //muestra proximo id
            string id_next = BDregistros.NextId();
            if (id_next == null)
                MessageBox.Show("Se perdio conexion con base de datos");
            else
                txtID.Text = id_next;

            //calcula el proximo numero de guia
            UInt32 guia;
            string text;
            try
            { text = BDregistros.LastGuia(); }
            catch
            { text = ConnFile.formatGuiaPrefijo + "-" + string.Format(ConnFile.formatGuiaDigits, 0); }

            string[] strGuia = text.Split('-');
            //evalua ultima guia guardada
            bool okGuia = false;
            guia = 0;
            if (strGuia.Length == 2)
            { okGuia = UInt32.TryParse(strGuia[1], out guia); }

            if (okGuia)
            {
                if (Main.resetGuia)
                {   guia = 1;txtGuia.Text = ConnFile.formatGuiaPrefijo + "-" + guia.ToString(ConnFile.formatGuiaDigits); }
                else
                {   guia = guia + 1;txtGuia.Text = ConnFile.formatGuiaPrefijo + "-" + guia.ToString(ConnFile.formatGuiaDigits); }
            }
            else
            {   //ultima guia en base de datos no valida, inspecciona si se activo reinicio
                if (Main.resetGuia)
                { guia = 1; txtGuia.Text = ConnFile.formatGuiaPrefijo + "-" + guia.ToString(ConnFile.formatGuiaDigits); }
                else
                { MessageBox.Show("No se puede verificar ultimo numero de guia, Reiniciar cuenta en menu Configuracion>Formatos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); this.Close(); }
            }

            //muestra otros datos
            txtUsuario.Text = Main.usuario;
            DateTime myDateTime = DateTime.Now;
            txtFecha.Text = myDateTime.ToString("yyyy-MM-dd HH:mm");

            //habilita muestreo de datos en pantalla
            timer1.Enabled = true;
            timer1.Start();

            if (!Main.admin)
            { chkPesajeManual.Enabled = false; }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            new w_productoNew().ShowDialog();
            if ( w_productoNew.flag )
            {
                cboProducto.DataSource = BDproductos.ProductsList();
                cboProducto.SelectedIndex = cboProducto.Items.Count - 1;
            }

        }

        private string TomarFoto(string id)
        {
            ConfigCamara.CargarConfig();

            string url = $"rtsp://{ConfigCamara.user}:{ConfigCamara.password}@{ConfigCamara.ip}:{ConfigCamara.rtsp}/cam/realmonitor?channel=1&subtype=0";

            using (var capture = new VideoCapture(url))
            using (var frame = new Mat())
            {
                if (capture.IsOpened() && capture.Read(frame) && !frame.Empty())
                {
                    string carpeta = ConfigCamara.rutaFotoEntrada;

                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    string nombre = $"input_{id}.jpg";
                    string ruta = Path.Combine(carpeta, nombre);

                    frame.SaveImage(ruta);
                    return ruta;
                }
            }
            return "";
        }

        private async Task<string> TomarFotoAsync(string id)
        {
            var cts = new CancellationTokenSource();
            Task<string> tarea = Task.Run(() => TomarFoto(id), cts.Token);
            if (await Task.WhenAny(tarea, Task.Delay(3000)) != tarea)
            {
                cts.Cancel();
                return "";
            }
            return await tarea;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if( (Main.timeoutSerial > 10) && (chkPesajeManual.Checked == false) )
            {
                MessageBox.Show("El sistema no obtiene datos de peso sobre plataforma", "Error de comunicacion con Indicador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtPlaca.Text.Trim() == "")
            {
                MessageBox.Show("Debe insertar al menos La placa del vehiculo");
                return;
            }

            if (txtCliente.Text.Trim() == "")
            {
                MessageBox.Show("Tiene que registrar datos de cliente");
                return;
            }

            int ps;
            if (int.TryParse(txtPeso.Text, out ps)==false)
            {
                MessageBox.Show("Data de peso no tiene valor valido");
                return;
            }

            //Obtiene informacion de la empresa seleccionada
            Empresa company = new Empresa();
            List<int> ids = BDempresas.IdList();    //obtiene la lista de IDs
            company = BDempresas.InfoEmpresa(txtCliente.Text);   //carga info en funcion de Nombre de empresaID
            if (company.empresa == null)
            { MessageBox.Show("El cliente: " + txtCliente.Text + " necesita registrarse antes"); return; }
            //carga fecha y hora actual
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            Registro RE = new Registro();
            RE.Guia = txtGuia.Text;
            RE.Placa = txtPlaca.Text;
            RE.Cliente = txtCliente.Text;
            RE.Chofer = txtConductor.Text;
            RE.Estado = "ENTRADA";
            RE.Producto = cboProducto.Text;
            RE.PesoIn = txtPeso.Text;
            RE.PesoOut = "-----";
            RE.Ruc = company.ruc;            
            RE.Observacion = txtObservaciones.Text;
            RE.FechaEntrada = sqlFormattedDate;
            RE.FechaSalida = null;
            RE.Usuario = Main.usuario;
            Main.resetGuia = false;
            if (chkPesajeManual.Checked)
                RE.Modo = "MANUAL";
            else
                RE.Modo = "automatico";

            btnGuardar.Enabled = false;
            RE.RutaFotoEntrada = await TomarFotoAsync(txtID.Text);
            btnGuardar.Enabled = true;

            int check = BDregistros.AddRE(RE);
            if (check == 0)
            { MessageBox.Show("No se ha podido guardar Registro de entrada", "Registro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);return; }
                                
            //evalua si se habilito reporte de entrada, 
            if (checkBox1.Checked == false)
            { MessageBox.Show("Se ha agregado un nuevo Registro de entrada", "Registro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); return; }

            //agrega instancia para nueva ventana de reporte
            this.Close();
            w_inputReport windowReport = new w_inputReport();

            List<Registro> lstREG = new List<Registro>();
            lstREG.Add(RE);

            //obtiene variables de datos especiales en reporte
            VarRPT2 var = new VarRPT2();
            double pesoout, pesoin;
            if (double.TryParse(RE.PesoOut, out pesoout) && double.TryParse(RE.PesoIn, out pesoin))
                var.pesoNeto = pesoout - pesoin;
            else
                var.pesoNeto = 0;

            //carga datos sobre ventana de reportes
            windowReport.datos.Add(var);
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //evalua si se ha fijado el peso
            if (chkFijarPeso.Checked)
                return;     //sale si se fijo peso

            if (chkPesajeManual.Checked)
                return;     //sale si esta en modo manual

            //peso ok
            txtPeso.Text = Main.PesoStr;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            string id1, id2;
            int k;
            //chekea numero de ultimo registro cliente para registrar si existira cambio
            id1 = BDempresas.LastId();
            //carga ventana de dialogo
            new w_clientAdd().ShowDialog();
            id2 = BDempresas.LastId();


            if (id1 != id2)    //se agrego nuevo cliente??
            {
                //carga nuevo cliente
                k = Convert.ToInt32(id2);
                txtCliente.Text = BDempresas.Client(k);

                //actualiza autocompletado de clientes
                AutoCompleteStringCollection sourceClients = new AutoCompleteStringCollection();
                List<string> listaClientes = BDempresas.ClientList();
                listaClientes.ForEach(el => sourceClients.Add(el));
                txtCliente.AutoCompleteCustomSource = sourceClients;


            }

        }

        private void chkFijarPeso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFijarPeso.Checked)
            { txtPeso.ForeColor = Color.White; }
            else
            { txtPeso.ForeColor = Color.Lime; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            string text = BDregistros.ClientByPlaca(txtPlaca.Text);

            if (text.Trim() == "")
                return;

            txtCliente.Text = text;
        }

        private void chkPesajeManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPesajeManual.Checked)
            {
                //pesaje manual habilitado
                txtPeso.ReadOnly = false;
                chkFijarPeso.Enabled = false;
                txtPeso.BackColor = Color.White;
                txtPeso.ForeColor = Color.Black;
            }      
            else
            {
                txtPeso.ReadOnly = true;
                chkFijarPeso.Enabled = true;
                txtPeso.BackColor = Color.Black;
                //evalua si es peso
                if (chkFijarPeso.Checked)
                    txtPeso.ForeColor = Color.White;
                else
                    txtPeso.ForeColor = Color.Lime;                
            }
        }
    }
}
