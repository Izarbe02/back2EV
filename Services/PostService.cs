using Models;


namespace dosEvAPI.Service
{

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Post post)
        {
            await _postRepository.AddAsync(post);
        }

        public async Task UpdateAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}