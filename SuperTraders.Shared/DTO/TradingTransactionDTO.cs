using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class TradingTransactionDTO
  {
    public int id { get; set; }
    public short transactiontype { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
    public int created_by { get; set; }
    public DateTime created_on { get; set; }
    public int modified_by { get; set; }
    public DateTime modified_on { get; set; }
    public int deleted_by { get; set; }
    public DateTime deleted_on { get; set; }
  }
}
