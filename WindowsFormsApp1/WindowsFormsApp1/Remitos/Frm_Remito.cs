using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ABM.Productos;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Remitos
{
    public partial class Frm_Remito : Form
    {
        CT_Remito transac = new CT_Remito();
        int i = -1;
        bool busco = false;
        Clases_NG.NG_Productos productos = new NG_Productos();
        public Frm_Remito()
        {
            InitializeComponent();
        }

        private void cargar_grilla(DataTable tabla)
        {
            dgv_productos.DataSource = tabla;
            dgv_productos.Columns[0].HeaderText = "ID";
            dgv_productos.Columns[1].HeaderText = "Descripción";
            dgv_productos.Columns[2].HeaderText = "Stock Disponible";
            dgv_productos.Columns[3].HeaderText = "Stock Minimo";
            dgv_productos.Columns[4].HeaderText = "Fecha Última Compra";
            dgv_productos.Columns[5].HeaderText = "Precio";

        }

        private void Frm_Remito_Load(object sender, EventArgs e)
        {
            DataTable tabla = transac.buscar_max();

            if (tabla.Rows.Count == 0) txt_nro.Text = "1";

            txt_nro.Text = (int.Parse(tabla.Rows[0][0].ToString()) + 1).ToString();
            tabla = productos.buscar_todos();
            cargar_grilla(tabla);
            cmb_estado.cargar("EstadosRemito", "id_estado", "descripcion");
            cmb_estado.SelectedValue = 0;
            dtp_fecha.Value = DateTime.Now;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_cuit.Text == "")
            {
                MessageBox.Show("Ingrese un CUIT");
                return;
            }
            DataTable tabla = transac.buscar_id(txt_cuit.Text);


            if (tabla.Rows.Count == 0) { MessageBox.Show("No se encontró el cliente."); return; }

            //Si llego acá paso las comprobaciones.

            if (tabla.Rows[0][1].ToString() == "")
            {
                txt_rz.Text = tabla.Rows[0][3].ToString();
            }
            else
            {
                txt_rz.Text = tabla.Rows[0][1].ToString() + tabla.Rows[0][2].ToString();
            }
            txt_iva.Text = tabla.Rows[0][4].ToString();
            txt_pago.Text = tabla.Rows[0][5].ToString();
            txt_dir.Text = tabla.Rows[0][8].ToString();
            busco = true;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count == 0 || txt_cant.Text == "")
            {
                MessageBox.Show("Elija un producto y una cantidad.");
                return;
            }
            if (txt_cantDes.Text != "" && int.Parse(txt_cantDes.Text) > int.Parse(txt_cant.Text))
            {
                MessageBox.Show("La cantidad despachada no puede superar la cantidad pedida");
                return;
            }
            if (int.Parse(txt_cant.Text) > int.Parse(dgv_productos.CurrentRow.Cells[2].Value.ToString()))
            {
                MessageBox.Show("La cantidad supera el stock actual.");
                return;
            }
            i += 1;
            dgv_detalle.Rows.Add();
            dgv_detalle.Rows[i].Cells["codigo"].Value = dgv_productos.CurrentRow.Cells[0].Value;
            dgv_detalle.Rows[i].Cells["descripcion"].Value = dgv_productos.CurrentRow.Cells[1].Value;
            dgv_detalle.Rows[i].Cells["cantPed"].Value = txt_cant.Text;


            if (txt_cantDes.Text == "")
            {
                dgv_detalle.Rows[i].Cells["cantDesp"].Value = txt_cant.Text;
                dgv_productos.CurrentRow.Cells[2].Value = int.Parse(dgv_productos.CurrentRow.Cells[2].Value.ToString()) - int.Parse(txt_cant.Text);
            }
            else
            {
                dgv_detalle.Rows[i].Cells["cantDesp"].Value = txt_cantDes.Text;
                dgv_productos.CurrentRow.Cells[2].Value = int.Parse(dgv_productos.CurrentRow.Cells[2].Value.ToString()) - int.Parse(txt_cantDes.Text);
            }

            txt_cant.Text = "";
            txt_cantDes.Text = "";

        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Elija un producto.");
                return;
            }
            string cod = dgv_detalle.CurrentRow.Cells[0].Value.ToString();
            int x = 0, y = 0;
            try
            {

                for (int i = 0; i < dgv_productos.Rows.Count - 1; i++)
                {
                    if (dgv_productos.Rows[i].Cells[0].Value.ToString() == cod)
                    {
                        x = i;
                        y = int.Parse(dgv_productos.Rows[i].Cells[2].Value.ToString());
                        break;
                    }

                }
                dgv_productos.Rows[x].Cells[2].Value = y + int.Parse(dgv_detalle.CurrentRow.Cells[3].Value.ToString());
                dgv_detalle.Rows.Remove(dgv_detalle.CurrentRow);
                i -= 1;

            }
            catch (Exception)
            {
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (!busco)
            {
                MessageBox.Show("Ingrese un cliente.");
                return;
            }
            if (cmb_estado.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Ingrese un estado");
                return;
            }

            if (dgv_detalle.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos 1 producto.");
                return;
            }

            bool var = transac.crear_Remito(txt_nro.Text, txt_cuit.Text, Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy/MM/dd"), dgv_detalle, txt_obs.Text, cmb_estado.SelectedValue.ToString());
            if (var) MessageBox.Show("Se creó con exito.");
            Frm_VerRemito rem = new Frm_VerRemito();
            rem.nro_Suc = "1";
            rem.nro_Remito = txt_nro.Text;
            rem.ShowDialog();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // boton buscar prodcutos
        {
            dgv_productos.DataSource = "";
            if (txt_ID.Text.Trim() == "" && txt_Nombre.Text.Trim() == "" && chk_todos.Checked == false)
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
                else if (txt_ID.Text != "")
                {
                    tabla = productos.buscar_id(txt_ID.Text);
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

        private void btn_agregar_item_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Producto prod = new Frm_Nuevo_Producto();
            prod.ShowDialog();
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    txt_pago.Text = "";
                    txt_iva.Text = "";
                    txt_rz.Text = "";
                    txt_dir.Text = "";
                    //BUSCAR DATOS DUEÑO
                    btn_buscar_Click(sender, e);



                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }
            }
        }

        private void solo_numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
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
