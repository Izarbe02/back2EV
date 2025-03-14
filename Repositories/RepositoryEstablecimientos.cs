using Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Repositories
{
    public class EstablecimientoRepository : IEstablecimientoRepository
    {
        private readonly string _connectionString;

        public EstablecimientoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Establecimiento>> GetAllAsync()
        {
            var establecimientos = new List<Establecimiento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, idOrganizador FROM Establecimientos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var establecimiento = new Establecimiento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Ubicacion = reader.GetString(2),
                                Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                                IdOrganizador = reader.GetInt32(4)
                            };
                            establecimientos.Add(establecimiento);
                        }
                    }
                }
            }
            return establecimientos;
        }

        public async Task<Establecimiento?> GetByIdAsync(int id)
        {
            Establecimiento? establecimiento = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, ubicacion, descripcion, idOrganizador FROM Establecimientos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            establecimiento = new Establecimiento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Ubicacion = reader.GetString(2),
                                Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                                IdOrganizador = reader.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return establecimiento;
        }

        public async Task<Establecimiento> AddAsync(Establecimiento establecimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Establecimientos (nombre, ubicacion, descripcion, idOrganizador) VALUES (@Nombre, @Ubicacion, @Descripcion, @IdOrganizador)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", establecimiento.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", establecimiento.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", (object?)establecimiento.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdOrganizador", establecimiento.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return establecimiento;
        }

        public async Task<Establecimiento> UpdateAsync(Establecimiento establecimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Establecimientos SET nombre = @Nombre, ubicacion = @Ubicacion, descripcion = @Descripcion, idOrganizador = @IdOrganizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", establecimiento.Id);
                    command.Parameters.AddWithValue("@Nombre", establecimiento.Nombre);
                    command.Parameters.AddWithValue("@Ubicacion", establecimiento.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion", (object?)establecimiento.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdOrganizador", establecimiento.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return establecimiento;
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Establecimientos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
