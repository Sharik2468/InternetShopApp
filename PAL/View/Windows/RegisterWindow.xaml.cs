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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Page
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = ClientViewModel.Instance;
        }
        private static Page RegisterPage = null;
        public static Page getInstance()
        {
            if (RegisterPage == null)
            {
                RegisterPage = new RegisterWindow();
            }
            return RegisterPage;
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
            string LocationName = "";
            switch (SelectedStreet.SelectedIndex)
            {
                case 0: LocationName = Loc0.Text; break;
                case 1: LocationName = Loc1.Text; break;
                case 2: LocationName = Loc2.Text; break;
                case 3: LocationName = Loc3.Text; break;
                case 4: LocationName = Loc4.Text; break;
                case 5: LocationName = Loc5.Text; break;
                case 6: LocationName = Loc6.Text; break;
                case 7: LocationName = Loc7.Text; break;
                case 8: LocationName = Loc8.Text; break;
                case 9: LocationName = Loc9.Text; break;
            }
            if (!ClientViewModel.Instance.Registration(SelectedUserTable.SelectedIndex == 0 ? ClientName.Text : SalesmanName.Text, LocationName)) return;

            this.NavigationService.Navigate(Start.getInstance());
        }
    }
}
