using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
    public interface IEstablecimientoColaboradorRepository
    {
        Task<List<EstablecimientoColaborador>> GetAllAsync();
        Task<EstablecimientoColaborador?> GetByIdAsync(int id);
        Task AddAsync(EstablecimientoColaborador establecimiento);
        Task UpdateAsync(EstablecimientoColaborador establecimiento);
        Task DeleteAsync(int id);
    }
}