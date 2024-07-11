using System.ComponentModel.DataAnnotations;


namespace Library_CRUD.Dtos;

public class AuthorPostDto
{
    public string Name {get;set;}
    public string LastName {get;set;}
    [Required]
    public DateOnly? BirthDate {get;set;} = null;
}
public class AuthorUpdateDto
{
    public string? Name {get;set;}
    public string? LastName {get;set;}
    public DateTime? BirthDate {get;set;}
}