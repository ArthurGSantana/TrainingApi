using System;
using Microsoft.EntityFrameworkCore;
using Training.Api.Entities;
using Training.Api.Infrastructure;
using Training.Api.Interfaces.Repository;

namespace Training.Api.Repositories;

public class EmployeeRepository(ConnectionContext _context) : IEmployeeRepository
{
    public async Task<Employee> CreateAsync(Employee employee)
    {
        await _context.Employee.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public Task<List<Employee>> ListAsync()
    {
        return _context.Employee.ToListAsync();
    }
}
