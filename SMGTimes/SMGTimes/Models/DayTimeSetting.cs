using System;

namespace SMGTimes.Models
{
    public class DayTimeSetting
    {
        public DayOfWeek Day { get; set;}

        public int Hours { get; set; }

        public string TaskName { get; set; }

        public string ProjectName { get; set; }
    }
}