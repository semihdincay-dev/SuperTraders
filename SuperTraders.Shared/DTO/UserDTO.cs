using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class UserDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int Created_by { get; set; }
    public DateTime Created_on { get; set; }
    public int Modified_by { get; set; }
    public DateTime Modified_on { get; set; }
    public int Deleted_by { get; set; }
    public DateTime Deleted_on { get; set; }

  }
}
