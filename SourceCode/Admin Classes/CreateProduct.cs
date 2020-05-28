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
    public partial class CreateProduct : UserControl
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios.");
            }
            else
            {
                try
                {
                    searchBusinesses();
                    DBConnect.ExecuteNonQuery($"INSERT INTO product(idBusiness, name) " +
                        $"VALUES({Convert.ToInt32(textBox1.Text)}, '{textBox2.Text}')");
                    MessageBox.Show("Se completo el proceso exitosamente.");
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

        private void searchBusinesses()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT name FROM business WHERE idBusiness = {textBox1.Text}");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
