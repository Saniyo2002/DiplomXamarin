using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class SolidStateDrives
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolidStateDrives()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

       
        public int SsdId { get; set; }

        public int ComponentTypeId { get; set; }
        public int ProcessorSocketId { get; set; }

        public int SsdFactoryId { get; set; }

       
        public string SsdName { get; set; }

        public decimal SsdPrice { get; set; }

        
        public string SsdImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
    }
}
