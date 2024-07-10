using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Book
{
    public Guid BookId {get;set;}
    public string Title {get;set;}
    public string ISBN {get;set;}
    public DateTime PublicationDate {get;set;}
    public Guid AuthorId {get;set;}
    public virtual ICollection<Borrow> Borrows {get;set;} = new List<Borrow>();
    public virtual ICollection<BorrowsBooks> BorrowsBooks {get;set;} = new List<BorrowsBooks>();
    public virtual Author Author {get;set;}
    [JsonIgnore]
    public DateTime CreationDate {get;set;}
    [JsonIgnore]
    public DateTime UpdateDate {get;set;}
}