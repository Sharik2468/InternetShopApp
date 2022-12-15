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

        public List<OrderModel> GetAllOrders()
        {
            return db.Order_Table.AsEnumerable().Select(o => new OrderModel(o)).ToList();
        }
        public ObservableCollection<Product> GetProductsByOrderItem(ObservableCollection<OrderItemModel> Orders)
        {
            ObservableCollection<Product> SelectedProduct = new ObservableCollection<Product>();

            foreach (var o in Orders)
            {
                var CurrentProduct = db.Product_Table.AsEnumerable().Select(o => new Product(o))
                     .Where(s => s.Product_Code == o.Product_Code).First();

                CurrentProduct.CurrentAmount = (int)o.Amount_Order_Item;
                CurrentProduct.CurrentStatusID = o.Status_Order_Item_Table_ID;
                CurrentProduct.CurrentSum = (float)o.Order_Sum;

                SelectedProduct.Add(CurrentProduct);
            }

            return SelectedProduct;
        }

        public OrderItemModel FindRepeatOrderItem(OrderItemModel OrderItem)
        {
                return db.Order_Item_Table.AsEnumerable().Select(o => new OrderItemModel(o))
                         .Where(s => s.Product_Code == OrderItem.Product_Code && s.Order_Code == OrderItem.Order_Code).First();
        }

        public void AddOrder(OrderModel Order)
        {
            int max = GetMaxOrderCode();

            var dbOrder = new Order_Table()
            {
                Order_Code = max + 1,
                Order_Fullfillment = Order.Order_Fullfillment,
                Order_Date = Order.Order_Date,
                Client_Code = Order.Client_Code,
                Salesman_Code = Order.Salesman_Code,
                Delivery_Code = Order.Delivery_Code
            };
            db.Order_Table.Add(dbOrder);
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
            Order_Item_Table p = db.Order_Item_Table.Where(s => s.Order_Item_Code == orderItem.Order_Item_Code).First();
            db.Order_Item_Table.Remove(p);
            db.SaveChanges();
        }

        public void DeleteOrder(OrderModel order)
        {
            Order_Table p = db.Order_Table.Where(s => s.Order_Code == order.Order_Code).First();
            db.Order_Table.Remove(p);
            db.SaveChanges();
        }

        public OrderModel GetCurentOrderForUser(UserModel User)
        {
            return db.Order_Table.AsEnumerable().Select(o => new OrderModel(o))
                     .Where(s => s.Client_Code == User.Client_Code).First();
        }
    }
}
