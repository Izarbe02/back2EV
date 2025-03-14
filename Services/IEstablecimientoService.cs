using dosEvAPI.Repositories;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Service
{
    public interface IEstablecimientoService
    {
        Task<List<Establecimiento>> GetAllAsync();
        Task<Establecimiento?> GetByIdAsync(int id);
        Task AddAsync(Establecimiento establecimiento);
        Task UpdateAsync(Establecimiento establecimiento);
        Task DeleteAsync(int id);
    }
}
