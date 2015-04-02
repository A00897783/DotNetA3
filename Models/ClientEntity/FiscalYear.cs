using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class FiscalYear
    {
        public virtual int FiscalYearId { get; set; }
        public virtual string Years { get; set; }

        public virtual ICollection<Clients> Clients { get; set; }
    }
}