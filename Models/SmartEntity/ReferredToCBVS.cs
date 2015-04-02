using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class ReferredToCBVS
    {
        public virtual int ReferredToCBVSId { get; set; }
        public virtual string YesNoPVBSOnlyNA { get; set; }

        public virtual ICollection<Smart> Smart { get; set; }
    }
}