﻿using Microsoft.EntityFrameworkCore;
using SuperTraders.Core.Data.Repository;
using SuperTraders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace SuperTraders.Core.Data.UnitOfWork
{
  public class UnitofWork : IUnitofWork
  {
    private readonly DbContext context;
    private Dictionary<Type, object> repositories;
    public UnitofWork(DbContext _context)
    {
      context = _context;
      repositories = repositories ?? new Dictionary<Type, object>();
    }

    private bool disposed = false;
    public void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    public IRepository<T> GetRepository<T>() where T : Entity<int>
    {
      if (repositories.Keys.Contains(typeof(T)))
      {
        return repositories[typeof(T)] as IRepository<T>;
      }
      var repository = new RepositoryBase<T>(context);
      repositories.Add(typeof(T), repository);
      return repository;
    }

    public int SaveChanges()
    {
      return context.SaveChanges();
    }

    public DbContext GetDbContext()
    {
      return context;
    }

  }
}
