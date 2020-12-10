using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases_NG
{
    class NG_Proveedores
    {
        BE_BD bd = new BE_BD();

        public DataTable buscar_todos()
        {
            string sql = "SELECT * FROM proveedores";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_razonSocial(string rz)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.razonSocial LIKE '%" + rz + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nombre(string nom)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.nombre LIKE '%" + nom + "%'";
            return bd.ejecutar_consulta(sql);

        }

        public DataTable buscar_apellido(string ape)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.apellido LIKE '%" + ape + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_nombre_apellido(string nom, string ape)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.nombre LIKE '%" + nom + "%' AND p.apellido LIKE '%" + ape + "%'";
            return bd.ejecutar_consulta(sql);
        }

        public DataTable buscar_CUIT(string cuit)
        {
            string sql = "SELECT * FROM proveedores p WHERE p.CUIT = " + cuit;
            return bd.ejecutar_consulta(sql);
        }

        public void eliminar(string cuit)
        {
            string sql = "DELETE FROM proveedores p WHERE p.CUIT = " + cuit;
            bd.insertar(sql);
        }
    }
}
