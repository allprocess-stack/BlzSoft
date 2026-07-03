using OpenCvSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlzSoft
{
    public partial class w_Camara : Form
    {
        public w_Camara()
        {
            InitializeComponent();
            CargarConfig();
        }

        private void CargarConfig()
        {
            if (ConfigCamara.CargarConfig() == 0)
            {
                txtUser.Text = ConfigCamara.user;
                txtPassword.Text = ConfigCamara.password;
                txtIp.Text = ConfigCamara.ip;
                txtRtsp.Text = ConfigCamara.rtsp;
                txtRutaFotoEntrada.Text = ConfigCamara.rutaFotoEntrada;
                txtRutaFotoSalida.Text = ConfigCamara.rutaFotoSalida;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ConfigCamara.user = txtUser.Text;
            ConfigCamara.password = txtPassword.Text;
            ConfigCamara.ip = txtIp.Text;
            ConfigCamara.rtsp = txtRtsp.Text;
            ConfigCamara.rutaFotoEntrada = txtRutaFotoEntrada.Text;
            ConfigCamara.rutaFotoSalida = txtRutaFotoSalida.Text;

            if (ConfigCamara.GuardarConfig() == 0)
            {
                MessageBox.Show("Configuracion guardada correctamente", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBrowseEntrada_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaFotoEntrada.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseFotoSalida_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaFotoSalida.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private bool ComprobarConexionCamara()
        {
            string url = $"rtsp://{ConfigCamara.user}:{ConfigCamara.password}@{ConfigCamara.ip}:{ConfigCamara.rtsp}/cam/realmonitor?channel=1&subtype=0";
            using (VideoCapture test = new VideoCapture(url))
            {
                if (test.IsOpened())
                {
                    return true;
                }
            }
            return false;
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            CargarConfig();
            btnCargar.Enabled = false;

            var cts = new CancellationTokenSource();
            Task<bool> tarea = Task.Run(() => ComprobarConexionCamara(), cts.Token);
            if (await Task.WhenAny(tarea, Task.Delay(5000)) != tarea)
            {
                cts.Cancel();
                btnCargar.Enabled = true;
                MessageBox.Show("Tiempo de espera agotado. No se pudo conectar con la camara.", "Timeout",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool conectado = await tarea;
            btnCargar.Enabled = true;

            if (!conectado)
            {
                MessageBox.Show("No se pudo establecer conexion con la camara. Verifique la configuracion.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new w_ViewCamara().Show();
        }


    }
}
