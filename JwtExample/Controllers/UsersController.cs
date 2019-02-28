using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JwtExample.Services;
using JwtExample.Entities;

namespace JwtExample.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [Route(nameof(Authenticate))]
        public IActionResult Authenticate([FromBody] User model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}