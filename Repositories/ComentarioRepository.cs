using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
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
                            var comentario = new Comentario
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1),
                                IdEvento = reader.GetInt32(2),
                                Contenido = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                            comentarios.Add(comentario);
                        }
                    }
                }
            }
            return comentarios;
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            Comentario? comentario = null;

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
                            comentario = new Comentario
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
            return comentario;
        }

        public async Task AddAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Comentarios (idUsuario, idEvento, comentario, fecha) VALUES (@IdUsuario, @IdEvento, @Comentario, @Fecha)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
                    command.Parameters.AddWithValue("@IdEvento", comentario.IdEvento);
                    command.Parameters.AddWithValue("@Comentario", comentario.Contenido);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha ?? (object)DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Comentarios SET idUsuario = @IdUsuario, idEvento = @IdEvento, comentario = @Comentario, fecha = @Fecha WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", comentario.Id);
                    command.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
                    command.Parameters.AddWithValue("@IdEvento", comentario.IdEvento);
                    command.Parameters.AddWithValue("@Comentario", comentario.Contenido);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha ?? (object)DBNull.Value);
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

        public async Task InicializarDatosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"
                    INSERT INTO Comentarios (idUsuario, idEvento, comentario, fecha)
                    VALUES 
                    (@IdUsuario1, @IdEvento1, @Comentario1, @Fecha1),
                    (@IdUsuario2, @IdEvento2, @Comentario2, @Fecha2)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario1", 1);
                    command.Parameters.AddWithValue("@IdEvento1", 1);
                    command.Parameters.AddWithValue("@Comentario1", "Gran evento, me encantó!");
                    command.Parameters.AddWithValue("@Fecha1", DateTime.UtcNow);

                    command.Parameters.AddWithValue("@IdUsuario2", 2);
                    command.Parameters.AddWithValue("@IdEvento2", 1);
                    command.Parameters.AddWithValue("@Comentario2", "No estuvo mal, pero esperaba más.");
                    command.Parameters.AddWithValue("@Fecha2", DateTime.UtcNow);
                    //utc tiempo unniversal coordinado
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}