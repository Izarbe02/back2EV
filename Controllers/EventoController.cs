using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _serviceEvento;

        public EventoController(IEventoService service)
        {
            _serviceEvento = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _serviceEvento.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("proximos")]
        public async Task<ActionResult<List<Evento>>> GetProximosEventosAsync()
        {
            var eventos = await _serviceEvento.GetProximosEventosAsync();
            return Ok(eventos);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _serviceEvento.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }


        [HttpGet("organizadorid/{organizadorid}")]
        public async Task<ActionResult<Evento>> GetEventoPorCategoria(int organizadorid)
        {
            var evento = await _serviceEvento.GetByOrganizadorIdAsync(organizadorid);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("organizador/{organizador}")]
        public async Task<ActionResult<Evento>> GetEventoPorOrganizador(string organizador)
        {
            var evento = await _serviceEvento.GetByOrganizadorAsync(organizador);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("DetalleEvento")]
        public async Task<ActionResult<EventoInfoDTO>> GetInfoEvento(int id)
        {
            var evento = await _serviceEvento.GetInfoEventoAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("BuscadorEvento/{busqueda}")]
        public async Task<ActionResult<List<Evento>>> GetInfoEventoBuscador(string busqueda)
        {
            var evento = await _serviceEvento.GetInfoEventoBuscadorsync(busqueda);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("categoria/{categoria}")]
        public async Task<ActionResult<Evento>> GetEventoPorCategoria(string categoria)
        {
            var evento = await _serviceEvento.GetByCategoriaAsync(categoria);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> CreateEvento(Evento evento)
        {
            await _serviceEvento.AddAsync(evento);
            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(int id, Evento updatedEvento)
        {
            var existingEvento = await _serviceEvento.GetByIdAsync(id);
            if (existingEvento == null)
            {
                return NotFound();
            }

            existingEvento.Nombre = updatedEvento.Nombre;
            existingEvento.Descripcion = updatedEvento.Descripcion;
            existingEvento.Ubicacion = updatedEvento.Ubicacion;
            existingEvento.FechaInicio = updatedEvento.FechaInicio;
            existingEvento.FechaFin = updatedEvento.FechaFin;
            existingEvento.Enlace = updatedEvento.Enlace;
            existingEvento.IdOrganizador = updatedEvento.IdOrganizador;

            await _serviceEvento.UpdateAsync(existingEvento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _serviceEvento.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            await _serviceEvento.DeleteAsync(id);
            return NoContent();
        }
    }
}
