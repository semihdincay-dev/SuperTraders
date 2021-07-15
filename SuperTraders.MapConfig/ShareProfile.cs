using SuperTraders.MapConfig.ConfigProfile;
using SuperTraders.Model;
using SuperTraders.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.MapConfig
{
  public class ShareProfile : ProfileBase
  {
    public ShareProfile()
    {
      CreateMap<Share, ShareDTO>().ReverseMap();
    }
  }
}
