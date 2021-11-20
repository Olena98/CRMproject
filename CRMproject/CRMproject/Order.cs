﻿using System;
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
        public List<ChangeEntry> ChangesEntries { get; set; }

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
