using System;
using Training.Api.Entities;

namespace Training.Api.Interfaces.Repository;

public interface IEmployeeRepository
{
    Task<Employee> CreateAsync(Employee employee);
    Task<List<Employee>> ListAsync();
}
