using System;

namespace SuperTraders.Core.Entities
{
  public abstract class Entity<T> : EntityBase, IEntity<T> where T : struct
  {
    public virtual T Id { get; set; }
    public virtual int CreatedBy { get; set; }
    public virtual DateTime CreatedOn { get; set; }
    public virtual int ModifiedBy { get; set; }
    public virtual DateTime ModifiedOn { get; set; }
    public virtual int DeletedBy { get; set; }
    public virtual DateTime DeletedOn { get; set; }
  }
}
