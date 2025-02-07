using System.Diagnostics;
using Models;


public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Ubicacion { get; set; }
    public string Contrasenia { get; set; }

    public Usuario(string username, string nombre, string contrasenia, string email = null, string ubicacion = null)
    {
        Username = username;
        Nombre = nombre;
        Contrasenia = contrasenia;
        Email = email;
        Ubicacion = ubicacion;
    }

    public Usuario() { }
    //neuvo objeto sin inicializacion inmediata 
}
