using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_app
{
    public partial class DateAskform : Form
    {
        public DateAskform()
        {
            InitializeComponent();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            //пометить книгу свободно, убрать ее из списка,отравить данные в таблицу и бд
            this.Close();
        }
    }
}
