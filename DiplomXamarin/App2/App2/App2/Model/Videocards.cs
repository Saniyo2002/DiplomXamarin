using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Videocards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videocards()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

       
        public int VideocardId { get; set; }

        public int ComponentTypeId { get; set; }

        public int VideocardFactoryId { get; set; }

        
        public string VideocardName { get; set; }

        public decimal VideocardPrice { get; set; }

        
        public string VideocardImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
    }
}
