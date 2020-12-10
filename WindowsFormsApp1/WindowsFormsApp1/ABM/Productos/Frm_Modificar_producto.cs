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
    public partial class Frm_Modificar_producto : Form
    {
        public string idProducto;
        Clases_NG.NG_Productos_Modificiacion productos = new Clases_NG.NG_Productos_Modificiacion();
        public Frm_Modificar_producto()
        {
            InitializeComponent();
        }

        private void Frm_Modificar_producto_Load(object sender, EventArgs e)
        {
            //Buscar los datos del producto e insertarlos en los txt BOX
            
            txt_id_interno.Text = idProducto;
            DataTable tabla  = productos.buscar_id(idProducto);
            txt_Nombre.Text = tabla.Rows[0][1].ToString();
            txt_stock.Text = tabla.Rows[0][3].ToString();
            txt_venta.Text = tabla.Rows[0][5].ToString();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_id_interno.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un ID.");
                txt_id_interno.Focus();
                return;
            }
            Clases_NG.NG_Productos_Modificiacion modif = new Clases_NG.NG_Productos_Modificiacion();
            modif.insertar(txt_id_interno.Text, txt_Nombre.Text, txt_stock.Text, txt_venta.Text);
            MessageBox.Show("Se ha realizado la modificación con éxito.");
            this.Close();
        }
    }
}

