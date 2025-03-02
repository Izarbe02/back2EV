using System.Diagnostics;
using Models;


public class Evento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Ubicacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Enlace { get; set; }
    public int IdOrganizador { get; set; }

    public Evento(string nombre,string descripcion,string ubicacion,DateTime fechaInicio,DateTime fechaFin,
        string enlace,int idOrganizador)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Ubicacion = ubicacion;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Enlace = enlace;
        IdOrganizador = idOrganizador;
    }

    public Evento() { }
}
