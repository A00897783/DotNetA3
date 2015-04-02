using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class CityOfResidence
    {
        public virtual int CityOfResidenceId { get; set; }
        public virtual string City { get; set; }

        public virtual ICollection<Smart> Smart { get; set; }
    }
}