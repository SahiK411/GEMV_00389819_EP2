using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceCode.UserView_Classes;

namespace SourceCode.Admin_Classes
{
    public partial class AdminView : UserControl
    {
        private string UserName;
        public AdminView(string userName)
        {
            UserName = userName;
            UserControl temp;
            InitializeComponent();

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new UpdatePassword(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage1.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new AddUser();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage2.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new DeleteUser();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage3.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CreateProduct();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage4.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new DeleteProduct();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage5.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CheckProducts();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage6.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CheckGlobalOrders();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage7.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CheckDemand();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage8.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new AddBusiness();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage9.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new DeleteBusiness();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage10.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1.TabIndexChanged += new EventHandler(this.TabChange_TabIndex);
        }

        private void TabChange_TabIndex(object sender, EventArgs e)
        {
            tabPage8.Controls.Clear();

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            var temp = new CheckDemand();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage8.Controls.Add(tableLayoutPanel1);
        }
    }
}
