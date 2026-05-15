using Microsoft.AspNetCore.Mvc;
using Moji.Application.DTOS.User;
using Moji.Application.Interfaces;

namespace Moji.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _userService.Register(request);
            return NoContent();
        }
    }
}
