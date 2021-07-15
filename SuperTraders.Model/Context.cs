using Microsoft.EntityFrameworkCore;
using SuperTraders.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Share> Shares { get; set; }
    public DbSet<TradingTransaction> TradingTransactions { get; set; }
    public DbSet<UserShare> UserShares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      optionsBuilder.UseNpgsql(@"host=localhost;database=SuperTraders;user id=postgres;Password=1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new ShareMap());
      modelBuilder.ApplyConfiguration(new UserShareMap());
      modelBuilder.ApplyConfiguration(new TradingTransactionMap());
    }

  }
}
