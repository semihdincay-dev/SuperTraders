﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Shared.DTO
{
  public class ShareDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Lastprice { get; set; }
    public int Quantity { get; set; }
    public DateTime Time { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }

  }
}
