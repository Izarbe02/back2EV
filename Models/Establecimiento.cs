using System.Diagnostics;
using Models;

public class Establecimiento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public string? Descripcion { get; set; }
    public int IdOrganizador { get; set; }

    public Establecimiento(int idOrganizador, string nombre, string ubicacion, string? descripcion)
    {
        IdOrganizador = idOrganizador;
        Nombre = nombre;
        Ubicacion = ubicacion;
        Descripcion = descripcion;
    }

    public Establecimiento() { }
}
