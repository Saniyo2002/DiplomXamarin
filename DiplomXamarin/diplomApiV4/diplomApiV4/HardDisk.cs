using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class HardDisk
    {
        public HardDisk()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int HddId { get; set; }
        public int ComponentTypeId { get; set; }
        public int HddFactoryId { get; set; }
        public string HddName { get; set; } = null!;
        public decimal HddPrice { get; set; }
        public string? HddImage { get; set; }
      
        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer HddFactory { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
