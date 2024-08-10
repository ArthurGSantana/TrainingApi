using System;
using Training.Api.Entities;
using Training.Api.Interfaces.Repository;
using Training.Api.Interfaces.Service;
using Training.Api.DTOs;

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

    public async Task<EmployeeResponseDto> GetAsync(int employeeId)
    {
        var employee = await _employeeRepository.GetAsync(employeeId);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Department = employee.Department,
            Age = employee.Age,
            Photo = employee.Photo
        };
    }

    public async Task<List<EmployeeResponseDto>> ListByFilterAsync(int pageNumber, int pageSize)
    {
        var employees = await _employeeRepository.ListByFilterAsync(pageNumber, pageSize);

        return employees.Select(employee => new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Department = employee.Department,
            Age = employee.Age,
            Photo = employee.Photo
        }).ToList();
    }

    public async Task<EmployeeResponseDto> UploadPhotoAsync(int employeeId, IFormFile Photo)
    {
        var employee = await _employeeRepository.GetAsync(employeeId);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        var path = await SavePhotoAsync(Photo);

        employee.Photo = path;

        _employeeRepository.Update(employee);

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Department = employee.Department,
            Age = employee.Age,
            Photo = employee.Photo
        };
    }

    private async Task<string> SavePhotoAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var path = Path.Combine("Storage", fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return path;
    }

    public async Task<byte[]> DownloadPhotoAsync(int employeeId)
    {
        var employee = await _employeeRepository.GetAsync(employeeId);

        if (employee == null || string.IsNullOrEmpty(employee.Photo))
        {
            throw new Exception("Employee not found");
        }

        return await File.ReadAllBytesAsync(employee.Photo);
    }
}
