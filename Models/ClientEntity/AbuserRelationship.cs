using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class AbuserRelationship
    {
        public virtual int AbuserRelationshipId { get; set; }
        public virtual string Relationship { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}