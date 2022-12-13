using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace diplomApiV4
{
    public partial class SocketType
    {
        public SocketType()
        {
            Matheboards = new HashSet<Matheboard>();
            Processors = new HashSet<Processor>();
        }

        public int IdSocketType { get; set; }
        public string SocketName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Matheboard> Matheboards { get; set; }
        [JsonIgnore]
        public virtual ICollection<Processor> Processors { get; set; }
    }
}
