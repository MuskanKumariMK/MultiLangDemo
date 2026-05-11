using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiLangDemo.Models;

namespace MultiLangDemo.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IStringLocalizer<AuthController> _localizer;
        public AuthController(IStringLocalizer<AuthController> localizer)
        {
            _localizer = localizer;
        }
        [HttpPost("login")]

        public IActionResult Login([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = _localizer["ValidationFailed"]
                });
            }

            if (model.Email == "abc@gmail.com" && model.Password == "admin@123")
            {
                return Ok(new
                {
                    success = true,
                    message = _localizer["LoginSuccess"]
                });
            }


            return Unauthorized(new
            {
                success = false,
                message = _localizer["LoginFailed"]
            });
        }
    }
}
