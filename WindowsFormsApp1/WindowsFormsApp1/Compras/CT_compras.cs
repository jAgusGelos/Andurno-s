using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases_NG;

namespace WindowsFormsApp1.Compras
{
    class CT_compras
    {
        BE_BD bd = new BE_BD();

        public bool comprar( string fecha, DataGridView data)
        {
                bd.iniciar_transaccion();              
                
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string sql = "SELECT stockDisponible FROM Productos where id_producto LIKE '" +data.Rows[i].Cells[0].Value.ToString()+ "'";
                    DataTable acu = bd.ejecutar_consulta(sql);
                int stock = 0;
                try
                {
                    stock = int.Parse(acu.Rows[0][0].ToString());
                }
                catch (Exception)
                {

                    
                } 
                    int total = stock + int.Parse(data.Rows[i].Cells[2].Value.ToString());
                    string sql1 = "UPDATE Productos SET stockDisponible = "+total+
                                ", fechaUltimaCompra = '"+fecha+"', precio = "+ data.Rows[i].Cells[3].Value.ToString()
                                +", precioLista = "+ data.Rows[i].Cells[4].Value.ToString()
                                +"WHERE id_producto LIKE '"+ data.Rows[i].Cells[0].Value.ToString()+"'";
                    bd.insertar(sql1);
                }
                BE_BD.estado_BE estado;
                estado = bd.cerrar_transaccion();
                if (estado == BE_BD.estado_BE.correcto) return true;
                return false;
            
        }
    }
}
