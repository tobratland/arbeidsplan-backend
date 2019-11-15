using Arbeidsplan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Entities.Extensions
{
    public static class EmployeeExtensions
    {
        public static void Map(this Employee dbEmployee, Employee employee)
        {
            dbEmployee.Name = employee.Name;
            dbEmployee.Email = employee.Email;
            dbEmployee.CanBackup1 = employee.CanBackup1;
            dbEmployee.CanBackup2 = employee.CanBackup2;
            dbEmployee.CanHost = employee.CanHost;
        }
    }
}
