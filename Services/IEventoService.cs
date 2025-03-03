using Models;


namespace dosEvAPI.Service
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllAsync();
        Task<List<Evento>> GetProximosEventosAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task<List<Evento>>  GetByCategoriaAsync(string categoria);
        Task<List<Evento>>  GetByOrganizadorAsync(string organizador);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
//por acabar
          Task<EventoInfoDTO?>  GetInfoEventoAsync(int id);

        Task<List<Evento?>> GetInfoEventoBuscadorsync(string nombre);

    }
}