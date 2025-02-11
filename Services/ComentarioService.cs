using Models;

using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Service
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _comentarioRepository.GetAllAsync();
        }

     
        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _comentarioRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Comentario comentario)
        {
            await _comentarioRepository.AddAsync(comentario);
        }

        public async Task DeleteAsync(int id)
        {
            await _comentarioRepository.DeleteAsync(id);
        }
    }
}
