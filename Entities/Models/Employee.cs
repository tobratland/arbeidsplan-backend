using Arbeidsplan.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Models
{
    [Table("employees")]
    public class Employee : IEntity
    {
        [Key]
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool CanHost { get; set; }
        public bool CanBackup1 { get; set; }
        public bool CanBackup2 { get; set; }

    }
}
