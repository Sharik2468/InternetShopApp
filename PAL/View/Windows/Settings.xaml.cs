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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            DataContext = ClientViewModel.Instance;
            
        }

        public static void ChangeButtonVisibility(bool isVisible)
        {
            
        }

        private static Page SettingsPage = null;
        public static Page getInstance()
        {
            if (SettingsPage == null)
            {
                SettingsPage = new Settings();
            }
            return SettingsPage;
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

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(PL.View.Windows.AddProductWindow.getInstance());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(PL.View.Windows.AboutWindow.getInstance());
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ClientViewModel.Instance.AuthorizedUser.Client_Code == 0) return;

            AddProductStackPanel.Visibility =
                ClientViewModel.Instance.AuthorizedUser.UserTable == PL.Model.ClientVariety.Продавец ?
                Visibility.Visible :
                Visibility.Hidden;
        }
    }
}
