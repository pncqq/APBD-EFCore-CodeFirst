using System.IdentityModel.Tokens.Jwt;
using CW9.DTO_s;
using CW9.Enums;

namespace CW9.Services.Interfaces;

public interface ILoginService
{
    public Task<dynamic> Login(LoginRequest loginRequest);
    public Task<DatabaseStatus> CreateNewUser(UserDto request);
    
}