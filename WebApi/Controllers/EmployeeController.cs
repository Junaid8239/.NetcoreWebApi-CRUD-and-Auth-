using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { message = $"Employee with ID {id} not found." });
            }

            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            var createdEmployee = await _employeeRepository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployeesById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            var existingEmployee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound(new { message = $"Employee with ID {id} not found." });
            }

            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(id, employee);

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesById([FromRoute] int id)
        {
            var employee = await _employeeRepository.DeleteEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = $"Employee with ID {id} not found." });
            }

            return Ok(new
            {
                message = $"Employee with ID {id} deleted successfully.",
                deletedEmployee = employee
            });
        }


    }
}
