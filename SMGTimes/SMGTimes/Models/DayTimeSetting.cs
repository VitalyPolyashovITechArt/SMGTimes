using System;
using System.Collections.Generic;

namespace SMGTimes.Models
{
    public class DayTimeSetting
    {
        public DayOfWeek Day { get; set;}

        public List<DayActivityTime> ActivityTimes { get; set; }
    }
}