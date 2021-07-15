using System;

namespace SuperTraders.Core.Entities
{
  public abstract class Entity<T> : EntityBase, IEntity<T> where T : struct
  {
    public virtual T Id { get; set; }
    public virtual int created_by { get; set; }
    public virtual DateTime created_on { get; set; }
    public virtual int modified_by { get; set; }
    public virtual DateTime modified_on { get; set; }
    public virtual int deleted_by { get; set; }
    public virtual DateTime deleted_on { get; set; }
  }
}
