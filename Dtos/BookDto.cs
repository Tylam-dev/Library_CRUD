namespace Library_CRUD.Dtos;

public class BookPostDto
{
    public string Title {get;set;}
    public string ISBN {get;set;}
    public DateTime PublicationDate {get;set;}
    public Guid AuthorId {get;set;}
}

public class BooksUpdateDto
{
    public string? Title {get;set;}
    public string? ISBN {get;set;}
    public DateTime? PublicationDate {get;set;}
    public Guid? AuthorId {get;set;}
}