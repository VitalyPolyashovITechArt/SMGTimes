using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMGTimes.Models;

namespace SMGTimes.Controllers
{

    [Route("api")]
    public class AppController : ApiController
    {
        public static List<DateTime> VacationDates = new List<DateTime>();

        public static UserOptions Options = new UserOptions()
        {
            DayTimeSettings = new List<DayTimeSetting>()
            {

                new DayTimeSetting()
                {
                    Day = DayOfWeek.Monday,
                    ActivityTimes = new List<DayActivityTime>()
                    {
                        new DayActivityTime() {TaskName = "Dev", Hours = 8}
                    }
                },
                new DayTimeSetting()
                {
                    Day = DayOfWeek.Tuesday,
                    ActivityTimes = new List<DayActivityTime>()
                    {
                        new DayActivityTime() {TaskName = "Dev", Hours = 8}
                    }
                },
                new DayTimeSetting()
                {
                    Day = DayOfWeek.Wednesday,
                    ActivityTimes = new List<DayActivityTime>()
                    {
                        new DayActivityTime() {TaskName = "Dev", Hours = 8}
                    }
                },

                new DayTimeSetting()
                {
                    Day = DayOfWeek.Thursday,
                    ActivityTimes = new List<DayActivityTime>()
                    {
                        new DayActivityTime() {TaskName = "Dev", Hours = 8}
                    }
                },
                new DayTimeSetting()
                {
                    Day = DayOfWeek.Friday,
                    ActivityTimes = new List<DayActivityTime>()
                    {
                        new DayActivityTime() {TaskName = "Dev", Hours = 8}
                    }
                }

            }
        }; 

        public static List<DayTime> InitialData = new List<DayTime>()
        {
            new DayTime() {}
        };

        [Route("getNotificationForLastWeek")]
        public List<DayTime> GetDataForLastWeek()
        {
            List<DayTime> dayTimes = new List<DayTime>();
            List<DateTime> workingDates = GetLastWorkingWeek();
            foreach (DateTime workingDate in workingDates)
            {
                //int hours = RequiredHoursFoDay(workingDate);]
                DayTime dayTime = new DayTime();
                dayTime.DateTime = workingDate;
                DayTimeSetting setting = Options.GetDefaultSettingForDay(workingDate);
                dayTime.ActivityTimes = setting.ActivityTimes;
                dayTimes.Add(dayTime);
            }
            return dayTimes;

        }

        private List<DateTime> GetLastWorkingWeek()
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime now = DateTime.Now.Date;
            DateTime day = now;

            do
            {
                day = day.AddDays(-1);
                if (day.IsWorkingDate())
                {
                    dates.Add(day);
                }
            } while (day.DayOfWeek != DayOfWeek.Sunday);


            //include "till 15th", "till end of month" cases


            if (now.GetLastWorkingDaysIfRequired().Any())
            {
                dates.AddRange(now.GetLastWorkingDaysIfRequired());
            }

            return dates;
        }

        private int RequiredHoursFoDay(DateTime date)
        {
            int hours = 0;
            var item = InitialData.FirstOrDefault(x => x.DateTime.Date == date.Date);
            if (item != null)
            {
                hours = item.ActivityTimes.Sum(x => x.Hours);
            }
            return Options.GetDefaultSettingForDay(date).ActivityTimes.Sum(x => x.Hours) - hours;

        }

        [Route("validate")]
        public string Validate(IEnumerable<DayTime> times)
        {
            var totalHours = times.SelectMany(a => a.ActivityTimes).Sum(t => t.Hours);
            if (!Options.IsPartTime)
            {
                if (totalHours > 40)
                {
                    return "More than 40 hours is going o be logged";
                }
                if (totalHours < 40)
                {
                    return "Less than 40 hours is going o be logged";
                }
            }
            return string.Empty;
        }

        [Route("log")]
        public void Log(IEnumerable<DayTime> times)
        {
            InitialData.AddRange(times);
        }

        [Route("getOptions")]
        public UserOptions GetOptions()
        {
            return Options;
        }
    }
}
