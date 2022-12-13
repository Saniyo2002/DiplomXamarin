using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class HardDisks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HardDisks()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

       
        public int HddId { get; set; }

        public int ComponentTypeId { get; set; }

        public int HddFactoryId { get; set; }

      
        public string HddName { get; set; }

        public decimal HddPrice { get; set; }

        
        public string HddImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
    }
}
