using System.Diagnostics;
using Models;

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