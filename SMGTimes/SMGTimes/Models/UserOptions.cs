using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace SMGTimes.Models
{
    public class UserOptions
    {
        public bool IsPartTime { get; set; }

        public bool NotifyOn15ThAndTheEndOfMonth { get; set; }

        public DayOfWeek NotificationDayOfWeek { get; set; }

        public LocalTime NotificationTime { get; set; }

        public bool NotifyOnMondayMorning { get; set; }

        public DayTimeSetting GetDefaultSettingForDay(DateTime date)
        {
            return DayTimeSettings.FirstOrDefault(x => x.Day == date.DayOfWeek);
        }

        public List<DayTimeSetting> DayTimeSettings { get; set; }

    }
}