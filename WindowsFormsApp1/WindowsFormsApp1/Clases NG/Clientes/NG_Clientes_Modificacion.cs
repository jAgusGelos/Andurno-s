using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG.Clientes
{
    class NG_Clientes_Modificacion
    {
        BE_BD bd = new BE_BD();
        public void nuevo(string id, string nom, string ape, string rz, string ci, string cp,
            string mail, string tel, string domCom, string domEntrega)
        {
            string sql = "UPDATE proveedores p SET p.nombre = '" + nom + "', p.apellido =  '" + ape
                + "', p.razonSocial = '" + rz + "', p.mail = '" + mail + "', p.telefono = " + tel + ", p.domComercial = '" + domCom + "' , p.domEntrega = '" + domEntrega + "', p.condicionIva = "+ci+ "', p.condicionPago = " + cp +  "  WHERE p.CUIT = " + id;
            bd.insertar(sql);
        }

        public DataTable buscar_id(string cuit)
        {
            string sql = "SELECT SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }
    }
}
