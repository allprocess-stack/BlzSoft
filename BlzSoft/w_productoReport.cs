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
    public partial class w_productoReport : Form
    {
        public List<Producto> dataclient = new List<Producto>();
        public w_productoReport()
        {
            InitializeComponent();
        }

        private void w_productoReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataclient));
            this.reportViewer1.RefreshReport();
        }
    }
}
