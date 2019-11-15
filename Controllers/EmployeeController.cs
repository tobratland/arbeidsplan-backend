using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arbeidsplan.Contracts;
using Arbeidsplan.Entities.Extensions;
using Arbeidsplan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arbeidsplan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public EmployeeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees();
                return Ok(employees);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "EmployeeById")]
        public IActionResult GetEmployeeById(Guid id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(id);
                if (employee.IsEmptyObject())
                {
                    return NotFound();
                }
                else return Ok(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("email/{email}", Name = "EmployeeByEmail")]
        public IActionResult GetEmployeeByEmail(string email)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeByEmail(email);
                if (employee.IsEmptyObject())
                {
                    return NotFound();
                }
                else return Ok(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee.IsObjectNull())
                {
                    return BadRequest("Score object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object model");
                }

                
                if(_repository.Employee.GetEmployeeByEmail(employee.Email) == null)
                {
                    _repository.Employee.CreateEmployee(employee);
                    _repository.Save();
                    return CreatedAtRoute("EmployeeById", new { id = employee.Id }, employee);

                }

                return StatusCode(500, "Person allready exists");

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] Employee employee)
        {
            try
            {
                if (employee.IsObjectNull())
                {
                    return BadRequest("account object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbemployee = _repository.Employee.GetEmployeeById(id);
                if (dbemployee.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Employee.UpdateEmployee(dbemployee, employee);
                _repository.Save();

                return Ok(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(id);
                if (employee.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Employee.DeleteEmployee(employee);
                _repository.Save();

                return Ok("deleted");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
