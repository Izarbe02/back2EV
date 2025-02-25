using Models;
using Microsoft.Data.SqlClient;
using dosEvAPI.DTOs;


namespace dosEvAPI.Repositories{
     
        public class UsuarioRepository : IUsuarioRepository
        {
            private readonly string _connectionString;

            public UsuarioRepository(string connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<List<Usuario>> GetAllAsync()
            {
                var usuarios = new List<Usuario>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT ID, username, nombre, email, ubicacion, contrasenia FROM Usuarios";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var usuario = new Usuario
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Contrasenia = reader.GetString(5)
                                };
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
                return usuarios;
            }

            public async Task<Usuario?> GetByIdAsync(int id)
            {
                Usuario? usuario = null;

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT ID, username, nombre, email, ubicacion, contrasenia FROM Usuarios WHERE ID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                usuario = new Usuario
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Contrasenia = reader.GetString(5)
                                };
                            }
                        }
                    }
                }
                return usuario;
            }

            public async Task AddAsync(Usuario usuario)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Usuarios (username, nombre, email, ubicacion, contrasenia) VALUES (@Username, @Nombre, @Email, @Ubicacion, @Contrasenia)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", usuario.Username);
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Email", (object?)usuario.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Ubicacion", (object?)usuario.Ubicacion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task UpdateAsync(Usuario usuario)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE Usuarios SET username = @Username, nombre = @Nombre, email = @Email, ubicacion = @Ubicacion, contrasenia = @Contrasenia WHERE ID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", usuario.Id);
                        command.Parameters.AddWithValue("@Username", usuario.Username);
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Email", (object?)usuario.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Ubicacion", (object?)usuario.Ubicacion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task DeleteAsync(int id)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM Usuarios WHERE ID = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }

            public async Task<usuarioDTOOut>  GetUserFromCredentials(LoginDTO loginDTO)
            {
                usuarioDTOOut loginuser = null ;
                string contrasenia = null;
                using (SqlConnection connection = new SqlConnection(_connectionString)){
                    await connection.OpenAsync();
                    string query = @"SELECT ID, email , contrasenia  FROM Usuarios WHERE email = @email";
                }
            }
        }
    }
