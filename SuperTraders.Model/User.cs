using SuperTraders.Core.Entities;
using System.Collections.Generic;

namespace SuperTraders.Model
{
  public class User : Entity<int>
  {
    public User()
    {
      UserShares = new HashSet<UserShare>();
      TradingTransactions = new HashSet<TradingTransaction>();
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public virtual ICollection<UserShare> UserShares { get; set; }
    public virtual ICollection<TradingTransaction> TradingTransactions { get; set; }
  }
}
