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
    public partial class AddBusiness : UserControl
    {
        public AddBusiness()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No puede dejar espacios en blanco.");
            }
            else
            {
                try
                {
                    DBConnect.ExecuteNonQuery($"INSERT INTO business(name, description) " +
                        $"VALUES('{textBox1.Text}', '{textBox2.Text}');");
                    MessageBox.Show("Se completo el proceso exitosamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Se produjo un error.");
                }
            }
        }
    }
}
