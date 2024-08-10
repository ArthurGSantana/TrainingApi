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

    public async Task<Employee?> GetAsync(int employeeId)
    {
        return await _context.Employee.FindAsync(employeeId);
    }

    public Task<List<Employee>> ListAsync()
    {
        return _context.Employee.ToListAsync();
    }

    public Task<List<Employee>> ListByFilterAsync(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;
        return _context.Employee.Skip(skip).Take(pageSize).ToListAsync();
    }

    public void Update(Employee employee)
    {
        _context.Employee.Update(employee);
        _context.SaveChanges();
    }
}
