using Models;
using dosEvAPI.Repositories;

namespace dosEvAPI.Service
{

    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<List<Evento>> GetAllAsync()
        {
            return await _eventoRepository.GetAllAsync();
        }

        public async Task<List<Evento>> GetProximosEventosAsync()
        {
            return await _eventoRepository.GetProximosEventosAsync();
        }

        // Funcion para filtrar por ID
        public async Task<Evento?> GetByIdAsync(int id)
        {
            return await _eventoRepository.GetByIdAsync(id);
        }

        public async  Task<List<Evento>>  GetByOrganizadorIdAsync(int organizadorid)
        {
            return await _eventoRepository.GetByOrganizadorIdAsync(organizadorid);
        }
        // Funcion para filtrar por categoria
        public async  Task<List<Evento>>  GetByCategoriaAsync(string categoria)
        {
            return await _eventoRepository.GetByCategoriaAsync(categoria);
        }

        // Funcion para filtrar por organizador
        public async  Task<List<Evento>>  GetByOrganizadorAsync(string organizador)
        {
            return await _eventoRepository.GetByOrganizadorAsync(organizador);
        }


        public async Task AddAsync(Evento evento)
        {
            await _eventoRepository.AddAsync(evento);
        }

        public async Task UpdateAsync(Evento evento)
        {
            await _eventoRepository.UpdateAsync(evento);
        }

        public async Task DeleteAsync(int id)
        {
            await _eventoRepository.DeleteAsync(id);
        }
                // Detalle total evento 
            public async Task<EventoInfoDTO?>  GetInfoEventoAsync(int id)
        {
           return  await _eventoRepository.GetInfoEventoAsync(id);
        }

    //info del buscador
           public async Task<List<Evento?>> GetInfoEventoBuscadorsync(string nombre)
        {
            return await _eventoRepository.GetInfoEventoBuscadorsync(nombre);
        }
    }
}