using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token = await _service.Login(cuenta);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al generar el token");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(LoginDTO usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token = await _service.Register(usuario);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al generar el token");
            }
        }
    }
}
