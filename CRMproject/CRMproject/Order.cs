using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class Order
    {
        public Guid OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientPhone { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductsId { get; set; }
        public List<ChangeEntry> ChangesEntries { get; set; } = new List<ChangeEntry>();

        public override string ToString()
        {
            var result = "Order Id: " + OrderId.ToString() + "\n\t Order Number: " + OrderNumber.ToString() + "\n\t Order date: " + OrderDate.ToString() + "\n\t Order Status: " + Status.ToString() + 
                "\n\t Client phone: " + ClientPhone + "\n\t Client Id: " + ClientId.ToString() + "\n\t Products Id: " + ProductsId.ToString();
            result += $"\n\tChange Entries Count: {ChangesEntries.Count}\n";
            foreach(var entry in ChangesEntries)
            {
                result += $"\t\t{entry.Date} - {entry.Status}\n";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }


        public class ChangeEntry
        {
            public DateTime Date { get; set; }
            public OrderStatus Status { get; set; }
        }

        public enum OrderStatus
        {
            New,
            IsMakingUp,
            Sent,
            Paid,
            Canceled
        }
    }
}
