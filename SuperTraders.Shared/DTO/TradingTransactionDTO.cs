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
    public ETradingTransactionType Transactiontype { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public ETradingTransactionResult Result { get; set; }
    public string ResultMessage { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }
  }
}
