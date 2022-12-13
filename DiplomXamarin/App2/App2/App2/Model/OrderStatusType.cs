using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class OrderStatusType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderStatusType()
        {
            Orders = new HashSet<Orders>();
        }

      
        public int OrderStatusId { get; set; }

       
        public string OrderTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
