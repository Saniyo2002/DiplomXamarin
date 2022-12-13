using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Processor
    {
        public Processor()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int ProcessorId { get; set; }
        public int ComponentTypeId { get; set; }
        public int ProcessorSocketId { get; set; }
        public int ProcessorFactoryId { get; set; }
        public string ProcessorName { get; set; } = null!;
        public decimal ProcessorPrice { get; set; }
        public string? ProcessorImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer ProcessorFactory { get; set; } = null!;
        public virtual SocketType ProcessorSocket { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
