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

        [HttpPost("/{employeeId}/upload")]
        public async Task<IActionResult> UploadPhoto(int employeeId, [FromForm] UploadPhotoRequestDto file)
        {
            var employee = await _employeeService.UploadPhotoAsync(employeeId, file.Photo!);
            return Ok(employee);
        }

        [HttpGet("/{employeeId}/download")]
        public async Task<ActionResult> DownloadPhoto(int employeeId)
        {
            var dataBytes = await _employeeService.DownloadPhotoAsync(employeeId);
            return File(dataBytes, "image/png");
        }
    }
}
