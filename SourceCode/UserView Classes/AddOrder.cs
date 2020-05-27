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
    public partial class AddOrder : UserControl
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios en blanco.");
            }
            else
            {
                try
                {
                    var dt = DBConnect.ExecuteQuery($"SELECT idProduct FROM product " +
                        $"WHERE idProduct = {Convert.ToInt32(textBox1.Text)}");
                    if (dt.Equals(null))
                    {
                        MessageBox.Show("El producto referenciado no existe. Por favor intente de nuevo");
                        return;
                    }

                    dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM address " +
                        $"WHERE idAddress = {Convert.ToInt32(textBox2.Text)}");
                    if (dt.Equals(null))
                    {
                        MessageBox.Show("La direccion referenciada no existe. Por favor intente de nuevo");
                        return;
                    }

                    DBConnect.ExecuteNonQuery($"INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                        $"VALUES('{System.DateTime.Today}', {Convert.ToInt32(textBox1.Text)}, {Convert.ToInt32(textBox2.Text)}); ");
                    MessageBox.Show("Operacion Completada Exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un problema.");
                }
            }
        }
    }
}
