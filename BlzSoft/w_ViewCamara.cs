using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlzSoft
{
    public partial class w_ViewCamara : Form
    {
        //Variables de camara
        VideoCapture capture;
        Mat frame;
        bool cameraActiva = false;
        public w_ViewCamara()
        {
            InitializeComponent();
            ConfigCamara.CargarConfig();
        }

        private void w_ViewCamara_Load(object sender, EventArgs e)
        {
            OpenCamara();
        }

        private void w_ViewCamara_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraActiva = false;
            capture?.Dispose();
            frame?.Dispose();
        }

        private void OpenCamara()
        {
            string url = $"rtsp://{ConfigCamara.user}:{ConfigCamara.password}@{ConfigCamara.ip}:{ConfigCamara.rtsp}/cam/realmonitor?channel=1&subtype=0";

            capture = new VideoCapture(url);
            frame = new Mat();

            cameraActiva = true;

            Task.Run(() =>
            {
                while (cameraActiva)
                {
                    try
                    {
                        if ((capture.Read(frame)) && (!frame.Empty()))
                        {
                            var image = BitmapConverter.ToBitmap(frame);
                            viewImg.Invoke((MethodInvoker)(() =>
                            {
                                viewImg.Image?.Dispose();
                                viewImg.Image = image;
                            }));
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        break;
                    }
                    catch (AccessViolationException)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(10);
                }
            });
        }
    }
}
