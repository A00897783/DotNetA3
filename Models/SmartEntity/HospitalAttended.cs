using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class HospitalAttended
    {
        public virtual int HospitalAttendedId { get; set; }
        public virtual string HospitalName { get; set; }

        public virtual ICollection<Smart> Smart { get; set; }
    }
}