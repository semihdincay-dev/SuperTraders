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
      modelBuilder.Entity<User>().HasData(new User[] {
        new User { Id = 1, Name = "Semih", Surname = "Dinçay", Username = "semihdincay", Email = "semihdincay@gmail.com", CreatedBy = 1, CreatedOn = DateTime.Now },
        new User { Id = 2, Name = "Can", Surname = "Kara", Username = "cankara", Email = "cankara@cankara.com", CreatedBy = 1, CreatedOn = DateTime.Now }
      });
      modelBuilder.Entity<Share>().HasData(new Share[] {
        new Share { Id = 1, Name = "Bitcoin", Symbol = "BTC", Price = 33333, Quantity = 17000, Time = DateTime.Now, CreatedBy = 1, CreatedOn = DateTime.Now },
        new Share { Id = 2, Name = "Ethereum", Symbol = "ETH", Price = 3333, Quantity = 13000000, Time = DateTime.Now, CreatedBy = 1, CreatedOn = DateTime.Now },
        new Share { Id = 3, Name = "Litecoin", Symbol = "LTC", Price = 133, Quantity = 37000000, Time = DateTime.Now, CreatedBy = 1, CreatedOn = DateTime.Now },
        new Share { Id = 4, Name = "Ripple", Symbol = "XRP", Price = 115, Quantity = 4700000, Time = DateTime.Now, CreatedBy = 1, CreatedOn = DateTime.Now },
        new Share { Id = 5, Name = "SemCoin", Symbol = "SEC", Price = 58633, Quantity = 700000, Time = DateTime.Now, CreatedBy = 1, CreatedOn = DateTime.Now }
      });
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new ShareMap());
      modelBuilder.ApplyConfiguration(new UserShareMap());
      modelBuilder.ApplyConfiguration(new TradingTransactionMap());
    }

  }
}
