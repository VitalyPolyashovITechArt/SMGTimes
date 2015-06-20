using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMGTimes.Models
{
    public class UserOptions
    {
        public bool IsFullTime { get; set; }

        public DayTimeSetting GetDefaultSettingForDay(DateTime date)
        {
            return DayTimeSettings.FirstOrDefault(x => x.Day == date.DayOfWeek);
        }

        public List<DayTimeSetting> DayTimeSettings { get; set; }

    }
}