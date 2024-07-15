using Library_CRUD.Dtos;
using Library_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorController: ControllerBase
{
    public IAuthorService _authorService;
    public AuthorController(IAuthorService AuthorService)
    {
        _authorService = AuthorService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Author> authors = await _authorService.GetAll();
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        Author author = await _authorService.GetOne(id);
        if ( author != null)
        {
            return Ok(author);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthorPostDto request)
    {
        await _authorService.Save(request);
        return  Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AuthorUpdateDto request)
    {
        await _authorService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.Delete(id);
        return Ok();
    }
}