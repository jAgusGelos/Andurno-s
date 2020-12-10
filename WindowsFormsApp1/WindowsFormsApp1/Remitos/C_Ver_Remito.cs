using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Remitos
{
    class C_Ver_Remito
    {
        BE_BD bd = new BE_BD();

        public DataTable buscar_cuit(string id)
        {
            string sql = "SELECT r.nroSucursal, r.nroRemito, r.cliente, c.razonSocial, r.fecha, e.descripcion FROM Remito r INNER JOIN EstadosRemito e ON (r.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (r.cliente = c.CUIT) WHERE r.cliente = " + id;
            return bd.ejecutar_consulta(sql);
        }
        public DataTable buscar_cuit_estado(string id, string estado)
        {
            string sql = "SELECT r.nroSucursal, r.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE r.cliente = " + id + " AND r.estadoRemito = " + estado;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_rz(string rz)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE c.razonSocial LIKE '%" + rz + "%'";
            return bd.ejecutar_consulta(sql);
        }
        public DataTable buscar_rz_estado(string rz, string estado)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE c.razonSocial LIKE '%" + rz + "%' AND n.estadoRemito = "+ estado;
            return bd.ejecutar_consulta(sql);
        }


        public DataTable buscar_todos()
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) ";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_todos_estado(string estado)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n " +
                "INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) " +
                " WHERE n.estadoRemito =  " + estado;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nro(string nro)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion " +
                "FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT)" +
                " WHERE n.nroRemito = " + nro;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_fecha(string fecha)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE n.fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }
        public DataTable buscar_fecha_estado(string fecha, string estado)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE n.fecha >= '" + fecha + "' AND n.estadoRemito = "+ estado;
            return bd.ejecutar_consulta(sql);
        }


        public DataTable buscar_cuit_fecha(string id, string fecha)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE n.cliente = " + id + " AND n.fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }


        public DataTable buscar_cuit_fecha_estado(string id, string fecha, string estado)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE n.cliente = " + id + " AND n.fecha >= '" + fecha + "' AND n.estadoRemito = "+estado;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_rz_fecha(string rz, string fecha)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE c.razonSocial LIKE '%" + rz + "%' AND n.fecha >= '" + fecha + "'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_rz_fecha_estado(string rz, string fecha, string estado)
        {
            string sql = "SELECT n.nroSucursal, n.nroRemito, n.Cliente, c.razonSocial, n.fecha, e.descripcion FROM Remito n INNER JOIN EstadosRemito e ON (n.estadoRemito = e.id_estado) INNER JOIN Clientes c ON (n.cliente = c.CUIT) WHERE c.razonSocial LIKE '%" + rz + "%' AND n.fecha >= '" + fecha + "' AND n.estadoRemito = "+ estado;
            return bd.ejecutar_consulta(sql);
        }
    }
}
