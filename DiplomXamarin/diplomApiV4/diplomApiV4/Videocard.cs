using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Videocard
    {
        public Videocard()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int VideocardId { get; set; }
        public int ComponentTypeId { get; set; }
        public int VideocardFactoryId { get; set; }
        public string VideocardName { get; set; } = null!;
        public decimal VideocardPrice { get; set; }
        public string? VideocardImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer VideocardFactory { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
