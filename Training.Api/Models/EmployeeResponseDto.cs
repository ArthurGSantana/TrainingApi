using System;

namespace Training.Api.Models;

public class EmployeeResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public int Age { get; set; }
    public string? Photo { get; set; }
}
