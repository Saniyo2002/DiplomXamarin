using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Managers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Managers()
        {
            Orders = new HashSet<Orders>();
        }

        
        public int ManagerId { get; set; }

        
        public string ManagerFullName { get; set; }

       
        public string ManagerPhone { get; set; }

       
        public string ManagerImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
