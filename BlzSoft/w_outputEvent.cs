using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace BlzSoft
{
    public partial class w_outputEvent : Form
    {
        int ID;        
        public static bool viewReport;
        bool LOAD = false;

        public w_outputEvent(int id)
        {
            ID = id;            
            InitializeComponent();
        }
        
        private void w_outputEvent_Load(object sender, EventArgs e)
        {
     
            AutoCompleteStringCollection sourcePlacas = new AutoCompleteStringCollection();
                     

            //actualiza lista de placas disponibles solo como entrada
            List<string> listaPlacas = BDregistros.PlacasListIN();
            listaPlacas.ForEach(el => sourcePlacas.Add(el));
            txtPlaca.AutoCompleteCustomSource = sourcePlacas;

            //update_ticket();

            if(ID!=0)   //se esta enviando con un indice adjunto apuntado, carga tickec de salida al inicio
            {
                Registro p = new Registro();

                p = BDregistros.Info(ID);       //carga registro de entrada ultimo en funcion a ID
                DateTime myDateTime = DateTime.Now;
                string fechanew = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                //agrega en controles de datos de Registro ingresado
                ID = p.Id;
                txtPlaca.Text = p.Placa;        //cambia valor de placa
                txtID.Text = p.Id.ToString();
                txtTicket.Text = p.Guia;
                txtCliente.Text = p.Cliente;
                txtConductor.Text = p.Chofer;
                txtProducto.Text = p.Producto;
                txtObservaciones.Text = p.Observacion;
                txtFecha.Text = p.FechaEntrada;
                txtUsuario.Text = p.Usuario;
                txtPesoIn.Text = p.PesoIn;

            }
            else
            {
                btnGuardar.Enabled = false;
            }

            //habilita muestreo de datos en pantalla
            timer1.Enabled = true;
            timer1.Start();

            if (!Main.admin)
            { chkPesajeManual.Enabled = false; }

            //actualiza estado de checkbox de vizualizacion de reporte
            //if (viewReport)
            //    checkBox1.Checked = true;
            //else
            //    checkBox1.Checked = false;
            LOAD = true;
            
            
        }

        public void update_ticket()
        {
            Registro p = new Registro();
            
            p = BDregistros.LastCheckIn(txtPlaca.Text);       //carga registro de entrada ultimo con placa
            DateTime myDateTime = DateTime.Now;
            string fechanew = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            //agrega en controles de datos de Registro ingresado
            ID = p.Id;
            txtID.Text = p.Id.ToString();
            txtTicket.Text = p.Guia;
            txtCliente.Text = p.Cliente;            
            txtConductor.Text = p.Chofer;
            txtProducto.Text = p.Producto;
            txtObservaciones.Text = p.Observacion;
            txtFecha.Text = p.FechaEntrada;
            txtUsuario.Text = p.Usuario;
            txtPesoIn.Text = p.PesoIn;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int ps;
            if (int.TryParse(txtPeso.Text, out ps) == false)
            {
                MessageBox.Show("Data de peso no tiene valor valido");
                return;
            }

            if ((Main.timeoutSerial > 10) && (chkPesajeManual.Checked == false))
            {
                MessageBox.Show("El sistema no obtiene datos de peso sobre plataforma", "Error de comunicacion con Indicador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Obtiene informacion de la empresa seleccionada
            Registro init = new Registro();
            init = BDregistros.Info(ID);
            
            //carga fecha y hora actual
            DateTime myDateTime = DateTime.Now;
            
            Registro RE = new Registro();
            RE.Id = init.Id;
            RE.Guia = init.Guia;
            RE.Placa = init.Placa;
            RE.Cliente = init.Cliente;
            RE.Chofer = init.Chofer;
            RE.Estado = "SALIDA";
            RE.Producto = init.Producto;
            RE.PesoIn = init.PesoIn;
            RE.PesoOut = txtPeso.Text;
            RE.Ruc = init.Ruc;            
            RE.Observacion = txtObservaciones.Text;
            RE.FechaEntrada = init.FechaEntrada;
            RE.FechaSalida = myDateTime.ToString("dd/MM/yyyy HH:mm:ss");     
            RE.Usuario = Main.usuario;
            if (chkPesajeManual.Checked)
            {
                if (init.Modo == "automatico")
                    RE.Modo = init.Modo + "/MANUAL";
                else
                    RE.Modo = "MANUAL";
            }                
            else
            {
                if (init.Modo == "MANUAL")
                    RE.Modo = init.Modo + "/automatico";
                else
                    RE.Modo = "automatico";
            }
                
            double pesoout=0, pesoin=0, pesoneto=0;
            if (double.TryParse(RE.PesoOut, out pesoout) && double.TryParse(RE.PesoIn, out pesoin))
                pesoneto = Math.Abs(pesoout - pesoin);
            else
                pesoneto = 0;

            RE.PesoNeto = pesoneto.ToString();

            btnGuardar.Enabled = false;
            RE.RutaFotoSalida = await TomarFotoAsync(txtID.Text);
            btnGuardar.Enabled = true;

            int check = BDregistros.Mod(RE);
            if (check == 0)
            { MessageBox.Show("No se ha podido guardar Registro de salida", "Registro de Salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);return; }

            //evalua si se habilito reporte de salida, si no solo informa de guardado exitoso de datos
            if(checkBox1.Checked==false)
            { MessageBox.Show("Guardado de Registro Salida con exito", "Registro de Salida", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();return; }

            //se habilito reporte de salida
            //muestra informacion de salida en reporte de manera automatica
            //agrega instancia para nueva ventana de reporte
            this.Close();            
            //agrega instancia para nueva ventana de reporte
            w_outputReport windowReport = new w_outputReport();

            List<Registro> lstREG = new List<Registro>();            
            lstREG.Add(RE);

            //obtiene variables de datos especiales en reporte
            VarRPT2 var = new VarRPT2();
            var.pesoNeto = pesoneto;
            if(pesoin>pesoout)
            {
                var.pesoBruto = pesoin.ToString();
                var.pesoTara = pesoout.ToString();
            }
            else
            {
                var.pesoBruto = pesoout.ToString();
                var.pesoTara = pesoin.ToString();
            }

            //carga datos sobre ventana de reportes
            windowReport.datos.Add(var);
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //evalua si se ha fijado el peso
            if ( (chkFijarPeso.Checked) && (!chkPesajeManual.Checked) )
                return;     //sale si se fijo peso

            if (!chkPesajeManual.Checked)
            { txtPeso.Text = Main.PesoStr; }    //carga peso de fuente principal

            double pesoF, pesoI;
            if (double.TryParse(txtPesoIn.Text, out pesoI) && double.TryParse(txtPeso.Text, out pesoF))
                pesoF = Math.Abs(pesoF - pesoI);
            else
                pesoF = 0;

            txtPesoNet.Text = pesoF.ToString();

        }

        private void cboTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
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
                    string carpeta = ConfigCamara.rutaFotoSalida;

                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    string nombre = $"output_{id}.jpg";
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
            if (await Task.WhenAny(tarea, Task.Delay(5000)) != tarea)
            {
                cts.Cancel();
                return "";
            }
            return await tarea;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                viewReport = true;
                
            }
            else
            {
                viewReport = false;
            }
        }

        private void cboTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkFijarPeso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFijarPeso.Checked)
            { txtPeso.ForeColor = Color.White; }
            else
            { txtPeso.ForeColor = Color.Lime; }
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            if (!LOAD)      //se asegura que ya  haya cargado 
                return;

            update_ticket();        //actualiza informacion mostrada de ticket

            if (txtTicket.Text.Trim() == "")
            {
                btnGuardar.Enabled = false;              
            }
            else
            {
                btnGuardar.Enabled = true;
            }
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
