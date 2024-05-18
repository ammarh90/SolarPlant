using Microsoft.AspNetCore.Mvc;
using SolarPlant.API.Interface;
using SolarPlant.DataLayer.Models;

namespace SolarPlant.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, IConfiguration config, ILogger<AuthController> logger)
        {
            _authService = authService;
            _config = config;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser user)
        {
            try
            {
                bool isUserRegistered = await _authService.RegisterUser(user);

                if (isUserRegistered)
                {
                    return Ok("Successfully registered.");
                }
                else
                {
                    return BadRequest("Something went wrong while registering.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AuthController,Method: RegisterUser.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUser user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                bool isUserAuthenticated = await _authService.Login(user);

                if (isUserAuthenticated)
                {
                    var tokenString = _authService.GenerateTokenString(user);
                    return Ok(tokenString);
                }
                else
                {
                    return BadRequest("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AuthController,Method: Login");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}