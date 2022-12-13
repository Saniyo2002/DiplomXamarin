using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class RamType
    {
        public RamType()
        {
            Rams = new HashSet<Ram>();
        }

        public int RamTypeId { get; set; }
        public string RamName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Ram> Rams { get; set; }
    }
}
