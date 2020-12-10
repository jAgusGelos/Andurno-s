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
    public partial class Frm_Nuevo_Cliente : Form
    {
        public Frm_Nuevo_Cliente()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if(txt_CUIT.Text.Trim() == "")
            {
                MessageBox.Show("Falta el CUIT");
                txt_CUIT.Focus();
                return;
            }
            if(txt_Apellido.Text.Trim() == "" && txt_Nombre.Text.Trim() == "" && txt_RazonSocial.Text.Trim() == "")
            {
                MessageBox.Show("Complete nombre y apellido o Razon Social");
                return;
            }
            if ((txt_Apellido.Text.Trim() == "" && txt_Nombre.Text.Trim() != "")||
                (txt_Nombre.Text.Trim() == "" && txt_Apellido.Text.Trim() != ""))
            {
                MessageBox.Show("Complete ambos campos nombre y apeliido.");
                txt_Nombre.Focus();
                return;
            }
            if (cmb_IVA.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la condición frente al IVA");
                cmb_IVA.Focus();
                return;
            }
            Clases_NG.Clientes.NG_Clientes_Alta cliente = new Clases_NG.Clientes.NG_Clientes_Alta();
            cliente.nuevo(txt_CUIT.Text, txt_Nombre.Text, txt_Apellido.Text, txt_RazonSocial.Text,
                cmb_IVA.SelectedValue.ToString(), cmb_Pagos.SelectedValue.ToString(), txt_mail.Text, txt_tel.Text,
                txt_DirComercial.Text, txt_DirEntrega.Text);
            MessageBox.Show("Se ha creado un nuevo cliente.");
            this.Close();
            
        }

        private void Frm_Nuevo_Cliente_Load(object sender, EventArgs e)
        {
            cmb_IVA.cargar("CondicionIva", "id_Iva", "descripcion");
            cmb_IVA.SelectedIndex = -1;
            cmb_Pagos.cargar("CondicionPago", "id_Pago", "descripcion");
            cmb_Pagos.SelectedIndex = -1;
        }
    }
}
