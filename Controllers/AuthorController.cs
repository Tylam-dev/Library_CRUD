using Library_CRUD.Dtos;
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
    public IActionResult GetAll()
    {
        _authorService.GetAll();
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(Guid id)
    {
        _authorService.GetOne(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Post([FromBody] AuthorPostDto request)
    {
        _authorService.Save(request);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] AuthorUpdateDto request)
    {
        _authorService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _authorService.Delete(id);
        return Ok();
    }
}