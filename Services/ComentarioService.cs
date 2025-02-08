using Models;

namespace dosEvAPI.Service
{

    public class ComentarioRepository : IComentarioRepository
    {
        private readonly string _connectionString;

        public ComentarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            var comentarios = new List<Comentario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, idUsuario, idEvento, comentario, fecha FROM Comentarios";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            comentarios.Add(new Comentario
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                IdEvento = reader.GetInt32(2),
                                Contenido = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return comentarios;
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, idUsuario, idEvento, comentario, fecha FROM Comentarios WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Comentario
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                IdEvento = reader.GetInt32(2),
                                Contenido = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task AddAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Comentarios (idUsuario, idEvento, comentario, fecha) VALUES (@IdUsuario, @IdEvento, @Contenido, @Fecha)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
                    command.Parameters.AddWithValue("@IdEvento", comentario.IdEvento);
                    command.Parameters.AddWithValue("@Contenido", comentario.Contenido);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Comentarios SET idUsuario = @IdUsuario, idEvento = @IdEvento, comentario = @Contenido, fecha = @Fecha WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", comentario.Id);
                    command.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
                    command.Parameters.AddWithValue("@IdEvento", comentario.IdEvento);
                    command.Parameters.AddWithValue("@Contenido", comentario.Contenido);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Comentarios WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}