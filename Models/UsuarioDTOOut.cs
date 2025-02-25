namespace dosEvAPI.DTOs;

public class usuarioDTOOut{
public int Id {get; set;}
public string email {get; set;}


public usuarioDTOOut(int id, string email){
    Id = id;
        this.email = email;

}
public usuarioDTOOut(){}
}