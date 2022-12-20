using PL.Commands;
using PL.Model;
using PL.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace PL.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService = new UserService();
        private static ClientViewModel _instance = new ClientViewModel();
        public static ClientViewModel Instance => _instance;
        public ClientViewModel()
        {
            Clients = new ObservableCollection<UserModel>(_userService.GetClients());
            Salesmans = new ObservableCollection<SalesmanModel>(_userService.GetSalesmans());
            _autorizedUser = new UserModel();
        }
        public ObservableCollection<UserModel> Clients { get; set; }
        public ObservableCollection<SalesmanModel> Salesmans { get; set; }
        private PageName _currentWindowName;
        public PageName CurrentWindowName
        {
            get
            {
                return _currentWindowName;
            }
            set
            {
                _currentWindowName = value;
                OnPropertyChanged(nameof(CurrentWindowName));
            }
        }

        private UserModel _autorizedUser;
        public UserModel AuthorizedUser
        {
            get
            {
                return _autorizedUser;
            }
            set
            {
                _autorizedUser = value;
                OnPropertyChanged(nameof(AuthorizedUser));
            }
        }
        public bool Autorization(string ClientOrSalesmanChoose)
        {
            SalesmanModel AuthorizedUserSalesman = new SalesmanModel()
            {
                Saleman_Name = AuthorizedUser.Name,
                Salesman_Surname = AuthorizedUser.Surname,
                Telephone_Number = AuthorizedUser.Telephone_Number,
                Password = AuthorizedUser.Password,
                Location_Code = AuthorizedUser.Location_Code
            };

            SetUser(ClientOrSalesmanChoose == "Покупатель" ?
                _userService.GetClientFull(AuthorizedUser)
                : new UserModel(_userService.GetSalesmanFull(AuthorizedUserSalesman)));

            if (AuthorizedUser.Client_Code == 0)
            {
                System.Windows.MessageBox.Show("Вы ввели неправильные данные!");
                return false;
            }

            System.Windows.MessageBox.Show("Вы прошли авторизацию!");
            return true;
        }

        private void SetUser(UserModel NewUser)
        {
            if (NewUser == null) return;

            AuthorizedUser.Client_Code = NewUser.Client_Code;
            AuthorizedUser.isAuthorized = NewUser.isAuthorized;
            AuthorizedUser.Location_Code = NewUser.Location_Code;
            AuthorizedUser.Name = NewUser.Name;
            AuthorizedUser.Password = NewUser.Password;
            AuthorizedUser.Surname = NewUser.Surname;
            AuthorizedUser.Telephone_Number = NewUser.Telephone_Number;
            AuthorizedUser.UserTable = NewUser.UserTable;
            AuthorizedUser.isAuthorized = Visibilities.Visible;
        }

        public bool Registration(string TableChoose, string LocationName)
        {
            try
            {
                UserModel RegistrationUser = new UserModel()
                {
                    Name = AuthorizedUser.Name,
                    Surname = AuthorizedUser.Surname,
                    Telephone_Number = AuthorizedUser.Telephone_Number,
                    Password = AuthorizedUser.Password,
                    Location_Code = _userService.GetLocationCodeByName(LocationName),
                    UserTable = TableChoose == "Продавец" ? ClientVariety.Продавец : ClientVariety.Покупатель
                };
                _userService.AddClient(RegistrationUser, TableChoose);
                AuthorizedUser.Name = "";//Для того, чтобы не отображалось в форме профиля
                System.Windows.MessageBox.Show("Вы успешно зарегистрировались! Вы можете войти в свой аккаунт.");
                return true;
            }
            catch
            {
                System.Windows.MessageBox.Show("Случилась непредвиденная ошибка, проверьте данные ввода");
                return false;
            }
        }

        private RelayCommand _deauthorizationCommand;
        public RelayCommand DeauthorizationCommand => _deauthorizationCommand ??
                  (_deauthorizationCommand = new RelayCommand(obj =>
                  {
                      UserModel DefaultUser = new UserModel()
                      {
                          Client_Code = 0,
                          isAuthorized = Visibilities.Hidden,
                          Name = "",
                          Surname = "",
                          Telephone_Number = 0,
                          Password = "",
                          Location_Code = 0,
                          UserTable = ClientVariety.Покупатель
                      };

                      SetUser(DefaultUser);
                      OrderViewModel.Instance.SetCurrentOrderForAuthorizedUser();
                      OrderViewModel.Instance.SetCurrentOrderItem();

                      System.Windows.MessageBox.Show("Вы успешно вышли из аккаунта!");
                  }));

        private RelayCommand _saveToPDFCommand;
        /// <summary>
        /// Сохранение информации о пользователе в PDF
        /// </summary>
        public RelayCommand SaveToPDFCommand => _saveToPDFCommand ??
                  (_saveToPDFCommand = new RelayCommand(obj =>
                  {
                      if (AuthorizedUser.UserTable == ClientVariety.Покупатель) return;

                      var dialog = new System.Windows.Forms.FolderBrowserDialog();
                      var DatePicker = new DateChoose();

                      var Dates = Prompt.ShowDialog("Введите начальную и конечную дату", "Date");

                      if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                      {
                          PL.PDFWritter.WriteUser(AuthorizedUser,
                              dialog.SelectedPath + Path.DirectorySeparatorChar + AuthorizedUser.Name + ".pdf",
                              (DateTime)Dates[0],
                              (DateTime)Dates[1]);
                          System.Windows.MessageBox.Show("Успешно!");
                      }
                  }));

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    enum PageName
    {
        Войти,
        Зарегистрироваться
    }

    public static class Prompt
    {
        public static List<DateTime> ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 250;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            DateTimePicker inputBox1 = new DateTimePicker() { Left = 50, Top = 50, Width = 400 };
            DateTimePicker inputBox2 = new DateTimePicker() { Left = 50, Top = 90, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 130 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox1);
            prompt.Controls.Add(inputBox2);
            prompt.ShowDialog();
            List<DateTime> Result = new List<DateTime>();
            Result.Add(inputBox1.Value);
            Result.Add(inputBox2.Value);
            return Result;
        }
    }
}
