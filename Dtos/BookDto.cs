using System.ComponentModel.DataAnnotations;

namespace Library_CRUD.Dtos;

public class BookPostDto
{
    public string Title {get;set;} = string.Empty;
    public string ISBN {get;set;} = string.Empty;
    [Required]
    public DateOnly? PublicationDate {get;set;} = null;
    public Guid AuthorId {get;set;}
}

public class BookUpdateDto
{
    public string? Title {get;set;}
    public string? ISBN {get;set;}
    public DateOnly? PublicationDate {get;set;} = null;
    public Guid? AuthorId {get;set;}
}