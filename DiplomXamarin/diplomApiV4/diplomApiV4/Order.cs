using System;
using System.Collections.Generic;

namespace diplomApiV4
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int ManagerId { get; set; }
        public int ClientComponentsId { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? OrderStatusId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ClientComponent ClientComponents { get; set; } = null!;
        public virtual Manager Manager { get; set; } = null!;
        public virtual OrderStatusType? OrderStatus { get; set; }
    }
}
