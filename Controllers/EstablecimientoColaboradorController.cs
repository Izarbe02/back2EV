using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientoColaboradorController : ControllerBase
    {
        private readonly IEstablecimientoColaboradorService _serviceEstablecimientoColaborador;

        public EstablecimientoColaboradorController(IEstablecimientoColaboradorService service)
        {
            _serviceEstablecimientoColaborador = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstablecimientoColaborador>>> GetEstablecimientos()
        {
            var establecimientos = await _serviceEstablecimientoColaborador.GetAllAsync();
            return Ok(establecimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstablecimientoColaborador>> GetEstablecimiento(int id)
        {
            var establecimiento = await _serviceEstablecimientoColaborador.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            return Ok(establecimiento);
        }

        [HttpPost]
        public async Task<ActionResult<EstablecimientoColaborador>> CreateEstablecimiento(EstablecimientoColaborador establecimiento)
        {
            await _serviceEstablecimientoColaborador.AddAsync(establecimiento);
            return CreatedAtAction(nameof(GetEstablecimiento), new { id = establecimiento.Id }, establecimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablecimiento(int id, EstablecimientoColaborador updatedEstablecimiento)
        {
            var existingEstablecimiento = await _serviceEstablecimientoColaborador.GetByIdAsync(id);
            if (existingEstablecimiento == null)
            {
                return NotFound();
            }

            existingEstablecimiento.Descripcion = updatedEstablecimiento.Descripcion;
            existingEstablecimiento.Enlace = updatedEstablecimiento.Enlace;
            existingEstablecimiento.Telefono = updatedEstablecimiento.Telefono;
            existingEstablecimiento.IdRol = updatedEstablecimiento.IdRol;
            existingEstablecimiento.IdCategoria = updatedEstablecimiento.IdCategoria;

            await _serviceEstablecimientoColaborador.UpdateAsync(existingEstablecimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablecimiento(int id)
        {
            var establecimiento = await _serviceEstablecimientoColaborador.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            await _serviceEstablecimientoColaborador.DeleteAsync(id);
            return NoContent();
        }
    }
}
