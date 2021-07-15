using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class TradeDTO
  {
    public short Transactiontype { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Share_id { get; set; }
    public int User_id { get; set; }

  }
}
