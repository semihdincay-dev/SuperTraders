using System;

namespace SuperTraders.Core.Entities
{
  public interface IEntity<T> where T : struct
  {
    T Id { get; set; }
    int CreatedBy { get; set; }
    DateTime CreatedOn { get; set; }
    int ModifiedBy { get; set; }
    DateTime ModifiedOn { get; set; }
    int DeletedBy { get; set; }
    DateTime DeletedOn { get; set; }
  }
}
