using System;

namespace Training.Api.DTOs;

public class LoginRequestDto
{
    public string? Name { get; set; }
    public string? Password { get; set; }
}
