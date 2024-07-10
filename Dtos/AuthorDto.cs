namespace Library_CRUD.Dtos;

public class AuthorPostDto
{
    public string Name {get;set;}
    public string LastName {get;set;}
    public DateTime BirthDate {get;set;}
}
public class AuthorUpdateDto
{
    public string? Name {get;set;}
    public string? LastName {get;set;}
    public DateTime? BirthDate {get;set;}
}