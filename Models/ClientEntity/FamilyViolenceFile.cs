using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class FamilyViolenceFile
    {
        public virtual int FamilyViolenceFileId { get; set; }
        public virtual string FileExists { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}