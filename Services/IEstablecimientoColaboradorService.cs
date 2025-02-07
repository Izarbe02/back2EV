using dosEvAPI.Repositories;
using Models;

namespace dosEvAPI.Service
{
    public interface IEstablecimientoColaboradorService
    {
        Task<List<EstablecimientoColaborador>> GetAllAsync();
        Task<EstablecimientoColaborador?> GetByIdAsync(int id);
        Task AddAsync(EstablecimientoColaborador establecimiento);
        Task UpdateAsync(EstablecimientoColaborador establecimiento);
        Task DeleteAsync(int id);
    }
}