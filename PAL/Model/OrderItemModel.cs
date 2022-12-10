using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PL.Model
{
    class OrderItemModel : INotifyPropertyChanged
    {
        public OrderItemModel()
        {

        }

        public OrderItemModel(DBAccess.Order_Item_Table c)
        {
            Order_Item_Code = c.Order_Item_Code;
            Order_Sum = c.Order_Sum;
            Amount_Order_Item = c.Amount_Order_Item;
            Product_Code = c.Product_Code;
            Order_Code = c.Order_Code;
            Status_Order_Item_Table_ID = c.Status_Order_Item_Table_ID;
        }
        public int Order_Item_Code
        {
            get => _orderItemCode;
            set
            {
                _orderItemCode = value;
                OnPropertyChanged(nameof(Order_Item_Code));
            }
        }
        public Nullable<int> Order_Sum
        {
            get => _orderSum;
            set
            {
                _orderSum = value;
                OnPropertyChanged(nameof(Order_Sum));
            }
        }
        public Nullable<float> Amount_Order_Item
        {
            get => _amountOrderItem;
            set
            {
                _amountOrderItem = value;
                OnPropertyChanged(nameof(Amount_Order_Item));
            }
        }
        public Nullable<int> Product_Code
        {
            get => _productCode;
            set
            {
                _productCode = value;
                OnPropertyChanged(nameof(Product_Code));
            }
        }
        public Nullable<int> Order_Code
        {
            get => _orderCode;
            set
            {
                _orderCode = value;
                OnPropertyChanged(nameof(Order_Code));
            }
        }
        public int Status_Order_Item_Table_ID
        {
            get => _statusOrderItemTableID;
            set
            {
                _statusOrderItemTableID = value;
                OnPropertyChanged(nameof(Status_Order_Item_Table_ID));
            }
        }

        private int _orderItemCode;
        private Nullable<int> _orderSum;
        private Nullable<float> _amountOrderItem;
        private Nullable<int> _productCode;
        private Nullable<int> _orderCode;
        private int _statusOrderItemTableID;

        #region Overides of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
