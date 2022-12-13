using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class RamType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RamType()
        {
            Rams = new HashSet<Rams>();
        }

        public int RamTypeId { get; set; }

       
        public string RamName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rams> Rams { get; set; }
    }
}
