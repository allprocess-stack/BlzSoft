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
    public partial class wFormatos : Form
    {
        public wFormatos()
        {
            InitializeComponent();
        }

        private void wFormatos_Load(object sender, EventArgs e)
        {
            string itemText;
            int i;

            //carga ultimo numero de guia
            if (Main.resetGuia)
            { txtLastGuia.Text = ConnFile.formatGuiaPrefijo + "-" + string.Format(ConnFile.formatGuiaDigits, 0); }
            else
            {
                try
                { txtLastGuia.Text = BDregistros.LastGuia(); }
                catch
                { txtLastGuia.Text = "No existe ningun registro"; }
            }    

            //carga formato de prefijo actual
            txtPrefijo.Text = ConnFile.formatGuiaPrefijo;
            
            //carga formato de digitos anterior
            for (i = 0; i < cboDigits.Items.Count; i++)
            {
                itemText = cboDigits.Items[i].ToString();
                if (itemText == ConnFile.formatGuiaDigits)  //inspecciona si puerto serial guardado esta presente
                {
                    cboDigits.SelectedIndex = i;       //selecciona item de combo box segun el guardado anteriormente
                    break;  //encuentra item selecciona y sale
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //GUARDA configuracion
            ConnFile.formatGuiaPrefijo = txtPrefijo.Text;
            ConnFile.formatGuiaDigits = cboDigits.Text;

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.resetGuia = true;
            txtLastGuia.Text = ConnFile.formatGuiaPrefijo + "-" + string.Format(ConnFile.formatGuiaDigits,0);
        }

        private void cboDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
