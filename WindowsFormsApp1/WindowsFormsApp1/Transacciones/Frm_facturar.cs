using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ABM.Clientes;

namespace WindowsFormsApp1.Transacciones
{
    public partial class Frm_facturar : Form
    {
        public Frm_facturar()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Frm_Cuenta_Cliente cliente = new Frm_Cuenta_Cliente();
            //BUSCAR SI EXISTE EL CUIT;
            cliente.iD_cliente = txt_CUIT.Text;
            cliente.ShowDialog();
            this.Close();
        }
    }
}
