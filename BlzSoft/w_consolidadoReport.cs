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
    public partial class w_consolidadoReport : Form
    {
        public List<Registro> dataDespachos = new List<Registro>();
        public List<VarRPT3> datos = new List<VarRPT3>();
        public w_consolidadoReport()
        {
            InitializeComponent();
        }

        private void w_consolidadoReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataDespachos));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", datos));
            this.reportViewer1.RefreshReport();
        }
    }
}
