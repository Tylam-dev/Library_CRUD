using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Borrow
{
    public Guid BorrowId {get;set;}
    public DateTime BorrowDate {get;set;}
    public DateTime? ReturnDate {get;set;} = null;
    [JsonIgnore]
    public DateTime CreationDate {get;set;}
    [JsonIgnore]
    public DateTime UpdateDate {get;set;}
    public virtual ICollection<Book> Books {get;set;} = new Collection<Book> ();
    [JsonIgnore]
    public virtual ICollection<BorrowsBooks> BorrowsBooks {get;set;}
}