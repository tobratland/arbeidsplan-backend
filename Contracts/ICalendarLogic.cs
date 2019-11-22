using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Contracts
{
    public interface ICalendarLogic
    {
        public void PopulateDateRangeWithDays(DateTime startDate, DateTime endDate);
    }
}
