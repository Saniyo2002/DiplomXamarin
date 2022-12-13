using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Processor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Processor()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int ProcessorId { get; set; }
        public int ComponentTypeId { get; set; }
        public int ProcessorSocketId { get; set; }
        public int ProcessorFactoryId { get; set; }
        public string ProcessorName { get; set; } 
        public decimal ProcessorPrice { get; set; }
        public string ProcessorImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; } 
        public virtual Manufacturers ProcessorFactory { get; set; } 
        public virtual SocketType ProcessorSocket { get; set; } 
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
