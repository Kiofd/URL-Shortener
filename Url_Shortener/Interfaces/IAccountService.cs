using Microsoft.AspNetCore.Mvc;
using Url_Shortener.Models;
using Url_Shortener.ViewModel;

namespace Url_Shortener.Interfaces;

public interface IAccountService
{
    Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel);
    Task Register([FromForm] RegisterViewModel registerViewModel);
    Task Logout();
}