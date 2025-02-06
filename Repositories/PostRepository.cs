
using Microsoft.Data.SqlClient;
namespace dosEvAPI.Repositories{
 public class PostRepository : IPostRepository
    {
        private readonly string _connectionString;

        public PostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = new List<Post>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, idUsuario, titulo, contenido, fecha FROM Posts";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var post = new Post
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                Titulo = reader.GetString(2),
                                Contenido = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                            posts.Add(post);
                        }
                    }
                }
            }
            return posts;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            Post? post = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, idUsuario, titulo, contenido, fecha FROM Posts WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            post = new Post
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                Titulo = reader.GetString(2),
                                Contenido = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }
            return post;
        }

        public async Task AddAsync(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Posts (idUsuario, titulo, contenido, fecha) VALUES (@IdUsuario, @Titulo, @Contenido, @Fecha)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", post.IdUsuario);
                    command.Parameters.AddWithValue("@Titulo", post.Titulo);
                    command.Parameters.AddWithValue("@Contenido", post.Contenido);
                    command.Parameters.AddWithValue("@Fecha", post.Fecha);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Post post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Posts SET idUsuario = @IdUsuario, titulo = @Titulo, contenido = @Contenido, fecha = @Fecha WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", post.Id);
                    command.Parameters.AddWithValue("@IdUsuario", post.IdUsuario);
                    command.Parameters.AddWithValue("@Titulo", post.Titulo);
                    command.Parameters.AddWithValue("@Contenido", post.Contenido);
                    command.Parameters.AddWithValue("@Fecha", post.Fecha);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Posts WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

