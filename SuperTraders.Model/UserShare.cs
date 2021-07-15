using SuperTraders.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class UserShare : BaseModel
  {
    public UserShare()
    {
      Shares = new HashSet<Share>();
      Users = new HashSet<User>();
    }
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
    public virtual ICollection<Share> Shares { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}
