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
        public IEnumerable<DayTime> GetDataForLast()
        {
            List<DateTime> workingDates = GetLastWorkingWeek();
            throw new Exception();

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
            return Options.DefaultHoursForDay(date) - hours;
        }

        public void Approve(IEnumerable<DateTime> times)
        {
            
        }




    }
}
