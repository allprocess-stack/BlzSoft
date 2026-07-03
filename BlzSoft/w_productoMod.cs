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
    public partial class w_productoMod : Form
    {
        public static bool flag = false;

        int ID;

        public w_productoMod(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text.Trim() == "")
            {
                MessageBox.Show("Debe insertar al menos el nombre de la empresa");
                return;
            }

            //guarda informacion de nuevo cliente en base de datos
            Producto item = new Producto();
            item.id = ID;
            item.producto = txtProduct.Text;
            item.descripcion = txtDescripcion.Text;
            
            int check = BDproductos.Mod(item);

            if (check > 0)
            { MessageBox.Show("Datos modificados correctamente", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information); flag = true; this.Close(); }
            else
            { MessageBox.Show("No se pudo mofificar los datos", "Modificacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void w_productoMod_Load(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p = BDproductos.Info(ID);

            //agrega en controles datos de empresa
            txtProduct.Text = p.producto;
            txtDescripcion.Text = p.descripcion;
            
        }
    }
}
