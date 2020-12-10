using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Clases_Reportes
{
    class C_Nota_Cotizacion
    {
        BE_BD bd = new BE_BD();
        public DataTable nota_cotizacion(string nro_Suc, string nro_NC)
        {
            string sql = "SELECT RIGHT(REPLICATE('0', (4-LEN(n.nro_Sucursal)))+ CAST(n.nro_Sucursal AS VARCHAR(7)), 7) as nro_Sucursal, " +
                "RIGHT(REPLICATE('0', (8-LEN(n.nro_NC)))+ CAST(n.nro_NC AS VARCHAR(8)), 8) as nro_NC, n.cliente, n.fecha, c.razonSocial, c.domEntrega, c.telefono, c.mail, n.fechaVigencia FROM NotaCotizacion n INNER JOIN Clientes c on (n.cliente =c.CUIT) WHERE n.nro_Sucursal = " + nro_Suc + "AND n.nro_NC = " + nro_NC;
            return bd.ejecutar_consulta(sql);
        }
        public DataTable detalle_nota_cotizacion(string nro_Suc, string nro_NC)
        {
            string sql = "SELECT n.id_producto, p.descripcion, n.cantidad, p.precio, (n.cantidad * p.precio) AS 'subtotal' FROM DetalleNotaCotizacion n INNER JOIN Productos p on (n.id_producto = p.id_producto) WHERE n.nro_Sucursal = " + nro_Suc + "AND n.nro_NC = " + nro_NC;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable total_nota_cotizacion(string nro_Suc, string nro_NC)
        {
            string sql = "SELECT SUM(n.cantidad * p.precio) AS 'subtotal',  SUM(n.cantidad * p.precio)*0.21 AS 'iva',  SUM(n.cantidad * p.precio*1.21) AS 'total' FROM DetalleNotaCotizacion n INNER JOIN Productos p on (n.id_producto = p.id_producto) WHERE n.nro_Sucursal = " + nro_Suc + "AND n.nro_NC = " + nro_NC;
            return bd.ejecutar_consulta(sql);
        }


    }
 }
