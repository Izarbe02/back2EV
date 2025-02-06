using Microsoft.Data.SqlClient;
namespace dosEvAPI.Repositories{
    public class EstablecimientoColaboradorRepository : IEstablecimientoColaboradorRepository
    {
        private readonly string _connectionString;

        public EstablecimientoColaboradorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<EstablecimientoColaborador>> GetAllAsync()
        {
            var establecimientos = new List<EstablecimientoColaborador>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol FROM EstablecimientosColaboradores";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var establecimiento = new EstablecimientoColaborador
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
                            establecimientos.Add(establecimiento);
                        }
                    }
                }
            }
            return establecimientos;
        }

        public async Task<EstablecimientoColaborador?> GetByIdAsync(int id)
        {
            EstablecimientoColaborador? establecimiento = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol FROM EstablecimientosColaboradores WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            establecimiento = new EstablecimientoColaborador
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
            return establecimiento;
        }

        public async Task AddAsync(EstablecimientoColaborador establecimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO EstablecimientosColaboradores (nombre, ubicacion, descripcion, enlace, email, contraseña, telefono, idRol) VALUES (@Nombre, @Ubicacion, @Descripcion, @Enlace, @Email, @Contraseña, @Telefono, @IdRol)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", establecimiento.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", establecimiento.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", establecimiento.Descripcion);
                    command.Parameters.AddWithValue("@Enlace", establecimiento.Enlace);
                    command.Parameters.AddWithValue("@Email", establecimiento.Email);
                    command.Parameters.AddWithValue("@Contraseña", establecimiento.Contraseña);
                    command.Parameters.AddWithValue("@Telefono", establecimiento.Telefono);
                    command.Parameters.AddWithValue("@IdRol", establecimiento.IdRol);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(EstablecimientoColaborador establecimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE EstablecimientosColaboradores SET nombre = @Nombre, ubicacion = @Ubicacion, descripcion = @Descripcion, enlace = @Enlace, email = @Email, contraseña = @Contraseña, telefono = @Telefono, idRol = @IdRol WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", establecimiento.Id);
                    command.Parameters.AddWithValue("@Nombre", establecimiento.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", establecimiento.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", establecimiento.Descripcion);
                    command.Parameters.AddWithValue("@Enlace", establecimiento.Enlace);
                    command.Parameters.AddWithValue("@Email", establecimiento.Email);
                    command.Parameters.AddWithValue("@Contraseña", establecimiento.Contraseña);
                    command.Parameters.AddWithValue("@Telefono", establecimiento.Telefono);
                    command.Parameters.AddWithValue("@IdRol", establecimiento.IdRol);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM EstablecimientosColaboradores WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}