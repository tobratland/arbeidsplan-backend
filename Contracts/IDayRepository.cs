using Arbeidsplan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Contracts
{
    public interface IDayRepository
    {
        IEnumerable<Day> GetAllDays();
        Day GetDayById(Guid id);
        Day GetDayByDate(DateTime date);
        Day CreateDay(Day day);
        void UpdateDay(Day dbDay, Day day);
        void DeleteDay(Day day);
    }
}
