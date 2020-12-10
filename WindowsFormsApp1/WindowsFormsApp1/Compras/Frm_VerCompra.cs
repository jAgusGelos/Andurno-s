using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Compras
{
    public partial class Frm_VerCompra : Form
    {
        private List<Comprado> datos = new List<Comprado>();
        public Frm_VerCompra()
        {
            InitializeComponent();
        }

        internal List<Comprado> Datos { get => datos; set => datos = value; }

        private void Frm_VerCompra_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Datos", datos));
            this.reportViewer1.RefreshReport();
        }
    }
}
