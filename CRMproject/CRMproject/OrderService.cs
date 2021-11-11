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
        public static List<Order> GetOrdersByDate(DateTime date) 
        {
            return OrdersDataBase.Orders.Where(o => o.OrderDate == date).ToList();
        }
        public static List<Order> GetOrdersByNumber(int number) 
        {
            return OrdersDataBase.Orders.Where(o => o.OrderNumber.ToString().ToUpper().Contains(number.ToString())).ToList(); 
        }
        public static List<Order> GetOrdersByStatus(string status) 
        {
            status = status.ToUpper();
            return OrdersDataBase.Orders.Where(o => o.OrderStatus.ToUpper().Contains(status)).ToList(); 
        }
        public static List<Client>GetOrdersByClientId(Guid clientId) 
        {
            return ClientsDataBase.Clients.Where(c => c.Id == clientId).ToList();
        }
        public static List<Product> GetOrdersByProductId(Guid productId) 
        {
            return ProductsDataBase.Products.Where(p => p.Id == productId).ToList();
        }
        public static List<Order> GetOrdersById(Guid guid) 
        {
            return OrdersDataBase.Orders.Where(o => o.OrderId == guid).ToList();
        }
    }
}
