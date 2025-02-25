using Microsoft.AspNetCore.Mvc;
using dosEvAPI.DTOs;
using dosEvAPI.Service;
using System.Threading.Tasks;

namespace dosEvAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public AuthController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token = await UsuarioService.(cuenta);
                return Ok(token);
            }
            catch (KeyNotFoundException )
            {
                return Unauthorized("Credenciales inválidas");
            }
            catch (Exception)
            {
                return BadRequest("Error al generar el token");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(LoginDTO loginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token = await _service.Register(loginDTO);
                return Ok(new { Token = token });
            }
            catch (KeyNotFoundException)
            {
                return Unauthorized("Error al registrar usuario");
            }
            catch (Exception)
            {
                return BadRequest("Error al generar el token");
            }
        }
    }
}
