using SuperTraders.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model
{
  public class User : BaseModel
  {
    public User()
    {
      UserShares = new HashSet<UserShare>();
    }
    public string name { get; set; }
    public string surname { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public virtual ICollection<UserShare> UserShares { get; set; }
  }
}
