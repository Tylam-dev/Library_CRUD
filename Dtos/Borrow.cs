using Library_CRUD.Models;

namespace Library_CRUD.Dtos;

public class BorrowPostDto
{
    public Guid BookId {get;set;}
    public DateTime BorrowDate {get;set;}
    public List<Guid> BookIds {get;set;} = new List<Guid>();
}

public class BorrowUpdateDto
{
    public DateTime? BorrowDate {get;set;}
    public DateTime? ReturnDate {get;set;}
    public List<Guid>? BookIds {get;set;}
    
}