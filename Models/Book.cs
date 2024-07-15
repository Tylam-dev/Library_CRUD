using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Book
{
    public Guid BookId {get;set;}
    public string Title {get;set;}
    public string ISBN {get;set;}
    public DateOnly? PublicationDate {get;set;} = null;
    [JsonIgnore]
    public Guid AuthorId {get;set;}
    [JsonIgnore]
    public virtual ICollection<Borrow> Borrows {get;set;}
    [JsonIgnore]
    public virtual ICollection<BorrowsBooks> BorrowsBooks {get;set;}
    public virtual Author Author {get;set;}
    [JsonIgnore]
    public DateTime CreationDate {get;set;}
    [JsonIgnore]
    public DateTime UpdateDate {get;set;}
}