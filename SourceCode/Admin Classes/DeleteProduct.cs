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
    public partial class DeleteProduct : UserControl
    {
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No puede dejar espacios en blanco.");
            }
            else
            {
                try
                {
                    searchProducts();
                    DBConnect.ExecuteNonQuery($"DELETE FROM PRODUCT WHERE idProduct = {Convert.ToInt32(textBox1.Text)}");
                    MessageBox.Show("Operacion completada exitosamente.");
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

        private void searchProducts()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT name FROM product WHERE idProduct = {Convert.ToInt32(textBox1.Text)}");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
