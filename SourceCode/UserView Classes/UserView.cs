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

namespace SourceCode
{
    public partial class UserView : UserControl
    {
        private string UserName;
        public UserView(string userName)
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
            temp = new AddAddress(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage2.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new UpdateAddress(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage3.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new DeleteAddress(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage4.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CheckAddress(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage5.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new AddOrder();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage6.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new DeleteOrder();
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage7.Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            temp = new CheckOrders(UserName);
            temp.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(temp, 0, 0);
            tabPage8.Controls.Add(tableLayoutPanel1);
        }
    }
}
