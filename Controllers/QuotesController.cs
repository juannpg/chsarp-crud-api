using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public QuotesController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet("getQuotes")]
  public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
  {
    return await _context.Quotes.ToListAsync();
  }

  [HttpPost("writeQuote")]
  public async Task<ActionResult<Quote>> WriteQuote(Quote quote)
  {
    _context.Quotes.Add(quote);
    await _context.SaveChangesAsync();
    return quote;
  }
}