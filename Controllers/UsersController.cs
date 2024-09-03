using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace csharp_crud_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public UsersController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet("getUsers")]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    return await _context.Users.ToListAsync();
  }

  [HttpGet("getUser")]
  public async Task<ActionResult<User>> GetUserWithId(int id)
  {
    return await _context.Users.SingleOrDefaultAsync(user => user.Id == id);
  }

  [HttpPost("createUser")]
  public async Task<ActionResult<User>> CreateUser(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetUserWithId", new { id = user.Id }, user);
  }
}