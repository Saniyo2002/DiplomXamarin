using System;
using System.Collections.Generic;

namespace diplomApiV4
{
    public partial class ClientComponent
    {
        public ClientComponent()
        {
            Orders = new HashSet<Order>();
        }

        public int ClientComponentId { get; set; }
        public int ClientId { get; set; }
        public int MatheboardId { get; set; }
        public int ProcessorId { get; set; }
        public int RamId { get; set; }
        public int VideocardId { get; set; }
        public int PowerCaseId { get; set; }
        public int CaseId { get; set; }
        public int HddId { get; set; }
        public int SsdId { get; set; }
        public int M2id { get; set; }
        public string BuildName { get; set; }

        public virtual Case? Case1 { get; set; } = null!;
        public virtual Client? Client { get; set; } = null!;
        public virtual HardDisk? Hdd { get; set; } = null!;
        public virtual M2? M2 { get; set; } = null!;
        public virtual Matheboard? Matheboard { get; set; } = null!;
        public virtual PowerCase? PowerCase { get; set; } = null!;
        public virtual Processor? Processor { get; set; } = null!;
        public virtual Ram? Ram { get; set; } = null!;
        public virtual SolidStateDrife? Ssd { get; set; } = null!;
        public virtual Videocard? Videocard { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
