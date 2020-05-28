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
    public partial class CheckOrders : UserControl
    {
        private string UserName;
        public CheckOrders(string userName)
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

                dt = DBConnect.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address " +
                    $"FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                    $"WHERE ao.idProduct = pr.idProduct " +
                    $"AND ao.idAddress = ad.idAddress " +
                    $"AND ad.idUser = au.idUser " +
                    $"AND au.idUser = {idUser}; ");
                

                dataGridView1.DataSource = dt;

                MessageBox.Show("Datos obtenidos excitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = DBConnect.ExecuteQuery("SELECT * FROM PRODUCT");

                dataGridView1.DataSource = dt;

                MessageBox.Show("Datos obtenidos excitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error.");
            }
        }
    }
}
