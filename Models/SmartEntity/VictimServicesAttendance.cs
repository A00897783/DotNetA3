﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class VictimServicesAttendance
    {
        public virtual int VictimServicesAttendanceId { get; set; }
        public virtual string YesNoNA { get; set; }

        public virtual ICollection<Smart> Smart { get; set; }
    }
}