using System;
using Training.Api.Entities;

namespace Training.Api.Interfaces.Repository;

public interface IEmployeeRepository
{
    Task<Employee?> GetAsync(int employeeId);
    Task<List<Employee>> ListAsync();
    Task<Employee> CreateAsync(Employee employee);
    void Update(Employee employee);
}
