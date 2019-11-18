using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Entities.Models
{
    [Table("Days")]
    public class Day: IEntity
    {
        [Key]
        [Column("DayId")]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid Host1Id { get; set; }
        public Guid Host2Id { get; set; }
        public Guid Backup1Id { get; set; }
        public Guid Backup2Id { get; set; }
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
