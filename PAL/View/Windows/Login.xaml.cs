using PL.Model;
using PL.ViewModel;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PAL.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private bool RestoreCachedUser = true;
        public Login()
        {
            InitializeComponent();
            DataContext = ClientViewModel.Instance;

            ClientViewModel.Instance.onAuthorized += Instance_onAuthorized;
        }

        private void Instance_onAuthorized()
        {
            RestoreCachedUser = false;
        }

        private static Page LoginPage = null;
        public static Page getInstance()
        {
            if (LoginPage == null)
            {
                LoginPage = new Login();
            }
            return LoginPage;
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Start.getInstance());
        }

        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Basket.getInstance());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Profile.getInstance());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Settings.getInstance());
        }

        private void RegisterOrLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ClientViewModel.Instance.Autorization(UserComboBox.SelectedIndex == 0 ? ClientName.Text : SalemanName.Text)) return;
            OrderViewModel.Instance.SetCurrentOrderForAuthorizedUser();
            OrderViewModel.Instance.SetCurrentOrderItem();
            ProductViewModel.Instance.SetAllProducts();
            this.NavigationService.Navigate(Start.getInstance());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            PasswordTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255)));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            PasswordTextBox.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255)));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            PasswordTextBox.SelectionBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255)));
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ClientViewModel.Instance.AuthorizedUser.Password = PasswordTextBox.Password;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RestoreCachedUser = true;
            ClientViewModel.Instance.CachedUser = new UserModel(ClientViewModel.Instance.AuthorizedUser);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (RestoreCachedUser)
                ClientViewModel.Instance.SetUser(ClientViewModel.Instance.CachedUser, ClientViewModel.Instance.CachedUser.UserTable.ToString());
        }
    }
}
