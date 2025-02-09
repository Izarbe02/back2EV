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
    public int IdTematica { get; set; }
    public string Enlace { get; set; }
    public int IdCategoria { get; set; }
    public int IdEstablecimientoColaborador { get; set; }

    public Evento(string nombre,string descripcion,string ubicacion,DateTime fechaInicio,DateTime fechaFin,int idTematica,
        string enlace,int idCategoria,int idEstablecimientoColaborador)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Ubicacion = ubicacion;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        IdTematica = idTematica;
        Enlace = enlace;
        IdCategoria = idCategoria;
        IdEstablecimientoColaborador = idEstablecimientoColaborador;
    }

    public Evento() { }
}
