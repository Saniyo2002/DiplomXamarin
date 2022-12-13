using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Case
    {
        public Case()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int CaseId { get; set; }
        public int ComponentTypeId { get; set; }
        public int CaseFactoryId { get; set; }
        public string CaseName { get; set; } = null!;
        public int CaseFormFactorId { get; set; }
        public decimal CasePrice { get; set; }
        public string? CaseImage { get; set; }
        [JsonIgnore]
        public virtual Manufacturer CaseFactory { get; set; } = null!;
        [JsonIgnore]
        public virtual FormFactorTypeMatheboard CaseFormFactor { get; set; } = null!;
        [JsonIgnore]
        public virtual ComponentsType ComponentType { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
