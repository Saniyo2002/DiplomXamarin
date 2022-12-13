using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class SolidStateDrife
    {
        public SolidStateDrife()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int SsdId { get; set; }
        public int ComponentTypeId { get; set; }
        public int SsdFactoryId { get; set; }
        public string SsdName { get; set; } = null!;
        public decimal SsdPrice { get; set; }
        public string? SsdImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer SsdFactory { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
