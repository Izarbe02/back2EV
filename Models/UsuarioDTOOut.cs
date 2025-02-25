namespace dosEvAPI.DTOs;

public class UsuarioDTOOut{
public int Id {get; set;}
public string email {get; set;}


public UsuarioDTOOut(int id, string email){
    Id = id;
        this.email = email;

}
public UsuarioDTOOut(){}
}