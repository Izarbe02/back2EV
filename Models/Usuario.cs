using System.Diagnostics;
using Models;
namespace dosEvAPI.Models;

public class Usuario
{
    public required int Id { get; set; }
    public  required string Username { get; set; }
    public  required string  Nombre { get; set; }
    public  required string  Email { get; set; }
    public  required string  Ubicacion { get; set; }
    public  required string  Contrasenia { get; set; }

    public Usuario(string username, string nombre, string contrasenia, string email , string ubicacion)
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
