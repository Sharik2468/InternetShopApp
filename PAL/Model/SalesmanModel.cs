using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PL.Model
{
    class SalesmanModel : INotifyPropertyChanged
    {
        public SalesmanModel()
        {

        }

        public SalesmanModel(DBAccess.Salesman_Table c)
        {
            Salesman_Code = c.Salesman_Code;
            Saleman_Name = c.Saleman_Name;
            Salesman_Surname = c.Salesman_Surname;
            Telephone_Number = c.Telephone_Number;
            Password = c.Password;
            Location_Code = c.Location_Code;
        }
        public int Salesman_Code
        {
            get => _salesmanCode;
            set
            {
                _salesmanCode = value;
                OnPropertyChanged(nameof(Salesman_Code));
            }
        }
        public string Saleman_Name
        {
            get => _salemanName;
            set
            {
                _salemanName = value;
                OnPropertyChanged(nameof(Saleman_Name));
            }
        }
        public string Salesman_Surname
        {
            get => _salesmanSurname;
            set
            {
                _salesmanSurname = value;
                OnPropertyChanged(nameof(Salesman_Surname));
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

        private int _salesmanCode;
        private string _salemanName;
        private string _salesmanSurname;
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
}
