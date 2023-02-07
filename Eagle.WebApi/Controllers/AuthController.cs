using Eagle.Config.Controller;
using Eagle.Logic.DataTransferObjects.AuthService;
using Eagle.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eagle.WebApi.Controllers
{
    public class AuthController : ApiControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginInformation)
        {
            return null;
        }
    }
}
