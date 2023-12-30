using CodeVidyalaya.Clean.Application.Identity;
using CodeVidyalaya.Clean.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeVidyalaya.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Login(RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }
    }
}
