using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
public class BookService : IBookService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    private readonly ILogger _Logger;
    public BookService(LibraryContext libraryDb, IMapper mapper, ILogger<BookService> logger)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
        _Logger = logger;
    }
    public async Task<IEnumerable<Book>> GetAll(string? author)
    {
        if (author != null)
        {   
            return await _LibraryDb.Books.Include(p => p.Author).Where(p => p.Author.Name == author).ToListAsync();
        }
        return await _LibraryDb.Books.Include(p => p.Author).ToListAsync();
    }

    public async Task<Book?> GetOne(Guid id)
    {
        Book? BookFound = await _LibraryDb.Books.FindAsync(id);
        if (BookFound != null)
        {
            return BookFound;
        }else {
            Console.WriteLine("Book does not exist");
            return null;
        }
    }
    public async Task Save(BookPostDto request)
    {
        Book newBook = _Mapper.Map<Book>(request);
        Author? author = await _LibraryDb.Authors.FindAsync(newBook.AuthorId);
        if (author != null)
        {
            newBook.Author = author;
            await _LibraryDb.AddAsync(newBook);
            await _LibraryDb.SaveChangesAsync();
        }
    } 
    public async Task Update(Guid id, BookUpdateDto request)
    {
        Book? currentBook = await _LibraryDb.Books.FindAsync(id);
        if(currentBook != null)
        {
            _Mapper.Map(request, currentBook);
            await _LibraryDb.SaveChangesAsync();
        }else {
            Console.WriteLine($"Error: Book with id {id} does not exist");
            return;
        }
    }
    public async Task Delete(Guid id)
    {
        Book? currentBook = await _LibraryDb.Books.FindAsync(id);
        if(currentBook != null)
        {
            _LibraryDb.Books.Remove(currentBook);
            await _LibraryDb.SaveChangesAsync();
        }else {
            Console.WriteLine($"Error: Book with id {id} does not exist");
            return;
        }
    }
}

public interface IBookService
{
    public Task<IEnumerable<Book>> GetAll(string? author);
    public Task<Book?> GetOne(Guid id);
    public Task Save(BookPostDto request);
    public Task Update(Guid id, BookUpdateDto request);
    public Task Delete(Guid id);
}