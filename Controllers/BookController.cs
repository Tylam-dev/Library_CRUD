using Library_CRUD.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookController: ControllerBase
{
    public IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        _bookService.GetAll();
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(Guid id)
    {
        _bookService.GetOne(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Post([FromBody] BookPostDto request)
    {
        _bookService.Save(request);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] BookUpdateDto request)
    {
        _bookService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _bookService.Delete(id);
        return Ok();
    }
}