using Arbeidsplan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        Employee GetEmployeeByEmail(string email);
        Employee CreateEmployee(Employee employee);
        void UpdateEmployee(Employee dbEmployee, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
