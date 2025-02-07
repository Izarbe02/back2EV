using System.Diagnostics;
using Models;

public class Comentario
{
    //update comentado, solo borrado y creacion
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public int IdEvento { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; }

    public Comentario(int idUsuario, int idEvento, string contenido, DateTime? fecha = null)
    {
        IdUsuario = idUsuario;
        IdEvento = idEvento;
        Contenido = contenido;
        Fecha = (DateTime)fecha;
    }

    public Comentario() { }
}
