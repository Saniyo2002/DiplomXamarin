using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Rams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rams()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

        
        public int RamId { get; set; }

        public int ComponentTypeId { get; set; }

        public int RamFactoryId { get; set; }

        public string RamImage { get; set; }
        public string RamName { get; set; }

        public int RamCountSlots { get; set; }

        public int RamTypeId { get; set; }

        public decimal RamPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }

        public virtual RamType RamType { get; set; }
    }
}
