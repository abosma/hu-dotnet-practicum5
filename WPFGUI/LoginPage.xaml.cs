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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(UsernameTextbox.Text) && !String.IsNullOrEmpty(PasswordTextbox.Password))
            {
                if (serviceClient.Login(UsernameTextbox.Text, PasswordTextbox.Password))
                {
                    ShopPage shopPage = new ShopPage(UsernameTextbox.Text);
                    this.NavigationService.Navigate(shopPage);
                }
                else
                {
                    StatusText.Content = "Customer not registered!";
                }
            }
        }

        private void GotoRegister(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            this.NavigationService.Navigate(registerPage);
        }
    }
}
