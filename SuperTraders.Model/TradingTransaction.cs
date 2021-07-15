using SuperTraders.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class TradingTransaction : BaseModel
  {
    public short transactiontype { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }

  }
}
