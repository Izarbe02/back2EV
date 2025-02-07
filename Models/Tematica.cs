using System.Diagnostics;
using Models;

public class Tematica
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Tematica(string nombre)
    {
        Nombre = nombre;
    }

    public Tematica() { }
}
