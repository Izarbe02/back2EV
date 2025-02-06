
using Microsoft.Data.SqlClient;
namespace dosEvAPI.Repositories{

public class CategoriaProductoRepository : ICategoriaProductoRepository
    {
        private readonly string _connectionString;

        public CategoriaProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CategoriaProducto>> GetAllAsync()
        {
            var categorias = new List<CategoriaProducto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Nombre FROM CategoriaProducto";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var categoria = new CategoriaProducto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                            categorias.Add(categoria);
                        }
                    }
                }
            }
            return categorias;
        }

        public async Task<CategoriaProducto?> GetByIdAsync(int id)
        {
            CategoriaProducto? categoria = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Nombre FROM CategoriaProducto WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            categoria = new CategoriaProducto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return categoria;
        }

        public async Task AddAsync(CategoriaProducto categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO CategoriaProducto (Nombre) VALUES (@Nombre)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(CategoriaProducto categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE CategoriaProducto SET Nombre = @Nombre WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", categoria.Id);
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM CategoriaProducto WHERE Id = @Id";
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
                    INSERT INTO CategoriaProducto (Nombre)
                    VALUES 
                    (@Nombre1),
                    (@Nombre2)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre1", "Conciertos");
                    command.Parameters.AddWithValue("@Nombre2", "Teatro");
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}