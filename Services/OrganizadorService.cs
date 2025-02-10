using dosEvAPI.Repositories;
using Models;

namespace dosEvAPI.Service
{
    public class OrganizadorService : IOrganizadorService
    {
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorService(IOrganizadorRepository organizadorRepository)
        {
            _organizadorRepository = organizadorRepository;
        }

        public async Task<List<Organizador>> GetAllAsync()
        {
            return await _organizadorRepository.GetAllAsync();
        }

        public async Task<Organizador?> GetByIdAsync(int id)
        {
            return await _organizadorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Organizador organizador)
        {
            await _organizadorRepository.AddAsync(organizador);
        }

        public async Task UpdateAsync(Organizador organizador)
        {
            await _organizadorRepository.UpdateAsync(organizador);
        }

        public async Task DeleteAsync(int id)
        {
            var organizador = await _organizadorRepository.GetByIdAsync(id);
            if (organizador == null)
            {
                //return NotFound();
            }
            await _organizadorRepository.DeleteAsync(id);
            //return NoContent();
        }
    }
}
