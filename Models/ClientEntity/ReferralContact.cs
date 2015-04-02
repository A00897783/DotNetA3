using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class ReferralContact
    {
        public virtual int ReferralContactId { get; set; }
        public virtual string Contact { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}