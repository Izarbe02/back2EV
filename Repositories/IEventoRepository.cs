using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories


{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task<Evento?> GetByEstablecimientoAsync(string establecimiento);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();
    }
}
