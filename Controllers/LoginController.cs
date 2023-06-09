using System.Security.Authentication;
using CW9.DTO_s;
using CW9.Enums;
using CW9.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _service;

    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var res = await _service.Login(loginRequest);

        if (res is not DatabaseStatus)
            return Ok(new
            {
                token = res[0],
                refreshToken = res[1]
            });
        throw new AuthenticationException("Błąd przy logowaniu");
    }

    // [AllowAnonymous] //na potrzeby zadania (zeby poprawnie wygenerowalo sie haslo do bazy)
    [HttpPost("addUser")]
    public async Task<IActionResult> CreateUser(UserDto request)
    {
        var res = await _service.CreateNewUser(request);

        return res == DatabaseStatus.UserAdded ? Ok("Dodano!") : throw new ArgumentException("Blad przy dodawaniu!");
    }

 
}