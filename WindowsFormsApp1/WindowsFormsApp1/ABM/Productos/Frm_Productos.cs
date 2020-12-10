using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.ABM.Productos
{
    public partial class Frm_Productos : Form
    {
        Comportamientos_Limpiar comportamientos = new Comportamientos_Limpiar();
        public Frm_Productos()
        {
            InitializeComponent();
        }

        Clases_NG.NG_Productos productos = new NG_Productos();

        public void limpiar()
        {

            comportamientos.limpiar_txt(txt_ID, txt_Nombre);
            comportamientos.limpiar_chk(chk_todos);
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            comportamientos.limpiar_grilla(dgv_productos);
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
                    limpiar();
                }
                else if (txt_ID.Text != "")
                {
                    tabla = productos.buscar_id(txt_ID.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                else
                {
                    tabla = productos.buscar_nombre(txt_Nombre.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                if (tabla.Rows.Count == 0) MessageBox.Show("No se encontraron resultados");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún producto.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar?", "Aviso", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes) productos.eliminar(dgv_productos.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Producto nuevo = new Frm_Nuevo_Producto();
            nuevo.ShowDialog();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_productos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún producto.");
            }
            else
            {
                //Mandar el Frm con los parámetros necesarios.
                Frm_Modificar_producto modif = new Frm_Modificar_producto();
                try
                {
                    modif.idProducto = dgv_productos.SelectedCells[0].Value.ToString();
                    modif.ShowDialog();
                }
                catch (Exception)
                {
                }
                
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
