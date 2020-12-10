using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Productos_Modificiacion
    {
        BE_BD bd = new BE_BD();

        public void insertar(string id, string nom, string stock, string venta)
        {
            string sql = "UPDATE  Productos  SET  id_producto = '" + id + "',descripcion = ' " + nom + "', stockMinimo = " + stock + ", precio =  " + venta + " WHERE  id_producto LIKE '"+id+"'";
            bd.insertar(sql);
        }

        public DataTable buscar_id(string id)
        {
            string sql = "SELECT * FROM Productos p WHERE p.id_producto = " + id + "";
            return bd.ejecutar_consulta(sql);
        }
    }
}
