using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class DuplicateFile
    {
        public virtual int DuplicateFileId { get; set; }
        public virtual string YesOrNull { get; set; }

        public virtual IEnumerable<Clients> Clients { get; set; }
    }
}