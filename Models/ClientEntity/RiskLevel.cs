using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class RiskLevel
    {
        public virtual int RiskLevelId { get; set; }
        public virtual string Level { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}