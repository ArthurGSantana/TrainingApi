using System;
using Training.Api.Entities;
using Training.Api.Models;

namespace Training.Api.Interfaces.Service;

public interface IEmployeeService
{
    Task<EmployeeResponseDto> GetAsync(int employeeId);
    Task<List<EmployeeResponseDto>> ListAsync();
    Task<EmployeeResponseDto> CreateAsync(EmployeeRequestDto employee);
    Task<EmployeeResponseDto> UploadPhotoAsync(int employeeId, IFormFile file);
    Task<byte[]> DownloadPhotoAsync(int employeeId);
}
