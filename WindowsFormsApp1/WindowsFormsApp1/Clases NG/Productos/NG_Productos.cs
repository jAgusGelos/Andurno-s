using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Productos
    {

        BE_BD bd = new BE_BD();

        public DataTable buscar_todos()
        {
            string sql = "SELECT id_producto, descripcion, stockDisponible, stockMinimo, fechaUltimaCompra, precio, precioLista FROM Productos";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_id(string id)
        {
            string sql = "SELECT id_producto, descripcion, stockDisponible, stockMinimo, fechaUltimaCompra, precio, precioLista FROM Productos p WHERE p.id_producto LIKE  '%" + id + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nombre(string nom)
        {
            string sql = "SELECT id_producto, descripcion, stockDisponible, stockMinimo, fechaUltimaCompra, precio, precioLista FROM Productos WHERE descripcion LIKE '%" + nom + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public void eliminar(string id)
        {
            string sql = "DELETE FROM Productos  WHERE id_producto = " + id ;
            bd.insertar(sql);

        }

        internal DataTable buscar_proveedor(string v)
        {
            string sql = "SELECT id_producto, descripcion, stockDisponible, stockMinimo, fechaUltimaCompra, precio, precioLista FROM Productos WHERE proveedor =  " + v;
            return bd.ejecutar_consulta(sql);
        }
    }
}
