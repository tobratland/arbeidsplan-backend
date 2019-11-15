using Arbeidsplan.Contracts;
using Arbeidsplan.Entities;
using Arbeidsplan.Entities.Extensions;
using Arbeidsplan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return FindAll()
                .OrderBy(e => e.Name)
                .ToList();

        }

        public Employee GetEmployeeByEmail(string email)
        {
            return FindByCondition(e => e.Email.Equals(email))
                .DefaultIfEmpty()
                .FirstOrDefault();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return FindByCondition(e => e.Id.Equals(id))
                    .DefaultIfEmpty()
                    .FirstOrDefault();
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            Create(employee);
            return (employee);
        }

        public void UpdateEmployee(Employee dbEmployee, Employee employee)
        {
            dbEmployee.Map(employee);
            Update(dbEmployee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
