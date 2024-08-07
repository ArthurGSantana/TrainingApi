using System;
using Training.Api.Entities;

namespace Training.Api.Interfaces;

public interface IEmployeeRepository
{
    void Add(Employee employee);
    List<Employee> GetAll();
}
