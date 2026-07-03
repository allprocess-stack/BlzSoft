namespace BlzSoft
{
    partial class w_outputPartialReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(w_outputPartialReport));
            this.RegistroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VarRPT2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RegistroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VarRPT2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RegistroBindingSource
            // 
            this.RegistroBindingSource.DataSource = typeof(BlzSoft.Registro);
            // 
            // VarRPT2BindingSource
            // 
            this.VarRPT2BindingSource.DataSource = typeof(BlzSoft.VarRPT2);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.RegistroBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.VarRPT2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BlzSoft.ReportSalida.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(890, 496);
            this.reportViewer1.TabIndex = 2;
            // 
            // w_outputPartialReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 496);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "w_outputPartialReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket de Salida";
            this.Load += new System.EventHandler(this.w_outputPartialReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RegistroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VarRPT2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RegistroBindingSource;
        private System.Windows.Forms.BindingSource VarRPT2BindingSource;
    }
}