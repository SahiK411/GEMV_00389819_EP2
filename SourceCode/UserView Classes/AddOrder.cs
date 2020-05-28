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
                    validateData();
                    DBConnect.ExecuteNonQuery($"INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                        $"VALUES('{DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Year.ToString()}'" +
                        $", {Convert.ToInt32(textBox1.Text)}, {Convert.ToInt32(textBox2.Text)}); ");
                    MessageBox.Show("Operacion Completada Exitosamente");
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
        private void validateData()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idProduct FROM product " +
                        $"WHERE idProduct = {Convert.ToInt32(textBox1.Text)}");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }

            dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM address " +
                $"WHERE idAddress = {Convert.ToInt32(textBox2.Text)}");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
