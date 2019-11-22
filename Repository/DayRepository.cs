using Arbeidsplan.Contracts;
using Arbeidsplan.Entities;
using Arbeidsplan.Entities.Extensions;
using Arbeidsplan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Repository
{
    public class DayRepository : RepositoryBase<Day>, IDayRepository
    {
        public DayRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public Day CreateDay(Day day)
        {
            day.Id = Guid.NewGuid();
            Create(day);
            return (day);
        }

        public void DeleteDay(Day day)
        {
            Delete(day);
        }

        public IEnumerable<Day> GetAllDays()
        {
            return FindAll()
                .OrderBy(e => e.Date)
                .ToList();
        }

        public Day GetDayByDate(DateTime date)
        {
            return FindByCondition(d => d.Date.Equals(date))
                .DefaultIfEmpty()
                .FirstOrDefault();
        }
        public IEnumerable<Day> GetDaysWithinDateRange(DateTime startDate, DateTime endDate)
        {
            var days = RepositoryContext.Days.Where(d => d.Date >= startDate && d.Date <= endDate).ToList();
            days.OrderBy(d => d.Date);
            return days;
        }

        public Day GetDayById(Guid id)
        {
            return FindByCondition(d => d.Id.Equals(id))
                       .DefaultIfEmpty()
                       .FirstOrDefault();
        }

        public void UpdateDay(Day dbDay, Day day)
        {
            dbDay.Map(day);
            Update(dbDay);
        }
    }
}
