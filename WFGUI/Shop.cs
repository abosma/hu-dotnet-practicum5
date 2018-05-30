using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFGUI
{
    public partial class Shop : Form
    {
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
        User currentUser;

        public Shop(string username)
        {
            InitializeComponent();

            UsernameLabel.Text = username;

            UpdateFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ShopInventory.SelectedItems.Count > 0)
            {
                if (serviceClient.BuyProduct(currentUser.UserID, (int)ShopInventory.SelectedItems[0].Tag))
                {
                    ShopError.Show();
                    ShopError.ForeColor = Color.Black;
                    ShopError.Text = "Purchase Successful";
                }
                else
                {
                    ShopError.Show();
                    ShopError.ForeColor = Color.Red;
                    ShopError.Text = "Not enough money, or storage is empty!";
                }
            }

            UpdateFields();
        }

        private void UpdateFields()
        {
            currentUser = serviceClient.GetUserByUsername(UsernameLabel.Text);

            UserMoney.Text = "€ " + currentUser.Money.ToString("0.00");

            List<Inventory> shopProducts = serviceClient.GetInventory();
            List<UserProducts> userProducts = serviceClient.GetUserProducts(currentUser.UserID);

            UserInventory.Items.Clear();
            ShopInventory.Items.Clear();

            UserInventory.BeginUpdate();

            userProducts.ForEach(product =>
            {
                UserInventory.Items.Add(product.Product.Name + ", Owned: " + product.Amount);
            });

            UserInventory.EndUpdate();

            ShopInventory.BeginUpdate();

            shopProducts.ForEach(product =>
            {
                ListViewItem item = new ListViewItem();
                item.Text = "€ " + product.Product.Price.ToString("0.00") + " : " + product.Product.Name + ", Amount: " + product.Storage;
                item.Tag = product.Product.ProductID;
                ShopInventory.Items.Add(item);
            });

            ShopInventory.EndUpdate();
        }

        private void ShopLogout_Click(object sender, EventArgs e)
        {
            currentUser = null;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
