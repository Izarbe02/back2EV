using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace dosEvAPI.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly string _connectionString;


        public TokenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<Usuario?> LoginAsync(UsuarioLogin authRequest)
        {
            Usuario? usuario = null;


            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT ID, username, nombre, email, ubicacion, contrasenia, idrol FROM Usuarios where username = @Username and contrasenia = @contrasenia";


                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", authRequest.Username);
                    command.Parameters.AddWithValue("@contrasenia", authRequest.Contrasenia);


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
                                    Contrasenia = reader.GetString(5),
                                    IdRol = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return usuario;
        }
    }
}
