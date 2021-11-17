using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMproject
{
    class OrderService
    {
        public static void AddNewOrder(Order orders)
        {
            OrdersDataBase.AddNewOrder(orders);
        }
        public static void AddChangedOrder(Order.ChangeEntry changeEntry) 
        {
            OrdersDataBase.AddNewOrder(changeEntry);
        }
        public static List<Order> GetOrdersByDate(DateTime date) 
        {
            var fullMatch = OrdersDataBase.Orders.Where(o => o.OrderDate == date).ToList();
            if(fullMatch.Count > 0)
            {
                return fullMatch;
            }

            var onlyDateMatch = OrdersDataBase.Orders.Where(o => o.OrderDate.Date == date.Date).ToList();
            return onlyDateMatch;
        }

        public static List<Order> GetOrdersByNumber(int number) 
        {
            return OrdersDataBase.Orders.Where(o => o.OrderNumber.ToString().ToUpper().Contains(number.ToString())).ToList(); 
        }
        public static List<Order> GetOrdersByStatus(string status) 
        {
            status = status.ToUpper();
            return OrdersDataBase.Orders.Where(o => !string.IsNullOrEmpty(o.OrderStatus) && o.OrderStatus.ToUpper().Contains(status)).ToList(); 
        }       
        public static List<Order> GetOrdersByPhone(string phone) 
        {
            return OrdersDataBase.Orders.Where(o => !string.IsNullOrEmpty(o.ClientPhone) && o.ClientPhone.Contains(phone)).ToList();
        }      
        public static List <Order> GetOrdersByClientGuid(Guid clientId) 
        {
            return OrdersDataBase.Orders.Where(o => o.ClientId == clientId).ToList();
        }       
        public static List<Order> GetOrdersByProductsGuid(Guid productId) 
        {
            return OrdersDataBase.Orders.Where(o => o.ProductsId == productId).ToList();
        }
        public static List<Order> GetOrdersById(Guid guid) 
        {
            return OrdersDataBase.Orders.Where(o => o.OrderId == guid).ToList();
        }
    }
}
