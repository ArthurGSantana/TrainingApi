using System;

namespace Training.Api.Models;

public class EmployeeRequestDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Age { get; set; }
    public string? Photo { get; set; }
}
