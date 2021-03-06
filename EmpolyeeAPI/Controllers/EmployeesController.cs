using EmployeeModels;
using EmpolyeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    err.Message);
            }
            
        }
            
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                Employee emp = await employeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee emp)
        {
            try
            {
                if (emp == null)
                {
                    return BadRequest();
                }

                var createdEmp = await employeeRepository.AddEmployee(emp);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmp.ID}, createdEmp);
            }
            catch (Exception err)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                Employee emp = await employeeRepository.GetEmployee(id);

                if (emp == null)
                {
                    return NotFound($"Employee with ID = {id} not found.");
                }

                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                Employee emp = await employeeRepository.GetEmployee(id);

                if (emp == null)
                {
                    return NotFound($"Employee with ID = {id} not found.");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string firstName, string? lastName, string? designation)
        {
            try
            {
                string _lastName = lastName == null ? string.Empty : lastName;
                string _designation = designation == null ? string.Empty : designation;

                var result = await employeeRepository.SearchEmp(firstName, _lastName, _designation);
                if (result.Any())
                {
                    return Ok(result);
                }
            }
            catch (Exception err)
            {

                throw;
            }
            
            return null;
        }
    }
}
