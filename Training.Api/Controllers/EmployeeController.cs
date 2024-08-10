using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training.Api.Interfaces.Service;
using Training.Api.Models;

namespace Training.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListByFilterAsync(int pageNumber, int pageSize)
    {
        var employees = await _employeeService.ListByFilterAsync(pageNumber, pageSize);
        return Ok(employees);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] EmployeeRequestDto employeeDto)
    {
        var employee = await _employeeService.CreateAsync(employeeDto);
        return Ok(employee);
    }

    [Authorize]
    [HttpPost("/{employeeId}/upload")]
    public async Task<IActionResult> UploadPhotoAsync(int employeeId, [FromForm] UploadPhotoRequestDto file)
    {
        var employee = await _employeeService.UploadPhotoAsync(employeeId, file.Photo!);
        return Ok(employee);
    }

    [Authorize]
    [HttpGet("/{employeeId}/download")]
    public async Task<ActionResult> DownloadPhotoAsync(int employeeId)
    {
        var dataBytes = await _employeeService.DownloadPhotoAsync(employeeId);
        return File(dataBytes, "image/png");
    }
}

