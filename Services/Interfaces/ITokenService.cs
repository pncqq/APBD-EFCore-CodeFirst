using System.IdentityModel.Tokens.Jwt;
using CW9.DTO_s;

namespace CW9.Services.Interfaces;

public interface ITokenService
{
    public Task<dynamic> GetNewAccessToken(string refreshToken);
    public JwtSecurityToken GenerateAccessToken(LoginRequest loginRequest);

    // public static string GenerateRefreshToken();
}