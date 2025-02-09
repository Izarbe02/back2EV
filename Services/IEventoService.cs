using Models;


namespace dosEvAPI.Service
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
    }
}