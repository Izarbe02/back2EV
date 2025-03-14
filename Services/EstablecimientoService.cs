using dosEvAPI.Repositories;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Service
{
    public class EstablecimientoService : IEstablecimientoService
    {
        private readonly IEstablecimientoRepository _establecimientoRepository;

        public EstablecimientoService(IEstablecimientoRepository establecimientoRepository)
        {
            _establecimientoRepository = establecimientoRepository;
        }

        public async Task<List<Establecimiento>> GetAllAsync()
        {
            return await _establecimientoRepository.GetAllAsync();
        }

        public async Task<Establecimiento?> GetByIdAsync(int id)
        {
            return await _establecimientoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Establecimiento establecimiento)
        {
            await _establecimientoRepository.AddAsync(establecimiento);
        }

        public async Task UpdateAsync(Establecimiento establecimiento)
        {
            await _establecimientoRepository.UpdateAsync(establecimiento);
        }

        public async Task DeleteAsync(int id)
        {
            var establecimiento = await _establecimientoRepository.GetByIdAsync(id);
            if (establecimiento == null)
            {
                return;
            }
            await _establecimientoRepository.DeleteAsync(id);
        }
    }
}
