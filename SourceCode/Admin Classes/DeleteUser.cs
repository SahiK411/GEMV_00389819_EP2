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
    public partial class DeleteUser : UserControl
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No puede dejar espacios en blanco.");
            }
            else{
                try
                {
                    searchNames();
                    DBConnect.ExecuteNonQuery($"DELETE FROM appuser WHERE username = '{textBox1.Text}'");
                    MessageBox.Show("El proceso se completo exitosamente.");
                }
                catch(Exception ex)
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

        private void searchNames()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT username FROM appuser WHERE username = '{textBox1.Text}'");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
