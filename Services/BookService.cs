using Library_CRUD.Context;
using Library_CRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly LibraryContext _LibraryDb;
    public BookService(LibraryContext libraryDb)
    {
        _LibraryDb = libraryDb;
    }
    public IEnumerable<Book> GetAll()
    {
        return _LibraryDb.Books;
    }

    public async Task<Book?> GetOne(Guid id)
    {
        var bookFound = await _LibraryDb.Books.FindAsync(id);
        if (bookFound == null)
        {
            Console.WriteLine("Book does not exist");
            return null;
        }
        return bookFound;
    }
}

public interface IBookService
{
    public IEnumerable<Book> GetAll();
    public Task<Book?> GetOne(Guid id);
    public Task Save();
    public Task Update();
    public Task Delete();
}