using PL.Commands;
using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PL.Model
{
    class OrderModel : INotifyPropertyChanged
    {
        public OrderModel()
        {

        }

        public OrderModel(DBAccess.Order_Table c)
        {
            Order_Code = c.Order_Code;
            Order_Fullfillment = c.Order_Fullfillment;
            Order_Date = c.Order_Date;
            Client_Code = c.Client_Code;
            Salesman_Code = c.Salesman_Code;
            Delivery_Code = c.Delivery_Code;
        }

        public OrderModel(OrderModel c)
        {
            Order_Code = c.Order_Code;
            Order_Fullfillment = c.Order_Fullfillment;
            Order_Date = c.Order_Date;
            Client_Code = c.Client_Code;
            Salesman_Code = c.Salesman_Code;
            Delivery_Code = c.Delivery_Code;
        }

        public int Order_Code
        {
            get => _orderCode;
            set
            {
                _orderCode = value;
                OnPropertyChanged(nameof(Order_Code));
            }
        }
        public Nullable<System.DateTime> Order_Fullfillment
        {
            get => _orderFullfillment;
            set
            {
                _orderFullfillment = value;
                OnPropertyChanged(nameof(Order_Fullfillment));
            }
        }
        public Nullable<System.DateTime> Order_Date
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(Order_Date));
            }
        }
        public Nullable<int> Client_Code
        {
            get => _clientCode;
            set
            {
                _clientCode = value;
                OnPropertyChanged(nameof(Client_Code));
            }
        }
        public Nullable<int> Salesman_Code
        {
            get => _salesmanCode;
            set
            {
                _salesmanCode = value;
                OnPropertyChanged(nameof(Salesman_Code));
            }
        }
        public Nullable<int> Delivery_Code
        {
            get => _deliveryCode;
            set
            {
                _deliveryCode = value;
                OnPropertyChanged(nameof(Delivery_Code));
            }
        }

        public Nullable<int> Order_Result_Sum
        {
            get => _orderResultSum;
            set
            {
                _orderResultSum = value;
                OnPropertyChanged(nameof(Order_Result_Sum));
            }
        }

        public string Order_Result_Name
        {
            get => _orderResultName;
            set
            {
                _orderResultName = value;
                OnPropertyChanged(nameof(Order_Result_Name));
            }
        }

        public string Order_Status_Name
        {
            get => _orderStatusName;
            set
            {
                _orderStatusName = value;
                OnPropertyChanged(nameof(Order_Status_Name));
            }
        }

        public string Order_Client_Name
        {
            get => _orderClientName;
            set
            {
                _orderClientName = value;
                OnPropertyChanged(nameof(Order_Client_Name));
            }
        }

        private int _orderCode;
        private Nullable<System.DateTime> _orderFullfillment;
        private Nullable<System.DateTime> _orderDate;
        private Nullable<int> _clientCode;
        private Nullable<int> _salesmanCode;
        private Nullable<int> _deliveryCode;
        private Nullable<int> _orderResultSum;
        private string _orderResultName;
        private string _orderStatusName;
        private string _orderClientName;

        private RelayCommand _changeOrderStatusCommand;
        public RelayCommand ChangeOrderStatusCommand => _changeOrderStatusCommand ??
                  (_changeOrderStatusCommand = new RelayCommand(obj =>
                  {
                      OrderViewModel.Instance.ChangeOrderStatus();
                  }));

        private RelayCommand _acceptOrderStatusCommand;
        public RelayCommand AcceptOrderStatusCommand => _acceptOrderStatusCommand ??
                  (_acceptOrderStatusCommand = new RelayCommand(obj =>
                  {
                      OrderViewModel.Instance.ChangeOrderStatus(true);
                  }));

        #region Overides of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
