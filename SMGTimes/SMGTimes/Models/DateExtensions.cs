using System;
using System.Collections.Generic;

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

        private const int LastWorkingDaysInterval = 3;

        public static List<DateTime> GetLastWorkingDaysIfRequired(this DateTime date)
        {
            List<DateTime> extraDates = new List<DateTime>();
            if (date.Day <= 15)
            {
                DateTime lastDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
                int diff = 0;

                do
                {
                   
                    if (lastDate.Date.IsWorkingDate())
                    {
                        extraDates.Add(lastDate);
                        diff++;
                    }
                    lastDate = lastDate.AddDays(-1);

                } while (lastDate.Date > date);

                if (diff < LastWorkingDaysInterval)
                {
                    return extraDates;
                }
            }

            if (date.Day > 15)
            {
                DateTime lastDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                int diff = 0;

                do
                {

                    if (lastDate.Date.IsWorkingDate())
                    {
                        extraDates.Add(lastDate);
                        diff++;
                    }
                    lastDate = lastDate.AddDays(-1);

                } while (lastDate.Date > date);

                if (diff < LastWorkingDaysInterval)
                {
                    return extraDates;
                }
            }
            return new List<DateTime>();

        }
    }
}