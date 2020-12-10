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
    public partial class Frm_Modificar_Proveedor : Form
    {
        public string idProveedor;
        Clases_NG.NG_Proveedores_Modificacion modif = new Clases_NG.NG_Proveedores_Modificacion();
        public Frm_Modificar_Proveedor()
        {
            InitializeComponent();
        }

        private void Frm_Modificar_Proveedor_Load(object sender, EventArgs e)
        {

            DataTable tabla = new DataTable();
            tabla = modif.buscar_CUIT(idProveedor);
            txt_CUIT.Text = idProveedor;
            txt_Nombre.Text = tabla.Rows[0][1].ToString();
            txt_Apellido.Text = tabla.Rows[0][2].ToString();
            txt_RazonSocial.Text = tabla.Rows[0][3].ToString();
            txt_mail.Text = tabla.Rows[0][4].ToString();
            txt_tel.Text = tabla.Rows[0][5].ToString();
            txt_domicilio.Text = tabla.Rows[0][6].ToString();           

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
                modif.nuevo(txt_CUIT.Text, txt_Nombre.Text, txt_Apellido.Text,
                    txt_RazonSocial.Text, txt_mail.Text, txt_tel.Text, txt_domicilio.Text);
                MessageBox.Show("Se ha modificado con éxito.");
                this.Close();

            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
