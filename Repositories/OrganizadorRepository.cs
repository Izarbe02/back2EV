using Models;
using Microsoft.Data.SqlClient;
namespace dosEvAPI.Repositories{
    public class OrganizadorRepository : IOrganizadorRepository
    {
        private readonly string _connectionString;

        public OrganizadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Organizador>> GetAllAsync()
        {
            var organizadores = new List<Organizador>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol FROM Organizador";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var organizador = new Organizador
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Ubicacion = reader.GetString(2),
                                Descripcion = reader.GetString(3),
                                Enlace = reader.GetString(4),
                                Email = reader.GetString(5),
                                Contraseña = reader.GetString(6),
                                Telefono = reader.GetString(7),
                                IdRol = reader.GetInt32(8)
                            };
                            organizadores.Add(organizador);
                        }
                    }
                }
            }
            return organizadores;
        }

        public async Task<Organizador?> GetByIdAsync(int id)
        {
            Organizador? organizador = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol FROM Organizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            organizador = new Organizador
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Ubicacion = reader.GetString(2),
                                Descripcion = reader.GetString(3),
                                Enlace = reader.GetString(4),
                                Email = reader.GetString(5),
                                Contraseña = reader.GetString(6),
                                Telefono = reader.GetString(7),
                                IdRol = reader.GetInt32(8)
                            };
                        }
                    }
                }
            }
            return organizador;
        }

        public async Task AddAsync(Organizador organizador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Organizador (nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol) VALUES (@Nombre, @Ubicacion, @Descripcion, @Enlace, @Email, @Contraseña, @Telefono, @IdRol)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", organizador.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", organizador.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", organizador.Descripcion);
                    command.Parameters.AddWithValue("@Enlace", organizador.Enlace);
                    command.Parameters.AddWithValue("@Email", organizador.Email);
                    command.Parameters.AddWithValue("@Contraseña", organizador.Contraseña);
                    command.Parameters.AddWithValue("@Telefono", organizador.Telefono);
                    command.Parameters.AddWithValue("@IdRol", organizador.IdRol);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Organizador organizador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Organizador SET nombre = @Nombre, ubicacion = @Ubicacion, descripcion = @Descripcion, enlace = @Enlace, email = @Email, contraseña = @Contraseña, telefono = @Telefono, idRol = @IdRol WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", organizador.Id);
                    command.Parameters.AddWithValue("@Nombre", organizador.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", organizador.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", organizador.Descripcion);
                    command.Parameters.AddWithValue("@Enlace", organizador.Enlace);
                    command.Parameters.AddWithValue("@Email", organizador.Email);
                    command.Parameters.AddWithValue("@Contraseña", organizador.Contraseña);
                    command.Parameters.AddWithValue("@Telefono", organizador.Telefono);
                    command.Parameters.AddWithValue("@IdRol", organizador.IdRol);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Organizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}