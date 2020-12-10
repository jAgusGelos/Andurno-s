using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG.Clientes
{
    class NG_Clientes_Alta
    {
        BE_BD bd = new BE_BD();
        public void nuevo(string id, string nom, string ape, string rz, string ci, string cp,
            string mail, string tel, string domCom, string domEntrega)
        {
            string sql = "INSERT INTO Clientes VALUES (" + id + " , '" + nom + "' , '" + ape + "' , '"
                + rz +"' , "+ci+", "+cp+ " , '" + mail + "' , " + tel + " , '" + domCom + "', '"+domEntrega+"')";
            bd.insertar(sql);
        }
    }
}
