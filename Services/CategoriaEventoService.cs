using dosEvAPI.Repositories;
using Models;
using dosEvAPI.Repositories;
namespace dosEvAPI.Service
{  
    public class CategoriaEventoService : ICategoriaEventoService
{
        private readonly ICategoriaEventoRepository _categoriaEventoRepository;

        public CategoriaEventoService(ICategoriaEventoRepository categoriaEventoRepository)
        {
            _categoriaEventoRepository = categoriaEventoRepository;
        }

        public async Task<List<CategoriaEvento>> GetAllAsync()
        {
            return await _categoriaEventoRepository.GetAllAsync();
        }

        public async Task<CategoriaEvento?> GetByIdAsync(int id)
        {
            return await _categoriaEventoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CategoriaEvento categoriaEvento)
        {
            await _categoriaEventoRepository.AddAsync(categoriaEvento);
        }

        public async Task UpdateAsync(CategoriaEvento categoriaEvento)
        {
            await _categoriaEventoRepository.UpdateAsync(categoriaEvento);
        }

        public async Task DeleteAsync(int id)
        {
            var categoriaEvento = await _categoriaEventoRepository.GetByIdAsync(id);
            if (categoriaEvento == null)
            {
                //return NotFound();
            }
            await _categoriaEventoRepository.DeleteAsync(id);
            //return NoContent();
        }
    }
}

