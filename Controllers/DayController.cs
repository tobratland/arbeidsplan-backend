using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arbeidsplan.Contracts;
using Arbeidsplan.Services;
using Arbeidsplan.Entities.Extensions;
using Arbeidsplan.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arbeidsplan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ICalendarLogic _logic;
        public DayController(IRepositoryWrapper repository, ICalendarLogic logic)
        {
            _repository = repository;
            _logic = logic;
        }
        // GET: api/Day
        [HttpGet]
        public IActionResult GetAllDays()
        {
            try
            {
                var days = _repository.Day.GetAllDays();
                return Ok(days);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{fromDateTime}/{toDateTime}", Name="DaysByDates")]
        public IActionResult GetDaysWithinDateRange(DateTime fromDateTime, DateTime toDateTime)
        {
            if(fromDateTime.Date >= toDateTime.Date)
            {
                return BadRequest("Startdate needs to be before end date");
            }
            var days =  _repository.Day.GetDaysWithinDateRange(fromDateTime, toDateTime);
            return Ok(days);
        }

        // GET: api/Day/5
        [HttpGet("{id}", Name = "dayById")]
        public IActionResult GetDayById(Guid id)
        {
            try
            {
                var day = _repository.Day.GetDayById(id);
                if (day.IsEmptyObject())
                {
                    return NotFound();
                }
                else return Ok(day);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Day
        [HttpPost]
        public IActionResult CreateDay([FromBody] Day day)
        {
            try
            {
                if (day.IsObjectNull())
                {
                    return BadRequest("Score object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid object model");
                }
                if (_repository.Day.GetDayByDate(day.Date) == null)
                {
                    _repository.Day.CreateDay(day);
                    _repository.Save();
                    return CreatedAtRoute("EmployeeById", new { id = day.Id }, day);

                }
                return StatusCode(500, "Day allready exists");

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{fromDateTime}/{toDateTime}", Name = "DaysByDates")]
        public IActionResult CreateDays(DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {

                if(fromDateTime >= toDateTime) {
                    return BadRequest("startdate must be before enddate");
                }
                _logic.PopulateDateRangeWithDays(fromDateTime, toDateTime);
                return Ok("Days created");

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Day/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] Day day)
        {
            try
            {
                if (day.IsObjectNull())
                {
                    return BadRequest("account object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object.");
                }

                var dbDay = _repository.Day.GetDayById(id);
                if (dbDay.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Day.UpdateDay(dbDay, day);
                _repository.Save();

                return Ok(day);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDay(Guid id)
        {
            try
            {
                var day = _repository.Day.GetDayById(id);
                if (day.IsEmptyObject())
                {
                    return NotFound();
                }

                _repository.Day.DeleteDay(day);
                _repository.Save();

                return Ok("deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
