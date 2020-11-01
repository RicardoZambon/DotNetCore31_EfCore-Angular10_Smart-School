using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Models;
using SmartSchool.WebApi.Services;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost, Route(nameof(Authenticate)), AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserLoginModel model)
        {
            if (userService.AuthenticateAndGenerateToken(model, out var token))
            {
                return new { model.Username, token };
            }
            return Unauthorized();
        }
    }
}