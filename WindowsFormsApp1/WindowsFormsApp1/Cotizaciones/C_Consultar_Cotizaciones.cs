using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Cotizaciones
{
    class C_Consultar_Cotizaciones
    {
        BE_BD bd = new BE_BD();
        public DataTable buscar_cuit(string id)
        {
            string sql = "SELECT * FROM NotaCotizacion WHERE cliente = "+id;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_rz(string rz)
        {
            string sql = "SELECT * FROM NotaCotizacion n INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE c.razonSocial LIKE '%" + rz + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_todos()
        {
            string sql = "SELECT * FROM NotaCotizacion ";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nro(string nro)
        {
            string sql = "SELECT * FROM NotaCotizacion WHERE nro_NC = "+nro;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_fecha(string fecha)
        {
            string sql = "SELECT * FROM NotaCotizacion WHERE fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_cuit_fecha(string id, string fecha)
        {
            string sql = "SELECT * FROM NotaCotizacion WHERE cliente = " + id+ " AND fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }
        public DataTable buscar_rz_fecha(string rz, string fecha)
        {
            string sql = "SELECT * FROM NotaCotizacion r INNER JOIN Clientes c ON (c.CUIT = r.cliente) WHERE razonSocial LIKE '%" + rz + "%' AND fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }
        
    }
}
