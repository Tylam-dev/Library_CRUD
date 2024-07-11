using System.Text.Json.Serialization;

namespace Library_CRUD.Models;
public class Author
{
    public Guid AuthorId {get;set;}
    public string Name {get;set;}
    public string LastName {get;set;}
    public DateOnly BirthDate {get;set;}
    public virtual ICollection<Book> Book {get;set;} = new List<Book>();
    [JsonIgnore]
    public DateTime CreationDate {get;set;}
    [JsonIgnore]
    public DateTime UpdateDate {get;set;}
}