using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PL.Commands;
using PL.Model;
using PL.ViewModel;


namespace PL.ViewModel
{
    class OrderViewModel : INotifyPropertyChanged
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly ProductService _productService = new ProductService();
        private static OrderViewModel _instance = new OrderViewModel();
        public static OrderViewModel Instance => _instance;
        OrderViewModel()
        {
            OrderItems = new ObservableCollection<OrderItemModel>();
            ProductsInBasket = new ObservableCollection<Product>();
            CurrentOrder = new OrderModel(GetCurrentOrderForAuthorizedUser());
        }
        public ObservableCollection<OrderItemModel> OrderItems { get; set; }
        public ObservableCollection<Product> ProductsInBasket { get; set; }
        private OrderModel _currentOrder;
        public OrderModel CurrentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        public OrderModel GetCurrentOrderForAuthorizedUser()
        {
            try
            {
                return _orderService.GetCurentOrderForUser(ClientViewModel.Instance.AuthorizedUser);
            }
            catch { return new OrderModel(); }
        }

        public void SetCurrentOrderForAuthorizedUser()
        {
            CurrentOrder = new OrderModel(GetCurrentOrderForAuthorizedUser());
            OnPropertyChanged(nameof(CurrentOrder));
        }

        public void SetCurrentOrderItem()
        {
            OrderItems = new ObservableCollection<OrderItemModel>(_orderService.GetAllOrderItems((int)CurrentOrder.Order_Code));
            OnPropertyChanged(nameof(OrderItems));

            ProductsInBasket = new ObservableCollection<Product>(GetProductsByOrderItem(OrderItems));
            OnPropertyChanged(nameof(ProductsInBasket));
        }

        private RelayCommand _addOrderItemCommand;
        public RelayCommand AddOrderItemCommand => _addOrderItemCommand ??
                  (_addOrderItemCommand = new RelayCommand(obj =>
                  {
                      AddNewOrderItemToTheBasket();
                  }));

        public void AddNewOrderItemToTheBasket()
        {
            bool NewOrder = false;
            if (CurrentOrder.Order_Code == 0)
            {
                CurrentOrder = new OrderModel()
                {
                    Order_Code = GetMaxOrderIndex() + 1,
                    Order_Fullfillment = DateTime.Now,
                    Order_Date = DateTime.Now,
                    Client_Code = ClientViewModel.Instance.AuthorizedUser.Client_Code,
                    Salesman_Code = 1,//TODO добавить код того, кто добавил продукт!!!!
                    Delivery_Code = 1,
                };
                if (CurrentOrder.Order_Code == 0) { CurrentOrder = new OrderModel(); return; }
                NewOrder = true;
                _orderService.AddOrder(CurrentOrder);
            }

            OrderItemModel NewOrderItem = new OrderItemModel()
            {
                Order_Item_Code = GetMaxOrderItemIndex() + 1,
                Order_Sum = (int)ProductViewModel.Instance.SelectedProduct.MarketPrice,
                Amount_Order_Item = 1,
                Product_Code = ProductViewModel.Instance.SelectedProduct.Product_Code,
                Order_Code = CurrentOrder.Order_Code,
                Status_Order_Item_Table_ID = 1
            };

            if (NewOrder)
            {
                OrderItems.Add(NewOrderItem);
                _orderService.AddOrderItem(NewOrderItem);
            }
            else
            {
                int RepeatIndex = FindRepeatOrder(NewOrderItem);

                if (RepeatIndex == 0) { OrderItems.Add(NewOrderItem); _orderService.AddOrderItem(NewOrderItem); }
                else SetNewAmount(Operations.Plus, _orderService.FindRepeatOrderItem(NewOrderItem));
            }
        }

        private void SetNewAmount(Operations Opeartion, OrderItemModel RepeatOrderItem)
        {
            OrderItemModel NewOrderItem = new OrderItemModel()
            {
                Order_Item_Code = FindRepeatOrder(RepeatOrderItem),
                Order_Sum = Opeartion == Operations.Plus ?
                                         RepeatOrderItem.Order_Sum += (int)_productService.GetProductByID((int)RepeatOrderItem.Product_Code)[0].MarketPrice :
                                         RepeatOrderItem.Order_Sum -= (int)_productService.GetProductByID((int)RepeatOrderItem.Product_Code)[0].MarketPrice,
                Amount_Order_Item = Opeartion == Operations.Plus ?
                                         RepeatOrderItem.Amount_Order_Item += 1 :
                                         RepeatOrderItem.Amount_Order_Item -= 1,
                Product_Code = ProductViewModel.Instance.SelectedProduct.Product_Code,
                Order_Code = CurrentOrder.Order_Code,
                Status_Order_Item_Table_ID = 1
            };

            _orderService.DeleteOrderItem(RepeatOrderItem);
            _orderService.AddOrderItem(NewOrderItem);
            SetCurrentOrderItem();
        }

        private int FindRepeatOrder(OrderItemModel OrderItem)
        {
            var item = _orderService.FindRepeatOrderItem(OrderItem);
            return (int)(item.Order_Code == 0 ? 0 : item.Order_Code);
        }
        private ObservableCollection<Product> GetProductsByOrderItem(ObservableCollection<OrderItemModel> Orders)
        {
            return _orderService.GetProductsByOrderItem(Orders);
        }

        private int GetMaxOrderIndex()
        {
            try
            {
                OrderModel max;
                List<OrderModel> Orders;
                max = new OrderModel();
                Orders = _orderService.GetAllOrders((int)CurrentOrder.Client_Code);
                foreach (var entry in Orders)
                    if (entry.Order_Code > max.Order_Code) max = entry;
                return max.Order_Code;
            }
            catch { System.Windows.MessageBox.Show("Пожалуйста, авторизтруйтесь"); return -1; }
        }

        private int GetMaxOrderItemIndex()
        {
            OrderItemModel max;
            List<OrderItemModel> OrderItems;
            max = new OrderItemModel();
            OrderItems = _orderService.GetAllOrderItems(CurrentOrder.Order_Code);
            foreach (var entry in OrderItems)
                if (entry.Order_Item_Code > max.Order_Item_Code) max = entry;
            return max.Order_Item_Code;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    enum Operations
    {
        Plus,
        Minus
    };
}
