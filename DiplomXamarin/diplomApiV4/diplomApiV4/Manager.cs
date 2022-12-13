using System;
using System.Collections.Generic;

namespace diplomApiV4
{
    public partial class Manager
    {
        public Manager()
        {
            Orders = new HashSet<Order>();
        }

        public int ManagerId { get; set; }
        public string ManagerFullName { get; set; } = null!;
        public string ManagerPhone { get; set; } = null!;
        public string ManagerImage { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
