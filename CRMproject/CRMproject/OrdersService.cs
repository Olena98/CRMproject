using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class OrdersService
    {
        public static void AddNewOrder(Order orders)
        {
            OrdersDataBase.AddNewOrder(orders);
        }


    }
}
