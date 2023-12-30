using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeVidyalaya.Clean.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public UserController(IAuthenticateService authenticateService)
        {
            this._authenticateService = authenticateService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthRequest login, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var isLoggendIn = await _authenticateService.Authenticate(login);
                if (isLoggendIn)
                    return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Login failed please try again");
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequest registrationRequest)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authenticateService.Register(registrationRequest);
                if (isCreated)
                    return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Registration failed. Please try again");
            return View(registrationRequest);
        }


        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authenticateService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
