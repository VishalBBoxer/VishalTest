using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingApplication.Models;
using TestingApplication.WebApi.Repository;

namespace TestingApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            try
            {
                return Ok(employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            try
            {
                var result = employeeRepository.GetEmployee(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeToUpdate = employeeRepository.GetEmployee(employee.EmployeeId);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");
                }

                return employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
