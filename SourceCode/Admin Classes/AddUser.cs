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
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Si");
            comboBox1.Items.Add("No");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals("") || comboBox1.SelectedItem.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios en blanco.");
            }
            else
            {
                try
                {
                    bool userType = false;
                    switch (comboBox1.SelectedItem)
                    {
                        case "Si":
                            userType = true;
                            break;
                        case "No":
                            userType = false;
                            break;
                    }

                    DBConnect.ExecuteNonQuery($"INSERT INTO appuser(fullname, username, password, userType) " +
                        $"VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox2.Text}', {userType})");

                    MessageBox.Show("Se completo la operacion exitosamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Se produjo un error.");
                }
            }
        }
    }
}
