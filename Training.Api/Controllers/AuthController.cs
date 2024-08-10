using System;
using Microsoft.AspNetCore.Mvc;
using Training.Api.Entities;
using Training.Api.DTOs;
using Training.Api.Security;

namespace Training.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
    {
        //verificaçao de teste só para gerar o token
        var token = TokenService.GenerateToken(loginRequestDto.Name!);
        return Ok(token);
    }

    // [HttpPost("register")]
    // public IActionResult Register([FromBody] RegisterRequestDto registerRequestDto)
    // {
    //     _authService.Register(registerRequestDto);
    //     return Ok();
    // }
}
