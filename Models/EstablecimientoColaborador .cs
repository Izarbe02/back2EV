namespace Models;

public class EstablecimientoColaborador : Usuario
{
    public string? Descripcion { get; set; }
    public string? Enlace { get; set; }
    public string? Telefono { get; set; }
    public int IdRol { get; set; }

    public EstablecimientoColaborador(
        string username,
        string nombre,
        string contraseña,
        int idRol,
        string? email = null,
        string? ubicacion = null,
        string? descripcion = null,
        string? enlace = null,
        string? telefono = null)
        : base(username, nombre, contraseña, email, ubicacion)
    {
        IdRol = idRol;
        Descripcion = descripcion;
        Enlace = enlace;
        Telefono = telefono;
    }

    public EstablecimientoColaborador() : base() { }
}
