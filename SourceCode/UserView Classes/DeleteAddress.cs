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
    public partial class DeleteAddress : UserControl
    {
        private string UserName;
        public DeleteAddress(string userName)
        {
            UserName = userName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                var dt = DBConnect.ExecuteQuery($"SELECT idUser FROM appuser WHERE username = '{UserName}';");
                var dr = dt.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());

                dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM address WHERE address = '{textBox1.Text}';");
                dr = dt.Rows[0];
                var idAddress = Convert.ToInt32(dr[0].ToString());

                DBConnect.ExecuteNonQuery($"DELETE FROM ADDRESS WHERE idUser = {idUser} AND idAddress = {idAddress}");
                MessageBox.Show("Operacion Completada Exitosamente");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void searchAddress()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT idUser FROM appuser WHERE username = '{UserName}';");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }

            dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM address WHERE address = '{textBox1.Text}';");

            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
        }
    }
}
