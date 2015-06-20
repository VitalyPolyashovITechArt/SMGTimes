using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMGTimes.Models
{
    public class UserOptions
    {
        public bool IsFullTime { get; set; }

        public int DefaultHoursForDay(DateTime date)
        {
            if (DayTimeSettings.Any(x => x.Day == date.DayOfWeek))
            {
                return DayTimeSettings.First(x => x.Day == date.DayOfWeek).Hours;
            }
            return 0;
        }

        public List<DayTimeSetting> DayTimeSettings { get; set; }

    }
}