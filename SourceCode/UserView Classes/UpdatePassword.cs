using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode.UserView_Classes
{
    public partial class UpdatePassword : UserControl
    {
        private string UserName;
        public UpdatePassword(string userName)
        {
            UserName = userName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios en blanco.");
            }
            else
            {
                try
                {
                    if (textBox1.Text.Equals(textBox2.Text))
                    {
                        DBConnect.ExecuteNonQuery($"UPDATE APPUSER SET password = '{textBox1.Text}' " +
                            $"WHERE username = '{UserName}'");
                        MessageBox.Show("Operacion Completada Exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Las contrasenas ingresadas no coinciden.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un problema.");
                }
            }
        }
    }
}
