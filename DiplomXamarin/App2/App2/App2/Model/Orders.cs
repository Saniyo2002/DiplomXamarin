using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Orders
    {
        
        public int OrderId { get; set; }

        public int ManagerId { get; set; }

        public int ClientComponentsId { get; set; }

        public int ClientId { get; set; }

       
        public DateTime OrderDate { get; set; }

        public int? OrderStatusId { get; set; }

        public virtual ClientComponent ClientComponent { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Managers Managers { get; set; }

        public virtual OrderStatusType OrderStatusType { get; set; }
    }
}
