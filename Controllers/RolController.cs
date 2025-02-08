using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _serviceRol;

        public RolController(IRolService service)
        {
            _serviceRol = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetRoles()
        {
            var roles = await _serviceRol.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _serviceRol.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> CreateRol(Rol rol)
        {
            await _serviceRol.AddAsync(rol);
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, Rol updatedRol)
        {
            var existingRol = await _serviceRol.GetByIdAsync(id);
            if (existingRol == null)
            {
                return NotFound();
            }

            existingRol.Nombre = updatedRol.Nombre;

            await _serviceRol.UpdateAsync(existingRol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _serviceRol.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            await _serviceRol.DeleteAsync(id);
            return NoContent();
        }
    }
}
