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
    public partial class wProductos : Form
    {
        public List<Producto> listaProductos;

        public wProductos()
        {
            InitializeComponent();
        }

        private void wProductos_Load(object sender, EventArgs e)
        {
            cboBusqueda.SelectedIndex = 0;
        }


        public void update_grid()
        {
            //Selecciona las variables de busqueda segun la configuracion actual       
            
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:  listaProductos=BDproductos.BuscarProductos(); break;
                case 1:  listaProductos = BDproductos.BuscarProductos(Convert.ToInt32(txtBusqueda.Text+"%")); break;
                case 2:  listaProductos = BDproductos.BuscarProductos(txtBusqueda.Text+"%"); break;
                default: listaProductos = BDproductos.BuscarProductos(); break;
            }

            dataGridView1.DataSource = listaProductos;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[2].Width = 180;

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new w_productoNew().ShowDialog();
            if (w_productoNew.flag)
            {
                update_grid();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                new w_productoMod(Id).ShowDialog();
                if (w_productoMod.flag)
                {
                    update_grid();
                }

            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun producto");
            }

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar producto?", "ELIMINAR PRODUCTO", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int check = BDproductos.Delete(Id);

                    if (check == 0)
                    { MessageBox.Show("No se pudo eliminar producto guardado", "ELiminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { update_grid(); }
                }
                                
            }
            else
            {
                MessageBox.Show("Aun no se ha seleccionado ningun producto");
            }

        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            //Crea instancia para manejar pantalla de reporte guardando datos de formulario

            w_productoReport windowReport = new w_productoReport();

            if (listaProductos != null)
            {
                //ajuste de datos sobre ventana de reportes
                windowReport.dataclient = listaProductos;
                windowReport.ShowDialog();

            }
            else
            {
                MessageBox.Show("No hay datos para mostrar en reporte");
            }
        }
    }
}
