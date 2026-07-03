using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlzSoft
{
    [Serializable]
    class ConfigCamara
    {
        public static string user;
        public static string password;
        public static string ip;
        public static string rtsp;
        public static string rutaFotoEntrada;
        public static string rutaFotoSalida;

        public static int GuardarConfig()
        {
            try
            {
                string filename = Application.StartupPath + "\\" + "ConfigCamara";
                using (StreamWriter sw = File.CreateText(filename))
                {
                    if (user.Trim() != "")
                    {
                        sw.WriteLine(user);
                    }
                    if (password.Trim() != "")
                    {
                        sw.WriteLine(password);
                    }
                    if (ip.Trim() != "")
                    {
                        sw.WriteLine(ip);
                    }
                    if (rtsp.Trim() != "")
                    {
                        sw.WriteLine(rtsp);
                    }
                    if (rutaFotoEntrada.Trim() != "")
                    {
                        sw.WriteLine(rutaFotoEntrada);
                    }
                    if (rutaFotoSalida.Trim() != "")
                    {
                        sw.WriteLine(rutaFotoSalida);
                    }

                    sw.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se puede guardar configuracion\r" + ex.Message);
                return 2;
            }
        }

        public static int CargarConfig()
        {
            try {
                string filename = Application.StartupPath + "\\" + "ConfigCamara";

                using(StreamReader sr= File.OpenText(filename))
                {
                    user=sr.ReadLine();
                    password=sr.ReadLine();
                    ip=sr.ReadLine();
                    rtsp=sr.ReadLine();
                    rutaFotoEntrada=sr.ReadLine();
                    rutaFotoSalida=sr.ReadLine();

                    sr.Close();
                    return 0;
                }
            } catch (Exception e) {
                MessageBox.Show("Error, no se puede leer archivo de configuracion\r" + e.Message);
                return 2;
            }
        }

        public ConfigCamara() { }
    }
}