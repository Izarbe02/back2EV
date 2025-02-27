using System.Diagnostics;
using Models;
using dosEvAPI.Models;

namespace  dosEvAPI.DTOs{

public class BuscadorEventoDTO
{
    public string NombreOrg { get; set; }
    public string NombreEvento { get; set; }
    public DateTime FechaInicio { get; set; }

    public string Enlace { get; set; }

    public BuscadorEventoDTO(string nombreOrg, string nombreEvento, DateTime fechaInicio, string enlace)
    {
        NombreOrg = nombreOrg;
        NombreEvento = nombreEvento;
        FechaInicio = fechaInicio;
        Enlace = enlace;

    }


    public BuscadorEventoDTO()
    {

    }

}
}