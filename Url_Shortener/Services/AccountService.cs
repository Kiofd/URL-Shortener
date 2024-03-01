using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Url_Shortener.Authentication;
using Url_Shortener.Data;
using Url_Shortener.Interfaces;
using Url_Shortener.Models;

namespace Url_Shortener.Services;

public class AccountService //: IAccountService
{
    private readonly LoginContext _context;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher _passwordHasher;

    public AccountService(LoginContext context, IJwtService jwtService, IPasswordHasher passwordHasher)
    {
        _context = context;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    // public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    // {
    //     var user = _context.Users.FirstOrDefault(u => u.email == loginViewModel.Email);
    // }
    //
    // public Task Register(RegisterViewModel registerViewModel)
    // {
    //     user newUser = new()
    //     {
    //         email = registerViewModel.Email,
    //         password = registerViewModel.Password
    //     };
    // }
    //
    // public Task Logout()
    // {
    //     throw new NotImplementedException();
    // }
}