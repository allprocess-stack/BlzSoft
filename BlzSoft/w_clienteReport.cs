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
    public partial class w_clienteReport : Form
    {
        public List<Empresa> dataclient = new List<Empresa>();
        public List<VarRPT1> datos = new List<VarRPT1>();
        public w_clienteReport()
        {
            InitializeComponent();
        }

        private void w_clienteReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataclient));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", datos));
            
            this.reportViewer1.RefreshReport();
        }
    }
}
