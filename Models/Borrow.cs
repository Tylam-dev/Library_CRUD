using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Borrow
{
    public Guid BorrowId {get;set;}
    public Guid BookId {get;set;}
    public DateTime BorrowDate {get;set;}
    public DateTime ReturnDate {get;set;}
    public DateTime CreationDate {get;set;}
    public DateTime UpdateDate {get;set;}
    public virtual ICollection<Book> Books {get;set;} = new List<Book>();
    public virtual ICollection<BorrowsBooks> BorrowsBooks {get;set;} = new List<BorrowsBooks>();
}