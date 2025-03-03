using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class TokenController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin authRequest)
        {
            var loginResponse = await _tokenService.AuthenticateAsync(authRequest);

            if (loginResponse == null)
                return Unauthorized(new { message = "Credenciales incorrectas" });

            return Ok(loginResponse);
        }
    }
}