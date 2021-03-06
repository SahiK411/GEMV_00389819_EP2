﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    /*var dt = DBConnect.ExecuteQuery($"SELECT password FROM appuser WHERE username = '{textBox1.Text}'");
                    if (dt.Rows[0].Equals(""))
                    {
                        throw new UserNotInTableException();
                    }

                    var dr = dt.Rows[0]; */
                    var userPassword = getPassword();

                    if (textBox2.Text.Equals(userPassword))
                    {
                        var dt = DBConnect.ExecuteQuery($"SELECT usertype FROM appuser WHERE username = '{textBox1.Text}'");
                        var dr = dt.Rows[0];

                        var userTypetext = (dr[0].ToString());
                        bool userType;
                        switch (userTypetext)
                        {
                            case "True":
                            case "true":
                                userType = true;
                                break;
                            case "False":
                            case "false":
                                userType = false;
                                break;
                            default:
                                userType = false;
                                break;
                        }
                        MainWindow mainForm = new MainWindow(userType, textBox1.Text);
                        mainForm.FormBorderStyle = FormBorderStyle.Sizable;
                        mainForm.Width = 1080;
                        mainForm.Height = 720;
                        mainForm.Show();
                        Parent.Parent.Hide();
                        //Application.Run(new MainWindow(userType, textBox1.Text));
                    }
                    else
                    {
                        MessageBox.Show("La contrasena era incorrecta.");
                    }
                }
                catch (Exception ex)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private string getPassword()
        {
            var dt = DBConnect.ExecuteQuery($"SELECT password FROM appuser WHERE username = '{textBox1.Text}'");
            
            if (dt.ExtendedProperties.Values.Count.Equals(0) && dt.Rows.Count == 0)
            {
                throw new UserNotInTableException();
            }
            var dr = dt.Rows[0];
            return dr[0].ToString();
        }
    }
}
