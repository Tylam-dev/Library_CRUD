using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;

public class BookService : IBookService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    public BookService(LibraryContext libraryDb, IMapper mapper)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
    }
    public IEnumerable<Book> GetAll()
    {
        return _LibraryDb.Books;
    }

    public async Task<Book?> GetOne(Guid id)
    {
        Book? bookFound = await _LibraryDb.Books.FindAsync(id);
        if (bookFound != null)
        {
            return bookFound;
        }
        Console.WriteLine("Book does not exist");
        return null;
    }
    public async Task Save(BookPostDto request)
    {
        Book book = new Book();
        _Mapper.Map(request, book);
        book.BookId = Guid.NewGuid();
        await _LibraryDb.AddAsync(book);
        await _LibraryDb.SaveChangesAsync();
    } 
    public async Task Update(Guid id, BookUpdateDto request)
    {
        Book? currentBook = await _LibraryDb.Books.FindAsync(id);
        if(currentBook != null)
        {
            _Mapper.Map(request, currentBook);
            await _LibraryDb.SaveChangesAsync();
        }
            Console.WriteLine($"Error: Book with id {id} does not exist");
            return;
    }
    public async Task Delete(Guid id)
    {
        Book? currentBook = await _LibraryDb.Books.FindAsync(id);
        if(currentBook != null)
        {
            _LibraryDb.Books.Remove(currentBook);
        }
        Console.WriteLine($"Error: Book with id {id} does not exist");
        return;
    }
}

public interface IBookService
{
    public IEnumerable<Book> GetAll();
    public Task<Book?> GetOne(Guid id);
    public Task Save(BookPostDto request);
    public Task Update(Guid id, BookUpdateDto request);
    public Task Delete(Guid id);
}