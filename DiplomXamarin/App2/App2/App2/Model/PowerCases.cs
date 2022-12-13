using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class PowerCases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PowerCases()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

       
        public int PowerCaseId { get; set; }

        public int ComponentTypeId { get; set; }

        public int PowerCaseFactoryId { get; set; }

        
        public string PowerCaseName { get; set; }

        public decimal PowerCasePrice { get; set; }

       
        public string PowerCaseImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
    }
}
