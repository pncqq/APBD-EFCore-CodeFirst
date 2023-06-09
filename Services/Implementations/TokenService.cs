using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CW9.Context;
using CW9.DTO_s;
using CW9.Enums;
using CW9.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CW9.Services.Implementations;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly MainDbContext _context;


    public TokenService(IConfiguration configuration, MainDbContext context)
    {
        _context = context;
        _configuration = configuration.GetSection("Tokens").GetSection("AccessToken");
    }


    public JwtSecurityToken GenerateAccessToken(LoginRequest loginRequest)
    {
        //Informacje o Userze
        var userClaims = new[]
        {
            new Claim(ClaimTypes.Name, loginRequest.Login),
            new Claim(ClaimTypes.Role, "user")
        };

        if (loginRequest.Login == "admin")
        {
            var list = userClaims.ToList();
            list.Add(new Claim(ClaimTypes.Role, "admin"));
            userClaims = list.ToArray();
        }

        //Klucze
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        var singningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["ValidIssuer"],
            audience: _configuration["ValidAudience"],
            claims: userClaims,
            expires: DateTime.Now.AddMinutes(3),
            signingCredentials: singningCredentials
        );

        return token;
    }

    public async Task<dynamic> GetNewAccessToken(string refreshToken)
    {
        // Czy istnieje user o takim tokenie
        var user = await _context.Users
            .Where(u => u.RefreshToken == refreshToken)
            .FirstOrDefaultAsync();

        if (user == null)
            return DatabaseStatus.UserNotFound;

        //Czy token jest wazny
        var expDate = await _context.Users
            .Where(u => u.RefreshToken == refreshToken)
            .Select(u => u.RefreshTokenExp)
            .FirstOrDefaultAsync();

        if (expDate < DateTime.Now)
            return DatabaseStatus.TokenExpired;


        //Generuj nowy access token
        var loginRequest = new LoginRequest
        {
            Login = user.Login,
            Password = user.Password
        };

        var accessToken = new JwtSecurityTokenHandler().WriteToken(GenerateAccessToken(loginRequest));

        return accessToken;
    }
    
    public static string GenerateRefreshToken()
    {
        using var genNum = RandomNumberGenerator.Create();
        var r = new byte[50];
        genNum.GetBytes(r);
        var refreshToken = Convert.ToBase64String(r);

        return refreshToken;
    }
}