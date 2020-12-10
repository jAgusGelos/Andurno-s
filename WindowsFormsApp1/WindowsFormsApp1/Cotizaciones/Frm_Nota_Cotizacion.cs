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
using WindowsFormsApp1.Frm_reportes;

namespace WindowsFormsApp1.Transacciones
{
    public partial class Frm_Pedido : Form
    {
        Clases_NG.Transacciones.NG_Transacciones transac = new Clases_NG.Transacciones.NG_Transacciones();
        bool busco = false;
        int i = -1;
        Clases_NG.NG_Productos productos = new NG_Productos();
        public Frm_Pedido()
        {
            InitializeComponent();

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

        private void Frm_Pedido_Load(object sender, EventArgs e)
        {
            DataTable tabla = transac.buscar_max();
            
        
            txt_nro.Text = (int.Parse(tabla.Rows[0][0].ToString()) + 1).ToString() ;
            tabla = transac.buscar_productos();
            cargar_grilla(tabla);
            dtp_fecha.Value = DateTime.Now;
           
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ABM.Clientes.Frm_Nuevo_Cliente nuevo = new ABM.Clientes.Frm_Nuevo_Cliente();
            nuevo.ShowDialog();
        }

        private void cargar_grilla(DataTable tabla)
        {
            dgv_productos.DataSource = tabla;
            dgv_productos.Columns[0].HeaderText = "ID";
            dgv_productos.Columns[1].HeaderText = "Descripción";
            dgv_productos.Columns[2].HeaderText = "Stock Disponible";
            dgv_productos.Columns[3].HeaderText = "Stock Minimo";
            dgv_productos.Columns[4].HeaderText = "Fecha Ultima Compra";
            dgv_productos.Columns[5].HeaderText = "Precio";



        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if(dgv_productos.SelectedRows.Count == 0 || txt_cant.Text == "")
            {
                MessageBox.Show("Elija un producto y una cantidad.");
                return;
            }
            //if (int.Parse(txt_cant.Text) > int.Parse(dgv_productos.CurrentRow.Cells[2].Value.ToString()))
            //{
            //    MessageBox.Show("La cantidad supera el stock actual.");
            //    return;
            //}
            i += 1;
            dgv_detalle.Rows.Add();            
            dgv_detalle.Rows[i].Cells["codigo"].Value = dgv_productos.CurrentRow.Cells[0].Value;
            dgv_detalle.Rows[i].Cells["descripcion"].Value = dgv_productos.CurrentRow.Cells[1].Value;
            dgv_detalle.Rows[i].Cells["precioUnit"].Value = dgv_productos.CurrentRow.Cells[5].Value;
            dgv_detalle.Rows[i].Cells["cant"].Value = txt_cant.Text;
            txt_cant.Text = "";
            dgv_detalle.Rows[i].Cells["precioIva"].Value = (float.Parse(dgv_productos.CurrentRow.Cells[5].Value.ToString()) * 1.21).ToString();
            dgv_detalle.Rows[i].Cells["precioTotal"].Value = float.Parse(dgv_detalle.Rows[i].Cells["cant"].Value.ToString())
                * float.Parse(dgv_detalle.Rows[i].Cells["precioIva"].Value.ToString());


            setPrecio();
            
        }

        public void setPrecio()
        {
            float acu = 0;
            for (int j = 0; j <= i; j++)
            {
                acu += float.Parse(dgv_detalle.Rows[j].Cells["precioTotal"].Value.ToString());
            }           
            lbl_Precio.Text = acu.ToString();
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count == 0 )
            {
                MessageBox.Show("Elija un producto.");
                return;
            }
            try
            {
                dgv_detalle.Rows.Remove(dgv_detalle.CurrentRow);
                i -= 1;
                setPrecio();

            }
            catch (Exception)
            {

                throw;
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
            if(dgv_detalle.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos 1 producto.");
                return;
            }
            bool var =  transac.crear_NC(String.Format("{0:0000}",txt_cuit.Text), String.Format("{0:0000}", txt_nro.Text), Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy/MM/dd"), dgv_detalle, Convert.ToDateTime(dtp_fecha.Text).AddMonths(1).ToString("yyyy/MM/dd"));
            if (var) MessageBox.Show("Se creó con exito.");
            Frm_NotaCotizacion nota = new Frm_NotaCotizacion();
            nota.nro_nc = txt_nro.Text;
            nota.nro_sucursal = "1";
            nota.ShowDialog();
            this.Close();
        }

        private void btn_agregar_item_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Producto prod = new Frm_Nuevo_Producto();
            prod.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_productos.DataSource = "";
            if (txt_ID.Text.Trim() == "" && txt_Nombre.Text.Trim() == "" && chk_todos.Checked == false )
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

        private void dgv_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cant.Focus();
        }

        private void solo_numeros(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
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
                    e.Handled = true;



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
    }
}
