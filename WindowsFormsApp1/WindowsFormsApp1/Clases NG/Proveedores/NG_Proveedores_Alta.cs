using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Proveedores_Alta
    {
        BE_BD bd = new BE_BD();

        public void nuevo(string id, string nom, string ape, string rz,  string domCom,
             string mail, string tel)
        {
            string sql = "INSERT INTO proveedores VALUES (" + id + " , '" + nom + "' , '" + ape + "' , '"
                + rz + "' , '"  + mail + "' , " + tel+ " , '" + domCom+ "' )";
            bd.insertar(sql);
        }
            
    }
}
