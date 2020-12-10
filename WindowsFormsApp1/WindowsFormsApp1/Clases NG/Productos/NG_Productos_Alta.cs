using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Productos_Alta
    {
        BE_BD bd = new BE_BD();
        public void insertar(string id, string nom, string stock, string venta, string actual, string precioLista)
        {
            string sql = "INSERT INTO Productos VALUES ('" + id + "', '" + nom + "', "+actual+ ", " + stock + ", null, " + venta + ", "+ precioLista + ") ";
            bd.insertar(sql);
        }
    }
}
