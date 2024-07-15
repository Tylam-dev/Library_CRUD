using System.ComponentModel.DataAnnotations;
using Library_CRUD.Models;

namespace Library_CRUD.Dtos;

public class BookPostDto
{
    public string Title {get;set;}
    public string ISBN {get;set;}
    [Required]
    public DateOnly? PublicationDate {get;set;} = null;
    [Required]
    public Guid? AuthorId {get;set;} = null;
}

public class BookUpdateDto
{
    public string? Title {get;set;}
    public string? ISBN {get;set;}
    public DateOnly? PublicationDate {get;set;} = null;
    public Guid? AuthorId {get;set;}
}