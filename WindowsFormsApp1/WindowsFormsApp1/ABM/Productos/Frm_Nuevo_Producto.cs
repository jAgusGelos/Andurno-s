using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ABM.Productos
{
    public partial class Frm_Nuevo_Producto : Form
    {
        public Frm_Nuevo_Producto()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_id_interno.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un ID.");
                txt_id_interno.Focus();
                return;
            }
            Clases_NG.NG_Productos_Alta nuevo = new Clases_NG.NG_Productos_Alta();
            nuevo.insertar(txt_id_interno.Text, txt_Nombre.Text, txt_stock.Text, txt_venta.Text, txt_stockActual.Text, txt_precioLista.Text);
            MessageBox.Show("Se ha creado un nuevo producto");
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    }

