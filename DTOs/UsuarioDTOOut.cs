using System.Diagnostics;
using Models;
using dosEvAPI.Models;
using dosEvAPI.DTOs;
 
namespace  dosEvAPI.DTOs{

public class UsuarioDTOOut{
        public int _idUSuario {get; set;} 
    public string _correo {get; set;} 
        public UsuarioDTOOut(int idUSuario, string correo){
                    
                _idUSuario = idUSuario;
                _correo = correo;
                        }

        
        public UsuarioDTOOut(){
        
        }

}
}