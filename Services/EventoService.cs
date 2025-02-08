using Models;


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

        public async Task<Evento?> GetByIdAsync(int id)
        {
            return await _eventoRepository.GetByIdAsync(id);
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
    }
}