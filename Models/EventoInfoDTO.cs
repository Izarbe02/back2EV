using System.Diagnostics;
using Models;

public class EventoInfoDTO{
        public string NombreOrg {get; set;} 
        public string NombreEvento {get; set;}
        public string Descripcion {get; set;}
        public DateTime FechaInicio {get; set;}
        public DateTime FechaFin {get; set;}
        public string Ubicacion {get; set;}
        public string Enlace {get; set;}
         public List<CategoriaEvento?> Categorias { get; set; }
         public List<Tematica?> Tematicas { get; set; }
         

        public EventoInfoDTO(string nombreOrg, string nombreEvento, string descripcion, DateTime fechaInicio, DateTime fechaFin, string ubicacion, string enlace){
            NombreOrg = nombreOrg;
            NombreEvento = nombreEvento;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Ubicacion = ubicacion;
            Enlace = enlace;

        }

        
        public EventoInfoDTO(){
        
        }

}