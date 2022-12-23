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
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Page
    {
        public ProductWindow()
        {
            InitializeComponent();
            DataContext = ProductViewModel.Instance;
        }

        private static Page ProductPage = null;
        public static Page getInstance()
        {
            if (ProductPage == null)
            {
                ProductPage = new ProductWindow();
            }
            return ProductPage;
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

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            OrderViewModel.Instance.AddOrderItemCommand.Execute(null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ClientViewModel.Instance.AuthorizedUser.Client_Code == 0 ||
                ClientViewModel.Instance.AuthorizedUser.UserTable == Model.ClientVariety.Покупатель)
            {
                DeleteProduct.Visibility = Visibility.Hidden;
                AddProduct.Visibility = Visibility.Hidden;
                DecreaseProduct.Visibility = Visibility.Hidden;

                return;
            }

            DeleteProduct.Visibility = Visibility.Visible;
            AddProduct.Visibility = Visibility.Visible;
            DecreaseProduct.Visibility = Visibility.Visible;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Start.getInstance());
        }

        private void DecreaseProduct_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Start.getInstance());
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Start.getInstance());
        }
    }
}
