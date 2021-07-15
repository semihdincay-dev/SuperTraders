using SuperTraders.Model.Base;
using SuperTraders.Shared.Enum;
using System.Collections.Generic;

namespace SuperTraders.Model
{
  public class TradingTransaction : BaseModel
  {
    public TradingTransaction()
    {
      Users = new HashSet<User>();
      Shares = new HashSet<Share>();
    }
    public ETradingTransactionType TransactionType { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public ETradingTransactionResult Result { get; set; }
    public string ResultMessage { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Share> Shares { get; set; }
  }
}
