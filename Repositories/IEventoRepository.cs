using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories


{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
         Task<List<Evento>>  GetByOrganizadorAsync(string organizador);
         Task<List<Evento>>  GetByCategoriaAsync(string categoria);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);

Task<EventoInfoDTO?> GetInfoEventoAsync(int id);


        Task<List<BuscadorEventoDTO?>> GetInfoEventoBuscadorsync(string nombre);
    }
}
