using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Clases_NG
{
    class BE_BD
    {
        string cadena_conexion = "Provider=SQLNCLI11;Data Source=LAPTOP-1E6LQJDI\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Watools";
        public enum estado_BE { correcto, error }
        public enum forma_conexion { simple, transaccion }

        OleDbTransaction transaccion;
        forma_conexion tipo_conexion = forma_conexion.simple;
        estado_BE control_transaccion = estado_BE.correcto;

        OleDbConnection conexion = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public void iniciar_transaccion()
        {
            tipo_conexion = forma_conexion.transaccion;
            control_transaccion = estado_BE.correcto;
        }

        public estado_BE cerrar_transaccion()
        {
            if (control_transaccion == estado_BE.correcto)
            {
                transaccion.Commit();
                tipo_conexion = forma_conexion.simple;
                desconectar();
                return estado_BE.correcto;
            }
            else
            {
                transaccion.Rollback();
                tipo_conexion = forma_conexion.simple;
                desconectar();
                return estado_BE.error;

            }
        }
        private void conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.ConnectionString = cadena_conexion;
                conexion.Open();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                if (tipo_conexion == forma_conexion.transaccion)
                {
                    transaccion = conexion.BeginTransaction(IsolationLevel.ReadUncommitted);
                    cmd.Transaction = transaccion;
                }
            }
        }
        private void desconectar()
        {
            if (tipo_conexion == forma_conexion.simple)
            {
                conexion.Close();
            }
        }
        public DataTable ejecutar_consulta(string sql)
        {
            conectar();
            DataTable tabla = new DataTable();
            cmd.CommandText = sql;
            try
            {
                tabla.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                control_transaccion = estado_BE.error;
                MessageBox.Show("Error con la Base de Datos" + "\n"
                  + "En el comando:" + "\n"
                  + sql + "\n"
                  + "El mensaje es:" + "\n"
                  + e.Message);

            }
            desconectar();
            return tabla;
        }

        public estado_BE insertar(string sql)
        {
            this.conectar();
            this.cmd.CommandText = sql;
            try
            {
                this.cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                control_transaccion = estado_BE.error;
                MessageBox.Show("Error con la Base de Datos" + "\n"
                  + "En el comando:" + "\n"
                  + sql + "\n"
                  + "El mensaje es:" + "\n"
                  + e.Message);
            }
            this.desconectar();
            return control_transaccion;
        }
    }
}
