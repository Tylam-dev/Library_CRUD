using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class BorrowService : IBorrowService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    private readonly ILogger _Logger;
    public BorrowService(LibraryContext libraryDb, IMapper mapper, ILogger<BorrowService> logger)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
        _Logger = logger;
    }
    public async Task<IEnumerable<Borrow>> GetAll()
    {
        return await _LibraryDb.Borrows.Include(p => p.Books).ToListAsync();
    }

    public async Task<Borrow?> GetOne(Guid id)
    {
        Borrow? BorrowFound = await _LibraryDb.Borrows.FindAsync(id);
        if (BorrowFound != null)
        {
            return BorrowFound;
        }else {
            Console.WriteLine("Borrow does not exist");
            return null;
        }
    }
    public async Task Save(BorrowPostDto request)
    {
        Borrow newBorrow = _Mapper.Map<Borrow>(request);
        foreach(Guid id in request.BookIds)
        {
            Book? bookFound =  await _LibraryDb.Books.FindAsync(id);
            if (bookFound == null)
            {
                throw new InvalidOperationException($"A book with id {id} does not exist");
            }else
            {
                newBorrow.Books.Add(bookFound);
            };
        }
        if (newBorrow.Books.Count() == request.BookIds.Count())
        {
            newBorrow.BorrowDate = newBorrow.BorrowDate.ToUniversalTime();
            await _LibraryDb.AddAsync(newBorrow);
            await _LibraryDb.SaveChangesAsync();
        }
    } 
    public async Task Update(Guid id, BorrowUpdateDto request)
    {
        Borrow? currentBorrow = await _LibraryDb.Borrows.Include(p => p.Books).FirstOrDefaultAsync(p => p.BorrowId == id);
        List<Book> newListBook = new List<Book>();
        if(currentBorrow != null)
        {
            _Mapper.Map(request, currentBorrow);
            if(request.BookIds != null)
            {
                foreach(Guid idBook in request.BookIds)
                {
                Book? bookFound =  await _LibraryDb.Books.FindAsync(idBook);
                if (bookFound == null)
                {
                    throw new InvalidOperationException($"A borrow with id {idBook} does not exist");
                }else
                {
                 newListBook.Add(bookFound);
                };
                }
                if (newListBook.Count() == request.BookIds.Count())
                {
                    currentBorrow.Books.Clear();
                    currentBorrow.Books = newListBook;
                    await _LibraryDb.SaveChangesAsync();
                }
            }
        }else {
            Console.WriteLine($"Error: Borrow with id {id} does not exist");
            return;
        }
    }
    public async Task Delete(Guid id)
    {
        Borrow? currentBorrow = await _LibraryDb.Borrows.FindAsync(id);
        if(currentBorrow != null)
        {
            _LibraryDb.Borrows.Remove(currentBorrow);
            await _LibraryDb.SaveChangesAsync();
        }else {
            Console.WriteLine($"Error: Borrow with id {id} does not exist");
            return;
        }
    }
}

public interface IBorrowService
{
    public Task<IEnumerable<Borrow>> GetAll();
    public Task<Borrow?> GetOne(Guid id);
    public Task Save(BorrowPostDto request);
    public Task Update(Guid id, BorrowUpdateDto request);
    public Task Delete(Guid id);
}