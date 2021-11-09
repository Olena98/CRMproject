using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class Order
    {
        public Guid OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime  OrderDate  { get; set; }
        public string OrderStatus { get; set; }
        
    }
}
