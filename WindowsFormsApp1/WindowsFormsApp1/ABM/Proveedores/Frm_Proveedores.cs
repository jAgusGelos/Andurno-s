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

namespace WindowsFormsApp1.ABM.Proveedores
{
    public partial class Frm_Proveedores : Form
    {
        Comportamientos_Limpiar comportamientos = new Comportamientos_Limpiar();
        public Frm_Proveedores()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            comportamientos.limpiar_txt(txt_CUIT, txt_RazonSocial,txt_Apellido,txt_Nombre);
            comportamientos.limpiar_chk(chk_todos);
        }
        private void cargar_grilla(DataTable tabla)
        {

            dgv_proveedores.DataSource = tabla;
            dgv_proveedores.Columns[0].HeaderText = "CUIT";
            dgv_proveedores.Columns[1].HeaderText = "Nombre";
            dgv_proveedores.Columns[2].HeaderText = "Apellido";
            dgv_proveedores.Columns[3].HeaderText = "Razon Social";
            dgv_proveedores.Columns[4].HeaderText = "Mail";
            dgv_proveedores.Columns[5].HeaderText = "Telefono";
            tabla = new DataTable();      
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            comportamientos.limpiar_grilla(dgv_proveedores);
            if (txt_CUIT.Text.Trim() == "" && txt_RazonSocial.Text.Trim() == "" && chk_todos.Checked == false && txt_Nombre.Text == ""
                && txt_Apellido.Text == "")
            {
                MessageBox.Show("No se ingresaron parámetros.");
            }
            else
            {
                NG_Proveedores prov = new NG_Proveedores();
                DataTable tabla = new DataTable();
                if (chk_todos.Checked)
                {
                    tabla = prov.buscar_todos();
                    cargar_grilla(tabla);
                    limpiar();
                }
                else if (txt_RazonSocial.Text.Trim() != "")
                {
                    //Buscar por razon Social.
                    tabla = prov.buscar_razonSocial(txt_RazonSocial.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                else if (txt_CUIT.Text != "")
                {
                    // Buscar por CUIT
                    tabla = prov.buscar_CUIT(txt_CUIT.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                else if(txt_Apellido.Text != "" && txt_Nombre.Text != "")
                {
                    // Buscar nombre y apellido
                    tabla = prov.buscar_nombre_apellido(txt_Nombre.Text,txt_Apellido.Text);
                    cargar_grilla(tabla);
                    limpiar();

                }
                else if(txt_Apellido.Text != "")
                {
                    // Buscar apellido
                    tabla = prov.buscar_apellido(txt_Apellido.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                else if (txt_Nombre.Text != "")
                {
                    // Buscar nombre 
                    tabla = prov.buscar_nombre(txt_Nombre.Text);
                    cargar_grilla(tabla);
                    limpiar();
                }
                if (tabla.Rows.Count == 0) MessageBox.Show("No se encontraron resultados");
                
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Proveedor nuevo = new Frm_Nuevo_Proveedor();
            nuevo.ShowDialog();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_proveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún provedor.");
            }
            else
            {
                Frm_Modificar_Proveedor modif = new Frm_Modificar_Proveedor();
                modif.idProveedor = dgv_proveedores.CurrentRow.Cells[0].Value.ToString();
                modif.ShowDialog();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_proveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún provedor.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar?", "Aviso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NG_Proveedores prov = new NG_Proveedores();
                    prov.eliminar(dgv_proveedores.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
