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
                string query = "SELECT ID, nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, enlace, idOrganizador FROM Eventos";
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
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
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
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, enlace, idOrganizador FROM Eventos WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Evento
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                FechaInicio = reader.GetDateTime(4),
                                FechaFin = reader.GetDateTime(5),
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Funcion para filtrar por categoria
        public async Task<List<Evento>> GetByCategoriaAsync(string categoria)
        {
            var eventos = new List<Evento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.enlace, e.idOrganizador 
                                 FROM Eventos e 
                                 INNER JOIN CategoriaEvento c ON e.idOrganizador = c.ID 
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
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return eventos;
        }


        public async Task<List<Evento>> GetByOrganizadorIdAsync(int organizadorid)
        {
            var eventos = new List<Evento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.enlace, e.idOrganizador 
                                 FROM Eventos e 
                                 WHERE e.idOrganizador = @organizadorid";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@organizadorid", organizadorid);
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
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
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
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.enlace, e.idOrganizador 
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
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return eventos;
        }
    

    public async Task<List<Evento>> GetProximosEventosAsync()
{
    var eventos = new List<Evento>();

    using (var connection = new SqlConnection(_connectionString))
    {
        await connection.OpenAsync();
        string query = @"
            SELECT TOP 3 e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.enlace, e.idOrganizador 
            FROM Eventos e 
            WHERE e.fecha_inicio >= GETDATE()
            ORDER BY e.fecha_inicio ASC";
            
        using (var command = new SqlCommand(query, connection))
        {
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
                        Enlace = reader.GetString(6),
                        IdOrganizador = reader.GetInt32(7)
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
                string query = "INSERT INTO Eventos (nombre, descripcion, ubicacion, fecha_inicio, fecha_fin, enlace, idOrganizador) VALUES (@Nombre, @Descripcion, @Ubicacion, @FechaInicio, @FechaFin, @Enlace, @IdOrganizador)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", evento.Ubicacion);
                    command.Parameters.AddWithValue("@FechaInicio", evento.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", evento.FechaFin);
                    command.Parameters.AddWithValue("@Enlace", evento.Enlace);
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
                string query = "UPDATE Eventos SET nombre = @Nombre, descripcion = @Descripcion, ubicacion = @Ubicacion, fecha_inicio = @FechaInicio, fecha_fin = @FechaFin, enlace = @Enlace, idOrganizador = @IdOrganizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", evento.Id);
                    command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", evento.Ubicacion);
                    command.Parameters.AddWithValue("@FechaInicio", evento.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", evento.FechaFin);
                    command.Parameters.AddWithValue("@Enlace", evento.Enlace);
                    command.Parameters.AddWithValue("@IdOrganizador", evento.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<EventoInfoDTO?> GetInfoEventoAsync (int id )
        {
            EventoInfoDTO eventoInfo = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query =@"SELECT o.nombre, e.nombre, e.descripcion, e.fecha_inicio, e.fecha_fin, e.ubicacion, e.enlace
                FROM Eventos e INNER JOIN Organizador o
                ON e.idOrganizador=o.ID 
                WHERE e.ID = @Id";
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
                                Enlace = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            if (eventoInfo != null){
                eventoInfo.Categorias = await GetCategoriaEventoByEventoIdAsync(id);
                eventoInfo.Tematicas = await GetTematicaByEventoIdAsync(id);
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


        public async Task<List<Evento>> GetInfoEventoBuscadorsync(string busqueda){
            var eventos = new List<Evento?>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT e.ID, e.nombre, e.descripcion, e.ubicacion, e.fecha_inicio, e.fecha_fin, e.enlace, e.idOrganizador from Eventos e
                WHERE e.nombre LIKE '%' + @busqueda + '%'
                or e.ubicacion LIKE '%' + @busqueda + '%'";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@busqueda" ,busqueda);
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
                                Enlace = reader.GetString(6),
                                IdOrganizador = reader.GetInt32(7)
                            };
                            eventos.Add(evento);
                        }
                    }
                }
            }
            return eventos;
        }


        public async Task<List<CategoriaEvento>> GetCategoriaEventoByEventoIdAsync(int eventoId)
        {
            var categoriasevento = new List<CategoriaEvento>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT c.Id, c.Nombre 
                                FROM CategoriaEvento c 
                                JOIN Eventos_Categoria ec ON c.Id = ec.Idcategoria
                                WHERE ec.Idevento = @Idevento";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Idevento", eventoId);
                    using (var reader = await command.ExecuteReaderAsync()){
                        while (await reader.ReadAsync()){
                            categoriasevento.Add(new CategoriaEvento{
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return categoriasevento;
        }

        public async Task<List<Tematica>> GetTematicaByEventoIdAsync(int eventoId)
        {
            var tematicasEvento = new List<Tematica>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"SELECT t.Id, t.Nombre 
                                FROM Tematica t 
                                JOIN Eventos_Tematica et ON t.Id = et.idtematica
                                WHERE et.Idevento = @Idevento";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Idevento", eventoId);
                    using (var reader = await command.ExecuteReaderAsync()){
                        while (await reader.ReadAsync()){
                            tematicasEvento.Add(new Tematica{
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return tematicasEvento;
        }
    }
    
}
