using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace BlzSoft
{
    public partial class Main : Form
    {
        //crea formato de clase delegado
        public static string Trama;
        public static string PesoStr;
        public static int IndType;
        public static int timeoutSerial;
        public static string usuario;
        public static string userType;
        public static bool admin;
        public static bool resetGuia = false;
        
        public Main()
        {
            InitializeComponent();
            foreach (string s in SerialPort.GetPortNames())
            {
                toolStripComboBoxSerial.Items.Add(s);

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string itemText;
            int i;
            //lee el archivo de configuracion
            ConnFile.Load();

            //carga modelo de indicador anterior
            for (i = 0; i < toolStripComboBoxIndicador.Items.Count; i++)
            {
                itemText = toolStripComboBoxIndicador.Items[i].ToString();
                if (itemText == ConnFile.INDICADOR)  //inspecciona si puerto serial guardado esta presente
                {
                    toolStripComboBoxIndicador.SelectedIndex = i;       //selecciona item de combo box segun el guardado anteriormente
                    CfgSerialIndicador(i);
                    IndType = i;
                    break;  //encuentra item selecciona y sale
                }
            }
            if (i >= toolStripComboBoxIndicador.Items.Count)
            { MessageBox.Show("Software no compatible con Indicador " + ConnFile.INDICADOR); }

            for (i = 0; i < toolStripComboBoxSerial.Items.Count; i++)
            {
                itemText = toolStripComboBoxSerial.Items[i].ToString();
                if (itemText == ConnFile.COM)  //inspecciona si puerto serial guardado esta presente
                {
                    toolStripComboBoxSerial.SelectedIndex = i;
                    OpenSerialPort1();
                    break;  //encuentra item selecciona y sale
                }
            }
            if (i >= toolStripComboBoxSerial.Items.Count)
            { MessageBox.Show("No se encontro puerto " + ConnFile.COM); }

            timeoutSerial = 100;    //establece tiempo de espera sobrepasado para evitar apertura de registro de peso al inicio
            //habilita muestreo de datos en pantalla
            timer1.Enabled = true;
            timer1.Start();

            //evalua habilitacion acceso de configuracion a base de datos
            if(Main.usuario == "root")
            { menuConfiguracionServidor.Enabled = true; }
            else
            { toolStripComboBoxIndicador.Enabled = false; }

            //restriccion de acceso a menus de configuracion
            if (!Main.admin)
            {
                operadorToolStripMenuItem.Enabled = false;
                formatosToolStripMenuItem.Enabled = false;
            }

            lblUser.Text = Usuario.USERlog;
            txtName.Text = Usuario.NOMBRElog;
            txtTipo.Text = Usuario.TIPOlog;
            
        }

        private void toolStripComboBoxSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = toolStripComboBoxSerial.Text;
            ConnFile.COM = toolStripComboBoxSerial.Text;        //guarda numero de puerto tal como se muestra en texto, al cambiar seleccion

        }

        private void menuAbrirCOM_Click(object sender, EventArgs e)
        {
            OpenSerialPort1();
        }

        public void OpenSerialPort1()
        {
            try
            {
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.Open();
                    toolStripComboBoxSerial.Enabled = false;
                    menuAbrirCOM.Enabled = false;
                    menuCerrarCOM.Enabled = true;
                    lblStatusCom.Text = "Iniciada";
                    lblStatusCom.ForeColor = System.Drawing.Color.Green;
                }

            }
            catch
            {
                MessageBox.Show("Puerto no válido");
                return;
            }
        }

        public void CloseSerialPort1()
        {
            if (serialPort1.IsOpen)
            {
                Thread CloseDown = new Thread(new ThreadStart(ThreadCloseSerial)); //close port in new thread to avoid hang
                CloseDown.Start(); //close port in new thread to avoid hang
                lblStatusCom.Text = "Detenida";
                lblStatusCom.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ThreadCloseSerial()
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
                serialPort1.Close(); //close the serial port
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }

        }

        public void CfgSerialIndicador(int type)
        {
            switch (type)
            {
                case 0: //doble de bytes de recepcion para indicador Flintec FT11
                    serialPort1.ReceivedBytesThreshold = 14;
                    serialPort1.NewLine = "\x0A";
                    break;
                case 1: //doble de bytes de recepcion para indicador Flintec FT11
                    serialPort1.ReceivedBytesThreshold = 36;
                    serialPort1.NewLine = "\x0D";
                    break;
                case 2: //para indicador generico chino XK D9
                    serialPort1.ReceivedBytesThreshold = 13;
                    serialPort1.NewLine = "\x03";
                    break;
                case 3: //para indicador precia molen
                    serialPort1.ReceivedBytesThreshold = 49;
                    serialPort1.NewLine = "\x0A";
                    break;
                default: return;
            }
        }

        private void menuCerrarCOM_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {   //si encuentra abierto
                CloseSerialPort1();
                toolStripComboBoxSerial.Enabled = true;
                menuAbrirCOM.Enabled = true;
                menuCerrarCOM.Enabled = false;
                
            }
        }

        private void toolStripComboBoxIndicador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnFile.INDICADOR = toolStripComboBoxIndicador.Text;       //Guarda el nombre del indicador tal como se muestra en combo box
            IndType = toolStripComboBoxIndicador.SelectedIndex;

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSerialPort1();
         

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (IndType == 0)
                ReadWeight_TransCell();
            if (IndType == 1)
                ReadWeight_FT11();
            if (IndType == 2)
                ReadWeight_XKR();
            if (IndType == 3)
                ReadWeight_PreciaMolen();

            serialPort1.DiscardInBuffer();
            

        }

        public void ReadWeight_TransCell()
        {
            string text, rawPeso;
            //int reg,signo,ndec;
            int lon;
            double y;
            text = serialPort1.ReadLine();
            lon = text.Length;
            
            if (lon < 13)
                return;

            Trama = text.Substring(text.IndexOf('\x02'));
            char signo = Trama.ElementAt(1);
            char codec = Trama.ElementAt(9);

            if (codec != 0x6B)  //si no cuenta con simbolo K  (Kg) retorna
                return;

            rawPeso = Trama.Substring(2, 7);

            y = int.Parse(rawPeso);
            if (signo != ' ')
            { y = y * (-1); }

            timeoutSerial = 0;

            PesoStr = y.ToString("0");


        }

        public void ReadWeight_FT11()
        {
            string text, rawPeso;
            char[] codec;
            int reg, signo, ndec;
            int lon;
            double x, y;
            text = serialPort1.ReadExisting();
            lon = text.Length;

            if (lon < 16)
                return;

            Trama = text.Substring(text.IndexOf('\x02'));
            rawPeso = Trama.Substring(4, 6);
            timeoutSerial = 0;

            //convierte a valor de Kilogramos
            codec = Trama.Substring(1, 2).ToCharArray();   //captura codigo de signo y decimal

            reg = codec[1] & 0x02;  //analiza signo
            if (reg == 2)
            { signo = -1; }
            else
            { signo = 1; }

            reg = codec[0] & 0x07;  //analiza #decimales
            if (reg < 2)
            { ndec = 0; }
            else
            { ndec = reg - 2; }

            try
            {
                //calcula peso en float
                x = Math.Pow(10, ndec);  //divisor
                y = double.Parse(rawPeso);
                y = (y * signo) / x;  //valor de peso en float
                PesoStr = y.ToString();
            }

            catch { return; }


        }

        public void ReadWeight_XKR()
        {
            string text, rawPeso;
            //int reg,signo,ndec;
            int lon;
            double y;

            text = serialPort1.ReadExisting();
            lon = text.Length;
            //if (lon > 23 )
            //  return;
            if (lon < 11)
                return;

            try
            {
                Trama = text.Substring(text.IndexOf('\x02'));
                char signo = Trama.ElementAt(1);
                rawPeso = Trama.Substring(2, 6);

                y = int.Parse(rawPeso);
                if (signo != '+')
                { y = y * (-1); }

                timeoutSerial = 0;

                PesoStr = y.ToString("0");
            }


            catch
            {
                return;
            }

        }

        public void ReadWeight_PreciaMolen()
        {
            string text, rawPeso;
            //int reg,signo,ndec;
            int lon;
            double y;

            text = serialPort1.ReadLine();
            lon = text.Length;                      
            
            if (lon < 48)
                return;

            try
            {
                Trama = text.Substring(text.IndexOf('\x01'));
                char signo = Trama.ElementAt(4);    //signo pos '0'
                rawPeso = Trama.Substring(37, 6);

                y = int.Parse(rawPeso);
                if (signo != '0')
                { y = y * (-1); }

                timeoutSerial = 0;

                PesoStr = y.ToString("0");
            }


            catch
            {
                return;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timeoutSerial<32000)     //limita cuenta de tiempo fuera
                timeoutSerial++;

            if (timeoutSerial > 10)
            {
                lblStatusDataSerial.Text = "no Data";
                lblStatusDataSerial.ForeColor = System.Drawing.Color.Red;
                txtSerialData.Text = "-----";
                return;
            }
            else
            {
                lblStatusDataSerial.Text = "Ok";
                lblStatusDataSerial.ForeColor = System.Drawing.Color.Green;
            }

            if (serialPort1.IsOpen == false)
            { txtSerialData.Text = "" ;return; }

            //peso ok
            txtSerialData.Text = PesoStr + " Kg";
            
        }

        private void menuConfiguracionServidor_Click(object sender, EventArgs e)
        {
            new wConnectionBD().ShowDialog();
        }

        private void nuevoREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NUEVO REGISTRO DE ENTRADA
            new wInputRegister().ShowDialog();
        }

        private void nuevoRSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NUEVO REGISTRO DE SALIDA
            new wOutputRegister().ShowDialog();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (txtSerialData.Text == "-----")
            { MessageBox.Show("El sistema no obtiene datos de peso, revisar conexion con indicador", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);return; }

            //Abre ventana de nuevo ingreso de Camion
            new w_inputEvent().ShowDialog();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (txtSerialData.Text == "-----")
            { MessageBox.Show("El sistema no obtiene datos de peso, revisar conexion con indicador", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            //obtiene lista de tickets con registros sin salida
            List<string> lst = BDregistros.IDlist();
            if (lst.Count > 0)      //evalua si existe alguno
            {
                //Int32 Id = Convert.ToInt32(lst.ElementAt(0));       //selecciona el primero de la lista 
                new w_outputEvent(0).ShowDialog();                 //envia id 0 para no vizualizar ninguno
            }
            else
            { MessageBox.Show("No hay registros de vehiculos en curso, Registre ingreso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abre ventana de acceso a base de datos de cliente
            new wCliente().ShowDialog();
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new wProductos().ShowDialog();
        }

        private void despachosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new wConsolidado().ShowDialog();
        }

        private void anuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new wFormatos().ShowDialog();
        }

        private void operadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new wOperadores().ShowDialog();
        }

        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new wCreditos().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guardarConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int key = ConnFile.Save();
            if (key == 2)
            { MessageBox.Show("error al guardar archivo de configuracion"); }
            else
            { MessageBox.Show("Configuracion guardada con exito "); }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConexionCamra_Click(object sender, EventArgs e)
        {
            new w_Camara().Show();
        }
    }
}
