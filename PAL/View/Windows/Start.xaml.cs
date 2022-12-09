using PL;
using PL.View.Windows;
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
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            DataContext = ProductViewModel.Instance;
        }

        private static Page StartPage = null;
        public static Page getInstance()
        {
            ProductViewModel.Instance.SetAllProducts();

            if (StartPage == null)
            {
                StartPage = new Start();
            }

            return StartPage;
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

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.F5)
        }

        private void ProductsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(ProductWindow.getInstance());
        }

        private void ProductsListBox_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = false;
        }

        private void ProductsListBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = false;
        }


        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(CathegoryChooseWindow.getInstance(4));
        }

        private void Smartphones_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(CathegoryChooseWindow.getInstance(2));
        }

        private void Appliances_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(CathegoryChooseWindow.getInstance(1));
        }

        private void Television_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(CathegoryChooseWindow.getInstance(3));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ResultWindow.getInstance(Search.Text));
        }
    }
}
