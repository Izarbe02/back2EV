namespace Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Ubicacion { get; set; }
    public string Imagen { get; set; }
    public int IdUsuario { get; set; }
    public int IdCategoria { get; set; }

    public Producto(int idUsuario, string nombre, string descripcion, string ubicacion, string imagen, int idCategoria)
    {
        IdUsuario = idUsuario;
        Nombre = nombre;
        Descripcion = descripcion;
        Ubicacion = ubicacion;
        Imagen = imagen;
        IdCategoria = idCategoria;
    }

    public Producto() { }
}
