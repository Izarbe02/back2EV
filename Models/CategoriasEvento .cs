namespace Models;

public class CategoriaEvento
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public CategoriaEvento(string nombre)
    {
        Nombre = nombre;
    }

    public CategoriaEvento() { }
}
