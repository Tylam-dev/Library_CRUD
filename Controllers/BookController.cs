using Library_CRUD.Dtos;
using Library_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookController: ControllerBase
{
    public IBookService _bookService;
    public BookController(IBookService BookService)
    {
        _bookService = BookService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Book> Books = await _bookService.GetAll();
        return Ok(Books);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        Book? Book = await _bookService.GetOne(id);
        if ( Book != null)
        {
            return Ok(Book);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookPostDto request)
    {
        await _bookService.Save(request);
        return  Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] BookUpdateDto request)
    {
        await _bookService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.Delete(id);
        return Ok();
    }
}