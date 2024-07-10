using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;

public class BorrowService : IBorrowService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    public BorrowService(LibraryContext libraryDb, IMapper mapper)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
    }
    public IEnumerable<Borrow> GetAll()
    {
        return _LibraryDb.Borrows;
    }

    public async Task<Borrow?> GetOne(Guid id)
    {
        Borrow? BorrowFound = await _LibraryDb.Borrows.FindAsync(id);
        if (BorrowFound != null)
        {
            return BorrowFound;
        }
        Console.WriteLine("Borrow does not exist");
        return null;
    }
    public async Task Save(BorrowPostDto request)
    {
        Borrow borrow = new Borrow();
        _Mapper.Map(request, borrow);
        borrow.BorrowId = Guid.NewGuid();
        await _LibraryDb.AddAsync(borrow);
        await _LibraryDb.SaveChangesAsync();
    } 
    public async Task Update(Guid id, BorrowUpdateDto request)
    {
        Borrow? currentBorrow = await _LibraryDb.Borrows.FindAsync(id);
        if(currentBorrow != null)
        {
            _Mapper.Map(request, currentBorrow);
            await _LibraryDb.SaveChangesAsync();
        }
            Console.WriteLine($"Error: Borrow with id {id} does not exist");
            return;
    }
    public async Task Delete(Guid id)
    {
        Borrow? currentBorrow = await _LibraryDb.Borrows.FindAsync(id);
        if(currentBorrow != null)
        {
            _LibraryDb.Borrows.Remove(currentBorrow);
        }
        Console.WriteLine($"Error: Borrow with id {id} does not exist");
        return;
    }
}

public interface IBorrowService
{
    public IEnumerable<Borrow> GetAll();
    public Task<Borrow?> GetOne(Guid id);
    public Task Save(BorrowPostDto request);
    public Task Update(Guid id, BorrowUpdateDto request);
    public Task Delete(Guid id);
}