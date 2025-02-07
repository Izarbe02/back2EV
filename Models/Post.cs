using System.Diagnostics;
using Models;


public class Post
{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }

    public Post(int idUsuario, string titulo, string contenido, DateTime fecha)
    {
        IdUsuario = idUsuario;
        Titulo = titulo;
        Contenido = contenido;
        Fecha = fecha;
    }

    public Post() { }
}
