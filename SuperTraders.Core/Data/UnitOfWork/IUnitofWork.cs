using Microsoft.EntityFrameworkCore;
using SuperTraders.Core.Data.Repository;
using SuperTraders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTraders.Core.Data.UnitOfWork
{
  public interface IUnitofWork : IDisposable
  {
    IRepository<T> GetRepository<T>() where T : Entity<int>;
    int SaveChanges();
  }
}
