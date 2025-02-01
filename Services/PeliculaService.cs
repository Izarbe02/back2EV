using Models;
using System;
using CineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CineAPI.Service;     
namespace CineAPI.Service
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaService(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public async Task<List<Pelicula>> GetAllAsync()
        {
            return await _peliculaRepository.GetAllAsync();
        }

        public async Task<Pelicula?> GetByIdAsync(int id)
        {
            return await _peliculaRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Pelicula pelicula)
        {
            await _peliculaRepository.AddAsync(pelicula);
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            await _peliculaRepository.UpdateAsync(pelicula);
        }

        public async Task DeleteAsync(int id)
        {
           var plato = await _peliculaRepository.GetByIdAsync(id);
           if (plato == null)
           {
               //return NotFound();
           }
           await _peliculaRepository.DeleteAsync(id);
           //return NoContent();
        } 
    }
}