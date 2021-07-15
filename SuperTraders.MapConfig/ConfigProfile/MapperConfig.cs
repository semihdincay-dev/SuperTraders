using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.MapConfig.ConfigProfile
{
  public class MapperConfig
  {
    public static void RegisterMappers()
    {
      MapperFactory.RegisterMappers();
    }
  }
}
