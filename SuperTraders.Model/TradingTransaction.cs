using SuperTraders.Core.Entities;
using SuperTraders.Shared.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Model
{
  public class TradingTransaction : Entity<int>
  {
    public ETradingTransactionType TransactionType { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public ETradingTransactionResult Result { get; set; }
    public string ResultMessage { get; set; }
    public virtual User User { get; set; }
    public int UserId { get; set; }
    public virtual Share Share { get; set; }
    public int ShareId { get; set; }
  }
}
