using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class ReferringHospital
    {
        public virtual int ReferringHospitalId { get; set; }
        public virtual string HospitalName { get; set; }

        public virtual ICollection<Smart> Smart { get; set; }
    }
}