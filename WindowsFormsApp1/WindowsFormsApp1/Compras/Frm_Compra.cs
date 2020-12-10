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
    public partial class Frm_Compra : Form
    {
        int i = -1;
        Clases_NG.NG_Productos productos = new Clases_NG.NG_Productos();
        public Frm_Compra()
        {
            InitializeComponent();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count == 0 || txt_cant.Text == "")
            {
                MessageBox.Show("Elija un producto y una cantidad.");
                return;
            }
            agregar(txt_cant.Text);

        }

        private void agregar(string cant)
        {
            i += 1;
            dgv_detalle.Rows.Add();
            dgv_detalle.Rows[i].Cells["id"].Value = dgv_productos.CurrentRow.Cells[0].Value;
            dgv_detalle.Rows[i].Cells["descripcion"].Value = dgv_productos.CurrentRow.Cells[1].Value;
            dgv_detalle.Rows[i].Cells["cantAdquirida"].Value = cant;
            txt_cantRap.Text = "";
            txt_cant.Text = "";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cantRap.Text == "" || txt_idRap.Text == "")
            {
                MessageBox.Show("Elija un producto y una cantidad.");
                return;
            }
            agregar(txt_cantRap.Text);
            txt_idRap.Text = "";

        }

        private void cargar_grilla(DataTable tabla)
        {
            dgv_productos.DataSource = tabla;
            dgv_productos.Columns[0].HeaderText = "ID";
            dgv_productos.Columns[1].HeaderText = "Descripción";
            dgv_productos.Columns[2].HeaderText = "Stock Disponible";
            dgv_productos.Columns[3].HeaderText = "Stock Minimo";
            dgv_productos.Columns[4].HeaderText = "Fecha Ultima Compra";
            dgv_productos.Columns[5].HeaderText = "Precio Provedor";
            dgv_productos.Columns[6].HeaderText = "Precio Lista";

        }

        private void Frm_Compra_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            Clases_NG.NG_Productos productos = new Clases_NG.NG_Productos();
            tabla = productos.buscar_todos();
            cargar_grilla(tabla);
            cmb_prov.cargar("Proveedores", "CUIT", "razonSocial");
            cmb_prov.SelectedValue = 0;
            dtp_fecha.Value = DateTime.Now;
        }

        private void dgv_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cant.Focus();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_productos.DataSource = "";
            if (txt_Nombre.Text.Trim() == "" && chk_todos.Checked == false && !chk_prov.Checked)
            {
                MessageBox.Show("No se ingresaron parámetros.");
            }
            else
            {
                DataTable tabla = new DataTable();
                if (chk_todos.Checked)
                {

                    tabla = productos.buscar_todos();
                    cargar_grilla(tabla);

                }
                else if (chk_prov.Checked)
                {
                    tabla = productos.buscar_proveedor(cmb_prov.SelectedValue.ToString());
                    cargar_grilla(tabla);
                }
                else
                {
                    tabla = productos.buscar_nombre(txt_Nombre.Text);
                    cargar_grilla(tabla);

                }
                if (tabla.Rows.Count == 0) MessageBox.Show("No se encontraron resultados");
            }
        }

        private void btn_comprar_Click(object sender, EventArgs e)
        {
            CT_compras transac = new CT_compras();

            Frm_VerCompra ver = new Frm_VerCompra();

            if (dgv_detalle.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos 1 producto.");
                return;
            }
            bool var = transac.comprar(Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy/MM/dd"), dgv_detalle);
            if (var) MessageBox.Show("Se cargó con exito la compra.");
            for (int i = 0; i < dgv_detalle.Rows.Count; i++)
            {
                Comprado buy = new Comprado();
                buy.id = dgv_detalle.Rows[i].Cells[0].Value.ToString();
                buy.descripcion = dgv_detalle.Rows[i].Cells[1].Value.ToString();
                buy.stockAdquirido = dgv_detalle.Rows[i].Cells[2].Value.ToString();
                buy.precio = dgv_detalle.Rows[i].Cells[3].Value.ToString();
                buy.precioLista = dgv_detalle.Rows[i].Cells[4].Value.ToString();
                ver.Datos.Add(buy);
            }

            ver.ShowDialog();
            this.Close();

        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Elija un producto.");
                return;
            }
            try
            {
                dgv_detalle.Rows.Remove(dgv_detalle.CurrentRow);
                i -= 1;

            }
            catch (Exception)
            {
            }
        }

        private void solo_numeros_add(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_add_Click(sender, e);
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void btn_agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_agregar_Click(sender, e);
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }

        }
    }
}
