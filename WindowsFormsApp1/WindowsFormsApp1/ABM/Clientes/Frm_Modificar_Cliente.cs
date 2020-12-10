using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ABM.Clientes
{    
    public partial class Frm_Modificar_Cliente : Form
    {
        Clases_NG.Clientes.NG_Clientes_Modificacion modif = new Clases_NG.Clientes.NG_Clientes_Modificacion();
        public string iD_cliente;
        public Frm_Modificar_Cliente()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            

            if (txt_CUIT.Text.Trim() == "")
            {
                MessageBox.Show("Falta el CUIT");
                txt_CUIT.Focus();
                return;
            }
            if (txt_Apellido.Text.Trim() == "" && txt_Nombre.Text.Trim() == "" && txt_RazonSocial.Text.Trim() == "")
            {
                MessageBox.Show("Complete nombre y apellido o Razon Social");
                return;
            }
            if ((txt_Apellido.Text.Trim() == "" && txt_Nombre.Text.Trim() != "") ||
                (txt_Nombre.Text.Trim() == "" && txt_Apellido.Text.Trim() != ""))
            {
                MessageBox.Show("Complete ambos campos nombre y apellido.");
                txt_Nombre.Focus();
                return;
            }
            if (cmb_IVA.SelectedValue.ToString() == "") 
            {
                MessageBox.Show("Seleccione la condición frente al IVA");
                cmb_IVA.Focus();
                return;
            }
            
            modif.nuevo(txt_CUIT.Text, txt_Nombre.Text, txt_Apellido.Text, txt_RazonSocial.Text,
                cmb_IVA.SelectedValue.ToString(), cmb_Pagos.SelectedValue.ToString(), txt_mail.Text, txt_tel.Text,
                txt_DirComercial.Text, txt_DirEntrega.Text);
        }

        private void Frm_Modificar_Cliente_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = modif.buscar_id(iD_cliente);
            txt_CUIT.Text = iD_cliente;
            txt_Nombre.Text = tabla.Rows[0][1].ToString();
            txt_Apellido.Text = tabla.Rows[0][2].ToString();
            txt_RazonSocial.Text = tabla.Rows[0][3].ToString();
            cmb_IVA.Text = tabla.Rows[0][4].ToString();
            cmb_Pagos.Text = tabla.Rows[0][5].ToString();            
            txt_mail.Text = tabla.Rows[0][6].ToString();
            txt_tel.Text = tabla.Rows[0][7].ToString();
            txt_DirComercial.Text = tabla.Rows[0][8].ToString();
            txt_DirEntrega.Text = tabla.Rows[0][9].ToString();

        }
    }
}
