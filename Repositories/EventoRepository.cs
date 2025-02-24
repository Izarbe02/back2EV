using Models;
using Microsoft.Data.SqlClient;

namespace dosEvAPI.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string _connectionString;

        public EventoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Evento>> GetAllAsync()
        {
            var eventos = new List<Evento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador FROM Eventos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var evento = new Evento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                FechaInicio = reader.GetDateTime(4),
                                FechaFin = reader.GetDateTime(5),
                                IdTematica = reader.GetInt32(6),
                                Enlace = reader.GetString(7),
                                IdCategoria = reader.GetInt32(8),
                                IdOrganizador = reader.GetInt32(9)
                            };
                            eventos.Add(evento);
                        }
                    }
                }
            }
            return eventos;
        }

        public async Task<Evento?> GetByIdAsync(int id)
        {
            Evento? evento = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador FROM Eventos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            evento = new Evento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                FechaInicio = reader.GetDateTime(4),
                                FechaFin = reader.GetDateTime(5),
                                IdTematica = reader.GetInt32(6),
                                Enlace = reader.GetString(7),
                                IdCategoria = reader.GetInt32(8),
                                IdOrganizador = reader.GetInt32(9)
                            };
                        }
                    }
                }
            }
            return evento;
        }

        // Funcion para filtrar por categoria
        public async Task<List<Evento>> GetByCategoriaAsync(string categoria)
        {
            var eventos = new List<Evento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.idTematica, e.enlace, e.idCategoria, e.idOrganizador 
                                 FROM Eventos e 
                                 INNER JOIN CategoriaEvento c ON e.idCategoria = c.ID 
                                 WHERE c.nombre = @categoria";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoria", categoria);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            eventos.Add(new Evento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                FechaInicio = reader.GetDateTime(4),
                                FechaFin = reader.GetDateTime(5),
                                IdTematica = reader.GetInt32(6),
                                Enlace = reader.GetString(7),
                                IdCategoria = reader.GetInt32(8),
                                IdOrganizador = reader.GetInt32(9)
                            });
                        }
                    }
                }
            }
            return eventos;
        }

        public async Task<List<Evento>> GetByOrganizadorAsync(string organizador)
        {
            var eventos = new List<Evento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.idTematica, e.enlace, e.idCategoria, e.idOrganizador 
                                 FROM Eventos e 
                                 INNER JOIN Organizador o ON e.idOrganizador = o.ID 
                                 WHERE o.nombre = @organizador";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@organizador", organizador);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            eventos.Add(new Evento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                FechaInicio = reader.GetDateTime(4),
                                FechaFin = reader.GetDateTime(5),
                                IdTematica = reader.GetInt32(6),
                                Enlace = reader.GetString(7),
                                IdCategoria = reader.GetInt32(8),
                                IdOrganizador = reader.GetInt32(9)
                            });
                        }
                    }
                }
            }
            return eventos;
        }
    

        public async Task AddAsync(Evento evento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Eventos (nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, idTematica, enlace, idCategoria, idOrganizador) VALUES (@Nombre, @Descripcion, @Ubicacion, @FechaInicio, @FechaFin, @IdTematica, @Enlace, @IdCategoria, @IdOrganizador)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", evento.Ubicacion);
                    command.Parameters.AddWithValue("@FechaInicio", evento.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", evento.FechaFin);
                    command.Parameters.AddWithValue("@IdTematica", evento.IdTematica);
                    command.Parameters.AddWithValue("@Enlace", evento.Enlace);
                    command.Parameters.AddWithValue("@IdCategoria", evento.IdCategoria);
                    command.Parameters.AddWithValue("@IdOrganizador", evento.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Evento evento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Eventos SET nombre = @Nombre, descripcion = @Descripcion, ubicacion = @Ubicacion, fecha_inicio = @FechaInicio, fecha_fin = @FechaFin, idTematica = @IdTematica, enlace = @Enlace, idCategoria = @IdCategoria, idOrganizador = @IdOrganizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", evento.Id);
                    command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", evento.Ubicacion);
                    command.Parameters.AddWithValue("@FechaInicio", evento.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", evento.FechaFin);
                    command.Parameters.AddWithValue("@IdTematica", evento.IdTematica);
                    command.Parameters.AddWithValue("@Enlace", evento.Enlace);
                    command.Parameters.AddWithValue("@IdCategoria", evento.IdCategoria);
                    command.Parameters.AddWithValue("@IdOrganizador", evento.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<EventoInfoDTO> GetInfoEventoAsync (int id )
        {
            EventoInfoDTO eventoInfo = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query =@"SELECT o.nombre, e.nombre, e.descripcion, e.fecha_inicio, e.fecha_fin, e.ubicacion, c.nombre, t.nombre, e.enlace
                FROM Eventos e INNER JOIN Organizador o 
                ON e.idOrganizador=o.ID INNER JOIN CategoriaEvento c
                 ON e.idCategoria=c.ID INNER JOIN Tematicas t
                  ON e.idTematica=t.ID WHERE e.ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            eventoInfo = new EventoInfoDTO
                            {       
                                NombreOrg = reader.GetString(0),
                                NombreEvento = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4),
                                Ubicacion = reader.GetString(5),
                                EventoCategoria = reader.GetString(6),
                                Tematica = reader.GetString(7),
                                Enlace = reader.GetString(8)
                            };
                        }
                    }
                }
            }
            return eventoInfo;
        }
      

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Eventos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<List<BuscadorEventoDTO>> GetInfoEventoBuscadorsync(string busqueda){
            var eventos = new List<BuscadorEventoDTO?>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.nombre , e.enlace , e.fecha_inicio , o.nombre from Eventos 
                e INNER JOIN Organizador o ON e.idOrganizador = o.ID 
                WHERE e.nombre LIKE @busqueda
                or WHERE o.nombre LIKE @busqueda";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@busqueda" ,busqueda);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var evento = new BuscadorEventoDTO
                            {
                              NombreOrg = reader.GetString(0),
                                NombreEvento = reader.GetString(1),
                                FechaInicio = reader.GetDateTime(2),
                                Enlace = reader.GetString(3)
                            };
                            eventos.Add(evento);
                        }
                    }
                }
            }
            return eventos;
        }
    }
}
