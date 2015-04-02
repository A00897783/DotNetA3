using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class RiskStatus
    {
        public virtual int RiskStatusId { get; set; }
        public virtual string Status { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}