using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class PowerCase
    {
        public PowerCase()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int PowerCaseId { get; set; }
        public int ComponentTypeId { get; set; }
        public int PowerCaseFactoryId { get; set; }
        public string PowerCaseName { get; set; } = null!;
        public decimal PowerCasePrice { get; set; }
        public string? PowerCaseImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; } = null!;
        public virtual Manufacturer PowerCaseFactory { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
