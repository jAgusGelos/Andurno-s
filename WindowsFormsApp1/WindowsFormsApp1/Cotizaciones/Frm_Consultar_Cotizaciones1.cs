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
using WindowsFormsApp1.Frm_reportes;

namespace WindowsFormsApp1.Cotizaciones
{
    public partial class Frm_Consultar_Cotizaciones1 : Form
    {
        C_Consultar_Cotizaciones coti = new C_Consultar_Cotizaciones();

        Comportamientos_Limpiar comportamientos = new Comportamientos_Limpiar();
        public Frm_Consultar_Cotizaciones1()
        {
            InitializeComponent();
        }
        private void cargar_grilla(DataTable tabla)
        {
            if (tabla.Rows.Count == 0) { MessageBox.Show("No se encontraron resultados"); return; };
            dgv_clientes.DataSource = tabla;
            dgv_clientes.Columns[0].HeaderText = "Nro Sucursal";
            dgv_clientes.Columns[1].HeaderText = "Nro Cotización";
            dgv_clientes.Columns[2].HeaderText = "Cliente";
            dgv_clientes.Columns[3].HeaderText = "Fecha";            
            tabla = new DataTable();



        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            comportamientos.limpiar_grilla(dgv_clientes);
            
            if(txt_cuit.Text == "" && txt_nro.Text == "" && txt_Razon_Social.Text == "" && chk_todos.Checked == false && !ch_fecha.Checked)
            {
                MessageBox.Show("Ingrese un parámetro.");
                return;
            }
            DataTable tabla = new DataTable();
            if (txt_cuit.Text != "" && !ch_fecha.Checked )
            {
                tabla = coti.buscar_cuit(txt_cuit.Text);
                cargar_grilla(tabla);
                return;
            }
            if (txt_nro.Text != "" && !ch_fecha.Checked)
            {
                tabla = coti.buscar_nro(txt_nro.Text);
                cargar_grilla(tabla);
                return;

            }
            if (txt_Razon_Social.Text != "" && !ch_fecha.Checked)
            {
                tabla = coti.buscar_rz(txt_Razon_Social.Text);
                cargar_grilla(tabla);
                return;
            }
            if (chk_todos.Checked)
            {
                tabla = coti.buscar_todos();
                cargar_grilla(tabla);
                return;
            }
            if(txt_cuit.Text == "" && txt_nro.Text == "" 
                && txt_Razon_Social.Text == "" && chk_todos.Checked == false
                 && ch_fecha.Checked)
            {
                tabla = coti.buscar_fecha(dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }
            if (txt_cuit.Text != "" && ch_fecha.Checked)
            {
                tabla = coti.buscar_cuit_fecha(txt_cuit.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }

            if (txt_Razon_Social.Text != "" && ch_fecha.Checked)
            {
                tabla = coti.buscar_cuit_fecha(txt_Razon_Social.Text, dtp_fecha.Value.ToString("yyyy/MM/dd"));
                cargar_grilla(tabla);
                return;
            }





           
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (dgv_clientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún cliente.");
            }
            else
            {
                Frm_NotaCotizacion nc = new Frm_NotaCotizacion();
                nc.nro_nc = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
                nc.nro_sucursal = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
                nc.ShowDialog();                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Consultar_Cotizaciones1_Load(object sender, EventArgs e)
        {

        }

        private void solo_numeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_buscar_Click(sender, e);
            }

            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
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
