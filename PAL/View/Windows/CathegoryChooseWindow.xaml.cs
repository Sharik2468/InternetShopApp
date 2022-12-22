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
    /// Логика взаимодействия для CathegoryChooseWindow.xaml
    /// </summary>
    public partial class CathegoryChooseWindow : Page
    {

        public CathegoryChooseWindow()
        {
            InitializeComponent();
            DataContext = CathegoryViewModel.Instance;
        }

        private static Page CategoryPage = null;
        public static Page getInstance(int CategoryParentID)
        {
            if (CategoryPage == null)
            {
                CathegoryViewModel.Instance.SetNewCategory(CategoryParentID);
                CategoryPage = new CathegoryChooseWindow();
            }
            else
            {
                CathegoryViewModel.Instance.SetNewCategory(CategoryParentID);
            }
            return CategoryPage;
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
            try
            {
                if (CathegoryViewModel.Instance.SelectedCategory.Category_ID != 0)
                    this.NavigationService.Navigate(ResultWindow.getInstance(CathegoryViewModel.Instance.SelectedCategory.Category_ID.ToString()));
            }
            catch { }
        }
    }
}
