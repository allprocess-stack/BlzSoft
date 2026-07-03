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
    public partial class w_productoNew : Form
    {
        public static string producto;
        public static bool flag=false;

        public w_productoNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] text = new string [2];

            if (txtProduct.Text.Trim() == "")
            {
                MessageBox.Show("Debe insertar el nombre del producto");
                return;
            }

            text[0] = txtProduct.Text;
            text[1] = txtDescripcion.Text;
            producto = text[0];
            //Agrega producto
            int check = BDproductos.AddProduct(text);
            if (check > 0)
            {
                MessageBox.Show("Producto guardado correctamente", "Guardado de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = true;
                this.Close();
                
            }
            else
            { MessageBox.Show("No se pudo guardar el Producto", "Guardado de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void w_productoNew_Load(object sender, EventArgs e)
        {

        }
    }
}
