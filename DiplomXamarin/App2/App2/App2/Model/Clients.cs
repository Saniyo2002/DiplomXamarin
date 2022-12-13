using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            ClientComponent = new HashSet<ClientComponent>();
            Orders = new HashSet<Orders>();
        }

      
        public int ClientId { get; set; }

        
        public string ClientNick { get; set; }

       
        public string ClientMail { get; set; }

        
        public DateTime? ClientBirthday { get; set; }

        
        public string ClientImage { get; set; }

       
        public string ClientPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientComponent> ClientComponent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
