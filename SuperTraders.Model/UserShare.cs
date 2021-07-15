using SuperTraders.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Model
{
  public class UserShare : Entity<int>
  {
    public UserShare()
    {
      Shares = new HashSet<Share>();
      Users = new HashSet<User>();
    }
    public string name { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
    [ForeignKey("User")]
    public int user_id { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("Share")]
    public int share_id { get; set; }
    public virtual Share Share { get; set; }
    public virtual ICollection<Share> Shares { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}
