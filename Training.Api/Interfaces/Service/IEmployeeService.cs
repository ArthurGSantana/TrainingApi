using System;
using Training.Api.Entities;
using Training.Api.Models;

namespace Training.Api.Interfaces.Service;

public interface IEmployeeService
{
    Task<EmployeeResponseDto> CreateAsync(EmployeeRequestDto employee);
    Task<List<EmployeeResponseDto>> ListAsync();
}
