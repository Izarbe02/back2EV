using System.Diagnostics;
using Models;


public class CategoriaProducto
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public CategoriaProducto(string nombre)
    {
        Nombre = nombre;
    }

    public CategoriaProducto() { }
}
