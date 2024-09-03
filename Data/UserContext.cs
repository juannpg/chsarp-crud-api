using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Quote> Quotes { get; set; }
  }
}