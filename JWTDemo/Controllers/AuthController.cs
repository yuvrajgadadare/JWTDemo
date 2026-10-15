using JWTDemo.Models;
using JWTDemo.Services;
using Microsoft.AspNetCore.Http;
 
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Simple hardcoded check for demonstration (Use DB validation in production)
            if (request.Username == "admin" && request.Password == "Password123!")
            {
                var token = _tokenService.GenerateToken(request.Username, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials.");
        }
    }
}
