using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Clases_NG.CMB
{
    class combo_box: ComboBox
    {
        BE_BD bd = new BE_BD();
        public void cargar(string _nom_tabla, string _pk, string _descriptor)
        {
            string sql = "SELECT * FROM " + _nom_tabla;
            this.DisplayMember = _descriptor;
            this.ValueMember = _pk;
            this.DataSource = bd.ejecutar_consulta(sql);
        }
    }
}
