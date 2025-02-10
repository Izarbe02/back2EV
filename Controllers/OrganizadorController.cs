using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController : ControllerBase
    {
        private readonly IOrganizadorService _serviceOrganizador;

        public OrganizadorController(IOrganizadorService service)
        {
            _serviceOrganizador = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Organizador>>> GetEstablecimientos()
        {
            var establecimientos = await _serviceOrganizador.GetAllAsync();
            return Ok(establecimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizador>> GetEstablecimiento(int id)
        {
            var establecimiento = await _serviceOrganizador.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return Ok(establecimiento);
        }

        [HttpPost]
        public async Task<ActionResult<Organizador>> CreateEstablecimiento(Organizador establecimiento)
        {
            await _serviceOrganizador.AddAsync(establecimiento);
            return CreatedAtAction(nameof(GetEstablecimiento), new { id = establecimiento.Id }, establecimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablecimiento(int id, Organizador updatedEstablecimiento)
        {
            var existingEstablecimiento = await _serviceOrganizador.GetByIdAsync(id);
            if (existingEstablecimiento == null)
            {
                return NotFound();
            }

            existingEstablecimiento.Descripcion = updatedEstablecimiento.Descripcion;
            existingEstablecimiento.Enlace = updatedEstablecimiento.Enlace;
            existingEstablecimiento.Telefono = updatedEstablecimiento.Telefono;
            existingEstablecimiento.IdRol = updatedEstablecimiento.IdRol;
            existingEstablecimiento.IdCategoria = updatedEstablecimiento.IdCategoria;

            await _serviceOrganizador.UpdateAsync(existingEstablecimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablecimiento(int id)
        {
            var establecimiento = await _serviceOrganizador.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            await _serviceOrganizador.DeleteAsync(id);
            return NoContent();
        }
    }
}
