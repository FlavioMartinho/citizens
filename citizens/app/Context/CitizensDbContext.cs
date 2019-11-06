using Microsoft.EntityFrameworkCore;
using Citizens.Models;

namespace Citizens.Context
{
  public class CitizensDbContext : DbContext
  {
    public DbSet<Address> Adresses { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Sex> Sexes { get; set; }

    public CitizensDbContext(DbContextOptions<CitizensDbContext> options) : base(options) { }
  }
}
