using Models;


namespace dosEvAPI.Service{

public interface ITematicaService
{
    Task<List<Tematica>> GetAllAsync();
    Task<Tematica?> GetByIdAsync(int id);
    Task AddAsync(Tematica tematica);
    Task UpdateAsync(Tematica tematica);
    Task DeleteAsync(int id);
}
}