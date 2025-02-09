using Models;


namespace dosEvAPI.Service
{

    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
    }
}