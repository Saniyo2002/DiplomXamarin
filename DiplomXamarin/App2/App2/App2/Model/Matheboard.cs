using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
   
    public partial class Matheboard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matheboard()
        {
            ClientComponents = new HashSet<ClientComponent>();
        }

        public int MatheboardId { get; set; }
        public int ComponentTypeId { get; set; }
        public int MatheboardManufacturerId { get; set; }
        public string MatheboardName { get; set; } 
        public decimal MatheboardPrice { get; set; }
        public int MatheboardSocketId { get; set; }
        public int MatheboardChipsetId { get; set; }
        public int MatheboardRamTypeId { get; set; }
        public int? MatheboardM2count { get; set; }
        public int? MatheboardFormFactorTypeId { get; set; }
        public int MatheboardCountSlotsRam { get; set; }
        public string MatheboardImage { get; set; }

        public virtual ComponentsType ComponentType { get; set; }
        public virtual Manufacturers MatheboardManufacturer { get; set; }
        public virtual SocketType MatheboardSocket { get; set; } 
        public virtual ICollection<ClientComponent> ClientComponents { get; set; }
    }
}
