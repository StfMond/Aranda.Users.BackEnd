using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Services.Definition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Users.BackEnd.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userParam)
        {
            if (userParam == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var user = _authService.Authenticate(userParam.Name, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}