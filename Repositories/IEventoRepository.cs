using Models;
using dosEvAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Repositories
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task<List<Evento>> GetByOrganizadorAsync(string organizador);
        Task<List<Evento>> GetByCategoriaAsync(string categoria);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);

        // Método para obtener información detallada de un evento por su ID
        Task<EventoInfoDTO?> GetInfoEventoAsync(int id);

        // Método para buscar eventos con el buscador
        Task<List<BuscadorEventoDTO>> GetInfoEventoBuscadorsync(string busqueda);
    }
}
