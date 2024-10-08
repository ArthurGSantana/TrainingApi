using System;

namespace Training.Api.Entities;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Age { get; set; }
    public string? Photo { get; set; }

    public Employee(string name, string department, int age)
    {
        Name = name;
        Department = department;
        Age = age;
    }
}
