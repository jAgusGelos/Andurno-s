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

namespace WindowsFormsApp1.ABM.Clientes
{
    public partial class Frm_Clientes : Form
    {
        Comportamientos_Limpiar comportamientos = new Comportamientos_Limpiar();
        Clases_NG.Clientes.NG_Clientes clientes = new Clases_NG.Clientes.NG_Clientes();
        public Frm_Clientes()
        {
            InitializeComponent();
        }
        private void cargar_grilla(DataTable tabla)
        {
            dgv_clientes.DataSource = tabla;
            dgv_clientes.Columns[0].HeaderText = "CUIT";
            dgv_clientes.Columns[1].HeaderText = "Nombre";
            dgv_clientes.Columns[2].HeaderText = "Apellido";
            dgv_clientes.Columns[3].HeaderText = "Razon Social";
            dgv_clientes.Columns[4].HeaderText = "Condición Iva";
            dgv_clientes.Columns[5].HeaderText = "Condición Pago";
            dgv_clientes.Columns[6].HeaderText = "Mail";
            dgv_clientes.Columns[7].HeaderText = "Teléfono";
            dgv_clientes.Columns[8].HeaderText = "Domicilio Comercial";
            dgv_clientes.Columns[9].HeaderText = "Domicilio Entrega";
            tabla = new DataTable();



        }

        private void limpiar()
        {
            comportamientos.limpiar_txt(txt_Apellido, txt_CUIT, txt_Nombre, txt_Razon_Social);
            comportamientos.limpiar_chk(chk_todos);
        }

        private void limpiar_Grilla()
        {
            comportamientos.limpiar_grilla(dgv_clientes);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_Apellido.Text.Trim() == "" && txt_CUIT.Text.Trim() == "" 
                && txt_Nombre.Text.Trim() == "" && txt_Razon_Social.Text.Trim() == ""
                && chk_todos.Checked == false)
            {
                MessageBox.Show("No ha seleccionado ningún parámetro.");
            }
            else
            {
                DataTable tabla = new DataTable();
                if (txt_CUIT.Text.Trim() != "")
                {
                    tabla = clientes.buscar_id(txt_CUIT.Text);
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }
                if (chk_todos.Checked)
                {
                    tabla = clientes.buscar_todos();
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }

                if (txt_Nombre.Text.Trim() != "" && txt_Apellido.Text.Trim() != "")
                {
                    //Buscar por nombre y apellido
                    tabla = clientes.buscar_nombre_apellido(txt_Nombre.Text, txt_Apellido.Text);
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }
                if (txt_Apellido.Text.Trim() != "")
                {
                    //Buscar por apellidot
                    tabla = clientes.buscar_apellido(txt_Apellido.Text);
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }
                if (txt_Nombre.Text.Trim() != "")
                {
                    //Buscar por Nombre
                    tabla = clientes.buscar_nombre(txt_Nombre.Text);
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }
                if(txt_Razon_Social.Text.Trim() != "")
                {
                    //Buscar por razon social
                    tabla = clientes.buscar_razonSocial(txt_Razon_Social.Text);
                    cargar_grilla(tabla);
                    limpiar();
                    return;
                }
                if (tabla.Rows.Count == 0) MessageBox.Show("No se encontraron resultados");

            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Frm_Nuevo_Cliente nuevo = new Frm_Nuevo_Cliente();
            nuevo.ShowDialog();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if(dgv_clientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún cliente.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar?", "Aviso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) this.Close();
                
            }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if(dgv_clientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún cliente.");
            }
            else
            {
                Frm_Modificar_Cliente modif = new Frm_Modificar_Cliente();
                modif.iD_cliente = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
                modif.ShowDialog();
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cuenta_Click(object sender, EventArgs e)
        {
            if (dgv_clientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún cliente.");
            }
            else
            {
                Frm_Cuenta_Cliente cuenta = new Frm_Cuenta_Cliente();
                cuenta.ShowDialog();
                cuenta.iD_cliente = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            }
            
        }
    }
}
