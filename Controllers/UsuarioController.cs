using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _serviceUsuario;

        public UsuarioController(IUsuarioService service)
        {
            _serviceUsuario = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuarios = await _serviceUsuario.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _serviceUsuario.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


         [HttpGet("username/{username}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByUsername(string username)
        {
            var usuario = await _serviceUsuario.GetByUsernameAsync(username);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }



        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            await _serviceUsuario.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var existingUsuario = await _serviceUsuario.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            existingUsuario.Username = updatedUsuario.Username;
            existingUsuario.Nombre = updatedUsuario.Nombre;
            existingUsuario.Email = updatedUsuario.Email;
            existingUsuario.Ubicacion = updatedUsuario.Ubicacion;
            existingUsuario.Contrasenia = updatedUsuario.Contrasenia;

            await _serviceUsuario.UpdateAsync(existingUsuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _serviceUsuario.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await _serviceUsuario.DeleteAsync(id);
            return NoContent();
        }
    }
}
