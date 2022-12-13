using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App2.Model
{
    public partial class ClientComponent
    {
        
       

        public int clientComponentId { get; set; }

        public int clientId { get; set; }

        public int matheboardId { get; set; }

        public int processorId { get; set; }

        public int ramId { get; set; }

        public int videocardId { get; set; }

        public int powerCaseId { get; set; }

        public int caseId { get; set; }

        public int hddId { get; set; }

        public int ssdId { get; set; }

        public int m2id { get; set; }
       
        public string buildName { get; set; }

        public virtual Cases case1 { get; set; }

        public virtual Clients client { get; set; }

        public virtual HardDisks hdd { get; set; }

        public virtual M2 m2 { get; set; }

        public virtual Matheboard matheboard { get; set; }

        public virtual PowerCases powerCase { get; set; }

        public virtual Processor processor { get; set; }

        public virtual Rams ram { get; set; }

        public virtual SolidStateDrives ssd { get; set; }

        public virtual Videocards videocard { get; set; }

      
        
    }
}
