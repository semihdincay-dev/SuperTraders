using SuperTraders.DTO;
using SuperTraders.MapConfig.ConfigProfile;
using SuperTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.MapConfig
{
  public class UserProfile : ProfileBase
  {
    public UserProfile()
    {
      CreateMap<User, UserDTO>().ReverseMap();
    }
  }
}
