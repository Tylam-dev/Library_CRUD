namespace Library_CRUD.Models;

public class BorrowsBooks
{
    public Guid BorrowBookId {get;set;}
    public Guid BookId {get;set;}
    public Guid BorrowId {get;set;}
    public virtual Book Book {get;set;} = null!;
    public virtual Borrow Borrow {get;set;} = null!;
}
