using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{

    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            var productos = new List<Producto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, ubicacion, imagen, idUsuario, idCategoria FROM Productos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                Imagen = reader.GetString(4),
                                IdUsuario = reader.GetInt32(5),
                                IdCategoria = reader.GetInt32(6)
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            Producto? producto = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, ubicacion, imagen, idUsuario, idCategoria FROM Productos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                Imagen = reader.GetString(4),
                                IdUsuario = reader.GetInt32(5),
                                IdCategoria = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return producto;
        }

        public async Task AddAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Productos (nombre, descripcion, ubicacion, imagen, idUsuario, idCategoria) VALUES (@Nombre, @Descripcion, @Ubicacion, @Imagen, @IdUsuario, @IdCategoria)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", producto.Ubicacion);
                    command.Parameters.AddWithValue("@Imagen", producto.Imagen);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                    command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Productos SET nombre = @Nombre, descripcion = @Descripcion, ubicacion = @Ubicacion, imagen = @Imagen, idUsuario = @IdUsuario, idCategoria = @IdCategoria WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", producto.Ubicacion);
                    command.Parameters.AddWithValue("@Imagen", producto.Imagen);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                    command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Productos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}