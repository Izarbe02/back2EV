using Models;
using Microsoft.Data.SqlClient;
using dosEvAPI.Service;


namespace dosEvAPI.Repositories


{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<List<Evento>> GetProximosEventosAsync();
        Task<Evento?> GetByIdAsync(int id);
         Task<List<Evento>>  GetByOrganizadorAsync(string organizador);
         Task<List<Evento>>  GetByCategoriaAsync(string categoria);
         Task<List<Evento>>  GetByOrganizadorIdAsync(int organizadorid);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);

          Task<EventoInfoDTO?>  GetInfoEventoAsync(int id);

        Task<List<Evento?>> GetInfoEventoBuscadorsync(string nombre);
    }
}
