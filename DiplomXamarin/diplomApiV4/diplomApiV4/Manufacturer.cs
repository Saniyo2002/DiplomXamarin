using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Cases = new HashSet<Case>();
            HardDisks = new HashSet<HardDisk>();
            M2s = new HashSet<M2>();
            Matheboards = new HashSet<Matheboard>();
            PowerCases = new HashSet<PowerCase>();
            Processors = new HashSet<Processor>();
            Rams = new HashSet<Ram>();
            SolidStateDrives = new HashSet<SolidStateDrife>();
            Videocards = new HashSet<Videocard>();
        }

        public int FactoryId { get; set; }
        public string FactoryName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Case> Cases { get; set; }
        [JsonIgnore]
        public virtual ICollection<HardDisk> HardDisks { get; set; }
        [JsonIgnore]
        public virtual ICollection<M2> M2s { get; set; }
        [JsonIgnore]
        public virtual ICollection<Matheboard> Matheboards { get; set; }
        [JsonIgnore]
        public virtual ICollection<PowerCase> PowerCases { get; set; }
        [JsonIgnore]
        public virtual ICollection<Processor> Processors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ram> Rams { get; set; }
        [JsonIgnore]
        public virtual ICollection<SolidStateDrife> SolidStateDrives { get; set; }
        [JsonIgnore]
        public virtual ICollection<Videocard> Videocards { get; set; }
    }
}
