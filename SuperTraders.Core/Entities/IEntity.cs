using System;

namespace SuperTraders.Core.Entities
{
  public interface IEntity<T> where T : struct
  {
    T Id { get; set; }
    int Created_by { get; set; }
    DateTime Created_on { get; set; }
    int Modified_by { get; set; }
    DateTime Modified_on { get; set; }
    int Deleted_by { get; set; }
    DateTime Deleted_on { get; set; }
  }
}
