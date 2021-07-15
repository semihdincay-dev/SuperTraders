using SuperTraders.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class Share : BaseModel
  {
    public string name { get; set; }
    public decimal lastprice { get; set; }
    public int quantity { get; set; }
    public DateTime time { get; set; }
  }
}
