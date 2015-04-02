using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class VictimOfIncident
    {
        public virtual int VictimOfIncidentId { get; set; }
        public virtual string PrimaryOrSecondary { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}