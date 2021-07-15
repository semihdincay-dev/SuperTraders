using SuperTraders.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class UserPortfolio : BaseModel
  {
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
  }
}
