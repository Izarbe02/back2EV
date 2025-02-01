
namespace Models;

    public class Pelicula {
        public int ID { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public DateTime AnioSalida { get; set; }
        public string Director { get; set; } = "";
        public string Caratula { get; set; } = "";
        public int Duracion { get; set; }
        public string TrailerURL { get; set; } = "";
   


    }