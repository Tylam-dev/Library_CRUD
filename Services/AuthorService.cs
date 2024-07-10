using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;

public class AuthorService : IAuthorService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    public AuthorService(LibraryContext libraryDb, IMapper mapper)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
    }
    public IEnumerable<Author> GetAll()
    {
        return _LibraryDb.Authors;
    }

    public async Task<Author?> GetOne(Guid id)
    {
        Author? AuthorFound = await _LibraryDb.Authors.FindAsync(id);
        if (AuthorFound != null)
        {
            return AuthorFound;
        }
        Console.WriteLine("Author does not exist");
        return null;
    }
    public async Task Save(AuthorPostDto request)
    {
        Author? Author = _Mapper.Map<Author>(request);
        if (Author != null)
        {
            await _LibraryDb.AddAsync(Author);
            await _LibraryDb.SaveChangesAsync();
        }
    } 
    public async Task Update(Guid id, AuthorUpdateDto request)
    {
        Author? currentAuthor = await _LibraryDb.Authors.FindAsync(id);
        if(currentAuthor != null)
        {
            _Mapper.Map(request, currentAuthor);
            await _LibraryDb.SaveChangesAsync();
        }
            Console.WriteLine($"Error: Author with id {id} does not exist");
            return;
    }
    public async Task Delete(Guid id)
    {
        Author? currentAuthor = await _LibraryDb.Authors.FindAsync(id);
        if(currentAuthor != null)
        {
            _LibraryDb.Authors.Remove(currentAuthor);
        }
        Console.WriteLine($"Error: Author with id {id} does not exist");
        return;
    }
}

public interface IAuthorService
{
    public IEnumerable<Author> GetAll();
    public Task<Author?> GetOne(Guid id);
    public Task Save(AuthorPostDto request);
    public Task Update(Guid id, AuthorUpdateDto request);
    public Task Delete(Guid id);
}