using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{

       public class TematicaRepository : ITematicaRepository
    {
        private readonly string _connectionString;

        public TematicaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Tematica>> GetAllAsync()
        {
            var tematicas = new List<Tematica>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre FROM Tematica";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tematica = new Tematica
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                            tematicas.Add(tematica);
                        }
                    }
                }
            }
            return tematicas;
        }

        public async Task<Tematica?> GetByIdAsync(int id)
        {
            Tematica? tematica = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre FROM Tematica WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            tematica = new Tematica
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return tematica;
        }

        public async Task AddAsync(Tematica tematica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Tematica (nombre) VALUES (@Nombre)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", tematica.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Tematica tematica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Tematica SET nombre = @Nombre WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tematica.Id);
                    command.Parameters.AddWithValue("@Nombre", tematica.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Tematica WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
