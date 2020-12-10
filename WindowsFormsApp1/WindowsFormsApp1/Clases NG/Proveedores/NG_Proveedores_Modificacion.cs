using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Proveedores_Modificacion
    {
        BE_BD bd = new BE_BD();

        public void nuevo(string id, string nom, string ape, string rz, string mail, string tel, string dom)
        {
            string sql = "UPDATE proveedores p SET p.nombre = '" + nom + "', p.apellido =  '" + ape 
                + "', p.razonSocial = '" + rz + "', p.mail = '" + mail + "', p.telefono = " + tel + ", p.domicilio = '"+dom+"'  WHERE p.CUIT = "+ id;
            bd.insertar(sql);
        }

        public DataTable buscar_CUIT(string cuit)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }
    }
}
