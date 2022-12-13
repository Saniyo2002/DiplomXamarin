using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class M2
    {
        public M2()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int M2id { get; set; }
        public int ComponentTypeId { get; set; }
        public int M2factoryId { get; set; }
        public string M2name { get; set; } = null!;
        public decimal M2price { get; set; }
        public string? M2image { get; set; }

        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer M2factory { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
