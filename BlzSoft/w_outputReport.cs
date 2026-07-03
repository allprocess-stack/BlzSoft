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
    public partial class w_outputReport : Form
    {
        public List<Registro> dataREG = new List<Registro>();
        public List<VarRPT2> datos = new List<VarRPT2>();
        
        public w_outputReport()
        {
            InitializeComponent();
        }

        private void w_outputReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataREG));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", datos));

            this.reportViewer1.RefreshReport();
        }
    }
}
