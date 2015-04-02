using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class ReferralSource
    {
        public virtual int ReferralSourceId { get; set; }
        public virtual string Source { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}