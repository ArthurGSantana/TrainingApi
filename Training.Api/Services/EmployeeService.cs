using System;
using Training.Api.Entities;
using Training.Api.Interfaces.Repository;
using Training.Api.Interfaces.Service;
using Training.Api.Models;

namespace Training.Api.Services;

public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
{
    public async Task<EmployeeResponseDto> CreateAsync(EmployeeRequestDto employeeRequestDto)
    {
        var employee = new Employee(employeeRequestDto.Name!, employeeRequestDto.Department!, employeeRequestDto.Age);

        await _employeeRepository.CreateAsync(employee);

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Department = employee.Department,
            Age = employee.Age,
            Photo = employee.Photo
        };
    }

    public async Task<List<EmployeeResponseDto>> ListAsync()
    {
        var employees = await _employeeRepository.ListAsync();

        return employees.Select(employee => new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Department = employee.Department,
            Age = employee.Age,
            Photo = employee.Photo
        }).ToList();
    }
}
