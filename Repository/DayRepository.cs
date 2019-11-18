using Arbeidsplan.Contracts;
using Arbeidsplan.Entities;
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
            throw new NotImplementedException();
        }

        public void DeleteDay(Day day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAllDays()
        {
            throw new NotImplementedException();
        }

        public Day GetDayByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Day GetDayById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDay(Day dbDay, Day day)
        {
            throw new NotImplementedException();
        }
    }
}
