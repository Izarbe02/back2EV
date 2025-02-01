
using Microsoft.Data.SqlClient;
using Models;

namespace CineAPI.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly string _connectionString;

        public PeliculaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Pelicula>> GetAllAsync()
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT ID, nombre, descripcion, añoSalida, director ,  caratula, duracion , trailerURL FROM Pelicula";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var pelicula = new Pelicula
                            {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                AnioSalida = (DateTime)reader.GetValue(3),
                                Director = reader.GetString(4),
                                Caratula = reader.GetString(5),
                                Duracion = reader.GetInt32(6), 
                                TrailerURL = reader.GetString(7)
                            }; 

                            peliculas.Add(pelicula);
                        }
                    }
                }
            }
            return peliculas;
        }

        public async Task<Pelicula> GetByIdAsync(int id)
        {
            Pelicula pelicula = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT ID, nombre, descripcion, añoSalida, director ,  caratula, duracion , trailerURL FROM Pelicula WHERE ID = @ID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            pelicula = new Pelicula
                            {
                                
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                AnioSalida = (DateTime)reader.GetValue(3),
                                Director = reader.GetString(4),
                                Caratula = reader.GetString(5),
                                Duracion = reader.GetInt32(6), 
                                TrailerURL = reader.GetString(7)
                        };
                    }
                }
            }
            return pelicula;
            }
        }

        public async Task AddAsync(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "insert into Pelicula (nombre, descripcion, añoSalida, director , caratula, duracion , trailerURL ) VALUES (@Nombre, @Descripcion, @AnioSalida, @Director, @Caratula, @Duracion, @TrailerURL)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", pelicula.Nombre);
                    command.Parameters.AddWithValue("@descripcion", pelicula.Descripcion);
                    command.Parameters.AddWithValue("@AnioSalida", pelicula.AnioSalida);
                    command.Parameters.AddWithValue("@Director", pelicula.Director);
                    command.Parameters.AddWithValue("@Caratula", pelicula.Caratula);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@TrailerURL", pelicula.TrailerURL);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Pelicula SET Nombre = @Nombre, Descripcion = @Descripcion, AnioSalida = @AnioSalida, Director = @Director, Caratula = @Caratula, Duracion = @Duracion, TrailerURL = @TrailerURL WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", pelicula.Nombre);
                    command.Parameters.AddWithValue("@Ddescripcion", pelicula.Descripcion);
                    command.Parameters.AddWithValue("@AnioSalida", pelicula.AnioSalida);
                    command.Parameters.AddWithValue("@Director", pelicula.Director);
                    command.Parameters.AddWithValue("@Caratula", pelicula.Caratula);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@TrailerURL", pelicula.TrailerURL);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Pelicula WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }

}