using System;

namespace SuperTraders.Core.Entities
{
  public interface IEntity<T> where T : struct
  {
    T Id { get; set; }
    int created_by { get; set; }
    DateTime created_on { get; set; }
    int modified_by { get; set; }
    DateTime modified_on { get; set; }
    int deleted_by { get; set; }
    DateTime deleted_on { get; set; }
  }
}
