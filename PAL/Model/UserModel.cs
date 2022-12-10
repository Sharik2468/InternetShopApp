using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PL.Model
{
    class UserModel : INotifyPropertyChanged
    {
        public UserModel()
        {

        }

        public UserModel(DBAccess.Client_Table c)
        {
            Client_Code = c.Client_Code;
            Name = c.Name;
            Surname = c.Surname;
            Telephone_Number = c.Telephone_Number;
            Password = c.Password;
            Location_Code = c.Location_Code;
            isAuthorized = Visibility.Hidden;
        }
        public UserModel(SalesmanModel c)
        {
            Client_Code = c.Salesman_Code;
            Name = c.Saleman_Name;
            Surname = c.Salesman_Surname;
            Telephone_Number = c.Telephone_Number;
            Password = c.Password;
            Location_Code = c.Location_Code;
            isAuthorized = Visibility.Hidden;
        }

        public Visibility isAuthorized
        {
            get => _isAuthorized;
            set
            {
                _isAuthorized = value;
                OnPropertyChanged(nameof(isAuthorized));
            }
        }
        public int Client_Code
        {
            get => _clientCode;
            set
            {
                _clientCode = value;
                OnPropertyChanged(nameof(Client_Code));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public Nullable<long> Telephone_Number
        {
            get => _telephoneNumber;
            set
            {
                _telephoneNumber = value;
                OnPropertyChanged(nameof(Telephone_Number));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public Nullable<int> Location_Code
        {
            get => _locationCode;
            set
            {
                _locationCode = value;
                OnPropertyChanged(nameof(Location_Code));
            }
        }

        private Visibility _isAuthorized;
        private int _clientCode;
        private string _name;
        private string _surname;
        private Nullable<long> _telephoneNumber;
        private string _password;
        private Nullable<int> _locationCode;


        #region Overides of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    enum Visibility
    {
        Hidden,
        Visible,
        Collapsed
    };
}
