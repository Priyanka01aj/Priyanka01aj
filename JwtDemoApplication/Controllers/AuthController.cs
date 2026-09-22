using JwtDemoApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemoApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            // Implementation for login logic
            if(model.Username == "testuser" && model.Password == "password")
            {
                var token = _jwtService.GenerateToken(1, model.Username, "User");
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
