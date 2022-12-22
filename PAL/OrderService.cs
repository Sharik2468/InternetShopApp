using DBAccess;
using PL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PL
{
    class OrderService
    {
        InternetShopEntities db;

        public OrderService()
        {
            db = new InternetShopEntities();
        }

        public List<OrderItemModel> GetAllOrderItems(int OrderID)
        {
            var c = db.Order_Item_Table.AsEnumerable().Select(o => new OrderItemModel(o))
                .Where(s => s.Order_Code == OrderID);
            return c.ToList();
        }

        public List<OrderModel> GetAllOrdersByUserID(int UserID)
        {
            var c = db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                .Where(s => s.Client_Code == UserID);
            return c.ToList();
        }

        public List<OrderModel> GetAllAcceptedOrdersForSelasman(int UserID, System.DateTime Start, System.DateTime End)
        {
            return db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                .Where(s => s.Salesman_Code == UserID
                && s.Order_Fullfillment >= Start
                && s.Order_Fullfillment <= End
                && s.Delivery_Code==3).ToList();
        }

        public List<OrderModel> GetAllOrders()
        {
            return db.Order_Table.AsEnumerable().Select(o => new OrderModel(o)).ToList();
        }

        public ObservableCollection<Product> GetProductsByOrderItem(ObservableCollection<OrderItemModel> Orders)
        {
            ObservableCollection<Product> SelectedProduct = new ObservableCollection<Product>();

            foreach (var o in Orders.Reverse())
            {
                var CurrentProduct = db.Product_Table.AsEnumerable().Select(o => new Product(o))
                     .Where(s => s.Product_Code == o.Product_Code).First();

                CurrentProduct.CurrentAmount = (int)o.Amount_Order_Item;
                CurrentProduct.CurrentStatusName = db.Status_Order_Item_Table.AsEnumerable().Select(o => new StatusItemModel(o))
                     .Where(s => s.Status_Order_Item_ID == o.Status_Order_Item_Table_ID).First().Status_Order_Item_Table1;
                CurrentProduct.CurrentSum = (float)o.Order_Sum;
                CurrentProduct.CurrentButtonStatusName = CurrentProduct.CurrentStatusName == "В наличии" ? "Не включать в заказ" : "Включать в заказ";

                SelectedProduct.Add(CurrentProduct);
            }

            return SelectedProduct;
        }

        public OrderItemModel FindRepeatOrderItem(OrderItemModel OrderItem)
        {
            return db.Order_Item_Table.AsEnumerable().Select(o => new OrderItemModel(o))
                     .Where(s => s.Product_Code == OrderItem.Product_Code && s.Order_Code == OrderItem.Order_Code).First();
        }

        public void AddOrder(OrderModel Order, bool ForceCode = false)
        {
            int max = GetMaxOrderCode();

            var dbOrder = new Order_Table()
            {
                Order_Code = ForceCode ? Order.Order_Code : max + 1,
                Order_Fullfillment = Order.Order_Fullfillment,
                Order_Date = Order.Order_Date,
                Client_Code = Order.Client_Code,
                Salesman_Code = Order.Salesman_Code,
                Delivery_Code = Order.Delivery_Code
            };
            db.Order_Table.Add(dbOrder);
            db.SaveChanges();
        }

        public void EditOrder(OrderModel Order)
        {
            var dbOrder = db.Order_Table.FirstOrDefault(u => u.Order_Code == Order.Order_Code);
            dbOrder.Order_Code = Order.Order_Code;
            dbOrder.Order_Fullfillment = Order.Order_Fullfillment;
            dbOrder.Order_Date = Order.Order_Date;
            dbOrder.Client_Code = Order.Client_Code;
            dbOrder.Salesman_Code = Order.Salesman_Code;
            dbOrder.Delivery_Code = Order.Delivery_Code;
            db.SaveChanges();
        }

        public void AddOrderItem(OrderItemModel OrderItem)
        {
            int max = GetMaxOrderItemCode();

            var dbOrder = new Order_Item_Table()
            {
                Order_Item_Code = max + 1,
                Order_Sum = OrderItem.Order_Sum,
                Amount_Order_Item = OrderItem.Amount_Order_Item,
                Product_Code = OrderItem.Product_Code,
                Order_Code = OrderItem.Order_Code,
                Status_Order_Item_Table_ID = OrderItem.Status_Order_Item_Table_ID
            };
            db.Order_Item_Table.Add(dbOrder);
            db.SaveChanges();
        }

        private int GetMaxOrderItemCode()
        {
            var max = new Order_Item_Table();
            foreach (var entry in db.Order_Item_Table)
            {
                if (entry.Order_Item_Code > max.Order_Item_Code)
                {
                    max = entry;
                }
            }
            return (int)max.Order_Item_Code;
        }

        private int GetMaxOrderCode()
        {
            var max = new Order_Table();
            foreach (var entry in db.Order_Table)
            {
                if (entry.Order_Code > max.Order_Code)
                {
                    max = entry;
                }
            }
            return max.Order_Code;
        }

        public void DeleteOrderItem(OrderItemModel orderItem)
        {
            if (orderItem.Order_Item_Code == 0) return;

            Order_Item_Table p = db.Order_Item_Table.Where(s => s.Order_Item_Code == orderItem.Order_Item_Code).First();
            db.Order_Item_Table.Remove(p);
            db.SaveChanges();
        }

        public void DeleteOrder(OrderModel order)
        {
            if (order.Order_Code == 0) return;
            Order_Table p = db.Order_Table.Where(s => s.Order_Code == order.Order_Code).First();
            db.Order_Table.Remove(p);
            db.SaveChanges();
        }

        public OrderModel GetCurentOrderForUser(UserModel User)
        {
            return db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                     .Where(s => s.Client_Code == User.Client_Code
                     && s.Delivery_Code == 1).First();
        }

        public ObservableCollection<OrderModel> GetOrdersForUser(UserModel User, ViewModel.OrderVariant variant = ViewModel.OrderVariant.ForView)
        {
            IEnumerable<OrderModel> Orders = null;
            switch (variant)
            {

                case ViewModel.OrderVariant.ForView:
                    Orders = db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                                                          .Where(s => s.Client_Code == User.Client_Code
                                                                    && s.Delivery_Code != 3); break;
                case ViewModel.OrderVariant.ForAccept:
                    Orders = db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                                                           .Where(s => s.Delivery_Code == 2); break;
                case ViewModel.OrderVariant.ForHistory:
                    Orders = db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                                                           .Where(s => s.Client_Code == User.Client_Code); break;
                case ViewModel.OrderVariant.ForSalesmanHistory:
                    Orders = db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                                                           .Where(s => s.Salesman_Code == User.Client_Code &&
                                                                       s.Delivery_Code == 3); break;
            }

            ObservableCollection<OrderModel> Result = new ObservableCollection<OrderModel>();

            foreach (var order in Orders.Reverse())
            {
                ProductService _productService = new ProductService();
                UserService _userService = new UserService();
                order.Order_Result_Sum = 0;

                var OrderItems = GetAllOrderItems(order.Order_Code);
                foreach (var orderItem in OrderItems)
                {
                    order.Order_Result_Name += _productService.GetProductByID((int)orderItem.Product_Code).FirstOrDefault().Name + " ";
                    order.Order_Result_Sum += (int)_productService.GetProductByID((int)orderItem.Product_Code).FirstOrDefault().MarketPrice;//TODO PriceToFloat
                }

                order.Order_Status_Name = GetOrderStatusByID((int)order.Delivery_Code);
                order.Order_Client_Name = _userService.GetClientByID((int)order.Client_Code).Name;
                Result.Add(order);
            }

            return Result;
        }

        public string GetOrderStatusByID(int ID)
        {
            return db.Status_Table.AsEnumerable().Select(o => new StatusOrderModel(o))
                     .Where(s => s.Delivery_Code == ID).First().Order_Status;
        }
    }
}
