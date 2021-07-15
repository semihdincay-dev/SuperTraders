using SuperTraders.Core.Entities;
using System;
using System.Collections.Generic;

namespace SuperTraders.Model
{
  public class Share : Entity<int>
  {
    public Share()
    {
      UserShares = new HashSet<UserShare>();
      TradingTransactions = new HashSet<TradingTransaction>();
    }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Time { get; set; }
    public virtual ICollection<UserShare> UserShares { get; set; }
    public virtual ICollection<TradingTransaction> TradingTransactions { get; set; }
  }
}
