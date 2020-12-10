using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Clases_NG
{
    class Comportamientos_Limpiar
    {
        public void limpiar_grilla(DataGridView data)
        {
            data.DataSource = "";
        }

        public void limpiar_txt(params TextBox[] textos)
        {
            foreach(TextBox text in textos)
            {
                text.Text = "";
            }
        }

        public void limpiar_chk(params CheckBox[] cheks)
        {
            foreach(CheckBox chk in cheks)
            {
                chk.Checked = false;
            }
        }
    }
}
