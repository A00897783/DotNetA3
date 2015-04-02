using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class AssignedWorker
    {
        public virtual int AssignedWorkerId { get; set; }
        public virtual string Name {get; set;}

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}