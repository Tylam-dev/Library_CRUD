using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Book
{
    public Guid BookId {get;set;}
    public string? Title {get;set;} = null;
    public string? ISBN {get;set;} = null;
    public DateOnly? PublicationDate {get;set;} = null;
    public Guid AuthorId {get;set;}
    public virtual ICollection<Borrow> Borrows {get;set;} = new List<Borrow>();
    public virtual ICollection<BorrowsBooks> BorrowsBooks {get;set;} = new List<BorrowsBooks>();
    public virtual Author Author {get;set;} = new Author();
    [JsonIgnore]
    public DateTime CreationDate {get;set;}
    [JsonIgnore]
    public DateTime UpdateDate {get;set;}
}