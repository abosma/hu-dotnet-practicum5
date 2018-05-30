using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFGUI
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();

        public Form1()
        {
            InitializeComponent();
            InfoLabel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(usernameTextbox.Text) && !String.IsNullOrEmpty(passwordTextbox.Text))
            {
                if (serviceClient.Login(usernameTextbox.Text, passwordTextbox.Text))
                {
                    var ShopForm = new Shop(usernameTextbox.Text);
                    ShopForm.Show();
                    this.Hide();
                }
                else
                {
                    InfoLabel.Show();
                    InfoLabel.Text = "Customer not registered!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UsernameRegister.Text))
            {
                RegisterPassword.Text = serviceClient.Register(UsernameRegister.Text);
            }
        }
    }
}
