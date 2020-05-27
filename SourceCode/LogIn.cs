using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    var dt = DBConnect.ExecuteQuery($"SELECT password FROM appuser WHERE username = '{textBox1.Text}'");
                    if (dt.Equals(null))
                    {
                        throw new UserNotInTableException();
                    }

                    var dr = dt.Rows[0];
                    var userPassword = dr.ToString();

                    if (textBox2.Text.Equals(userPassword))
                    {
                        dt = DBConnect.ExecuteQuery($"SELECT usertype FROM appuser WHERE username = '{textBox1.Text}'");
                        dr = dt.Rows[0];

                        var userType = Convert.ToBoolean(dr[0].ToString());

                        this.Parent.Hide();
                        Application.Run(new MainWindow(userType));
                    }
                }
                catch(Exception ex)
                {
                    if(ex is UserNotInTableException)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un problema.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
