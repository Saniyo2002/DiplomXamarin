using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Cases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cases()
        {
            ClientComponent = new HashSet<ClientComponent>();
        }

       
        public int CaseId { get; set; }

        public int ComponentTypeId { get; set; }

        public int CaseFactoryId { get; set; }

        
        public string CaseName { get; set; }

        public int CaseFormFactorId { get; set; }

        public decimal CasePrice { get; set; }

      
        public string CaseImage { get; set; }

        public virtual ComponentsType ComponentsType { get; set; }

        public virtual FormFactorTypeMatheboard FormFactorTypeMatheboard { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }
    }
}
