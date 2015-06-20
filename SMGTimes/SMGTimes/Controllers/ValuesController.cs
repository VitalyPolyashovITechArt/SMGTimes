using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMGTimes.Models;

namespace SMGTimes.Controllers
{
    public class MainController : ApiController
    {
        public static List<DateTime> VacationDates = new List<DateTime>();

        public static UserOptions Options = new UserOptions();

        public static List<DayTime> InitialData = new List<DayTime>()
        {
            new DayTime() {}
        };

        // GET api/values

        public List<DayTime> GetDataForLastWeek()
        {
            List<DayTime> dayTimes = new List<DayTime>();
            List<DateTime> workingDates = GetLastWorkingWeek();
            foreach (DateTime workingDate in workingDates)
            {
                int hours = RequiredHoursFoDay(workingDate);

            }
            throw new NotImplementedException();
        }

        public string GetWarningFOrTheLastWeek()
        {
            throw new NotImplementedException();
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

            return dates;
        }

        private int RequiredHoursFoDay(DateTime date)
        {
            int hours = 0;
            var item = InitialData.FirstOrDefault(x => x.DateTime.Date == date.Date);
            if (item != null)
            {
                hours = item.Hours;
            }
            return Options.GetDefaultSettingForDay(date).Hours - hours;

        }

        [Route("main/validate")]
        public string Validate(IEnumerable<DayTime> times)
        {
            var totalHours = times.Sum(t => t.Hours);
            if (!Options.IsPartTime && totalHours > 40)
            {
                return "More than 40 hours";
            }
            return string.Empty;
        }

        [Route("main/approve")]
        public void Approve(IEnumerable<DayTime> times)
        {
            InitialData.AddRange(times);
        }

        [Route("main/getOptions")]
        public UserOptions GetOptions()
        {
            return Options;
        }
    }
}
