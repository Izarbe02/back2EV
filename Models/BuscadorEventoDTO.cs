using System.Diagnostics;
using Models;

public class BuscadorEventoDTO
{
    public string NombreOrg { get; set; }
    public string NombreEvento { get; set; }
    public DateTime FechaInicio { get; set; }
    public string Enlace { get; set; }
    public int Idevento { get; set; }

    public BuscadorEventoDTO(string nombreOrg, string nombreEvento, DateTime fechaInicio, string enlace, int idevento)
    {
        NombreOrg = nombreOrg;
        NombreEvento = nombreEvento;
        FechaInicio = fechaInicio;
        Enlace = enlace;
        Idevento = idevento;
    }


    public BuscadorEventoDTO()
    {

    }

}