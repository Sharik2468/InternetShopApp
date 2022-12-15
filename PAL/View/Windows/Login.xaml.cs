using PL.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PAL.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            DataContext = ClientViewModel.Instance;
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
            this.NavigationService.Navigate(Start.getInstance());
        }
    }
}
