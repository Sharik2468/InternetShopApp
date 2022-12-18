using PAL.Windows;
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

namespace PL.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AcceptOrdersWindows.xaml
    /// </summary>
    public partial class AcceptOrdersWindows : Page
    {
        public AcceptOrdersWindows()
        {
            InitializeComponent();
            DataContext = OrderViewModel.Instance;
        }
        private static Page OrderAcceptPage = null;
        public static Page getInstance()
        {
            if (OrderAcceptPage == null)
            {
                OrderAcceptPage = new AcceptOrdersWindows();
            }
            return OrderAcceptPage;
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

        private void ProductsListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                OrderScrollViewer.LineDown();
            }
            else
            {
                OrderScrollViewer.LineUp();
            }
        }

        private void ClientName_Loaded(object sender, RoutedEventArgs e)
        {
            if (ClientViewModel.Instance.AuthorizedUser.Client_Code == 0) { ClientName.Text = "гость"; return; }
            ClientName.Text = ClientViewModel.Instance.AuthorizedUser.Name;
        }
    }
}
