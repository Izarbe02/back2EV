using Microsoft.AspNetCore.Mvc;
using CineAPI.Repositories;
using CineAPI.Service;
using Models;

namespace CineAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PeliculaController : ControllerBase
   {
    private static List<Pelicula> peliculas = new List<Pelicula>();

    private readonly IPeliculaService _servicePelicula;

    public PeliculaController(IPeliculaService service)
        {
            _servicePelicula = service;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas()
        {
            var peliculas = await _servicePelicula.GetAllAsync();
            return Ok(peliculas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await _servicePelicula.GetByIdAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> CreatePelicula(Pelicula pelicula)
        {
            await _servicePelicula.AddAsync(pelicula);
            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.ID }, pelicula);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePelicula(int id, Pelicula updatedPelicula)
        {
            var existingPelicula = await _servicePelicula.GetByIdAsync(id);
            if (existingPelicula == null)
            {
                return NotFound();
            }

            // Actualizar el pelicula existente
            existingPelicula.Nombre = updatedPelicula.Nombre;
            existingPelicula.Descripcion = updatedPelicula.Descripcion;
            existingPelicula.AnioSalida = updatedPelicula.AnioSalida;
            existingPelicula.Director = updatedPelicula.Director;
            existingPelicula.Caratula = updatedPelicula.Caratula;
            existingPelicula.Duracion = updatedPelicula.Duracion;
            existingPelicula.TrailerURL = updatedPelicula.TrailerURL;



            await _servicePelicula.UpdateAsync(existingPelicula);
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeletePelicula(int id)
       {
           var pelicula = await _servicePelicula.GetByIdAsync(id);
           if (pelicula == null)
           {
               return NotFound();
           }
           await _servicePelicula.DeleteAsync(id);
           return NoContent();
       }


   }
}