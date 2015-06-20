using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMGTimes.Models
{
    public static class DateExtensions
    {
        public static bool IsWorkingDate(this DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }
    }
}