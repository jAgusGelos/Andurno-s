using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG.Clientes
{

    class NG_Clientes
    {
        BE_BD bd = new BE_BD();



        public DataTable buscar_todos()
        {
            string sql = @"SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago)";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_id(string cuit)
        {
            string sql = " SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nombre(string nom)
        {
            string sql = " SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.nombre LIKE '%" + nom + "%'";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_razonSocial(string rz)
        {
            string sql = " SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.razonSocial LIKE '%" + rz + "%'";
            return bd.ejecutar_consulta(sql);
        }



        public DataTable buscar_apellido(string ape)
        {
            string sql = " SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.apellido LIKE '%" + ape + "%'";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_nombre_apellido(string nom, string ape)
        {
            string sql = "SELECT c.CUIT, c.nombre, c.apellido,c.razonSocial, ci.descripcion, cp.descripcion, c.mail, c.telefono, c.domComercial, c.domEntrega FROM clientes c INNER JOIN CondicionIva ci on (c.condicionIva = ci.id_Iva) INNER JOIN CondicionPago cp ON (c.condicionPago = cp.id_Pago) WHERE c.nombre LIKE '%" + 
                nom + "%' AND c.apellido LIKE '%" + ape + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public void eliminar(string id)
        {
            string sql = "DELETE FROM clientes p WHERE p.CUIT = " + id;
            bd.insertar(sql);

        }
    }
}

