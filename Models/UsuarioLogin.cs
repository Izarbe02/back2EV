using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Models;


public class UsuarioLogin
{
    public string Username { get; set; }
    public string Contrasenia { get; set; }
 

    public UsuarioLogin(string username, string contrasenia)
    {
        Username = username;
        Contrasenia = contrasenia;
    }

    public UsuarioLogin() { }
    //neuvo objeto sin inicializacion inmediata 
}