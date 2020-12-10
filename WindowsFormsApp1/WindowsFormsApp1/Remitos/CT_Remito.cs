using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Remitos
{
    
    class CT_Remito
    {
        BE_BD bd = new BE_BD();
        public DataTable buscar_max()
        {
            string sql = "SELECT MAX(n.nroRemito) FROM Remito n";
            return bd.ejecutar_consulta(sql);
        }
        
        public DataTable buscar_id(string cuit)
        {
            string sql = "SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM Clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }

        public bool crear_Remito(string nro, string cliente, string fecha, DataGridView data, string obs, string est)
        {
            bd.iniciar_transaccion();
            string sql = "INSERT INTO Remito VALUES (" + 1 + ", " + nro + ", " + cliente +", '"+ obs +"', '" + fecha + "', "+est+")";
            bd.insertar(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string sql1 = "INSERT INTO DetalleRemito VALUES (" + 1 + ", " + nro + ", '" + data.Rows[i].Cells[0].Value.ToString() +  "',  "+ data.Rows[i].Cells[2].Value.ToString()  + ", " + data.Rows[i].Cells[3].Value.ToString() + ")";
                bd.insertar(sql1);
                string sql2 = "SELECT stockDisponible FROM Productos WHERE id_producto LIKE '" + data.Rows[i].Cells[0].Value.ToString()+"'";
                DataTable stockViejo = bd.ejecutar_consulta(sql2);
                int stockFinal = 0;
                try
                {
                    stockFinal = int.Parse(stockViejo.Rows[0][0].ToString()) - int.Parse(data.Rows[i].Cells[3].Value.ToString());
                    string sql3 = "UPDATE Productos SET stockDisponible = " + stockFinal + " WHERE id_Producto LIKE '" + data.Rows[i].Cells[0].Value.ToString() + "'";
                    bd.insertar(sql3);

                }
                catch (Exception)
                {                    
                }

            }
            BE_BD.estado_BE estado;
            estado = bd.cerrar_transaccion();
            if (estado == BE_BD.estado_BE.correcto) return true;
            return false;
        }

        
        public DataTable buscar_remito(string nro_sc, string nro_Rem)
        {
            string sql = "SELECT  RIGHT(REPLICATE('0', (4-LEN(r.nroSucursal)))+ CAST(r.nroSucursal AS VARCHAR(4)), 4) as nroSucursal, " +
                "RIGHT(REPLICATE('0', (8-LEN(nroRemito)))+ CAST(r.nroRemito AS VARCHAR(8)), 8) as nroRemito, r.fecha FROM Remito r WHERE r.nroSucursal =  " + nro_sc+" AND r.nroRemito =  "+nro_Rem;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_detalle_remito(string nro_sc, string nro_Rem)
        {
            string sql = "SELECT r.id_producto, p.descripcion, r.cantPedida, r.cantDespachada FROM DetalleRemito r INNER JOIN Productos p ON (r.id_producto = p.id_producto) WHERE r.nroSucursal =  " + nro_sc + " AND r.nroRemito = " + nro_Rem;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_cliente(string nro_suc, string nro_rem)
        {
            string sql = "SELECT c.razonSocial, c.CUIT, cp.descripcion AS condicionPago, c.domEntrega FROM Clientes c INNER JOIN Remito r ON (c.CUIT = r.cliente) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_pago) WHERE r.nroSucursal = "+ nro_suc+" AND r.nroRemito = "+nro_rem;;
            return bd.ejecutar_consulta(sql);
        }


    }
}
