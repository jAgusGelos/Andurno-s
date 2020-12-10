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
using WindowsFormsApp1.ABM.Productos;
using WindowsFormsApp1.ABM.Proveedores;
using WindowsFormsApp1.Compras;
using WindowsFormsApp1.Cotizaciones;
using WindowsFormsApp1.Remitos;
using WindowsFormsApp1.Transacciones;

namespace WindowsFormsApp1.Menues
{
    public partial class Frm_Inicio : Form
    {
        
        public Frm_Inicio()
        {
            InitializeComponent();
        }
         
        private void Frm_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void nuevaCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Pedido nuevo = new Frm_Pedido();
            nuevo.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Clientes nuevo = new Frm_Clientes();
            nuevo.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Cliente nuev = new Frm_Nuevo_Cliente();
        }

        private void cuentasClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cuenta_Cliente cuenta = new Frm_Cuenta_Cliente();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Productos nuevo = new Frm_Productos();
            nuevo.ShowDialog();

        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Producto prod = new Frm_Nuevo_Producto();
            prod.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Proveedores nuevo = new Frm_Proveedores();
            nuevo.ShowDialog();
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Proveedor prov = new Frm_Nuevo_Proveedor();
            prov.ShowDialog();
        }

        private void consultarCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consultar_Cotizaciones1 nuevo = new Frm_Consultar_Cotizaciones1();
            nuevo.ShowDialog();
        }

        private void nuevoRemitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Remito remito = new Frm_Remito();
            remito.ShowDialog();
        }

        private void consultarRemitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consultar_Remitos rem = new Frm_Consultar_Remitos();
            rem.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Compra compr = new Frm_Compra();
            compr.ShowDialog();
        }
    }
}
