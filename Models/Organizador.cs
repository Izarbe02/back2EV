namespace Models;
using dosEvAPI.Models;


public class Organizador : Usuario
{
    public string Descripcion { get; set; }
    public string Enlace { get; set; }
    public string Telefono { get; set; }
    public int IdRol { get; set; }
    public int IdCategoria { get; set; }

    public Organizador(string username,string nombre,string contrasenia,int idRol,int idCategoria,string email,
        string ubicacion,
        string descripcion,
        string enlace,
        string telefono)
        : base(username, nombre, contrasenia, email, ubicacion)
    {
        IdRol = idRol;
        IdCategoria = idCategoria;
        Descripcion = descripcion;
        Enlace = enlace;
        Telefono = telefono;
    }

    public Organizador() : base() { }
}
