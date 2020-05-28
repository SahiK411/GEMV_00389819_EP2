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
    public partial class CheckProducts : UserControl
    {
        public CheckProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = DBConnect.ExecuteQuery("SELECT * FROM PRODUCT");

                dataGridView1.DataSource = dt;

                MessageBox.Show("Datos obtenidos excitosamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Se produjo un error.");
            }
        }
    }
}
