using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class FormFactorTypeMatheboard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormFactorTypeMatheboard()
        {
            Cases = new HashSet<Cases>();
        }

      
        public int FormFactorTypeId { get; set; }

        
        public string FormFactorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cases> Cases { get; set; }
    }
}
