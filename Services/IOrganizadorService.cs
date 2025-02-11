
using Models;

namespace dosEvAPI.Service
{
    public interface IOrganizadorService
    {
        Task<List<Organizador>> GetAllAsync();
        Task<Organizador?> GetByIdAsync(int id);
        Task AddAsync(Organizador organizador);
        Task UpdateAsync(Organizador organizador);
        Task DeleteAsync(int id);
    }
}