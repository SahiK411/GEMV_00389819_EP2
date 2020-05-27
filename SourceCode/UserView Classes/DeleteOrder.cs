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

                if (dt.Equals(null))
                {
                    MessageBox.Show("La orden referenciada no existe. Por favor intente de nuevo.");
                    return;
                }

                DBConnect.ExecuteNonQuery($"DELETE FROM APPORDER WHERE idOrder = {Convert.ToInt32(textBox1.Text)}");
                MessageBox.Show("Operacion Completada Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error.");
            }
        }
    }
}
