using System.Security.Authentication;
using CW9.Enums;
using CW9.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _service;

    public TokenController(ITokenService service)
    {
        _service = service;
    }

    [HttpGet("newToken")]
    public async Task<IActionResult> GetNewAccessToken([FromQuery] string refreshToken)
    {
        var res = await _service.GetNewAccessToken(refreshToken);

        if (res is not DatabaseStatus) return Ok(res);
        return res switch
        {
            DatabaseStatus.UserNotFound => throw new AuthenticationException("User not found"),
            DatabaseStatus.WrongPassword => throw new AuthenticationException("Unauthorized"),
            DatabaseStatus.TokenExpired => throw new AuthenticationException("Token expired"),
            _ => Ok(res)
        };
    }
}