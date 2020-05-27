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
    public partial class CheckAddress : UserControl
    {
        private string UserName;
        public CheckAddress(string userName)
        {
            UserName = userName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = DBConnect.ExecuteQuery($"SELECT idUser FROM appuser WHERE username = '{UserName}';");
                var dr = dt.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());

                var ds = DBConnect.ExecuteQuery($"SELECT ad.idAddress, ad.address " +
                $"FROM ADDRESS ad WHERE ad.idUser = {idUser}");

                dataGridView1.DataSource = ds;

                MessageBox.Show("Datos obtenidos excitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema.");
            }
        }
    }
}
