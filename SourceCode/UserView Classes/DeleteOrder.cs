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
    public partial class DeleteOrder : UserControl
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = DBConnect.ExecuteQuery($"SELECT idOrder FROM APPORDER " +
                    $"WHERE idOrder = {Convert.ToInt32(textBox1.Text)};");

                validateData();

                DBConnect.ExecuteNonQuery($"DELETE FROM APPORDER WHERE idOrder = {Convert.ToInt32(textBox1.Text)}");
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

        private void validateData()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idOrder FROM APPORDER " +
                    $"WHERE idOrder = {Convert.ToInt32(textBox1.Text)};");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
