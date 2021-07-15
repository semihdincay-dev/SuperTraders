using System;

namespace SuperTraders.Core.Entities
{
  public abstract class Entity<T> : EntityBase, IEntity<T> where T : struct
  {
    public virtual T Id { get; set; }
    public virtual int Created_by { get; set; }
    public virtual DateTime Created_on { get; set; }
    public virtual int Modified_by { get; set; }
    public virtual DateTime Modified_on { get; set; }
    public virtual int Deleted_by { get; set; }
    public virtual DateTime Deleted_on { get; set; }
  }
}
