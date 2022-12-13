using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class M2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M2()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

        public int M2Id { get; set; }

        public int ComponentTypeId { get; set; }

        public int M2FactoryId { get; set; }

       
        public string M2Name { get; set; }

        public decimal M2Price { get; set; }

       
        public string M2Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
    }
}
