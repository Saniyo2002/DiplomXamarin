using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Ram
    {
        public Ram()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int RamId { get; set; }
        public int ComponentTypeId { get; set; }
        public int RamFactoryId { get; set; }
        public string RamName { get; set; } = null!;
        public int RamCountSlots { get; set; }
        public int RamTypeId { get; set; }
        public decimal RamPrice { get; set; }
        public string RamImage { get; set; } = null!;

      
        public virtual ComponentsType ComponentType { get; set; } = null!;
      
        public virtual Manufacturer RamFactory { get; set; } = null!;
      
        public virtual RamType RamType { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
