using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
    public interface ITematicaRepository
    {
        Task<List<Tematica>> GetAllAsync();
        Task<Tematica?> GetByIdAsync(int id);
        Task AddAsync(Tematica tematica);
        Task UpdateAsync(Tematica tematica);
        Task DeleteAsync(int id);
    }
}