using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class ChipsetTypeMatheboard
    {
        public ChipsetTypeMatheboard()
        {
            Matheboards = new HashSet<Matheboard>();
        }

        public int ChipsetTypeId { get; set; }
        public string ChipsetName { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Matheboard> Matheboards { get; set; }
    }
}
