using System;
using Training.Api.Entities;

namespace Training.Api.Interfaces.Repository;

public interface IEmployeeRepository
{
    Task<Employee?> GetAsync(int employeeId);
    Task<List<Employee>> ListAsync();
    Task<List<Employee>> ListByFilterAsync(int pageNumber, int pageSize);
    Task<Employee> CreateAsync(Employee employee);
    void Update(Employee employee);
}
