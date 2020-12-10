using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases_Reportes;

namespace WindowsFormsApp1.Frm_reportes
{
    public partial class Frm_NotaCotizacion : Form
    {
        public string nro_sucursal, nro_nc;
        public Frm_NotaCotizacion()
        {
            InitializeComponent();
        }

        private void Frm_NotaCotizacion_Load(object sender, EventArgs e)
        {
            C_Nota_Cotizacion coti = new C_Nota_Cotizacion();
            DataTable tabla = coti.nota_cotizacion(nro_sucursal, nro_nc);
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
                return;
            }
            notaCreditoBindingSource.DataSource = tabla;
            tabla = coti.detalle_nota_cotizacion(nro_sucursal, nro_nc);
            detalleNCBindingSource1.DataSource = tabla;
            tabla = coti.total_nota_cotizacion(nro_sucursal, nro_nc);
            totalBindingSource.DataSource = tabla;
            rp_NC.RefreshReport();



        }
    }
}
