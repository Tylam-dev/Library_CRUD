using Library_CRUD.Models;

namespace Library_CRUD.Dtos;

public class BorrowPostDto
{
    public DateTime BorrowDate {get;set;}
    public ICollection<Guid> BookIds {get;set;}
}
public class BorrowUpdateDto
{
    public DateTime? BorrowDate {get;set;}
    public DateTime? ReturnDate {get;set;}
    public List<Guid>? BookIds {get;set;}
    
}