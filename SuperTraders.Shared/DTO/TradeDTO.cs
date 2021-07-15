using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class TradeDTO
  {
    public short transactiontype { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
    public int share_id { get; set; }
    public int user_id { get; set; }

  }
}
