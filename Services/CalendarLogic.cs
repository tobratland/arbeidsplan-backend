using Arbeidsplan.Contracts;
using Arbeidsplan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Services
{
    public class CalendarLogic: ICalendarLogic
    {
        private readonly IRepositoryWrapper _repository;

        public CalendarLogic(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public void PopulateDateRangeWithDays(DateTime startDate, DateTime endDate)
        {
            foreach(DateTime day in EachDay(startDate, endDate))
            {
                TimeSpan timeSpanOpening = new TimeSpan(11, 00, 00);
                TimeSpan timeSpanClosing = new TimeSpan(14, 00, 00);
                DateTime openingHour = day.Date + timeSpanOpening;
                DateTime closingHour = day.Date + timeSpanClosing; 
                var newDay = new Day
                {
                    Id = Guid.NewGuid(),
                    Date = day,
                    Host1Id = Guid.Empty,
                    Host2Id = Guid.Empty,
                    Backup1Id = Guid.Empty,
                    Backup2Id = Guid.Empty,
                    OpeningHour = openingHour,
                    ClosingHour = closingHour
                };
                _repository.Day.CreateDay(newDay);
                _repository.Save();
            }
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
