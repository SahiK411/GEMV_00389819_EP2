using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class MainWindow : Form
    {
        protected string UserName;

        UserControl current = new UserControl();
        public MainWindow(bool userType, string userName)
        {
            InitializeComponent();
            UserName = userName;
            if (!userType)
            {
                current = new UserView(UserName);
                current.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(current, 0, 0);
            }
            else
            {

            }
            this.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
