using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode.Admin_Classes
{
    public partial class CheckGlobalOrders : UserControl
    {
        public CheckGlobalOrders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = DBConnect.ExecuteQuery($"SELECT * FROM APPORDER");

                dataGridView1.DataSource = dt;

                MessageBox.Show("Operacion completada exitosamente.");
            }
            catch (Exception ex)
            {
                if (ex is UserNotInTableException)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show("Se produjo un error.");
                }
            }
        }
    }
}
