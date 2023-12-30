using CodeVidyalaya.Clean.Application.Identity;
using CodeVidyalaya.Clean.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeVidyalaya.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> UserList()
        {
            return Ok(await _userService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> UserList(string id)
        {
            return Ok(await _userService.GetEmployee(id));
        }
    }
}
