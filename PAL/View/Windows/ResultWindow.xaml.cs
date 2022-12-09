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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Page
    {
        public ResultWindow()
        {
            InitializeComponent();
            DataContext = ProductViewModel.Instance;
        }

        private static Page ResultPage = null;
        public static Page getInstance(string Request)
        {
            int numericValue;

            if (ResultPage == null)
            {
                if (int.TryParse(Request, out numericValue)) ProductViewModel.Instance.SetProductByID(Int32.Parse(Request));
                else ProductViewModel.Instance.SetProductByText(Request);
                ResultPage = new ResultWindow();
            }
            else
            {
                if (int.TryParse(Request, out numericValue)) ProductViewModel.Instance.SetProductByID(Int32.Parse(Request));
                else ProductViewModel.Instance.SetProductByText(Request);
            }
            return ResultPage;
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
        private void ProductsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(ProductWindow.getInstance());
        }

        private void ProductsListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
