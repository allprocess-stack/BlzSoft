using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BlzSoft
{
    [Serializable]
    class ConnFile
    {
        public static string COM;
        public static string INDICADOR;
        public static string SERVIDOR;
        public static string BD;
        public static string userAccess;
        public static string password;
        public static string formatGuiaPrefijo;
        public static string formatGuiaDigits;


        public static int Save()
        {
            try
            {
                //Guardar la configuracion
                //valores de variables se guardan tal como se muestran en cuadros texto o combo boxes
                string fileName = Application.StartupPath + "\\" + "CfgBalanza";
                                
                using (StreamWriter st = File.CreateText(fileName))
                {
                    if (COM.Trim() != "")
                    { st.WriteLine(COM); }
                    if (INDICADOR.Trim() != "")
                    { st.WriteLine(INDICADOR); }
                    if (SERVIDOR.Trim() != "")
                    { st.WriteLine(SERVIDOR); }
                    if (BD.Trim() != "")
                    { st.WriteLine(BD); }
                    if (userAccess.Trim() != "")
                    { st.WriteLine(userAccess); }
                    if (password.Trim() != "")
                    { st.WriteLine(password); }
                    if (formatGuiaPrefijo.Trim() != "")
                    { st.WriteLine(formatGuiaPrefijo); }
                    if (formatGuiaDigits.Trim() != "")
                    { st.WriteLine(formatGuiaDigits); }

                    st.Close();
                    return 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error, no se puede guardar configuracion\r" + e.Message);
                return 2;
            }
            
        }

        public static int Load()
        {
            try
            {
                //Cargar la configuracion
                //string fileName = Application.StartupPath + "\\" + "Cfg";
                string fileName = Application.StartupPath + "\\" + "CfgBalanza";


                using (StreamReader st = File.OpenText(fileName))
                {
                    COM = st.ReadLine();
                    INDICADOR = st.ReadLine();
                    SERVIDOR = st.ReadLine();
                    BD = st.ReadLine();
                    userAccess = st.ReadLine();
                    password = st.ReadLine();
                    formatGuiaPrefijo = st.ReadLine();
                    formatGuiaDigits = st.ReadLine();
                    st.Close();
                    return 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error, no se puede leer archivo de configuracion\r" + e.Message);
                return 2;
            }

        }

        //construsctor sin argumentos
        public ConnFile() { }
    }
}
