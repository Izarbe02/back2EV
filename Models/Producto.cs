using System.Diagnostics;
using Models;


public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Ubicacion { get; set; }
    public string Imagen { get; set; }
    public int IdOrganizador { get; set; }
    public int IdCategoria { get; set; }

    public Producto(int idOrganizador, string nombre, string descripcion, string ubicacion, string imagen, int idCategoria)
    {
        IdOrganizador = idOrganizador;
        Nombre = nombre;
        Descripcion = descripcion;
        Ubicacion = ubicacion;
        Imagen = imagen;
        IdCategoria = idCategoria;
    }

    public Producto() { }
}
