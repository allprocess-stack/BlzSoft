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
    public partial class w_infoRegistro : Form
    {
        int ID;

        public w_infoRegistro(int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void w_infoRegistro_Load(object sender, EventArgs e)
        {
            Registro p = new Registro();
            p = BDregistros.Info(ID);

            //agrega informacion en text boxes
            txtTicket.Text = p.Guia;
            txtCliente.Text = p.Cliente;
            txtEstado.Text = p.Estado;
            txtRuc.Text = p.Ruc;            
            txtPlaca.Text = p.Placa;
            txtConductor.Text = p.Chofer;
            txtProducto.Text = p.Producto;
            txtModo.Text = p.Modo;
            txtPesoIn.Text = p.PesoIn;
            txtPesoOut.Text = p.PesoOut;
            txtPesoNeto.Text = p.PesoNeto;
            txtFechaIn.Text = p.FechaEntrada;
            txtFechaOut.Text = p.FechaSalida;
            txtObservaciones.Text = p.Observacion;
            txtUsuario.Text = p.Usuario;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            //muestra informacion de registro
            //agrega instancia para nueva ventana de reporte
            this.Close();

            Registro RE = new Registro();
            RE = BDregistros.Info(ID);

            w_inforegReport windowReport = new w_inforegReport();

            List<Registro> lstREG = new List<Registro>();
            lstREG.Add(RE);

            //obtiene variables de datos especiales en reporte
            VarRPT2 var = new VarRPT2();
            double pesoout, pesoin;
            if (double.TryParse(RE.PesoOut, out pesoout) && double.TryParse(RE.PesoIn, out pesoin))
                var.pesoNeto = Math.Abs(pesoout - pesoin);
            else
                var.pesoNeto = 0;

            //carga datos sobre ventana de reportes
            windowReport.datos.Add(var);
            windowReport.dataREG = lstREG;

            windowReport.ShowDialog();
        }
    }
}
