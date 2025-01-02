using Business.Services.Abstract;
using Business.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    #region Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountRegisterVM model)
    {
        var isSucceeded = await _accountService.RegisterAsync(model);
        if (isSucceeded) return RedirectToAction(nameof(Login));

        return View(model);
    }

    public async Task<IActionResult> ConfirmEmail(string email, string token)
    {
        var IsSucceeded = await _accountService.ConfirmEmailAsync(email, token);
        if (IsSucceeded) return RedirectToAction(nameof(Login));

        return BadRequest("Confirmation failed");
    }
    #endregion

    #region Login
    
    [HttpGet]
    public IActionResult Login()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginVM model)
    {
        var (IsSucceeded, returnUrl) = await _accountService.LoginAsync(model);
        if (IsSucceeded)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    #endregion
}
