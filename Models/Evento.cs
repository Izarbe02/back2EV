namespace Models;

public class Evento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string Ubicacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string? Tematica { get; set; }
    public string? Enlace { get; set; }
    public int? IdCategoria { get; set; }
    public int IdOrganizador { get; set; }
    public Evento(string nombre,string ubicacion,DateTime fechaInicio,DateTime fechaFin,int idOrganizador,string? descripcion = null,
    string? tematica = null,string? enlace = null,int? idCategoria = null)
    {
        Nombre = nombre;
        Ubicacion = ubicacion;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        IdOrganizador = idOrganizador;
        Descripcion = descripcion;
        Tematica = tematica;
        Enlace = enlace;
        IdCategoria = idCategoria;
    }

    public Evento() { }
}
