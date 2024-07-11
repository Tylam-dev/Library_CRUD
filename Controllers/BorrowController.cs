using Library_CRUD.Dtos;
using Library_CRUD.Models;
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
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Borrow> Borrows = await _borrowService.GetAll();
        return Ok(Borrows);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        Borrow? Borrow = await _borrowService.GetOne(id);
        if ( Borrow != null)
        {
            return Ok(Borrow);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BorrowPostDto request)
    {
        await _borrowService.Save(request);
        return  Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] BorrowUpdateDto request)
    {
        await _borrowService.Update(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _borrowService.Delete(id);
        return Ok();
    }
}