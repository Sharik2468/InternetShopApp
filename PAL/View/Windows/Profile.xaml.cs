using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PAL.Windows
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = ClientViewModel.Instance;
        }
        private static Page ProfilePage = null;
        public static Page getInstance()
        {

            if (ProfilePage == null)
            {
                ProfilePage = new Profile();
            }
            return ProfilePage;
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Login.getInstance());
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(PL.View.Windows.RegisterWindow.getInstance());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(ClientViewModel.Instance.AuthorizedUser.Client_Code == 0) { ClientProfileName.Text = "гость"; return; }
            ClientProfileName.Text = ClientViewModel.Instance.AuthorizedUser.Name;
        }
    }
}
