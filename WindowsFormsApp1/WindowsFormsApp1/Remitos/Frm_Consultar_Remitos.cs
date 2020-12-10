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

namespace WindowsFormsApp1.Remitos
{
    public partial class Frm_Consultar_Remitos : Form
    {
        public Frm_Consultar_Remitos()
        {
            InitializeComponent();
        }
        C_Ver_Remito rem = new C_Ver_Remito();
        Comportamientos_Limpiar comportamientos = new Comportamientos_Limpiar();
        
        private void cargar_grilla(DataTable tabla)
        {
            if (tabla.Rows.Count == 0) { MessageBox.Show("No se encontraron resultados");return; };
            dgv_remitos.DataSource = tabla;
            dgv_remitos.Columns[0].HeaderText = "Nro Sucursal";
            dgv_remitos.Columns[1].HeaderText = "Nro Remito";
            dgv_remitos.Columns[2].HeaderText = "Cliente";
            dgv_remitos.Columns[3].HeaderText = "Razon Social";
            dgv_remitos.Columns[4].HeaderText = "Fecha";
            dgv_remitos.Columns[5].HeaderText = "Estado";

            tabla = new DataTable(); 

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            comportamientos.limpiar_grilla(dgv_remitos);

            if (txt_cuit.Text == "" && txt_nro.Text == "" && txt_Razon_Social.Text == "" && chk_todos.Checked == false && !ch_fecha.Checked && !chk_estado.Checked)
            {
                MessageBox.Show("Ingrese un parámetro.");
                return;
            }
            DataTable tabla = new DataTable();
            if (txt_cuit.Text != "" && !ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_cuit(txt_cuit.Text);
                cargar_grilla(tabla);
                return;
            }
            if (txt_nro.Text != "" && !ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_nro(txt_nro.Text);
                cargar_grilla(tabla);
                return;

            }
            if (txt_Razon_Social.Text != "" && !ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_rz(txt_Razon_Social.Text);
                cargar_grilla(tabla);
                return;
            }
            if (chk_todos.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_todos();
                cargar_grilla(tabla);
                return;
            }
            if (txt_cuit.Text == "" && txt_nro.Text == ""
                && txt_Razon_Social.Text == "" && chk_todos.Checked == false
                 && ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_fecha(dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }
            if (txt_cuit.Text != "" && ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_cuit_fecha(txt_cuit.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }

            if (txt_Razon_Social.Text != "" && ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_cuit_fecha(txt_Razon_Social.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }

            //--------------------------Filtro con Estados--------------------------------

            
             
            if (txt_cuit.Text != "" && !ch_fecha.Checked && chk_estado.Checked)
            {
                tabla = rem.buscar_cuit_estado(txt_cuit.Text,cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }
            if (txt_nro.Text != "" && !ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_nro(txt_nro.Text);
                cargar_grilla(tabla);
                return;

            }
            if (txt_Razon_Social.Text != "" && !ch_fecha.Checked && chk_estado.Checked)
            {
                tabla = rem.buscar_rz_estado(txt_Razon_Social.Text, cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }
            if (chk_todos.Checked && chk_estado.Checked)
            {
                tabla = rem.buscar_todos_estado(cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }
            if (txt_cuit.Text == "" && txt_nro.Text == ""
                && txt_Razon_Social.Text == "" && chk_todos.Checked == false
                 && ch_fecha.Checked && chk_estado.Checked)
            {
                tabla = rem.buscar_fecha_estado(dtp_fecha.Value.ToString("yyyy/MM/dd"),cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }
            if (txt_cuit.Text != "" && ch_fecha.Checked && chk_estado.Checked)
            {
                tabla = rem.buscar_cuit_fecha_estado(txt_cuit.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"), cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }

            if (txt_Razon_Social.Text != "" && ch_fecha.Checked && !chk_estado.Checked)
            {
                tabla = rem.buscar_rz_fecha_estado(txt_Razon_Social.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"), cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }

            if (chk_estado.Checked)
            {
                tabla = rem.buscar_todos_estado(cmb_Estado.SelectedValue.ToString());
                cargar_grilla(tabla);
                return;
            }



        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (dgv_remitos.SelectedCells.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún cliente.");
            }
            else
            {
                Frm_VerRemito rem = new Frm_VerRemito();
                rem.nro_Remito = dgv_remitos.CurrentRow.Cells[1].Value.ToString();
                rem.nro_Suc = dgv_remitos.CurrentRow.Cells[0].Value.ToString();
                rem.ShowDialog();
            }
        }

        private void Frm_Consultar_Remitos_Load(object sender, EventArgs e)
        {
            cmb_Estado.cargar("EstadosRemito", "id_estado", "descripcion");
            cmb_Estado.SelectedValue = 0;
            
        }

        private void txt_cuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void solo_numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_buscar_Click(sender, e);
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

