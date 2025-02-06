using Models;

namespace dosEvAPI.Service
{
    public class EstablecimientoColaboradorService : IEstablecimientoColaboradorService
    {
        private readonly IEstablecimientoColaboradorRepository _establecimientoColaboradorRepository;

        public EstablecimientoColaboradorService(IEstablecimientoColaboradorRepository establecimientoColaboradorRepository)
        {
            _establecimientoColaboradorRepository = establecimientoColaboradorRepository;
        }

        public async Task<List<EstablecimientoColaborador>> GetAllAsync()
        {
            return await _establecimientoColaboradorRepository.GetAllAsync();
        }

        public async Task<EstablecimientoColaborador?> GetByIdAsync(int id)
        {
            return await _establecimientoColaboradorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(EstablecimientoColaborador establecimiento)
        {
            await _establecimientoColaboradorRepository.AddAsync(establecimiento);
        }

        public async Task UpdateAsync(EstablecimientoColaborador establecimiento)
        {
            await _establecimientoColaboradorRepository.UpdateAsync(establecimiento);
        }

        public async Task DeleteAsync(int id)
        {
            var establecimiento = await _establecimientoColaboradorRepository.GetByIdAsync(id);
            if (establecimiento == null)
            {
                //return NotFound();
            }
            await _establecimientoColaboradorRepository.DeleteAsync(id);
            //return NoContent();
        }
    }
}
