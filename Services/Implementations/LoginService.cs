using System.IdentityModel.Tokens.Jwt;
using CW9.Context;
using CW9.DTO_s;
using CW9.Enums;
using CW9.Middlewares;
using CW9.Models;
using CW9.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CW9.Services.Implementations;

public class LoginService : ILoginService
{
    private readonly MainDbContext _context;
    private readonly ITokenService _tokenService;

    public LoginService(MainDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }


    public async Task<dynamic> Login(LoginRequest loginRequest)
    {
        //Czy istnieje taki login
        User user;
        try
        {
            user = await _context.Users
                .Where(u => u.Login == loginRequest.Login)
                .FirstAsync();
        }
        catch (Exception e) //try-catch zeby logger zlapal blad
        {
            return DatabaseStatus.UserNotFound;
        }


        //Walidacja hasła
        var hasher = new PasswordHasher<UserDto>();
        var result = hasher.VerifyHashedPassword(new UserDto { Password = user.Password, Login = user.Login },
            user.Password, loginRequest.Password);

        if (result != PasswordVerificationResult.Success)
            return DatabaseStatus.WrongPassword;


        var accessToken = new JwtSecurityTokenHandler().WriteToken(_tokenService.GenerateAccessToken(loginRequest));
        var refreshToken = TokenService.GenerateRefreshToken();

        var tokens = new List<string>
        {
            accessToken,
            refreshToken
        };

        return tokens;
    }

    public async Task<DatabaseStatus> CreateNewUser(UserDto request)
    {
        //Czy login istnieje
        try
        {
            await _context.Users
                .Where(user => user.Login == request.Login)
                .FirstAsync();

            return DatabaseStatus.UserAlreadyInDb;
        }
        catch (Exception e)
        {
            //1. Hash and salt
            var hasher = new PasswordHasher<UserDto>();
            var hashedPassword = hasher.HashPassword(request, request.Password);

            //Dodawanie do bazy
            var refreshToken = TokenService.GenerateRefreshToken();

            await _context.Users
                .AddAsync(new User
                {
                    Password = hashedPassword,
                    Login = request.Login,
                    RefreshToken = refreshToken,
                    RefreshTokenExp = DateTime.Now.AddDays(10)
                });
            await _context.SaveChangesAsync();


            return DatabaseStatus.UserAdded;
        }
    }
}