using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Url_Shortener.Authentication;
using Url_Shortener.Data;
using Url_Shortener.Interfaces;
using Url_Shortener.Models;
using Url_Shortener.Services;
using Url_Shortener.ViewModel;

namespace Url_Shortener.Controllers;

public class AccountController : Controller
{
    private readonly LoginContext _context;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher _passwordHasher;

    public AccountController(LoginContext context, IJwtService jwtService, IPasswordHasher passwordHasher)
    {
        _context = context;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/login")]
    public async Task<LoginResponse>Login (LoginViewModel loginViewModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.email == loginViewModel.Email);
        var result = _passwordHasher.Verify(user.password, loginViewModel.Password);
        if (!result)
        {
            throw new Exception("Wrong password");
        }; // Here i need to make UnAuthorized;
        
        RedirectToAction("Index", "Home");

        LoginResponse response = new ()
        {
            Token = _jwtService.CreateToken(_jwtService.GetClaims(user))
        };
        return response;
        // //var jwtAuthenticationManager = new JwtAuthenticationManager();
        // //var authResult = JwtAuthenticationManager.Authenticate(authRequest.Email, authRequest.Password);
        // if (authResult == null)
        //     return Unauthorized();
        //
        // return Ok(authResult);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            user? user = _context.Users.FirstOrDefault(e => e.email == model.Email);
            if (user == null)
            {
                var passwordHash = _passwordHasher.Hash(model.Password);
                await _context.Users.AddAsync(new user { email = model.Email, password = passwordHash });
                await _context.SaveChangesAsync();

                //JwtAuthenticationManager.Authenticate(model.Email, model.Password);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Tu lox typui");
        }

        return View(model);
    }

    // [HttpGet]
    // [AllowAnonymous]
    // public IActionResult Login()
    // {
    //     return View();
    // }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
}