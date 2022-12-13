using System;
using System.Collections.Generic;

namespace diplomApiV4
{
    public partial class FormFactorTypeMatheboard
    {
        public FormFactorTypeMatheboard()
        {
            Cases = new HashSet<Case>();
        }

        public int FormFactorTypeId { get; set; }
        public string FormFactorName { get; set; } = null!;

        public virtual ICollection<Case> Cases { get; set; }
    }
}
