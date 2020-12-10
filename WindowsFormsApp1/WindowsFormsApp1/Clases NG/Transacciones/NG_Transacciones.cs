using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Clases_NG.BE_BD;

namespace WindowsFormsApp1.Clases_NG.Transacciones
{
    class NG_Transacciones
    {
        BE_BD bd = new BE_BD();

        public DataTable buscar_id(string cuit)
        {
            string sql = "SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM Clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_max()
        {
            string sql = "SELECT MAX(n.nro_NC) FROM NotaCotizacion n";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_productos()
        {
            string sql = "SELECT * FROM Productos";
            return bd.ejecutar_consulta(sql);

        }

        public bool crear_NC(string cliente, string nro, string fecha, DataGridView data, string fechavig)
        {
            bd.iniciar_transaccion();
            string sql = "INSERT INTO NotaCotizacion VALUES (" + 1 + ", " + nro + ", " + cliente + ", '" + fecha + "', '"+fechavig+"')";
            bd.insertar(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string sql1 = "INSERT INTO DetalleNotaCotizacion VALUES (" + data.Rows[i].Cells[0].Value.ToString() + ", " + 1 + ", " + nro + ", " + data.Rows[i].Cells[2].Value.ToString() + ")";
                bd.insertar(sql1);
            }
            estado_BE estado;
            estado = bd.cerrar_transaccion();
            if (estado == estado_BE.correcto ) return true;
            return false;

        }
    }
}
