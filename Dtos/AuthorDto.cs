using System.ComponentModel.DataAnnotations;
using Library_CRUD.Models;


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
    public DateOnly? BirthDate {get;set;}
}