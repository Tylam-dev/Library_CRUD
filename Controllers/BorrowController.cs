using Library_CRUD.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BorrowController: ControllerBase
{
    public IBorrowService _borrowService;
    public BorrowController(IBorrowService BorrowService)
    {
        _borrowService = BorrowService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        _borrowService.GetAll();
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(Guid id)
    {
        _borrowService.GetOne(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Post([FromBody] BorrowPostDto request)
    {
        _borrowService.Save(request);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] BorrowUpdateDto request)
    {
        _borrowService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _borrowService.Delete(id);
        return Ok();
    }
}