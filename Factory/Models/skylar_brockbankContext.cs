using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class skylar_brockbankContext : DbContext
  {
    public DbSet<Engineer> Engineers {get;set;}
    public DbSet<Machine> Machines {get;set;}
    public DbSet<EngineerMachine> EngineerMachines {get;set;}
    public skylar_brockbankContext(DbContextOptions options) : base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}