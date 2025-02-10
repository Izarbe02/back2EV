using Models;


namespace dosEvAPI.Service
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task<Evento?> GetByCategoriaAsync(string categoria);
        Task<Evento?> GetByOrganizadorAsync(string organizador);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
    }
}