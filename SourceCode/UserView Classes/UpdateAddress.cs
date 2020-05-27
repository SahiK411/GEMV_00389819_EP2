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
    public partial class UpdateAddress : UserControl
    {
        private string UserName;
        public UpdateAddress(string userName)
        {
            UserName = userName;
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
                 
                    var dt = DBConnect.ExecuteQuery($"SELECT idUser FROM appuser WHERE username = '{UserName}';");
                    var dr = dt.Rows[0];
                    var idUser = Convert.ToInt32(dr[0].ToString());

                    dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM ADDRESS ad WHERE ad.address = '{textBox2.Text}'");
                    dr = dt.Rows[0];
                    var idAddress = Convert.ToInt32(dr[0].ToString());

                    DBConnect.ExecuteNonQuery($"UPDATE ADDRESS SET address = '{textBox1.Text}' WHERE idUser = {idUser} " +
                        $"AND idAddress = {idAddress}");
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
