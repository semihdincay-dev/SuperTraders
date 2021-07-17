using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperTraders.BLL.Abstract;
using SuperTraders.BLL.Concrete;
using SuperTraders.Core.Data.UnitOfWork;
using SuperTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTraders.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<DbContext, Context>();
      serviceCollection.AddScoped<IUnitofWork, UnitofWork>();
      serviceCollection.AddScoped<ITradeService, TradeService>();
      return serviceCollection;
    }
  }
}
