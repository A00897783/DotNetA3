using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class Ethnicity
    {
        public virtual int EthnicityId { get; set; }
        public virtual string Description { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}