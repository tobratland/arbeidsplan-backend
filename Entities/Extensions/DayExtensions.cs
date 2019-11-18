using Arbeidsplan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Entities.Extensions
{
    public static class DayExtensions
    {
        public static void Map(this Day dbDay, Day day)
        {
            dbDay.Date = day.Date;
            dbDay.Host1Id = day.Host1Id;
            dbDay.Host2Id = day.Host2Id;
            dbDay.Backup1Id = day.Backup1Id;
            dbDay.Backup2Id = day.Backup2Id;
            dbDay.OpeningHour = day.OpeningHour;
            dbDay.ClosingHour = day.ClosingHour;
        }
    }
}
