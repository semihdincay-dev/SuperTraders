using SuperTraders.Core.Entities;
using System.Collections.Generic;

namespace SuperTraders.Model
{
  public class User : Entity<int>
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
