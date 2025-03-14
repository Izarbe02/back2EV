using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Service;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientoController : ControllerBase
    {
        private readonly IEstablecimientoService _serviceEstablecimiento;

        public EstablecimientoController(IEstablecimientoService service)
        {
            _serviceEstablecimiento = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Establecimiento>>> GetEstablecimientos()
        {
            var establecimientos = await _serviceEstablecimiento.GetAllAsync();
            return Ok(establecimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Establecimiento>> GetEstablecimiento(int id)
        {
            var establecimiento = await _serviceEstablecimiento.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return Ok(establecimiento);
        }

        [HttpPost]
        public async Task<ActionResult<Establecimiento>> CreateEstablecimiento(Establecimiento establecimiento)
        {
            await _serviceEstablecimiento.AddAsync(establecimiento);
            return CreatedAtAction(nameof(GetEstablecimiento), new { id = establecimiento.Id }, establecimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablecimiento(int id, Establecimiento updatedEstablecimiento)
        {
            var existingEstablecimiento = await _serviceEstablecimiento.GetByIdAsync(id);
            if (existingEstablecimiento == null)
            {
                return NotFound();
            }

            existingEstablecimiento.Nombre = updatedEstablecimiento.Nombre;
            existingEstablecimiento.Ubicacion = updatedEstablecimiento.Ubicacion;
            existingEstablecimiento.Descripcion = updatedEstablecimiento.Descripcion;
            existingEstablecimiento.IdOrganizador = updatedEstablecimiento.IdOrganizador;

            await _serviceEstablecimiento.UpdateAsync(existingEstablecimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablecimiento(int id)
        {
            var establecimiento = await _serviceEstablecimiento.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            await _serviceEstablecimiento.DeleteAsync(id);
            return NoContent();
        }
    }
}
