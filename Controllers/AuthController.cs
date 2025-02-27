using Microsoft.AspNetCore.Mvc;
using dosEvAPI.DTOs;
using dosEvAPI.Service;
using System.Threading.Tasks;
using dosEvAPI.Models;

namespace dosEvAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService service)
        {
            _usuarioService = service;
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

                string token = await _usuarioService.Login(cuenta);
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
        public async Task<ActionResult> Register(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token = await _usuarioService.Register(usuario);
                return Ok(token);
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


