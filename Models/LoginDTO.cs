using System.Diagnostics;
using Models;

public class LoginDTO{
     public string _username {get; set;} 
 
        public string _email {get; set;} 
    public string _password {get; set;} 
        public LoginDTO(string username, string email, string password ){
       _username = username;
_email = email;
_password = password;
        }

        
        public LoginDTO(){
        
        }

}