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

                dt = DBConnect.ExecuteQuery($"SELECT idAddress FROM address WHERE idUser = {idUser}");
                DataTable final = new DataTable();
                final.Columns.Add(new DataColumn());
                final.Columns.Add(new DataColumn());
                final.Columns.Add(new DataColumn());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var temp = DBConnect.ExecuteQuery($"SELECT idOrder FROM apporder WHERE idAddress = {dt.Rows[i]}");
                    for(int j = 0; j < temp.Rows.Count; j++)
                    {
                        DataRow row = final.NewRow();
                        row[0] = dt.Rows[i];
                        row[1] = temp.Rows[j];

                        final.Rows.Add(row);
                    }
                }

                dataGridView1.DataSource = final;

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
                var dt = DBConnect.ExecuteQuery("SELECT * FROM PRODUCTS");

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
