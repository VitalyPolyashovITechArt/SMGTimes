using System;
using System.Collections.Generic;

namespace SMGTimes.Models
{
    public class DayTime
    {
        public DateTime DateTime { get; set; }

        public List<DayActivityTime> ActivityTimes { get; set; }
    }
}