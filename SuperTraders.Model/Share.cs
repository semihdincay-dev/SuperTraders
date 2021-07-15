using SuperTraders.Core.Entities;
using System;

namespace SuperTraders.Model
{
  public class Share : Entity<int>
  {
    public string name { get; set; }
    public decimal lastprice { get; set; }
    public int quantity { get; set; }
    public DateTime time { get; set; }
  }
}
