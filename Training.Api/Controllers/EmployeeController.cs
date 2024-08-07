using Microsoft.AspNetCore.Mvc;
using Training.Api.Interfaces.Service;
using Training.Api.Models;

namespace Training.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.ListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRequestDto employeeDto)
        {
            var employee = await _employeeService.CreateAsync(employeeDto);
            return Ok(employee);
        }
    }
}
