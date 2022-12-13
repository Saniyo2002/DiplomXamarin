
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace App2.Model
{
    public partial class SocketType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SocketType()
        {
            Matheboards = new HashSet<Matheboard>();
            Processors = new HashSet<Processor>();
        }

        public int IdSocketType { get; set; }
        public string SocketName { get; set; } 
        
        public virtual ICollection<Matheboard> Matheboards { get; set; }
        
        public virtual ICollection<Processor> Processors { get; set; }

    }
}
