using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
        User currentUser;

        public ShopPage(string username)
        {
            InitializeComponent();

            UsernameLabel.Content = username;

            UpdateFields();
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            if (ShopInventory.SelectedItems.Count > 0)
            {
                ListViewItem item = (ListViewItem)ShopInventory.SelectedItem;
                if (serviceClient.BuyProduct(currentUser.UserID, (int)item.Tag))
                {
                    ShopError.Visibility = Visibility.Visible;
                    ShopError.Foreground = Brushes.Black;
                    ShopError.Content = "Purchase Successful";
                }
                else
                {
                    ShopError.Visibility = Visibility.Visible;
                    ShopError.Foreground = Brushes.Red;
                    ShopError.Content = "Not enough money, or storage is empty!";
                }
            }

            UpdateFields();
        }

        private void Logout(object sender, EventArgs e)
        {
            currentUser = null;
            LoginPage loginPage = new LoginPage();
            this.NavigationService.Navigate(loginPage);
        }

        private void UpdateFields()
        {
            currentUser = serviceClient.GetUserByUsername(UsernameLabel.Content.ToString());

            UserMoney.Content = "€ " + currentUser.Money.ToString("0.00");

            List<Inventory> shopProducts = serviceClient.GetInventory();
            List<UserProducts> userProducts = serviceClient.GetUserProducts(currentUser.UserID);

            UserInventory.Items.Clear();
            ShopInventory.Items.Clear();

            userProducts.ForEach(product =>
            {
                UserInventory.Items.Add(product.Product.Name + ", Owned: " + product.Amount);
            });

            shopProducts.ForEach(product =>
            {
                ListViewItem item = new ListViewItem();
                item.Content = "€ " + product.Product.Price.ToString("0.00") + " : " + product.Product.Name + ", Amount: " + product.Storage;
                item.Tag = product.Product.ProductID;
                ShopInventory.Items.Add(item);
            });
        }
    }
}
