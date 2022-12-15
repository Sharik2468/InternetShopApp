using PL.Commands;
using PL.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
            AuthorizedUser.isAuthorized = Visibility.Visible;
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
}
