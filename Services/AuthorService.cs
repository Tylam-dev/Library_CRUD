using Library_CRUD.Context;
using Library_CRUD.Models;
using Library_CRUD.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class AuthorService : IAuthorService
{
    private readonly LibraryContext _LibraryDb;
    private readonly IMapper _Mapper;
    private readonly ILogger _Logger;
    public AuthorService(LibraryContext libraryDb, IMapper mapper, ILogger<AuthorService> logger)
    {
        _LibraryDb = libraryDb;
        _Mapper = mapper;
        _Logger = logger;
    }
    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _LibraryDb.Authors.ToListAsync();
    }

    public async Task<Author?> GetOne(Guid id)
    {
        Author? AuthorFound = await _LibraryDb.Authors.FindAsync(id);
        if (AuthorFound != null)
        {
            return AuthorFound;
        }else {
            Console.WriteLine("Author does not exist");
            return null;
        }
    }
    public async Task Save(AuthorPostDto request)
    {
        Author newAuthor = _Mapper.Map<Author>(request);
        await _LibraryDb.AddAsync(newAuthor);
        await _LibraryDb.SaveChangesAsync();
    } 
    public async Task Update(Guid id, AuthorUpdateDto request)
    {
        Author? currentAuthor = await _LibraryDb.Authors.FindAsync(id);
        if(currentAuthor != null)
        {
            _Mapper.Map(request, currentAuthor);
            await _LibraryDb.SaveChangesAsync();
        }else {
            Console.WriteLine($"Error: Author with id {id} does not exist");
            return;
        }
    }
    public async Task Delete(Guid id)
    {
        Author? currentAuthor = await _LibraryDb.Authors.FindAsync(id);
        if(currentAuthor != null)
        {
            _LibraryDb.Authors.Remove(currentAuthor);
            await _LibraryDb.SaveChangesAsync();
        }else {
            Console.WriteLine($"Error: Author with id {id} does not exist");
            return;
        }
    }
}

public interface IAuthorService
{
    public Task<IEnumerable<Author>> GetAll();
    public Task<Author?> GetOne(Guid id);
    public Task Save(AuthorPostDto request);
    public Task Update(Guid id, AuthorUpdateDto request);
    public Task Delete(Guid id);
}