using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("secure-data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok(new { Message = "This endpoint is guarded by JWT authentication!" });
        }
        [HttpGet("admin-data")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok(new { Message = "Welcome, administrator." });
        }
    }
}
