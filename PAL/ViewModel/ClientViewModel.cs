using PL.Model;
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
        public void Autorization(string ClientOrSalesmanChoose)
        {
            SalesmanModel AuthorizedUserSalesman = new SalesmanModel()
            {
                Saleman_Name = AuthorizedUser.Name,
                Salesman_Surname = AuthorizedUser.Surname,
                Telephone_Number = AuthorizedUser.Telephone_Number,
                Password = AuthorizedUser.Password,
                Location_Code = AuthorizedUser.Location_Code
            };
            AuthorizedUser = ClientOrSalesmanChoose == "Покупатель" ?
                _userService.GetClientFull(AuthorizedUser)
                : new UserModel(_userService.GetSalesmanFull(AuthorizedUserSalesman));

            AuthorizedUser.isAuthorized = Visibility.Visible;
        }
        public void SetPageName(string Name)
        {
            CurrentWindowName = Name == "Login" ? PageName.Войти : PageName.Зарегистрироваться;
            OnPropertyChanged(nameof(CurrentWindowName));
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
