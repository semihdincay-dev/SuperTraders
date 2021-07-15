using SuperTraders.MapConfig.ConfigProfile;
using SuperTraders.Model;
using SuperTraders.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Mapping.ProjectBaseMapping
{
  public class UserProfile : ProfileBase
  {
    public UserProfile()
    {
      CreateMap<User, UserDTO>().ReverseMap();
    }
  }
}
