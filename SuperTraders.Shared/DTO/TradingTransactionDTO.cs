using SuperTraders.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class TradingTransactionDTO
  {
    public int Id { get; set; }
    public short Transactiontype { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public ETradingTransactionResult Result { get; set; }
    public string ResultMessage { get; set; }
    public int Created_by { get; set; }
    public DateTime Created_on { get; set; }
    public int Modified_by { get; set; }
    public DateTime Modified_on { get; set; }
    public int Deleted_by { get; set; }
    public DateTime Deleted_on { get; set; }
  }
}
