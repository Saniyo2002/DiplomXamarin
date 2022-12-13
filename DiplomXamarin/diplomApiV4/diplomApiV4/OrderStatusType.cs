using System;
using System.Collections.Generic;

namespace diplomApiV4
{
    public partial class OrderStatusType
    {
        public OrderStatusType()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderTitle { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
