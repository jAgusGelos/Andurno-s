using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Remitos
{
    public partial class Frm_VerRemito : Form
    {
        public string nro_Remito, nro_Suc;
        public Frm_VerRemito()
        {
            InitializeComponent();
        }

        private void Frm_VerRemito_Load(object sender, EventArgs e)
        {
            CT_Remito rem = new CT_Remito();
            DataTable tabla = rem.buscar_remito(nro_Suc, nro_Remito);
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
                return;
            }
            remitoBindingSource.DataSource = tabla;
            tabla = rem.buscar_detalle_remito(nro_Suc, nro_Remito);
            detaleBindingSource.DataSource = tabla;
            tabla = rem.buscar_cliente(nro_Suc, nro_Remito);
            clienteBindingSource1.DataSource = tabla;
            rp_rem.RefreshReport();

        }
    }
}
