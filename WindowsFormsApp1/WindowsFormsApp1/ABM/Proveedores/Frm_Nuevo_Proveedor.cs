using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ABM.Proveedores
{
    public partial class Frm_Nuevo_Proveedor : Form
    {
        public Frm_Nuevo_Proveedor()
        {
            InitializeComponent();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if(txt_CUIT.Text == "" || (txt_RazonSocial.Text == "" && txt_Apellido.Text == "" && txt_Nombre.Text == ""))
            {
                MessageBox.Show("Por favor ingrese CUIT, Nombre y Apellido o Razón Social.");
                txt_CUIT.Focus();
                
            }
            else
            {
                Clases_NG.NG_Proveedores_Alta prov = new Clases_NG.NG_Proveedores_Alta();
                prov.nuevo(txt_CUIT.Text, txt_Nombre.Text, txt_Apellido.Text, txt_RazonSocial.Text, txt_domicilio.Text, txt_mail.Text, txt_tel.Text);
                MessageBox.Show("Se ha creado un nuevo proveedor");
                this.Close();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
